using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public  class ServiceExtensions
    {
        public  void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PlayerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public  void ConfigureMediatR(this IServiceCollection service)
        {
            service.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(Program).Assembly));
        }
    }
}
