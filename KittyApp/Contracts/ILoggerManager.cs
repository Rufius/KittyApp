namespace KittyApp.Contracts
{
    public interface ILoggerManager
    {
        void LogError(string msg);
        void LogWarning(string msg);
        void LogInfo(string msg);
    }
}