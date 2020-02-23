using System.Linq;
using System.Threading.Tasks;
using Crowdfund_TeamProject.Core.Model;
using Crowdfund_TeamProject.Services;
using Crowdfund_TeamProject.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Crowdfund_TeamProject.Web.Controllers
{
    public class CreatorController : Controller
    {
        private readonly ICreatorService crsrv_;
        private readonly Data.Crowdfund_TeamProjectDbContext context_;

        public CreatorController(
            ICreatorService crsrv,
            Data.Crowdfund_TeamProjectDbContext context)
        {
            crsrv_ = crsrv;
            context_ = context;
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


        [HttpGet]

        public async Task<IActionResult> DashBoard()
        {
            var projlist = context_
                .Set<Project>()
                .Where(p => p.Creator.Id == 1)
                .ToList();

            var creator = await crsrv_
                .GetCreatorByIdAsync(1);
                
                
                

            var model = new Models.CreatorProjectViewModel()
            {
                Creator = creator.Data,
                ProjectList = projlist
            };

            return View(model);

        }


    }
}
