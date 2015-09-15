using System.Linq;
using FubuCore.Logging;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using FubuTestingSupport;
using NUnit.Framework;
using StructureMap;

namespace FubuMVC.NLog.Testing
{
    [TestFixture]
    public class NLogListeningRegistrationTester
    {
        [Test]
        public void log_listener_is_registered()
        {
            using (var runtime = FubuApplication.For<LoggedRegistry>().StructureMap(new Container()).Bootstrap())
            {
                runtime.Factory.GetAll<ILogListener>().Any(x => x is NLogListener)
                    .ShouldBeTrue();
            }
        }

        [Test]
        public void debugging_is_disabled_by_default()
        {
            using (var runtime = FubuApplication.For<LoggedRegistry>().StructureMap().Bootstrap())
            {
                runtime.Factory.GetAll<ILogListener>().OfType<NLogListener>()
                    .Single()
                    .IsDebugEnabled.ShouldBeFalse();
            }
        }
    }

    public class LoggedRegistry : FubuRegistry
    {
        public LoggedRegistry()
        {
            Import<NLogListening>();
        }
    }
}