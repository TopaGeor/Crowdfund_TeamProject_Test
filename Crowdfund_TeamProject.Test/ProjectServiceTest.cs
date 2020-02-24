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
                    Category = Core.Model.ProjectCategory.Book,
                    Description = "lola ena axladi",
                    Title = "axladi",
                    Goal = 100,
                    ExpirationDate = DateTimeOffset.Now ,
                    PhotoUrl = "picture2",
                    VideoUrl = "video2"
                });
            Assert.Equal(StatusCode.OK, project.ErrorCode);
          
        }

       
    }
}
