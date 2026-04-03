using System.Text.Json;
using Azure.Messaging.ServiceBus;
using UserService.Services.Interfaces;

public class MessageBusService : IMessageBusService
{
    private readonly string _connectionString;
    private readonly string _queueName;

    public MessageBusService(IConfiguration configuration)
    {
        _connectionString = configuration["ServiceBus:ConnectionString"];
        _queueName = configuration["ServiceBus:QueueName"];
    }

    public async Task PublishUserCreatedEvent(Common.Models.ViewModels.User userCreated)
    {
        await using var client = new ServiceBusClient(_connectionString);
        ServiceBusSender sender = client.CreateSender(_queueName);

        string messageBody = JsonSerializer.Serialize(userCreated);
        ServiceBusMessage message = new ServiceBusMessage(messageBody);

        await sender.SendMessageAsync(message);
    }
}