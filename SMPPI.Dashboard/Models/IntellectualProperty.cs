using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMPPI.Dashboard.Models
{
    [Table("tblIntellectualProperty")]
    public class IntellectualProperty
    {
        [Key]
        public int IPID { get; set; }

        [Required]
        [StringLength(50)]
        public string ApplicationNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string IPTitle { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string IPType { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Inventors { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FilingDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? GrantedDate { get; set; }

        [StringLength(50)]
        public string IPStatus { get; set; } = "Filed";

        public int? LinkedProjectID { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime DateUpdated { get; set; } = DateTime.Now;

        // Navigation Properties
        [ForeignKey("LinkedProjectID")]
        public virtual ResearchProject? LinkedProject { get; set; }
    }
}
