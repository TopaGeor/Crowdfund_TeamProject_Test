using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Crowdfund.Core.Model.Options;
using Crowdfund.Core.Services;
using Crowdfund_TeamProject.Data;
using Xunit;

namespace Crowdfund_TeamProject.Test
{
    public class BackerServiceTest : IClassFixture<Crowdfund_TeamProjectFixure>
    {
        private readonly IBackerService brsrv_;
        private readonly Crowdfund_TeamProjectDbContext context_;

        public BackerServiceTest(
           Crowdfund_TeamProjectFixure fixture)
        {
            context_ = fixture.DbContext;
            brsrv_ = fixture.Container.Resolve<IBackerService>();
        }


        [Fact]
        public async Task Create_Backer_Success()
        {
            var backer = await brsrv_.AddBackerAsync(
                new AddBackerOptions()
                {
                    Email = "backerr1@gmail.com",
                    Name = "backerr_ioanna"
                });

            Assert.NotNull(backer);
        }

    }
}
