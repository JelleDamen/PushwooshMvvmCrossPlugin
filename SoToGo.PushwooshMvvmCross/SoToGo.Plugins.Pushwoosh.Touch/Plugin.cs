using System;
using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;

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

