using Microsoft.AspNetCore.Mvc;
using SMPPI.Dashboard.Services;
using SMPPI.Dashboard.ViewModels;
using System.Text.Json;

namespace SMPPI.Dashboard.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IExportService _exportService;
        private readonly IResearcherService _researcherService;
        private readonly IProjectService _projectService;
        private readonly IPublicationService _publicationService;
        private readonly IGrantService _grantService;
        private readonly IIntellectualPropertyService _ipService;

        public ReportsController(
            IExportService exportService,
            IResearcherService researcherService,
            IProjectService projectService,
            IPublicationService publicationService,
            IGrantService grantService,
            IIntellectualPropertyService ipService)
        {
            _exportService = exportService;
            _researcherService = researcherService;
            _projectService = projectService;
            _publicationService = publicationService;
            _grantService = grantService;
            _ipService = ipService;
        }

        [HttpPost]
        public async Task<IActionResult> ExportResearchers(string format, string filters)
        {
            var filterModel = JsonSerializer.Deserialize<ResearcherSearchViewModel>(filters ?? "{}") ?? new ResearcherSearchViewModel();
            filterModel.PageSize = 10000; // Get all for export
            var data = await _researcherService.SearchResearchersAsync(filterModel);

            var result = format.ToLower() switch
            {
                "excel" => await _exportService.ExportToExcelAsync(data.Researchers, "Researchers"),
                "csv" => await _exportService.ExportToCsvAsync(data.Researchers, "Researchers"),
                "pdf" => await _exportService.ExportToPdfAsync(data.Researchers, "Researchers", "Academic Staff Report"),
                _ => null
            };

            if (result == null || !result.Success)
            {
                return BadRequest(result?.ErrorMessage ?? "Export failed");
            }

            await _exportService.LogExportAsync("System", "Researchers", format, result.RecordCount, filters);

            return File(result.FileData!, result.ContentType!, result.FileName!);
        }

        [HttpPost]
        public async Task<IActionResult> ExportProjects(string format, string filters)
        {
            var filterModel = JsonSerializer.Deserialize<ProjectSearchViewModel>(filters ?? "{}") ?? new ProjectSearchViewModel();
            filterModel.PageSize = 10000;
            var data = await _projectService.SearchProjectsAsync(filterModel);

            var result = format.ToLower() switch
            {
                "excel" => await _exportService.ExportToExcelAsync(data.Projects, "Projects"),
                "csv" => await _exportService.ExportToCsvAsync(data.Projects, "Projects"),
                "pdf" => await _exportService.ExportToPdfAsync(data.Projects, "Projects", "Research Projects Report"),
                _ => null
            };

            if (result == null || !result.Success)
            {
                return BadRequest(result?.ErrorMessage ?? "Export failed");
            }

            await _exportService.LogExportAsync("System", "Projects", format, result.RecordCount, filters);

            return File(result.FileData!, result.ContentType!, result.FileName!);
        }

        [HttpPost]
        public async Task<IActionResult> ExportPublications(string format, string filters)
        {
            var filterModel = JsonSerializer.Deserialize<PublicationSearchViewModel>(filters ?? "{}") ?? new PublicationSearchViewModel();
            filterModel.PageSize = 10000;
            var data = await _publicationService.SearchPublicationsAsync(filterModel);

            var result = format.ToLower() switch
            {
                "excel" => await _exportService.ExportToExcelAsync(data.Publications, "Publications"),
                "csv" => await _exportService.ExportToCsvAsync(data.Publications, "Publications"),
                "pdf" => await _exportService.ExportToPdfAsync(data.Publications, "Publications", "Publications Report"),
                _ => null
            };

            if (result == null || !result.Success)
            {
                return BadRequest(result?.ErrorMessage ?? "Export failed");
            }

            await _exportService.LogExportAsync("System", "Publications", format, result.RecordCount, filters);

            return File(result.FileData!, result.ContentType!, result.FileName!);
        }

        [HttpPost]
        public async Task<IActionResult> ExportGrants(string format, string filters)
        {
            var filterModel = JsonSerializer.Deserialize<GrantSearchViewModel>(filters ?? "{}") ?? new GrantSearchViewModel();
            filterModel.PageSize = 10000;
            var data = await _grantService.SearchGrantsAsync(filterModel);

            var result = format.ToLower() switch
            {
                "excel" => await _exportService.ExportToExcelAsync(data.Grants, "Grants"),
                "csv" => await _exportService.ExportToCsvAsync(data.Grants, "Grants"),
                "pdf" => await _exportService.ExportToPdfAsync(data.Grants, "Grants", "Grant Financials Report"),
                _ => null
            };

            if (result == null || !result.Success)
            {
                return BadRequest(result?.ErrorMessage ?? "Export failed");
            }

            await _exportService.LogExportAsync("System", "Grants", format, result.RecordCount, filters);

            return File(result.FileData!, result.ContentType!, result.FileName!);
        }

        [HttpPost]
        public async Task<IActionResult> ExportIP(string format, string filters)
        {
            var filterModel = JsonSerializer.Deserialize<IPSearchViewModel>(filters ?? "{}") ?? new IPSearchViewModel();
            filterModel.PageSize = 10000;
            var data = await _ipService.SearchIPAsync(filterModel);

            var result = format.ToLower() switch
            {
                "excel" => await _exportService.ExportToExcelAsync(data.IntellectualProperties, "IntellectualProperty"),
                "csv" => await _exportService.ExportToCsvAsync(data.IntellectualProperties, "IntellectualProperty"),
                "pdf" => await _exportService.ExportToPdfAsync(data.IntellectualProperties, "IntellectualProperty", "Intellectual Property Report"),
                _ => null
            };

            if (result == null || !result.Success)
            {
                return BadRequest(result?.ErrorMessage ?? "Export failed");
            }

            await _exportService.LogExportAsync("System", "IP", format, result.RecordCount, filters);

            return File(result.FileData!, result.ContentType!, result.FileName!);
        }
    }
}
