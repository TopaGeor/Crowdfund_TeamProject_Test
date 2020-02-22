using System.Threading.Tasks;
using Crowdfund_TeamProject.Core.Model;
using Crowdfund_TeamProject.Services;
using Crowdfund_TeamProject.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Crowdfund_TeamProject.Web.Controllers
{
    public class CreatorController : Controller
    {
        private readonly ICreatorService crsrv_;

        public CreatorController(
            ICreatorService crsrv)
        {
            crsrv_ = crsrv;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> CreateCreator(
            [FromBody] Core.Model.Options.AddCreatorOptions options)
        {
            var result = await crsrv_
                .AddCreatorAsync(options);

            return result.AsStatusResult();

        }

        [HttpGet]
        public IActionResult CreateCreator()
        {
            return View();
        }


    }
}
