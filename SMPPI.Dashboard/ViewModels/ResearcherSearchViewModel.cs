using SMPPI.Dashboard.Models;

namespace SMPPI.Dashboard.ViewModels
{
    public class ResearcherSearchViewModel
    {
        // Search Filters
        public string? SearchTerm { get; set; }
        public string? Faculty { get; set; }
        public string? Position { get; set; }
        public string? ResearchDomain { get; set; }
        public bool? IsActive { get; set; }

        // Sorting
        public string SortBy { get; set; } = "FullName";
        public string SortOrder { get; set; } = "asc";

        // Pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);

        // Results
        public List<AcademicStaff> Researchers { get; set; } = new();

        // Filter Options (for dropdowns)
        public List<string> AvailableFaculties { get; set; } = new();
        public List<string> AvailablePositions { get; set; } = new();
        public List<string> AvailableResearchDomains { get; set; } = new();

        // Active Filters Count
        public int ActiveFiltersCount
        {
            get
            {
                int count = 0;
                if (!string.IsNullOrWhiteSpace(SearchTerm)) count++;
                if (!string.IsNullOrWhiteSpace(Faculty)) count++;
                if (!string.IsNullOrWhiteSpace(Position)) count++;
                if (!string.IsNullOrWhiteSpace(ResearchDomain)) count++;
                if (IsActive.HasValue) count++;
                return count;
            }
        }
    }
}
