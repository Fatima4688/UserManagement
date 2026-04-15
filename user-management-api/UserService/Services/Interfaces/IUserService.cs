using Common.ViewModels;
using Common.Models.ViewModels;

namespace UserService.Services.Interfaces
{   
    public interface IUserService
    {
        Task<ResponseViewModel> CreateUser(User user);
        Task<ResponseViewModel> DeleteUser(Guid userId);
        Task<ResponseViewModel> GetUsers();
    }
}
