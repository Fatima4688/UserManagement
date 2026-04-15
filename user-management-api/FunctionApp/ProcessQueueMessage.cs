using System.Net;
using System.Net.Mail;
using System.Text.Json;
using Common.Models.ViewModels;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

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

    [Function("DeleteUser")]
    public async Task<HttpResponseData> DeleteUser(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "users/{id}")]
        HttpRequestData req,
        string id)
    {
        // Simulate delete logic
        Console.WriteLine($"Deleting user with ID: {id}");

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteStringAsync($"User {id} deleted successfully");

        return response;
    }
}