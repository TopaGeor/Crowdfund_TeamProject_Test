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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
            //return View(new CreateProjectViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Core.Model.Options.AddProjectOptions options)
        {            
            var result = await project_.CreateProjectAsync(1, options);
            //CreateProjectViewModel model
            return result.AsStatusResult();
        }

    }
}
