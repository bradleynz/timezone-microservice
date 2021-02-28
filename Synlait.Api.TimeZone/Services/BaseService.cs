using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Synlait.Api.TimeZone.Services
{
    public abstract class BaseService
    {
        public readonly DbContextOptions<DatabaseContext> _options;
        public BaseService(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(configuration["DatabaseConnection"]);
            _options = optionsBuilder.Options;
        }
    }
}
