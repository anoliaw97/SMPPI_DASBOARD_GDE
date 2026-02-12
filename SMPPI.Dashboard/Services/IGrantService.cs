using SMPPI.Dashboard.ViewModels;
using SMPPI.Dashboard.Models;

namespace SMPPI.Dashboard.Services
{
    public interface IGrantService
    {
        Task<GrantSearchViewModel> SearchGrantsAsync(GrantSearchViewModel model);
        Task<GrantFinancial?> GetGrantByIdAsync(int id);
        Task<List<string>> GetGrantSchemesAsync();
        Task<List<string>> GetPhasesAsync();
        Task<List<int>> GetFiscalYearsAsync();
    }
}
