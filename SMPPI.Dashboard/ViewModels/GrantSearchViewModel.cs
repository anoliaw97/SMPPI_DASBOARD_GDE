using SMPPI.Dashboard.Models;

namespace SMPPI.Dashboard.ViewModels
{
    public class GrantSearchViewModel
    {
        // Search Filters
        public string? GrantCode { get; set; }
        public string? GrantScheme { get; set; }
        public string? Phase { get; set; }
        public int? FiscalYear { get; set; }
        public string? GrantStatus { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }

        // Sorting
        public string SortBy { get; set; } = "FiscalYear";
        public string SortOrder { get; set; } = "desc";

        // Pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);

        // Results
        public List<GrantFinancial> Grants { get; set; } = new();

        // Filter Options
        public List<string> AvailableGrantSchemes { get; set; } = new();
        public List<string> AvailablePhases { get; set; } = new();
        public List<int> AvailableFiscalYears { get; set; } = new();
        public List<string> AvailableStatuses { get; set; } = new();

        // Summary Statistics
        public decimal TotalAllocated { get; set; }
        public decimal TotalSpent { get; set; }
        public decimal TotalBalance { get; set; }

        // Active Filters Count
        public int ActiveFiltersCount
        {
            get
            {
                int count = 0;
                if (!string.IsNullOrWhiteSpace(GrantCode)) count++;
                if (!string.IsNullOrWhiteSpace(GrantScheme)) count++;
                if (!string.IsNullOrWhiteSpace(Phase)) count++;
                if (FiscalYear.HasValue) count++;
                if (!string.IsNullOrWhiteSpace(GrantStatus)) count++;
                if (MinAmount.HasValue || MaxAmount.HasValue) count++;
                return count;
            }
        }
    }
}
