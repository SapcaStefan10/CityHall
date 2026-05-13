using SElab5.Models;

namespace SElab5.Repositories.Interfaces
{
    public interface IRequestRepository : IRepository<Request>
    {
        Task<IEnumerable<Request>> GetByCitizenIdAsync(int citizenId);
        Task<IEnumerable<Request>> GetByDepartmentIdAsync(int departmentId);
    }
}

