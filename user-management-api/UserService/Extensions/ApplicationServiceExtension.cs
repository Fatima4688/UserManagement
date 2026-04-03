using UserService.Cores.Interfaces;
using UserService.Services.Interfaces;

namespace UserService.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, Services.UserService>();
            services.AddScoped<IUserCore, Cores.UserCore>();
            services.AddSingleton<IMessageBusService, MessageBusService>();

            return services;
        }
    }
}
