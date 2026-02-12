using Microsoft.AspNetCore.Mvc;
using SMPPI.Dashboard.Services;
using SMPPI.Dashboard.ViewModels;

namespace SMPPI.Dashboard.Controllers
{
    public class ResearchersController : Controller
    {
        private readonly IResearcherService _researcherService;

        public ResearchersController(IResearcherService researcherService)
        {
            _researcherService = researcherService;
        }

        public async Task<IActionResult> Index(ResearcherSearchViewModel model)
        {
            var viewModel = await _researcherService.SearchResearchersAsync(model);
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var researcher = await _researcherService.GetResearcherByIdAsync(id);
            if (researcher == null)
            {
                return NotFound();
            }
            return View(researcher);
        }
    }
}
