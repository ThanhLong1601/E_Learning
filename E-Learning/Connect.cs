using E_Learning.DBContext;
using Microsoft.EntityFrameworkCore;

namespace E_Learning
{
    public static class Connect
    {
        public static IServiceCollection ServicesCollection(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("Context"),
               x => x.MigrationsAssembly(typeof(Context).Assembly.FullName)), ServiceLifetime.Transient);

            return service;
        }
    }
}
