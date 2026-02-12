using SMPPI.Dashboard.ViewModels;

namespace SMPPI.Dashboard.Services
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> GetDashboardDataAsync();
    }
}
