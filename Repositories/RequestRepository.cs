using Microsoft.EntityFrameworkCore;
using SElab5.Data;
using SElab5.Models;
using SElab5.Repositories.Interfaces;

namespace SElab5.Repositories
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Request>> GetByCitizenIdAsync(int citizenId)
        {
            return await _dbSet.Where(r => r.CitizenID == citizenId)
                               .Include(r => r.Department)
                               .ToListAsync();
        }

        public async Task<IEnumerable<Request>> GetByDepartmentIdAsync(int departmentId)
        {
            return await _dbSet.Where(r => r.DepartmentID == departmentId)
                               .Include(r => r.Citizen)
                               .ToListAsync();
        }
    }
}

