using System;
using Cirrious.CrossCore;
using Android.Content;
using Pushwoosh;

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

