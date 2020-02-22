using Crowdfund_TeamProject.Services;
using Xunit;

namespace Crowdfund_TeamProject.Test
{
    public class LoggerServiceTest
    {


        [Fact]
        public void Log_Error_Test()
        {
            var logger = new LoggerService();
            logger.LogError(Core.StatusCode.NotFound, $"text");
        } 
    }
}
