using SElab5.Models;

 namespace SElab5.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<bool> CreateDepartmentAsync(Department department);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<object> GetDashboardStatsAsync();
    }
}

