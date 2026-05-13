using Microsoft.EntityFrameworkCore;
using SElab5.Data;
using SElab5.Models;
using SElab5.Repositories.Interfaces;

namespace SElab5.Repositories
{
    public class HearingRepository : Repository<Hearing>, IHearingRepository
    {
        public HearingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Hearing>> GetByCitizenIdAsync(int citizenId)
        {
            return await _dbSet.Where(h => h.CitizenID == citizenId)
                               .Include(h => h.Employee)
                               .ToListAsync();
        }

        public async Task<IEnumerable<Hearing>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _dbSet.Where(h => h.EmployeeID == employeeId)
                               .Include(h => h.Citizen)
                               .ToListAsync();
        }
    }
}

