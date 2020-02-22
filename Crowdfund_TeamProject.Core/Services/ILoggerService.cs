using Crowdfund_TeamProject.Core;

namespace Crowdfund_TeamProject.Services
{
    public interface ILoggerService
    {
        void LogError(StatusCode errorcode, string text);
        void LogInformation(string text);
    }
}
