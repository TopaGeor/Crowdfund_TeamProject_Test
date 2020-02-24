using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Crowdfund_TeamProject.Web.Models;
using Crowdfund_TeamProject.Core.Model;

namespace Crowdfund_TeamProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Data.Crowdfund_TeamProjectDbContext context_;

        public HomeController(ILogger<HomeController> logger,
            Data.Crowdfund_TeamProjectDbContext context)
        {
            _logger = logger;
            context_ = context;
        }

        public IActionResult Index()
        {
            var trendy = context_
                .Set<Project>()
                .OrderByDescending(p => p.Achieved)
                .Take(3).ToList();

            return View(trendy);
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
    }
}
