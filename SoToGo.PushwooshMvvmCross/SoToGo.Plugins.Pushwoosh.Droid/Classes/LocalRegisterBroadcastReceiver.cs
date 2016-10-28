using System;
using Pushwoosh;
using Android.Content;
using MvvmCross.Platform;

namespace SoToGo.Plugins.Pushwoosh.Droid
{
	public class LocalRegisterBroadcastReceiver : BaseRegistrationReceiver
	{
		protected override void OnRegisterActionReceive (Context p0, Intent intent)
		{
			var service = Mvx.Resolve<IPushwooshService> () as PushwooshServiceDroid;
			if (service != null)
			{
				service.CheckIntent (intent);
			}
		}

	}
}

