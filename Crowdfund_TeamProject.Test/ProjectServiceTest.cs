using System;
using System.Threading.Tasks;
using Autofac;
using Crowdfund_TeamProject.Core;
using Crowdfund_TeamProject.Core.Model.Options;
using Crowdfund_TeamProject.Data;
using Crowdfund_TeamProject.Services;
using Xunit;

namespace Crowdfund_TeamProject.Test
{
    public class ProjectServiceTest : IClassFixture<Crowdfund_TeamProjectFixure>
    {
        private readonly IProjectService  prsrv_;
        private readonly Crowdfund_TeamProjectDbContext context_;

        public ProjectServiceTest(
            Crowdfund_TeamProjectFixure fixture)
        {
            context_ = fixture.DbContext;
            prsrv_ = fixture.Container.Resolve<IProjectService>();
        }

        [Fact]
        public async Task Create_Project_Success()
        {
            var project = await prsrv_.CreateProjectAsync(1,
                new AddProjectOptions()
                {
                    Category = Core.Model.ProjectCategory.Art,
                    Description = "pinakas 2020",
                    Title = "pinakas",
                    Goal = 1200,
                    ExpirationDate = DateTimeOffset.Now.ToString(),
                    PhotoUrl = "picture3",
                    VideoUrl = "video3",
                });
            project.Data.Achieved = 160.00M;

           await  context_.SaveChangesAsync();
           Assert.Equal(StatusCode.OK, project.ErrorCode); 
        }
    }
}
