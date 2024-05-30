using AppBlog.Data;
using AppBlog.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AppBlog.Extentions
{
    public static class AppServiceExtention
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            // Services.AddHttpContextAccessor();
            // Db
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("AppConnection")));

            // mapper
            services.AddAutoMapper(typeof(AutoMapperProfiles));

            // mediatr
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
