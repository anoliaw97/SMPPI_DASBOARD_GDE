using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMPPI.Dashboard.Models
{
    [Table("tblAcademicStaff")]
    public class AcademicStaff
    {
        [Key]
        public int StaffID { get; set; }

        [Required]
        [StringLength(20)]
        public string UMSPER { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Position { get; set; }

        [StringLength(100)]
        public string? Faculty { get; set; }

        [StringLength(100)]
        public string? Department { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? ResearchDomain { get; set; }

        public int? HIndex { get; set; }

        public int TotalPublications { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime DateUpdated { get; set; } = DateTime.Now;

        // Navigation Properties
        public virtual ICollection<ResearchProject>? ResearchProjects { get; set; }
        public virtual ICollection<GraduateResearcher>? GraduateResearchers { get; set; }
    }
}
