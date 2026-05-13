using Microsoft.EntityFrameworkCore;
using SElab5.Data;
using SElab5.Models;
using SElab5.Repositories.Interfaces;
using SElab5.Services.Interfaces;

namespace SElab5.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ApplicationDbContext _context; // For simple stats queries

        public DepartmentService(IDepartmentRepository departmentRepository, ApplicationDbContext context)
        {
            _departmentRepository = departmentRepository;
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }

        public async Task<bool> CreateDepartmentAsync(Department department)
        {
            await _departmentRepository.AddAsync(department);
            return await _departmentRepository.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _departmentRepository.GetAllEmployeesAsync();
        }

        public async Task<object> GetDashboardStatsAsync()
        {
            var totalUsers = await _context.Users.CountAsync();
            var totalRequests = await _context.Requests.CountAsync();
            var pendingRequests = await _context.Requests.CountAsync(r => r.Status == RequestStatus.Pending);
            var totalDepartments = await _context.Departments.CountAsync();

            return new
            {
                TotalUsers = totalUsers,
                TotalRequests = totalRequests,
                PendingRequests = pendingRequests,
                TotalDepartments = totalDepartments
            };
        }
    }
}

