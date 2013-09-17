using System;
using FubuCore;
using FubuCore.Logging;
using Logger = NLog.Logger;

namespace FubuMVC.NLog
{
    public class NLogListener : ILogListener
    {
        private readonly Logger _logger;
        private readonly Func<Type, bool> _filter;

        public NLogListener(Logger logger, Func<Type, bool> filter)
        {
            _logger = logger;
            _filter = filter;
        }

        public bool ListensFor(Type type)
        {
            return _filter(type);
        }

        public void DebugMessage(object message)
        {
            _logger.Debug(message);
        }

        public void InfoMessage(object message)
        {
            _logger.Info(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Error(string message, Exception ex)
        {
            _logger.ErrorException(message, ex);
        }

        public void Error(object correlationId, string message, Exception ex)
        {
            _logger.ErrorException("Id: {0} / {1}".ToFormat(correlationId, message), ex);
        }

        public bool IsDebugEnabled { get { return _logger.IsDebugEnabled; } }
        public bool IsInfoEnabled { get { return _logger.IsInfoEnabled; } }
    }
}