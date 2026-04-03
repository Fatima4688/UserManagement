using Common.ViewModels;
using Common.Models.ViewModels;

namespace UserService.Cores.Interfaces
{
    public interface IUserCore
    {
        Task CreateUser(User user);
        Task<List<User>> GetUsers();
    }
}
