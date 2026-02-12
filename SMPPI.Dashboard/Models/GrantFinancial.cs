using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMPPI.Dashboard.Models
{
    [Table("tblGrantFinancials")]
    public class GrantFinancial
    {
        [Key]
        public int GrantID { get; set; }

        [Required]
        [StringLength(50)]
        public string GrantCode { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string GrantScheme { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Phase { get; set; } = string.Empty;

        [Required]
        public int FiscalYear { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AllocatedAmount { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal SpentAmount { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal BalanceAmount { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal PercentageSpent { get; set; } = 0;

        public int TotalProjects { get; set; } = 0;

        [StringLength(50)]
        public string GrantStatus { get; set; } = "Active";

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
