using System.Text;
using System.Text.Json;
using Common.ViewModels;
using UserService.Cores;
using Common.Models.ViewModels;
using UserService.Cores.Interfaces;
using UserService.Services.Interfaces;
using Common.Models.ResponseViewModel;

namespace UserService.Services
{
    public class UserService: IUserService
    {
        private readonly IUserCore _userCore;
        private readonly IMessageBusService _messageBus;
        public UserService(IUserCore userCore, IMessageBusService messageBus)
        {
            _userCore = userCore;
            _messageBus = messageBus;
        }

        public async Task<ResponseViewModel> CreateUser(User user)
        {
            ResponseViewModel response = new();
            try
            {
                await _userCore.CreateUser(user);

                await _messageBus.PublishUserCreatedEvent(new Common.Models.ViewModels.User
                {
                    Email = user.Email,
                    Name = user.Name
                });

                response.Status = StatusCodes.Status200OK;
                response.Response = "User created";
                return response;
            }
            catch
            {
                response.Status = StatusCodes.Status500InternalServerError;
                response.Response = "User not created";
                return response;
            }
        }

        public async Task<ResponseViewModel> GetUsers()
        {
            ResponseViewModel response = new();
            try
            {
                List<User> users = await _userCore.GetUsers();

                response.Status = StatusCodes.Status200OK;
                response.Response = new ResponseOk(users);
                return response;
            }
            catch
            {
                response.Status = StatusCodes.Status500InternalServerError;
                return response;
            }
        }
    }
}