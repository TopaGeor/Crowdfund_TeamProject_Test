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
            return View();
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

        [HttpPost]

        public IActionResult SearchProject( 
            Core.Model.ProjectCategory category)
        {
            if(category == Core.Model.ProjectCategory.Invalid) {
                return BadRequest("Category is required");
            }

            var resultList =  project_.
                SearchProject(
                new SearchProjectOptions()
                {
                   Category = category
                })
                .Select(c => new { c.Category, c.Creator.Name,
                    c.Title, c.Goal, c.ExpirationDate})
                .Take(100)
                .ToList();

            if(resultList.Count > 0) {
                return Json(resultList);
            }
            var result2 = context_
                .Set<Project>()
                .Take(100)
                .ToList();

            return Json(result2);
        }
    }
}
