using AdvanceRestApi.Models;

namespace AdvanceRestApi.Interfaces
{
    public interface IUser
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task AddUser(User user);
        Task UpdateUser(Guid id, User user);
        Task DeleteUser(Guid id);
    }
}
