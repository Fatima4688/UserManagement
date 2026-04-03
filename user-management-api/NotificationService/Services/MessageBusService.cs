using System.Text.Json;
using Common.Models.ViewModels;
using Azure.Messaging.ServiceBus;

namespace NotificationService.Services
{
    public class MessageBusService: BackgroundService
    {
        private readonly IConfiguration _config;
        private ServiceBusProcessor _processor;

        public MessageBusService(IConfiguration config)
        {
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var client = new ServiceBusClient(_config["ServiceBus:ConnectionString"]);
            _processor = client.CreateProcessor(_config["ServiceBus:QueueName"], new ServiceBusProcessorOptions());

            _processor.ProcessMessageAsync += HandleMessageAsync;
            _processor.ProcessErrorAsync += ErrorHandler;

            await _processor.StartProcessingAsync();
        }

        private async Task HandleMessageAsync(ProcessMessageEventArgs args)
        {
            var body = args.Message.Body.ToString();

            var user = JsonSerializer.Deserialize<Common.Models.ViewModels.User>(body);

            Console.WriteLine($"Sending email to {user.Name}");

            await SendEmail(user);

            await args.CompleteMessageAsync(args.Message);
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        private Task SendEmail(User user)
        {
            Console.WriteLine($"Email sent to {user.Name}");
            return Task.CompletedTask;
        }
    }
}
