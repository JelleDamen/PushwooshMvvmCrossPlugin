using System;
using MvvmCross.Platform.Plugins;
using MvvmCross.Platform;

namespace SoToGo.Plugins.Pushwoosh.Touch
{
	public class Plugin : IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<IPushwooshService>(() => new PushwooshServiceTouch());
			Mvx.RegisterSingleton<INotificationParser> (()=> new TouchNotificationParser ());
		}
	}
}

