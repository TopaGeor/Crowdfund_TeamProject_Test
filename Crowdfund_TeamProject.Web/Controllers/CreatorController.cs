using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Crowdfund_TeamProject.Web.Controllers
{
    public class CreatorController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CreatorController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]

        //public async Task<IActionResult> CreateCreator(

        // [FromBody] Core.Model.Options. options)

        //{

        //    var result = await customers_.CreateCustomerAsync(

        //        options);



        //    return result.AsStatusResult();

        //}
    } 
}
