using Mayordomo.Transversal.Logging.Main;
using NLog;

namespace Mayordomo.Transversal.Common.Main
{
    public class AppLogger<T> : IAppLogger<T>
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public void LogError(string message, Exception ex)
        {
            _logger.Error(ex, message);
        }

        public void LogInformation(string message)
        {
            _logger.Info(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warn(message);
        }
    }
}
