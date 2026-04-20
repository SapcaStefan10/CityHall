using System.ComponentModel.DataAnnotations;

namespace SElab5.Models
{
    public class Document
    {
        [Key]
        public int DocumentID { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        [Required]
        [StringLength(500)]
        public string FilePath { get; set; }

        public string Category { get; set; }

        [Required]
        public int OwnerID { get; set; }

        public int? DepartmentID { get; set; }

        public bool IsArchived { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual User Owner { get; set; }
        public virtual Department Department { get; set; }
    }
}
