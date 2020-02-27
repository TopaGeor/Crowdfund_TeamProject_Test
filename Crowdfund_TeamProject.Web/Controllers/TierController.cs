using Crowdfund_TeamProject.Core.Model;
using Crowdfund_TeamProject.Services;
using Crowdfund_TeamProject.Web.Extensions;
using Crowdfund_TeamProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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
            options.Options.Project = context_
                .Set<Project>()
                .Where(p => p.Id == options.ProjectId)
                .SingleOrDefault();

            var result = await trsrv_
                .AddTierServiceAsync(options.Options);
                
            return result.AsStatusResult();
        }

        [HttpGet ("tier/create/{id}")]
        public IActionResult Create(int id)
        {
            var project = context_
                .Set<Project>()
                .Where(p => p.Id == id)
                .SingleOrDefault();

            return View(new CreateTierViewModel(id, project.Title));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }   
}
