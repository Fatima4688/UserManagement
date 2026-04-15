using System.Text;
using System.Net.Http;
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
        private readonly HttpClient _httpClient;
        public UserService(IUserCore userCore, IMessageBusService messageBus, HttpClient httpClient)
        {
            _userCore = userCore;
            _messageBus = messageBus;
            _httpClient = httpClient;
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
                response.Response = new ResponseOk();
                return response;
            }
            catch
            {
                response.Status = StatusCodes.Status500InternalServerError;
                response.Response = new ResponseOk();
                return response;
            }
        }

        public async Task<ResponseViewModel> DeleteUser(Guid userId)
        {
            ResponseViewModel response = new();
            try
            {
                var url = $"http://localhost:7089/api/users/{userId}";

                var httpResponse = await _httpClient.DeleteAsync(url);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    response.Status = StatusCodes.Status500InternalServerError;
                    response.Response = "Function failed to delete user";
                    return response;
                }

                await _userCore.DeleteUser(userId);

                response.Status = StatusCodes.Status200OK;
                response.Response = new ResponseOk();
                return response;
            }
            catch
            {
                response.Status = StatusCodes.Status500InternalServerError;
                response.Response = new ResponseOk();
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