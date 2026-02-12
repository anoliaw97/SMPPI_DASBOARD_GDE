using Microsoft.EntityFrameworkCore;
using SMPPI.Dashboard.Data;
using SMPPI.Dashboard.Models;
using SMPPI.Dashboard.ViewModels;

namespace SMPPI.Dashboard.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly SMPPIDbContext _context;

        public PublicationService(SMPPIDbContext context)
        {
            _context = context;
        }

        public async Task<PublicationSearchViewModel> SearchPublicationsAsync(PublicationSearchViewModel model)
        {
            var query = _context.Publications
                .Include(p => p.LinkedProject)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.SearchTerm))
            {
                query = query.Where(p => p.Title.Contains(model.SearchTerm) ||
                                        (p.DOI != null && p.DOI.Contains(model.SearchTerm)));
            }

            if (!string.IsNullOrWhiteSpace(model.Author))
                query = query.Where(p => p.Authors != null && p.Authors.Contains(model.Author));

            if (!string.IsNullOrWhiteSpace(model.PublicationType))
                query = query.Where(p => p.PublicationType == model.PublicationType);

            if (model.PublicationYear.HasValue)
                query = query.Where(p => p.PublicationYear == model.PublicationYear.Value);

            if (!string.IsNullOrWhiteSpace(model.Quartile))
                query = query.Where(p => p.Quartile == model.Quartile);

            if (model.IsIndexed.HasValue)
                query = query.Where(p => p.IsIndexed == model.IsIndexed.Value);

            if (!string.IsNullOrWhiteSpace(model.GrantCode))
                query = query.Where(p => p.GrantCode != null && p.GrantCode.Contains(model.GrantCode));

            model.TotalRecords = await query.CountAsync();

            query = model.SortOrder == "asc" ?
                query.OrderBy(p => p.PublicationYear) :
                query.OrderByDescending(p => p.PublicationYear);

            model.Publications = await query
                .Skip((model.PageNumber - 1) * model.PageSize)
                .Take(model.PageSize)
                .Select(p => new PublicationListItem
                {
                    PublicationID = p.PublicationID,
                    Title = p.Title,
                    PublicationType = p.PublicationType,
                    PublicationYear = p.PublicationYear,
                    Authors = p.Authors,
                    VenueName = p.VenueName,
                    DOI = p.DOI,
                    Quartile = p.Quartile,
                    CitationCount = p.CitationCount,
                    IsIndexed = p.IsIndexed,
                    ProjectCode = p.LinkedProject != null ? p.LinkedProject.ProjectCode : null,
                    GrantCode = p.GrantCode
                })
                .ToListAsync();

            model.AvailablePublicationTypes = await GetPublicationTypesAsync();
            model.AvailableYears = await GetPublicationYearsAsync();

            return model;
        }

        public async Task<Publication?> GetPublicationByIdAsync(int id)
        {
            return await _context.Publications
                .Include(p => p.LinkedProject)
                .FirstOrDefaultAsync(p => p.PublicationID == id);
        }

        public async Task<List<string>> GetPublicationTypesAsync()
        {
            return await _context.Publications
                .Select(p => p.PublicationType)
                .Distinct()
                .OrderBy(t => t)
                .ToListAsync();
        }

        public async Task<List<int>> GetPublicationYearsAsync()
        {
            return await _context.Publications
                .Select(p => p.PublicationYear)
                .Distinct()
                .OrderByDescending(y => y)
                .ToListAsync();
        }
    }
}
