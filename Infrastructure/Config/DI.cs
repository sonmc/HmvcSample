

using HmvcSample.Infrastructure.Repositories;
using HmvcSample.Modules.UserModule;
namespace HmvcSample.Infrastructure.Config
{
    public class DIConfig
    {
        public static void AddDependency(IServiceCollection services)
        {
            // services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGeneralRepository<>), (typeof(GeneralRepository<>)));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
