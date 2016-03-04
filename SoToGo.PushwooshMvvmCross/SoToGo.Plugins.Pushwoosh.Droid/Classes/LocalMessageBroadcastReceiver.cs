using System;
using Android.Content;
using Pushwoosh;
using MvvmCross.Platform;

namespace SoToGo.Plugins.Pushwoosh.Droid
{
	class LocalMessageBroadcastReceiver : BasePushMessageReceiver
	{
		protected override void OnMessageReceive (Intent intent)
		{
			var service = Mvx.Resolve<IPushwooshService> () as PushwooshServiceDroid;
			if (service != null) {
				var msg = intent.GetStringExtra (BasePushMessageReceiver.JsonDataKey);
				service.OnMessageReceive (msg);
			}
		}

	}
}

