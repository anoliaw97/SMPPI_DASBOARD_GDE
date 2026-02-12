using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMPPI.Dashboard.Models
{
    [Table("tblPublications")]
    public class Publication
    {
        [Key]
        public int PublicationID { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string PublicationType { get; set; } = string.Empty;

        [Required]
        public int PublicationYear { get; set; }

        [StringLength(1000)]
        public string? Authors { get; set; }

        [StringLength(300)]
        public string? VenueName { get; set; }

        [StringLength(100)]
        public string? DOI { get; set; }

        [StringLength(10)]
        public string? Quartile { get; set; }

        public int CitationCount { get; set; } = 0;

        public int? LinkedProjectID { get; set; }

        [StringLength(50)]
        public string? GrantCode { get; set; }

        public bool IsIndexed { get; set; } = false;

        [DataType(DataType.Date)]
        public DateTime? DatePublished { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        // Navigation Properties
        [ForeignKey("LinkedProjectID")]
        public virtual ResearchProject? LinkedProject { get; set; }
    }
}
