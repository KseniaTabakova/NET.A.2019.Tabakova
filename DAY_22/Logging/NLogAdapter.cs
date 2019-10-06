namespace Logging
{
    /// <summary>
    /// NLog logger adapter.
    /// </summary>
    public class NLogAdapter : ILogger
    {
        private readonly NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <inheritdoc />
        public void Debug(string message) => logger.Debug(message);

        /// <inheritdoc />
        public void Error(string message) => logger.Error(message);

        /// <inheritdoc />
        public void Info(string message) => logger.Info(message);

        /// <inheritdoc />
        public void Warn(string message) => logger.Warn(message);
    }
}
