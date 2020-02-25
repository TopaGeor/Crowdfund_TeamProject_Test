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
using Crowdfund_TeamProject.Core.Model.Options;
using Crowdfund_TeamProject.Core.Model;


namespace Crowdfund_TeamProject.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService project_;
        private readonly Data.Crowdfund_TeamProjectDbContext context_;

        public ProjectController(
            IProjectService project, 
            Data.Crowdfund_TeamProjectDbContext context)
        {   
            context_ = context;
            project_ = project;
        }

        public IActionResult Index()
        {
            var resultList = context_
                .Set<Project>().ToList();

            return View("List",resultList);
        }


        [HttpGet("project/{id}")]

        public async Task<IActionResult> Details(
           int id)
        {

            var result = await project_
                .SearchProjectByIdAaync(id);
            if(result.ErrorCode == Core.StatusCode.OK) {
                return View(result.Data);
            }

            return result.AsStatusResult();

        }




        [HttpGet]
        public IActionResult Create()
        {
            return View();
            //return View(new CreateProjectViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProjectOptions options)
        {            
            var result = await project_.CreateProjectAsync(1, options);
            //CreateProjectViewModel model
            return result.AsStatusResult();
        }

      

        public IActionResult SearchProject( )
        {
            var resultList = context_
                .Set<Project>()
                .Take(100)
                .ToList();

            return View(resultList);
        }

        [HttpPost]
        public IActionResult Search(
           [FromBody] Core.Model.Options.SearchProjectOptions options)
        {
            if (options.Category == ProjectCategory.Invalid) {
                return BadRequest("Project Category is required");
            }

            var resultList = project_.SearchProject(
                new SearchProjectOptions()
                {
                    Category = options.Category
                })
                .Select(r => new { r.Category, r.Creator, r.Title, r.Goal, r.ExpirationDate })
                .Take(100)
                .ToList();

            return Json(resultList);
        }
    }
}
