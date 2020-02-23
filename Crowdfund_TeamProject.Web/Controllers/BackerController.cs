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
using Crowdfund_TeamProject.Core.Model;

namespace Crowdfund_TeamProject.Web.Controllers
{
    public class BackerController : Controller
    {
        private readonly IBackerService bksrv_;
        private readonly Data.Crowdfund_TeamProjectDbContext context_;

        public BackerController(
         IBackerService bksrv,
         Data.Crowdfund_TeamProjectDbContext context)
        {
            bksrv_ = bksrv;
            context_ = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(
           [FromBody] Core.Model.Options.AddBackerOptions options)
        {
            var result = await bksrv_
                .AddBackerAsync(options);
                
            return result.AsStatusResult();

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> DashBoard()
        {
            
            var backer = await bksrv_
                .GetBackerByIdAsync(1);
 
            var model = new BackerProjectViewModel()
            {
                Backer = backer.Data,
                ProjectList = backer.Data.FundedProject
            };

            return View(model);

        }

    }
   
}
