using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMPPI.Dashboard.Models
{
    [Table("tblResearchProjects")]
    public class ResearchProject
    {
        [Key]
        public int ProjectID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProjectCode { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string ProjectTitle { get; set; } = string.Empty;

        [Required]
        public int PrincipalInvestigatorID { get; set; }

        [StringLength(50)]
        public string? GrantScheme { get; set; }

        [StringLength(20)]
        public string? Phase { get; set; }

        [StringLength(100)]
        public string? ResearchDomain { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExtensionDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AllocatedBudget { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal SpentAmount { get; set; } = 0;

        [Range(0, 100)]
        public int ProgressPercentage { get; set; } = 0;

        [StringLength(50)]
        public string ProjectStatus { get; set; } = "Active";

        [Range(0, 100)]
        public int MilestonePercentage { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime DateUpdated { get; set; } = DateTime.Now;

        // Navigation Properties
        [ForeignKey("PrincipalInvestigatorID")]
        public virtual AcademicStaff? PrincipalInvestigator { get; set; }

        public virtual ICollection<Publication>? Publications { get; set; }
        public virtual ICollection<IntellectualProperty>? IntellectualProperties { get; set; }
        public virtual ICollection<GraduateResearcher>? GraduateResearchers { get; set; }
    }
}
