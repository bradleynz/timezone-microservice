using Synlait.Api.TimeZone.Models;
using System;
using System.Threading.Tasks;

namespace Synlait.Api.TimeZone.Services
{
    public interface ITimeZoneService
    {
        TimeZoneOutputLogModel[] GetTimeZoneDataLogs();
        Task<TimeZoneOutputModel> GetTimeZoneDataAsync(string apiKey, float latitude, float longitude, DateTimeOffset dateTimeOffset);
    }
}