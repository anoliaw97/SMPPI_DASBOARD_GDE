using SMPPI.Dashboard.Models;

namespace SMPPI.Dashboard.ViewModels
{
    public class IPSearchViewModel
    {
        // Search Filters
        public string? SearchTerm { get; set; }
        public string? IPType { get; set; }
        public string? IPStatus { get; set; }
        public string? Inventor { get; set; }
        public DateTime? FilingDateFrom { get; set; }
        public DateTime? FilingDateTo { get; set; }

        // Sorting
        public string SortBy { get; set; } = "FilingDate";
        public string SortOrder { get; set; } = "desc";

        // Pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);

        // Results
        public List<IPListItem> IntellectualProperties { get; set; } = new();

        // Filter Options
        public List<string> AvailableIPTypes { get; set; } = new() { "Patent", "Copyright", "Trademark", "IndustrialDesign" };
        public List<string> AvailableIPStatuses { get; set; } = new() { "Filed", "Granted", "Registered", "Pending" };

        // Active Filters Count
        public int ActiveFiltersCount
        {
            get
            {
                int count = 0;
                if (!string.IsNullOrWhiteSpace(SearchTerm)) count++;
                if (!string.IsNullOrWhiteSpace(IPType)) count++;
                if (!string.IsNullOrWhiteSpace(IPStatus)) count++;
                if (!string.IsNullOrWhiteSpace(Inventor)) count++;
                if (FilingDateFrom.HasValue || FilingDateTo.HasValue) count++;
                return count;
            }
        }
    }

    public class IPListItem
    {
        public int IPID { get; set; }
        public string ApplicationNumber { get; set; } = string.Empty;
        public string IPTitle { get; set; } = string.Empty;
        public string IPType { get; set; } = string.Empty;
        public string? Inventors { get; set; }
        public DateTime FilingDate { get; set; }
        public DateTime? GrantedDate { get; set; }
        public string IPStatus { get; set; } = string.Empty;
        public string? ProjectCode { get; set; }
    }
}
