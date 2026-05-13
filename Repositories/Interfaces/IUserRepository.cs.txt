using SElab5.Models;

namespace SElab5.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<bool> ExistsAsync(string email);
    }
}

