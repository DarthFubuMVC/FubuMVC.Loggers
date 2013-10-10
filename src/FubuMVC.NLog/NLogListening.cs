using FubuCore.Logging;
using FubuMVC.Core;
using FubuMVC.Core.Registration.ObjectGraph;

namespace FubuMVC.NLog
{
    public class NLogListening : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Services(x => x.AddService(typeof (ILogListener), ObjectDef.ForValue(new NLogListener())));
        }
    }
}