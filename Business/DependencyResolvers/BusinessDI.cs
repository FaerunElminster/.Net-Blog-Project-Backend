using Business.Abstracts;
using Business.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers
{
    public static class BusinessDI
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Resolve Services and Managers
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IBlogService, BlogService>();

        }
    }
}
