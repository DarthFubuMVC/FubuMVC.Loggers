using System;
using FubuCore.Logging;
using FubuMVC.Core;
using FubuMVC.Core.Registration.ObjectGraph;
using NLog;
using Logger = NLog.Logger;

namespace FubuMVC.NLog
{
    public class NLogListening : IFubuRegistryExtension
    {
        public NLogListening()
        {
            Filter = t => true;
            Logger = LogManager.GetCurrentClassLogger();
        }

        public Logger Logger { get; set; }

        public Func<Type, bool> Filter { get; set; }

        public void Configure(FubuRegistry registry)
        {
            registry.Services(x => x.AddService(typeof(ILogListener), ObjectDef.ForValue(new NLogListener(Logger, Filter))));
        }
    }

}