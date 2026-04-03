using Common.Models.ViewModels;

namespace UserService.Services.Interfaces
{
    public interface IMessageBusService
    {
        Task PublishUserCreatedEvent(Common.Models.ViewModels.User userCreated);
    }
}
