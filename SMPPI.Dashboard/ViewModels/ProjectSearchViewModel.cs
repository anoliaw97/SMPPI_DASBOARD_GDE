using SMPPI.Dashboard.Models;

namespace SMPPI.Dashboard.ViewModels
{
    public class ProjectSearchViewModel
    {
        // Search Filters
        public string? SearchTerm { get; set; }
        public string? GrantScheme { get; set; }
        public string? Phase { get; set; }
        public string? ProjectStatus { get; set; }
        public string? ResearchDomain { get; set; }
        public string? PrincipalInvestigator { get; set; }
        public decimal? MinBudget { get; set; }
        public decimal? MaxBudget { get; set; }
        public int? MinProgress { get; set; }
        public int? MaxProgress { get; set; }

        // Sorting
        public string SortBy { get; set; } = "ProjectCode";
        public string SortOrder { get; set; } = "desc";

        // Pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);

        // Results
        public List<ProjectListItem> Projects { get; set; } = new();

        // Filter Options
        public List<string> AvailableGrantSchemes { get; set; } = new();
        public List<string> AvailablePhases { get; set; } = new();
        public List<string> AvailableStatuses { get; set; } = new();
        public List<string> AvailableResearchDomains { get; set; } = new();

        // Active Filters Count
        public int ActiveFiltersCount
        {
            get
            {
                int count = 0;
                if (!string.IsNullOrWhiteSpace(SearchTerm)) count++;
                if (!string.IsNullOrWhiteSpace(GrantScheme)) count++;
                if (!string.IsNullOrWhiteSpace(Phase)) count++;
                if (!string.IsNullOrWhiteSpace(ProjectStatus)) count++;
                if (!string.IsNullOrWhiteSpace(ResearchDomain)) count++;
                if (!string.IsNullOrWhiteSpace(PrincipalInvestigator)) count++;
                if (MinBudget.HasValue || MaxBudget.HasValue) count++;
                if (MinProgress.HasValue || MaxProgress.HasValue) count++;
                return count;
            }
        }
    }

    public class ProjectListItem
    {
        public int ProjectID { get; set; }
        public string ProjectCode { get; set; } = string.Empty;
        public string ProjectTitle { get; set; } = string.Empty;
        public string PIName { get; set; } = string.Empty;
        public string? GrantScheme { get; set; }
        public string? Phase { get; set; }
        public string? ResearchDomain { get; set; }
        public decimal AllocatedBudget { get; set; }
        public decimal SpentAmount { get; set; }
        public int ProgressPercentage { get; set; }
        public string ProjectStatus { get; set; } = string.Empty;
        public DateTime? EndDate { get; set; }
    }
}
