using DataAccess.Repositories.Abstracts;
using DataAccess.Repositories.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.DependencyResolvers
{
    public static class DataAccessDI
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Inject Service and Manager
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddSingleton<IBlogRepository, BlogRepository>();

        }
    }
}
