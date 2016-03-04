using System;
using MvvmCross.Platform.Plugins;
using MvvmCross.Platform;

namespace SoToGo.Plugins.Pushwoosh.Droid
{
	public class Plugin : IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<IPushwooshService>(() => new PushwooshServiceDroid());
			Mvx.RegisterSingleton<INotificationParser> (()=> new DroidNotificationParser ());
		}
	}
}

