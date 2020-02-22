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

        public TierController(
         ITierService trsrv)
        {
            trsrv_ = trsrv;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(
           [FromBody] Core.Model.Options.AddTierOptions options)
        {
            var result = await trsrv_
                .AddTierServiceAsync(options);
                
            return result.AsStatusResult();

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


    }
    
}
