using Microsoft.AspNetCore.Mvc;
using SMPPI.Dashboard.Services;
using SMPPI.Dashboard.ViewModels;

namespace SMPPI.Dashboard.Controllers
{
    public class GrantsController : Controller
    {
        private readonly IGrantService _grantService;

        public GrantsController(IGrantService grantService)
        {
            _grantService = grantService;
        }

        public async Task<IActionResult> Index(GrantSearchViewModel model)
        {
            var viewModel = await _grantService.SearchGrantsAsync(model);
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var grant = await _grantService.GetGrantByIdAsync(id);
            if (grant == null)
            {
                return NotFound();
            }
            return View(grant);
        }
    }
}
