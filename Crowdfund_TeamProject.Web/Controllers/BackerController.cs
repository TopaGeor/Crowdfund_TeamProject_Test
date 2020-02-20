using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Crowdfund_TeamProject.Web.Models;

namespace Crowdfund_TeamProject.Web.Controllers
{
    public class BackerController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public BackerController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
    
}
