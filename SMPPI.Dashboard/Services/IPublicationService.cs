using SMPPI.Dashboard.ViewModels;
using SMPPI.Dashboard.Models;

namespace SMPPI.Dashboard.Services
{
    public interface IPublicationService
    {
        Task<PublicationSearchViewModel> SearchPublicationsAsync(PublicationSearchViewModel model);
        Task<Publication?> GetPublicationByIdAsync(int id);
        Task<List<string>> GetPublicationTypesAsync();
        Task<List<int>> GetPublicationYearsAsync();
    }
}
