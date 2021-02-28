using Synlait.Api.TimeZone.Models;
using System.Threading.Tasks;

namespace Synlait.Api.TimeZone
{
    public interface IGoogleApiTimeZoneClient
    {
        Task<TimeZoneOutputModel> GetTimeZoneDataAsync(string apiKey, float latitude, float longitude, long time);
    }
}