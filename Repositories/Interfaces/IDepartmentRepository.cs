using SElab5.Models;

namespace SElab5.Repositories.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Department> GetWithEmployeesAsync(int departmentId);
    }
}

