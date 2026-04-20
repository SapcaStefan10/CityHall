using System.ComponentModel.DataAnnotations;

namespace SElab5.Models
{
    public class Request
    {
        [Key]
        public int RequestID { get; set; }

        [Required]
        public int CitizenID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public RequestStatus Status { get; set; } = RequestStatus.Pending;

        public int? DepartmentID { get; set; }

        [Required]
        public RequestPriority Priority { get; set; } = RequestPriority.Medium;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual User Citizen { get; set; }
        public virtual Department Department { get; set; }
    }

    public enum RequestStatus
    {
        Pending,
        InProgress,
        Resolved,
        Rejected
    }

    public enum RequestPriority
    {
        Low,
        Medium,
        High
    }
}
