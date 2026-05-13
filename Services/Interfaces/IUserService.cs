using SElab5.Models;

namespace SElab5.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string email, string password);
        Task<bool> RegisterAsync(User user, string password);
        Task<User> GetUserProfileAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(int userId);
    }
}

