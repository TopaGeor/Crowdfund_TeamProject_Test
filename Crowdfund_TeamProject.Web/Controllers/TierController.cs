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
    public class TierController : Controller
    {
        private readonly ITierService trsrv_;
        private readonly Data.Crowdfund_TeamProjectDbContext context_;

        public TierController(
            ITierService trsrv,
            Data.Crowdfund_TeamProjectDbContext context)
        {
            context_ = context;
            trsrv_ = trsrv;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
           [FromBody] CreateTierViewModel options)
        {

            var result = await trsrv_
                .AddTierServiceAsync(options.Options);
                
            return result.AsStatusResult();
        }

        [HttpGet ("tier/create/{id}")]
        public IActionResult Create(int id)
        {
            return View(new CreateTierViewModel(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }   
}
