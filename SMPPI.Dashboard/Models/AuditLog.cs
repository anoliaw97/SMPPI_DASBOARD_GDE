using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMPPI.Dashboard.Models
{
    [Table("tblAuditLog")]
    public class AuditLog
    {
        [Key]
        public int AuditID { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string ActionType { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string EntityType { get; set; } = string.Empty;

        [StringLength(20)]
        public string? ExportFormat { get; set; }

        public int RecordCount { get; set; } = 0;

        public string? FilterCriteria { get; set; }

        [StringLength(50)]
        public string? IPAddress { get; set; }

        public DateTime DatePerformed { get; set; } = DateTime.Now;
    }
}
