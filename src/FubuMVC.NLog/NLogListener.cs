using System;
using FubuCore;
using FubuCore.Descriptions;
using FubuCore.Logging;
using FubuCore.Util;
using NLog;
using Logger = NLog.Logger;

namespace FubuMVC.NLog
{
    public class NLogListener : ILogListener
    {
        private readonly Cache<Type, Logger> _logger;

        public NLogListener()
        {
            _logger = new Cache<Type, Logger>(x => LogManager.GetLogger(x.FullName));
        }

        public bool IsDebugEnabled
        {
            get { return true; }
        }

        public bool IsInfoEnabled
        {
            get { return true; }
        }

        public void Debug(string message)
        {
            DebugMessage(message);
        }

        public void DebugMessage(object message)
        {
            _logger[message.GetType()].Debug(Description.For(message));
        }

        public void Error(string message, Exception ex)
        {
            _logger[message.GetType()].ErrorException(message, ex);
        }

        public void Error(object correlationId, string message, Exception ex)
        {
            Error(message, ex);
        }

        public void Info(string message)
        {
            InfoMessage(message);
        }

        public void InfoMessage(object message)
        {
            _logger[message.GetType()].Info(Description.For(message));
        }

        public bool ListensFor(Type type)
        {
            return true;
        }
    }
}