using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SMPPI.Dashboard.Data;
using SMPPI.Dashboard.ViewModels;

namespace SMPPI.Dashboard.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly SMPPIDbContext _context;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "DashboardData";
        private readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(15);

        public DashboardService(SMPPIDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<DashboardViewModel> GetDashboardDataAsync()
        {
            // Try to get cached data
            if (_cache.TryGetValue(CacheKey, out DashboardViewModel? cachedData) && cachedData != null)
            {
                return cachedData;
            }

            var viewModel = new DashboardViewModel();

            // Statistics Cards
            viewModel.TotalResearchers = await _context.AcademicStaff
                .Where(s => s.IsActive)
                .CountAsync();

            viewModel.ActiveProjects = await _context.ResearchProjects
                .Where(p => p.ProjectStatus == "Active" || p.ProjectStatus == "OnSchedule")
                .CountAsync();

            var currentYear = DateTime.Now.Year;
            viewModel.CurrentYearPublications = await _context.Publications
                .Where(p => p.PublicationYear == currentYear)
                .CountAsync();

            viewModel.TotalGrantAmount = await _context.GrantFinancials
                .SumAsync(g => g.AllocatedAmount);

            // Projects by Phase
            viewModel.ProjectsByPhase = await _context.ResearchProjects
                .Where(p => p.Phase != null)
                .GroupBy(p => p.Phase!)
                .Select(g => new { Phase = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Phase, x => x.Count);

            // Publications by Type
            viewModel.PublicationsByType = await _context.Publications
                .GroupBy(p => p.PublicationType)
                .Select(g => new { Type = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Type, x => x.Count);

            // Research Domain Distribution
            viewModel.ResearchDomainDistribution = await _context.ResearchProjects
                .Where(p => p.ResearchDomain != null)
                .GroupBy(p => p.ResearchDomain!)
                .Select(g => new { Domain = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Domain, x => x.Count);

            // Grant Spending Data
            viewModel.GrantSpendingData = await _context.GrantFinancials
                .OrderBy(g => g.FiscalYear)
                .Select(g => new GrantSpendingData
                {
                    Phase = g.Phase,
                    AllocatedAmount = g.AllocatedAmount,
                    SpentAmount = g.SpentAmount
                })
                .ToListAsync();

            // Recent Activities (simulated from recent data)
            var recentPublications = await _context.Publications
                .OrderByDescending(p => p.DateCreated)
                .Take(3)
                .ToListAsync();

            var recentProjects = await _context.ResearchProjects
                .OrderByDescending(p => p.DateCreated)
                .Take(2)
                .ToListAsync();

            viewModel.RecentActivities = new List<RecentActivityItem>();

            foreach (var pub in recentPublications)
            {
                viewModel.RecentActivities.Add(new RecentActivityItem
                {
                    ActivityType = "Publication",
                    Description = $"New publication: {pub.Title.Substring(0, Math.Min(80, pub.Title.Length))}...",
                    Date = pub.DateCreated,
                    Icon = "book",
                    Color = "success"
                });
            }

            foreach (var proj in recentProjects)
            {
                viewModel.RecentActivities.Add(new RecentActivityItem
                {
                    ActivityType = "Project",
                    Description = $"New project: {proj.ProjectCode}",
                    Date = proj.DateCreated,
                    Icon = "briefcase",
                    Color = "primary"
                });
            }

            viewModel.RecentActivities = viewModel.RecentActivities
                .OrderByDescending(a => a.Date)
                .Take(5)
                .ToList();

            // Cache the data
            _cache.Set(CacheKey, viewModel, CacheDuration);

            return viewModel;
        }
    }
}
