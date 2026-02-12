using Microsoft.EntityFrameworkCore;
using SMPPI.Dashboard.Data;
using SMPPI.Dashboard.Models;
using SMPPI.Dashboard.ViewModels;

namespace SMPPI.Dashboard.Services
{
    public class ProjectService : IProjectService
    {
        private readonly SMPPIDbContext _context;

        public ProjectService(SMPPIDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectSearchViewModel> SearchProjectsAsync(ProjectSearchViewModel model)
        {
            var query = _context.ResearchProjects
                .Include(p => p.PrincipalInvestigator)
                .AsQueryable();

            // Apply filters
            if (!string.IsNullOrWhiteSpace(model.SearchTerm))
            {
                query = query.Where(p => p.ProjectCode.Contains(model.SearchTerm) ||
                                        p.ProjectTitle.Contains(model.SearchTerm));
            }

            if (!string.IsNullOrWhiteSpace(model.GrantScheme))
                query = query.Where(p => p.GrantScheme == model.GrantScheme);

            if (!string.IsNullOrWhiteSpace(model.Phase))
                query = query.Where(p => p.Phase == model.Phase);

            if (!string.IsNullOrWhiteSpace(model.ProjectStatus))
                query = query.Where(p => p.ProjectStatus == model.ProjectStatus);

            if (!string.IsNullOrWhiteSpace(model.ResearchDomain))
                query = query.Where(p => p.ResearchDomain == model.ResearchDomain);

            if (model.MinBudget.HasValue)
                query = query.Where(p => p.AllocatedBudget >= model.MinBudget.Value);

            if (model.MaxBudget.HasValue)
                query = query.Where(p => p.AllocatedBudget <= model.MaxBudget.Value);

            if (model.MinProgress.HasValue)
                query = query.Where(p => p.ProgressPercentage >= model.MinProgress.Value);

            if (model.MaxProgress.HasValue)
                query = query.Where(p => p.ProgressPercentage <= model.MaxProgress.Value);

            model.TotalRecords = await query.CountAsync();

            // Apply sorting
            query = model.SortBy switch
            {
                "ProjectCode" => model.SortOrder == "asc" ? query.OrderBy(p => p.ProjectCode) : query.OrderByDescending(p => p.ProjectCode),
                "AllocatedBudget" => model.SortOrder == "asc" ? query.OrderBy(p => p.AllocatedBudget) : query.OrderByDescending(p => p.AllocatedBudget),
                _ => query.OrderByDescending(p => p.ProjectCode)
            };

            // Apply pagination and project to DTO
            model.Projects = await query
                .Skip((model.PageNumber - 1) * model.PageSize)
                .Take(model.PageSize)
                .Select(p => new ProjectListItem
                {
                    ProjectID = p.ProjectID,
                    ProjectCode = p.ProjectCode,
                    ProjectTitle = p.ProjectTitle,
                    PIName = p.PrincipalInvestigator != null ? p.PrincipalInvestigator.FullName : "",
                    GrantScheme = p.GrantScheme,
                    Phase = p.Phase,
                    ResearchDomain = p.ResearchDomain,
                    AllocatedBudget = p.AllocatedBudget,
                    SpentAmount = p.SpentAmount,
                    ProgressPercentage = p.ProgressPercentage,
                    ProjectStatus = p.ProjectStatus,
                    EndDate = p.EndDate
                })
                .ToListAsync();

            // Load filter options
            model.AvailableGrantSchemes = await GetGrantSchemesAsync();
            model.AvailablePhases = await GetPhasesAsync();
            model.AvailableStatuses = await GetProjectStatusesAsync();

            return model;
        }

        public async Task<ResearchProject?> GetProjectByIdAsync(int id)
        {
            return await _context.ResearchProjects
                .Include(p => p.PrincipalInvestigator)
                .Include(p => p.Publications)
                .Include(p => p.IntellectualProperties)
                .Include(p => p.GraduateResearchers)
                .FirstOrDefaultAsync(p => p.ProjectID == id);
        }

        public async Task<List<string>> GetGrantSchemesAsync()
        {
            return await _context.ResearchProjects
                .Where(p => !string.IsNullOrEmpty(p.GrantScheme))
                .Select(p => p.GrantScheme!)
                .Distinct()
                .OrderBy(g => g)
                .ToListAsync();
        }

        public async Task<List<string>> GetPhasesAsync()
        {
            return await _context.ResearchProjects
                .Where(p => !string.IsNullOrEmpty(p.Phase))
                .Select(p => p.Phase!)
                .Distinct()
                .OrderBy(p => p)
                .ToListAsync();
        }

        public async Task<List<string>> GetProjectStatusesAsync()
        {
            return await _context.ResearchProjects
                .Select(p => p.ProjectStatus)
                .Distinct()
                .OrderBy(s => s)
                .ToListAsync();
        }
    }
}
