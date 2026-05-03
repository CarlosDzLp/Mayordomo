namespace Mayordomo.Transversal.Logging.Main
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message, Exception ex);
        void LogDebug(string message);
    }
}
