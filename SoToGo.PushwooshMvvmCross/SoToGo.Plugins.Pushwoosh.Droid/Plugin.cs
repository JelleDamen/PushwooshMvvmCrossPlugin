using System;
using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;

namespace SoToGo.Plugins.Pushwoosh.Droid
{
	public class Plugin : IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<IPushwooshService>(() => new PushwooshServiceDroid());

		}
	}
}

