using NotificationService.Services;

namespace NotificationService.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddHostedService<MessageBusService>();

            return services;
        }
    }
}
