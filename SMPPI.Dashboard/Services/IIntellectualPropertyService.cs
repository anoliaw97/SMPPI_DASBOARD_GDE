using SMPPI.Dashboard.ViewModels;
using SMPPI.Dashboard.Models;

namespace SMPPI.Dashboard.Services
{
    public interface IIntellectualPropertyService
    {
        Task<IPSearchViewModel> SearchIPAsync(IPSearchViewModel model);
        Task<IntellectualProperty?> GetIPByIdAsync(int id);
    }
}
