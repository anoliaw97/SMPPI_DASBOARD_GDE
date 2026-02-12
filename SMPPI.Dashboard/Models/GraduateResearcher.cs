using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMPPI.Dashboard.Models
{
    [Table("tblGraduateResearchers")]
    public class GraduateResearcher
    {
        [Key]
        public int ResearcherID { get; set; }

        [Required]
        [StringLength(20)]
        public string StudentID { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string ProgramLevel { get; set; } = string.Empty;

        [Required]
        public int SupervisorID { get; set; }

        public int? LinkedProjectID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CompletionDate { get; set; }

        [StringLength(50)]
        public string ResearcherStatus { get; set; } = "Active";

        public bool IsLocal { get; set; } = true;

        public DateTime DateCreated { get; set; } = DateTime.Now;

        // Navigation Properties
        [ForeignKey("SupervisorID")]
        public virtual AcademicStaff? Supervisor { get; set; }

        [ForeignKey("LinkedProjectID")]
        public virtual ResearchProject? LinkedProject { get; set; }
    }
}
