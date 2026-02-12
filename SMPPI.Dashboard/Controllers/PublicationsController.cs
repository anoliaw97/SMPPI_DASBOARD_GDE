using Microsoft.AspNetCore.Mvc;
using SMPPI.Dashboard.Services;
using SMPPI.Dashboard.ViewModels;

namespace SMPPI.Dashboard.Controllers
{
    public class PublicationsController : Controller
    {
        private readonly IPublicationService _publicationService;

        public PublicationsController(IPublicationService publicationService)
        {
            _publicationService = publicationService;
        }

        public async Task<IActionResult> Index(PublicationSearchViewModel model)
        {
            var viewModel = await _publicationService.SearchPublicationsAsync(model);
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var publication = await _publicationService.GetPublicationByIdAsync(id);
            if (publication == null)
            {
                return NotFound();
            }
            return View(publication);
        }
    }
}
