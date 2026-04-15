using System.Net.Mail;
using System.Text.Json;
using Common.Models.ViewModels;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker;

namespace FunctionApp;
public class ProcessQueueMessage
{
    [Function("ServiceBusFunc")]
    public async Task ServiceBusFuncRun(
        [ServiceBusTrigger("%QueueName%", Connection = "ServiceBusConnectionString")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        var bodyString = message.Body.ToString();

        var data = JsonSerializer.Deserialize<User>(bodyString);
        Console.WriteLine($"Email sent to {data.Email}");

        await messageActions.CompleteMessageAsync(message);
    }

    [Function("TimerFunc")]
    public void TimerFuncRun([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
    {
        Console.WriteLine($"Function ran at: {DateTime.Now}");
    }
}