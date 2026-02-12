using Microsoft.AspNetCore.Mvc;
using SMPPI.Dashboard.Services;
using SMPPI.Dashboard.ViewModels;

namespace SMPPI.Dashboard.Controllers
{
    public class IntellectualPropertyController : Controller
    {
        private readonly IIntellectualPropertyService _ipService;

        public IntellectualPropertyController(IIntellectualPropertyService ipService)
        {
            _ipService = ipService;
        }

        public async Task<IActionResult> Index(IPSearchViewModel model)
        {
            var viewModel = await _ipService.SearchIPAsync(model);
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var ip = await _ipService.GetIPByIdAsync(id);
            if (ip == null)
            {
                return NotFound();
            }
            return View(ip);
        }
    }
}
