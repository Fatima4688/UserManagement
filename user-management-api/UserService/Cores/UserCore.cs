using UserService.Data;
using Common.Models.ViewModels;
using UserService.Cores.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UserService.Cores
{
    public class UserCore: IUserCore
    {
        public readonly AppDbContext _db;
        public UserCore(AppDbContext db) => _db = db;
        public async Task CreateUser(User user)
        { 
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }
        public async Task<List<User>> GetUsers()
        {
            return await _db.Users.ToListAsync();
            
        }

        public async Task DeleteUser(Guid userId)
        {
            User? user = await _db.Users.FirstOrDefaultAsync(userEntry=> userEntry.Id.Equals(userId));
            if(user is not null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
        }

    }
}
