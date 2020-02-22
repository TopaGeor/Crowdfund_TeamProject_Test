using Crowdfund_TeamProject.Core;
using Serilog;
using Serilog.Core;

namespace Crowdfund_TeamProject.Services
{
    public class LoggerService : ILoggerService
    {
        private Logger log_;

        public LoggerService()
        {
            log_ = new LoggerConfiguration()
                .WriteTo
                .File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void LogError(StatusCode errorcode, string text)
        {
            log_.Error("{errorcode} {text}", errorcode, text);
        }

        public void LogInformation(string text)
        {
            log_.Information(text);
        }
    }
}
