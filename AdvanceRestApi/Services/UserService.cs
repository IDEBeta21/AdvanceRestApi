using AdvanceRestApi.Data;
using AdvanceRestApi.Interfaces;
using AdvanceRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvanceRestApi.Services
{
    public class UserService : IUser
    {
        private UserDbContext _dbContext;
        public UserService(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            return user;
        }

        public async Task UpdateUser(Guid id, User user)
        {
            var userObj = await _dbContext.Users.FindAsync(id);
            userObj.Name = user.Name;
            userObj.Address = user.Address;
            userObj.Phone = user.Phone;
            userObj.BloodGroup = user.BloodGroup;
            await _dbContext.SaveChangesAsync();

        }
    }
}
