using SMPPI.Dashboard.Models;

namespace SMPPI.Dashboard.ViewModels
{
    public class PublicationSearchViewModel
    {
        // Search Filters
        public string? SearchTerm { get; set; }
        public string? Author { get; set; }
        public string? PublicationType { get; set; }
        public int? PublicationYear { get; set; }
        public string? Quartile { get; set; }
        public bool? IsIndexed { get; set; }
        public string? GrantCode { get; set; }

        // Sorting
        public string SortBy { get; set; } = "PublicationYear";
        public string SortOrder { get; set; } = "desc";

        // Pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);

        // Results
        public List<PublicationListItem> Publications { get; set; } = new();

        // Filter Options
        public List<string> AvailablePublicationTypes { get; set; } = new();
        public List<int> AvailableYears { get; set; } = new();
        public List<string> AvailableQuartiles { get; set; } = new() { "Q1", "Q2", "Q3", "Q4" };

        // Active Filters Count
        public int ActiveFiltersCount
        {
            get
            {
                int count = 0;
                if (!string.IsNullOrWhiteSpace(SearchTerm)) count++;
                if (!string.IsNullOrWhiteSpace(Author)) count++;
                if (!string.IsNullOrWhiteSpace(PublicationType)) count++;
                if (PublicationYear.HasValue) count++;
                if (!string.IsNullOrWhiteSpace(Quartile)) count++;
                if (IsIndexed.HasValue) count++;
                if (!string.IsNullOrWhiteSpace(GrantCode)) count++;
                return count;
            }
        }
    }

    public class PublicationListItem
    {
        public int PublicationID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string PublicationType { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public string? Authors { get; set; }
        public string? VenueName { get; set; }
        public string? DOI { get; set; }
        public string? Quartile { get; set; }
        public int CitationCount { get; set; }
        public bool IsIndexed { get; set; }
        public string? ProjectCode { get; set; }
        public string? GrantCode { get; set; }
    }
}
