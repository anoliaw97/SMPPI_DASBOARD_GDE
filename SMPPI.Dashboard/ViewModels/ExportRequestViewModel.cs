namespace SMPPI.Dashboard.ViewModels
{
    public class ExportRequestViewModel
    {
        public string EntityType { get; set; } = string.Empty;
        public string ExportFormat { get; set; } = "Excel"; // Excel, PDF, CSV
        public string? FilterCriteria { get; set; }
        public DateTime RequestedDate { get; set; } = DateTime.Now;
        public string RequestedBy { get; set; } = string.Empty;
    }

    public class ExportResult
    {
        public bool Success { get; set; }
        public string? FileName { get; set; }
        public byte[]? FileData { get; set; }
        public string? ContentType { get; set; }
        public string? ErrorMessage { get; set; }
        public int RecordCount { get; set; }
    }
}
