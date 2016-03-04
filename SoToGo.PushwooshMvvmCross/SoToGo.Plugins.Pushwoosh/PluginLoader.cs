using System;
using MvvmCross.Platform.Plugins;
using MvvmCross.Platform;

namespace SoToGo.Plugins.Pushwoosh
{
	public class PluginLoader : IMvxPluginLoader          
	{
		public static readonly PluginLoader Instance = new PluginLoader();

		public void EnsureLoaded()
		{
			var manager = Mvx.Resolve<IMvxPluginManager>();
			manager.EnsurePlatformAdaptionLoaded<PluginLoader>();
		}
	}
}

