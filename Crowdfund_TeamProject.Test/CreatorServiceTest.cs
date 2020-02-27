using System.Threading.Tasks;
using Autofac;
using Crowdfund_TeamProject.Core;
using Crowdfund_TeamProject.Core.Model.Options;
using Crowdfund_TeamProject.Data;
using Crowdfund_TeamProject.Services;
using Xunit;

namespace Crowdfund_TeamProject.Test
{
    public class CreatorServiceTest : IClassFixture<Crowdfund_TeamProjectFixure>
    {
        private readonly ICreatorService crsrv_;
        private readonly Crowdfund_TeamProjectDbContext context_;

        public CreatorServiceTest(
            Crowdfund_TeamProjectFixure fixture)
        {
            context_ = fixture.DbContext;
            crsrv_ = fixture.Container.Resolve<ICreatorService>();
        }

        [Fact]
        public async Task Create_Creator_Success()
        {
            var creator = await crsrv_.AddCreatorAsync(
                new AddCreatorOptions()
                {
                    Email = "creatorrr4@gmail.com",
                    Name = "creatorrr_ioanna"
                });

            Assert.NotNull(creator);
        }

        [Fact]
        public async Task Create_Creator_Failure()
        {
            var creator = await crsrv_.AddCreatorAsync(
                new AddCreatorOptions()
                {
                    Email = "",
                    Name = "creatorrr_ioanna"
                });

            Assert.Equal(StatusCode.BadRequest, creator.ErrorCode);

        }

        [Fact]
        public async Task Update_Creator_Success()
        {
            var result = await crsrv_.UpdateCreatorAsync(5,
                new UpdateCreatorOptions()
                {
                    Name = "ioanaaa"
                });
        }
    }
}
