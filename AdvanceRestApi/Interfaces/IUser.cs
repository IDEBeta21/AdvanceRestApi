using AdvanceRestApi.DTO_s;
using AdvanceRestApi.Models;

namespace AdvanceRestApi.Interfaces
{
    public interface IUser
    {
        Task<(bool IsSuccess, List<UserDTO> User, string ErrorMessage)> GetAllUsers();
        Task<(bool IsSuccess, UserDTO User, string ErrorMessage)> GetUserById(Guid id);
        Task<(bool IsSuccess, string ErrorMessage)> AddUser(UserDTO user);
        Task<(bool IsSuccess, string ErrorMessage)> UpdateUser(Guid id, UserDTO user);
        Task<(bool IsSuccess, string ErrorMessage)> DeleteUser(Guid id);
    }
}
