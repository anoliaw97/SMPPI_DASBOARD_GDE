using Microsoft.AspNetCore.Mvc;
using SMPPI.Dashboard.Services;
using SMPPI.Dashboard.ViewModels;

namespace SMPPI.Dashboard.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index(ProjectSearchViewModel model)
        {
            var viewModel = await _projectService.SearchProjectsAsync(model);
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
    }
}
