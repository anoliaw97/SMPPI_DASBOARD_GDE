using Microsoft.EntityFrameworkCore;
using SMPPI.Dashboard.Data;
using SMPPI.Dashboard.Models;
using SMPPI.Dashboard.ViewModels;

namespace SMPPI.Dashboard.Services
{
    public class ResearcherService : IResearcherService
    {
        private readonly SMPPIDbContext _context;

        public ResearcherService(SMPPIDbContext context)
        {
            _context = context;
        }

        public async Task<ResearcherSearchViewModel> SearchResearchersAsync(ResearcherSearchViewModel model)
        {
            var query = _context.AcademicStaff.AsQueryable();

            // Apply filters
            if (!string.IsNullOrWhiteSpace(model.SearchTerm))
            {
                query = query.Where(r => r.FullName.Contains(model.SearchTerm) ||
                                        r.UMSPER.Contains(model.SearchTerm) ||
                                        (r.Email != null && r.Email.Contains(model.SearchTerm)));
            }

            if (!string.IsNullOrWhiteSpace(model.Faculty))
            {
                query = query.Where(r => r.Faculty == model.Faculty);
            }

            if (!string.IsNullOrWhiteSpace(model.Position))
            {
                query = query.Where(r => r.Position == model.Position);
            }

            if (!string.IsNullOrWhiteSpace(model.ResearchDomain))
            {
                query = query.Where(r => r.ResearchDomain == model.ResearchDomain);
            }

            if (model.IsActive.HasValue)
            {
                query = query.Where(r => r.IsActive == model.IsActive.Value);
            }

            // Get total count
            model.TotalRecords = await query.CountAsync();

            // Apply sorting
            query = model.SortBy switch
            {
                "FullName" => model.SortOrder == "asc" ? query.OrderBy(r => r.FullName) : query.OrderByDescending(r => r.FullName),
                "Faculty" => model.SortOrder == "asc" ? query.OrderBy(r => r.Faculty) : query.OrderByDescending(r => r.Faculty),
                "Position" => model.SortOrder == "asc" ? query.OrderBy(r => r.Position) : query.OrderByDescending(r => r.Position),
                _ => query.OrderBy(r => r.FullName)
            };

            // Apply pagination
            model.Researchers = await query
                .Skip((model.PageNumber - 1) * model.PageSize)
                .Take(model.PageSize)
                .ToListAsync();

            // Load filter options
            model.AvailableFaculties = await GetFacultiesAsync();
            model.AvailablePositions = await GetPositionsAsync();
            model.AvailableResearchDomains = await GetResearchDomainsAsync();

            return model;
        }

        public async Task<AcademicStaff?> GetResearcherByIdAsync(int id)
        {
            return await _context.AcademicStaff
                .Include(s => s.ResearchProjects)
                .Include(s => s.GraduateResearchers)
                .FirstOrDefaultAsync(s => s.StaffID == id);
        }

        public async Task<List<string>> GetFacultiesAsync()
        {
            return await _context.AcademicStaff
                .Where(s => !string.IsNullOrEmpty(s.Faculty))
                .Select(s => s.Faculty!)
                .Distinct()
                .OrderBy(f => f)
                .ToListAsync();
        }

        public async Task<List<string>> GetPositionsAsync()
        {
            return await _context.AcademicStaff
                .Where(s => !string.IsNullOrEmpty(s.Position))
                .Select(s => s.Position!)
                .Distinct()
                .OrderBy(p => p)
                .ToListAsync();
        }

        public async Task<List<string>> GetResearchDomainsAsync()
        {
            return await _context.AcademicStaff
                .Where(s => !string.IsNullOrEmpty(s.ResearchDomain))
                .Select(s => s.ResearchDomain!)
                .Distinct()
                .OrderBy(d => d)
                .ToListAsync();
        }
    }
}
