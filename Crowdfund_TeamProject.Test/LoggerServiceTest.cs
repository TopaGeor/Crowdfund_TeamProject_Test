using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Autofac;
using Crowdfund.Core.Services;

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
