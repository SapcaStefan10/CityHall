using Microsoft.EntityFrameworkCore;
using SElab5.Data;
using SElab5.Models;
using SElab5.Repositories.Interfaces;

namespace SElab5.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                                 .Include(e => e.User)
                                 .Include(e => e.Department)
                                 .ToListAsync();
        }

        public async Task<Department> GetWithEmployeesAsync(int departmentId)
        {
            return await _dbSet.Include(d => d.Employees)
                               .ThenInclude(e => e.User)
                               .FirstOrDefaultAsync(d => d.DepartmentID == departmentId);
        }
    }
}

