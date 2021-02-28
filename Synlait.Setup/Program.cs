using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Synlait.Setup
{
    class Program
    {
        static void Main(string[] args)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            
            cmd.StandardInput.WriteLine("docker inspect -f '{{range.NetworkSettings.Networks}}{{.IPAddress}}{{end}}' synlaitapitimezone_sqldata_1");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            var result = cmd.StandardOutput.ReadToEnd();

            Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            MatchCollection ipAddressMatch = ip.Matches(result);
            var ipAddress = ipAddressMatch[0];


            cmd.Start();
            cmd.StandardInput.WriteLine($"sqlcmd -S tcp:{ipAddress.Value},1433 -U sa -P Pass@word");

            cmd.StandardInput.WriteLine("USE [master]");
            cmd.StandardInput.WriteLine("GO");
            cmd.StandardInput.WriteLine("DROP DATABASE IF EXISTS [TimezoneDb]");
            cmd.StandardInput.WriteLine("GO");
            cmd.StandardInput.WriteLine("CREATE DATABASE [TimezoneDb]");
            cmd.StandardInput.WriteLine("GO");
            cmd.StandardInput.WriteLine("USE [TimezoneDb]");
            cmd.StandardInput.WriteLine("GO");
            cmd.StandardInput.WriteLine("IF OBJECT_ID('dbo.TimeZoneData', 'U') IS NOT NULL DROP TABLE dbo.TimeZoneData");
            cmd.StandardInput.WriteLine("GO");
            cmd.StandardInput.WriteLine("CREATE TABLE [dbo].[TimeZoneData]([RequestId] [uniqueidentifier] NOT NULL, [Latitude] [float] NOT NULL, [Longitude] [float] NOT NULL, [Request] [nvarchar](max) NOT NULL, [Response] [nvarchar](max) NOT NULL, [Timestamp] [bigint] NOT NULL, [DateCreated] [datetime] NULL, [DateModified] [datetime] NULL)");
            cmd.StandardInput.WriteLine("GO");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            Console.ReadLine();
        }
    }
}
