using Microsoft.EntityFrameworkCore;
using SMPPI.Dashboard.Data;
using SMPPI.Dashboard.Models;
using SMPPI.Dashboard.ViewModels;

namespace SMPPI.Dashboard.Services
{
    public class IntellectualPropertyService : IIntellectualPropertyService
    {
        private readonly SMPPIDbContext _context;

        public IntellectualPropertyService(SMPPIDbContext context)
        {
            _context = context;
        }

        public async Task<IPSearchViewModel> SearchIPAsync(IPSearchViewModel model)
        {
            var query = _context.IntellectualProperties
                .Include(ip => ip.LinkedProject)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchTerm))
            {
                query = query.Where(ip => ip.IPTitle.Contains(model.SearchTerm) ||
                                         ip.ApplicationNumber.Contains(model.SearchTerm));
            }

            if (!string.IsNullOrWhiteSpace(model.IPType))
                query = query.Where(ip => ip.IPType == model.IPType);

            if (!string.IsNullOrWhiteSpace(model.IPStatus))
                query = query.Where(ip => ip.IPStatus == model.IPStatus);

            if (!string.IsNullOrWhiteSpace(model.Inventor))
                query = query.Where(ip => ip.Inventors != null && ip.Inventors.Contains(model.Inventor));

            if (model.FilingDateFrom.HasValue)
                query = query.Where(ip => ip.FilingDate >= model.FilingDateFrom.Value);

            if (model.FilingDateTo.HasValue)
                query = query.Where(ip => ip.FilingDate <= model.FilingDateTo.Value);

            model.TotalRecords = await query.CountAsync();

            query = model.SortOrder == "asc" ?
                query.OrderBy(ip => ip.FilingDate) :
                query.OrderByDescending(ip => ip.FilingDate);

            model.IntellectualProperties = await query
                .Skip((model.PageNumber - 1) * model.PageSize)
                .Take(model.PageSize)
                .Select(ip => new IPListItem
                {
                    IPID = ip.IPID,
                    ApplicationNumber = ip.ApplicationNumber,
                    IPTitle = ip.IPTitle,
                    IPType = ip.IPType,
                    Inventors = ip.Inventors,
                    FilingDate = ip.FilingDate,
                    GrantedDate = ip.GrantedDate,
                    IPStatus = ip.IPStatus,
                    ProjectCode = ip.LinkedProject != null ? ip.LinkedProject.ProjectCode : null
                })
                .ToListAsync();

            return model;
        }

        public async Task<IntellectualProperty?> GetIPByIdAsync(int id)
        {
            return await _context.IntellectualProperties
                .Include(ip => ip.LinkedProject)
                .FirstOrDefaultAsync(ip => ip.IPID == id);
        }
    }
}
