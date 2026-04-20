using System.ComponentModel.DataAnnotations;

namespace SElab5.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(100)]
        public string DeptName { get; set; }

        public string Description { get; set; }

        public int? ManagerID { get; set; }

        // Navigation properties
        public virtual User Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }

    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        [StringLength(100)]
        public string JobTitle { get; set; }

        public DateTime HireDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Department Department { get; set; }
    }
}
