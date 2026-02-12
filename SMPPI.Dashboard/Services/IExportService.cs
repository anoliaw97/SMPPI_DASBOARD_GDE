using SMPPI.Dashboard.ViewModels;

namespace SMPPI.Dashboard.Services
{
    public interface IExportService
    {
        Task<ExportResult> ExportToExcelAsync<T>(List<T> data, string fileName) where T : class;
        Task<ExportResult> ExportToPdfAsync<T>(List<T> data, string fileName, string title) where T : class;
        Task<ExportResult> ExportToCsvAsync<T>(List<T> data, string fileName) where T : class;
        Task LogExportAsync(string userName, string entityType, string exportFormat, int recordCount, string? filterCriteria = null);
    }
}
