using System.ComponentModel.DataAnnotations;

namespace SElab5.Models
{
    public class Hearing
    {
        [Key]
        public int HearingID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ScheduledDate { get; set; }

        [Required]
        public int CitizenID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public HearingStatus Status { get; set; } = HearingStatus.Scheduled;

        public string Transcript { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual User Citizen { get; set; }
        public virtual User Employee { get; set; }
    }

    public enum HearingStatus
    {
        Scheduled,
        Completed,
        Cancelled
    }
}
