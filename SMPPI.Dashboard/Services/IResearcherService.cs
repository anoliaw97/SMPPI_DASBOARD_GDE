using SMPPI.Dashboard.ViewModels;
using SMPPI.Dashboard.Models;

namespace SMPPI.Dashboard.Services
{
    public interface IResearcherService
    {
        Task<ResearcherSearchViewModel> SearchResearchersAsync(ResearcherSearchViewModel model);
        Task<AcademicStaff?> GetResearcherByIdAsync(int id);
        Task<List<string>> GetFacultiesAsync();
        Task<List<string>> GetPositionsAsync();
        Task<List<string>> GetResearchDomainsAsync();
    }
}
