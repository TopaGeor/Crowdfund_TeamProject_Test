using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Crowdfund_TeamProject.Web.Models;
using Crowdfund_TeamProject.Services;
using Crowdfund_TeamProject.Web.Extensions;

namespace Crowdfund_TeamProject.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectService project_;

        public ProjectController(ILogger<HomeController> logger, IProjectService project)
        {
            _logger = logger;
            project_ = project;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateProjectViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectViewModel model)
        {            
            var result = await project_.CreateProjectAsync(1, model.Options);
            return result.AsStatusResult();
        }

    }
}
