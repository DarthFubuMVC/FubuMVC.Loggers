using FubuMVC.Core;

namespace FubuMVC.NLog
{
	public class NLogRegistry : FubuPackageRegistry
	{
		public NLogRegistry()
		{
			// Register any custom FubuMVC policies, inclusions, or 
			// other FubuMVC configuration here for ONLY this bottle
			// Or leave as is to use the default conventions unchanged
		}
	}
	
	public class NLogExtensions : IFubuRegistryExtension
	{
        public void Configure(FubuRegistry registry)
        {
            // Register any policies or services to be applied
			// to the global 
        }
	}
}