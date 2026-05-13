using SElab5.Models;

namespace SElab5.Repositories.Interfaces
{
    public interface IHearingRepository : IRepository<Hearing>
    {
        Task<IEnumerable<Hearing>> GetByCitizenIdAsync(int citizenId);
        Task<IEnumerable<Hearing>> GetByEmployeeIdAsync(int employeeId);
    }
}

