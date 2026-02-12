using Microsoft.EntityFrameworkCore;
using SMPPI.Dashboard.Data;
using SMPPI.Dashboard.Models;
using SMPPI.Dashboard.ViewModels;

namespace SMPPI.Dashboard.Services
{
    public class GrantService : IGrantService
    {
        private readonly SMPPIDbContext _context;

        public GrantService(SMPPIDbContext context)
        {
            _context = context;
        }

        public async Task<GrantSearchViewModel> SearchGrantsAsync(GrantSearchViewModel model)
        {
            var query = _context.GrantFinancials.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.GrantCode))
                query = query.Where(g => g.GrantCode.Contains(model.GrantCode));

            if (!string.IsNullOrWhiteSpace(model.GrantScheme))
                query = query.Where(g => g.GrantScheme == model.GrantScheme);

            if (!string.IsNullOrWhiteSpace(model.Phase))
                query = query.Where(g => g.Phase == model.Phase);

            if (model.FiscalYear.HasValue)
                query = query.Where(g => g.FiscalYear == model.FiscalYear.Value);

            if (!string.IsNullOrWhiteSpace(model.GrantStatus))
                query = query.Where(g => g.GrantStatus == model.GrantStatus);

            if (model.MinAmount.HasValue)
                query = query.Where(g => g.AllocatedAmount >= model.MinAmount.Value);

            if (model.MaxAmount.HasValue)
                query = query.Where(g => g.AllocatedAmount <= model.MaxAmount.Value);

            model.TotalRecords = await query.CountAsync();
            model.TotalAllocated = await query.SumAsync(g => g.AllocatedAmount);
            model.TotalSpent = await query.SumAsync(g => g.SpentAmount);
            model.TotalBalance = await query.SumAsync(g => g.BalanceAmount);

            query = model.SortOrder == "asc" ?
                query.OrderBy(g => g.FiscalYear) :
                query.OrderByDescending(g => g.FiscalYear);

            model.Grants = await query
                .Skip((model.PageNumber - 1) * model.PageSize)
                .Take(model.PageSize)
                .ToListAsync();

            model.AvailableGrantSchemes = await GetGrantSchemesAsync();
            model.AvailablePhases = await GetPhasesAsync();
            model.AvailableFiscalYears = await GetFiscalYearsAsync();

            return model;
        }

        public async Task<GrantFinancial?> GetGrantByIdAsync(int id)
        {
            return await _context.GrantFinancials.FindAsync(id);
        }

        public async Task<List<string>> GetGrantSchemesAsync()
        {
            return await _context.GrantFinancials
                .Select(g => g.GrantScheme)
                .Distinct()
                .OrderBy(s => s)
                .ToListAsync();
        }

        public async Task<List<string>> GetPhasesAsync()
        {
            return await _context.GrantFinancials
                .Select(g => g.Phase)
                .Distinct()
                .OrderBy(p => p)
                .ToListAsync();
        }

        public async Task<List<int>> GetFiscalYearsAsync()
        {
            return await _context.GrantFinancials
                .Select(g => g.FiscalYear)
                .Distinct()
                .OrderByDescending(y => y)
                .ToListAsync();
        }
    }
}
