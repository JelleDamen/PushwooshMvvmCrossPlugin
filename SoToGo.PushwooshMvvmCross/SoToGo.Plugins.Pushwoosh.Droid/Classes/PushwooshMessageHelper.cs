using System;
using Android.Content;
using Pushwoosh;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;

namespace SoToGo.Plugins.Pushwoosh.Droid
{
	public static class PushwooshMessageHelper
	{
		public static void CheckMessage(Intent intent)
		{

			if (intent != null) {
				var service = Mvx.Resolve<IPushwooshService> () as PushwooshServiceDroid;

				if (intent.HasExtra (PushManager.PushReceiveEvent)) {
					service.OnMessageReceive (intent.Extras.GetString (PushManager.PushReceiveEvent));
				} else if (intent.HasExtra (PushManager.RegisterEvent)) {
					service.OnRegistered (intent.Extras.GetString (PushManager.RegisterEvent));
				} else if (intent.HasExtra (PushManager.UnregisterEvent)) {
					service.OnUnregisteredError (intent.Extras.GetString (PushManager.UnregisterEvent));
				} else if (intent.HasExtra (PushManager.RegisterErrorEvent)) {
					service.OnRegisteredError (intent.Extras.GetString (PushManager.RegisterErrorEvent));
				} else if (intent.HasExtra (PushManager.UnregisterErrorEvent)) {
					service.OnUnregistered (intent.Extras.GetString (PushManager.UnregisterErrorEvent));
				}

				resetIntentValues ();
			}
		}

		private static void resetIntentValues()
		{
			//TODO: see if we need a ref to the actual activity
			var activty = Mvx.Resolve<IMvxAndroidCurrentTopActivity> ();
			var mainAppIntent = activty.Activity.Intent;

			if (mainAppIntent.HasExtra(PushManager.PushReceiveEvent))
			{
				mainAppIntent.RemoveExtra(PushManager.PushReceiveEvent);
			}
			else if (mainAppIntent.HasExtra(PushManager.RegisterEvent))
			{
				mainAppIntent.RemoveExtra(PushManager.RegisterEvent);
			}
			else if (mainAppIntent.HasExtra(PushManager.UnregisterEvent))
			{
				mainAppIntent.RemoveExtra(PushManager.UnregisterEvent);
			}
			else if (mainAppIntent.HasExtra(PushManager.RegisterErrorEvent))
			{
				mainAppIntent.RemoveExtra(PushManager.RegisterErrorEvent);
			}
			else if (mainAppIntent.HasExtra(PushManager.UnregisterErrorEvent))
			{
				mainAppIntent.RemoveExtra(PushManager.UnregisterErrorEvent);
			}

			activty.Activity.Intent = mainAppIntent;
		}
	}
}

