using System.ComponentModel.DataAnnotations;

namespace CityHallManagement.Models
{
    public class Document
    {
        [Key]
        public int DocumentID { get; set; }

        [StringLength(255)]
        public string? FileName { get; set; }

        public string? FilePath { get; set; }

        public string Category { get; set; }

        [Required]
        public int OwnerID { get; set; }

        public int? DepartmentID { get; set; }

        public bool IsArchived { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual User? Owner { get; set; }
        public virtual Department? Department { get; set; }
    }
}

