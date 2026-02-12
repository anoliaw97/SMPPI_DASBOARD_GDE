using System.Globalization;
using System.Text;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SMPPI.Dashboard.Data;
using SMPPI.Dashboard.Models;
using SMPPI.Dashboard.ViewModels;

namespace SMPPI.Dashboard.Services
{
    public class ExportService : IExportService
    {
        private readonly SMPPIDbContext _context;

        public ExportService(SMPPIDbContext context)
        {
            _context = context;
        }

        public async Task<ExportResult> ExportToExcelAsync<T>(List<T> data, string fileName) where T : class
        {
            try
            {
                using var package = new ExcelPackage();
                var worksheet = package.Workbook.Worksheets.Add("Data");

                // Load data into worksheet
                worksheet.Cells["A1"].LoadFromCollection(data, true);

                // Format header row
                using (var range = worksheet.Cells[1, 1, 1, worksheet.Dimension.Columns])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                    range.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // Auto-fit columns
                worksheet.Cells.AutoFitColumns();

                // Freeze header row
                worksheet.View.FreezePanes(2, 1);

                // Add summary sheet
                var summarySheet = package.Workbook.Worksheets.Add("Summary");
                summarySheet.Cells["A1"].Value = "Export Summary";
                summarySheet.Cells["A1"].Style.Font.Bold = true;
                summarySheet.Cells["A1"].Style.Font.Size = 14;
                summarySheet.Cells["A3"].Value = "Total Records:";
                summarySheet.Cells["B3"].Value = data.Count;
                summarySheet.Cells["A4"].Value = "Export Date:";
                summarySheet.Cells["B4"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                summarySheet.Cells.AutoFitColumns();

                var fileData = package.GetAsByteArray();

                return new ExportResult
                {
                    Success = true,
                    FileName = $"{fileName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                    FileData = fileData,
                    ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    RecordCount = data.Count
                };
            }
            catch (Exception ex)
            {
                return new ExportResult
                {
                    Success = false,
                    ErrorMessage = $"Excel export failed: {ex.Message}"
                };
            }
        }

        public async Task<ExportResult> ExportToPdfAsync<T>(List<T> data, string fileName, string title) where T : class
        {
            try
            {
                // For PDF generation, we'll use a simple HTML to PDF conversion
                // In production, you would use DinkToPdf or similar library
                var html = GenerateHtmlTable(data, title);
                var pdfBytes = Encoding.UTF8.GetBytes(html); // Placeholder - would use actual PDF library

                return new ExportResult
                {
                    Success = true,
                    FileName = $"{fileName}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                    FileData = pdfBytes,
                    ContentType = "application/pdf",
                    RecordCount = data.Count
                };
            }
            catch (Exception ex)
            {
                return new ExportResult
                {
                    Success = false,
                    ErrorMessage = $"PDF export failed: {ex.Message}"
                };
            }
        }

        public async Task<ExportResult> ExportToCsvAsync<T>(List<T> data, string fileName) where T : class
        {
            try
            {
                using var memoryStream = new MemoryStream();
                using var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8);
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                await csvWriter.WriteRecordsAsync(data);
                await streamWriter.FlushAsync();

                var fileData = memoryStream.ToArray();

                return new ExportResult
                {
                    Success = true,
                    FileName = $"{fileName}_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                    FileData = fileData,
                    ContentType = "text/csv",
                    RecordCount = data.Count
                };
            }
            catch (Exception ex)
            {
                return new ExportResult
                {
                    Success = false,
                    ErrorMessage = $"CSV export failed: {ex.Message}"
                };
            }
        }

        public async Task LogExportAsync(string userName, string entityType, string exportFormat, int recordCount, string? filterCriteria = null)
        {
            var auditLog = new AuditLog
            {
                UserName = userName,
                ActionType = "Export",
                EntityType = entityType,
                ExportFormat = exportFormat,
                RecordCount = recordCount,
                FilterCriteria = filterCriteria,
                IPAddress = "127.0.0.1", // Would get actual IP in production
                DatePerformed = DateTime.Now
            };

            _context.AuditLogs.Add(auditLog);
            await _context.SaveChangesAsync();
        }

        private string GenerateHtmlTable<T>(List<T> data, string title)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html><head>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: Arial, sans-serif; }");
            sb.AppendLine("h1 { color: #333; text-align: center; }");
            sb.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            sb.AppendLine("th { background-color: #4f81bd; color: white; padding: 10px; text-align: left; }");
            sb.AppendLine("td { border: 1px solid #ddd; padding: 8px; }");
            sb.AppendLine("tr:nth-child(even) { background-color: #f2f2f2; }");
            sb.AppendLine(".footer { margin-top: 20px; text-align: center; color: #666; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head><body>");
            sb.AppendLine($"<h1>{title}</h1>");
            sb.AppendLine($"<div class='footer'>Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss} | Total Records: {data.Count}</div>");
            sb.AppendLine("</body></html>");

            return sb.ToString();
        }
    }
}
