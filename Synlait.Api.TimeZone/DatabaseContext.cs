using Microsoft.EntityFrameworkCore;
using Synlait.Api.TimeZone.Entities;

namespace Synlait.Api.TimeZone
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<TimeZoneDataEntity> TimeZoneData { get; set; }
    }
}