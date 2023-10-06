using AdvanceRestApi.Models;

namespace AdvanceRestApi.Interfaces
{
    public interface IUser
    {
        Task<(bool IsSuccess, List<User> User, string ErrorMessage)> GetAllUsers();
        Task<(bool IsSuccess, User User, string ErrorMessage)> GetUserById(Guid id);
        Task<(bool IsSuccess, string ErrorMessage)> AddUser(User user);
        Task<(bool IsSuccess, string ErrorMessage)> UpdateUser(Guid id, User user);
        Task<(bool IsSuccess, string ErrorMessage)> DeleteUser(Guid id);
    }
}
