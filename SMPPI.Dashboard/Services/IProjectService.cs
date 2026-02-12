using SMPPI.Dashboard.ViewModels;
using SMPPI.Dashboard.Models;

namespace SMPPI.Dashboard.Services
{
    public interface IProjectService
    {
        Task<ProjectSearchViewModel> SearchProjectsAsync(ProjectSearchViewModel model);
        Task<ResearchProject?> GetProjectByIdAsync(int id);
        Task<List<string>> GetGrantSchemesAsync();
        Task<List<string>> GetPhasesAsync();
        Task<List<string>> GetProjectStatusesAsync();
    }
}
