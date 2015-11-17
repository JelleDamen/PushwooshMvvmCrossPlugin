using System;
using Cirrious.MvvmCross.Touch.Platform;
using UIKit;
using Foundation;
using SoToGo.Plugins.Pushwoosh.Touch.PushwooshSDK;
using Cirrious.CrossCore;

namespace SoToGo.Plugins.Pushwoosh.Touch
{
	public class MvxPushwooshApplicationDelegate : MvxApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			PushNotificationManager pushmanager = PushNotificationManager.PushManager;
			pushmanager.Delegate = this;

			if (options != null) {
				if (options.ContainsKey (UIApplication.LaunchOptionsRemoteNotificationKey)) { 
					pushmanager.HandlePushReceived (options);
				}
			}

			Mvx.Resolve<IPushwooshService>().Register ();

			return true;
		}

		public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		{
			PushNotificationManager.PushManager.HandlePushRegistration (deviceToken);
			Mvx.Resolve<IPushwooshService> ().OnRegistered (deviceToken.Description);
		}

		public override void FailedToRegisterForRemoteNotifications (UIApplication application , NSError error)
		{
			PushNotificationManager.PushManager.HandlePushRegistrationFailure (error);
			Mvx.Resolve<IPushwooshService> ().OnRegisteredError (error.Description);
		}

		public override void ReceivedRemoteNotification (UIApplication application, NSDictionary userInfo)		
		{
			PushNotificationManager.PushManager.HandlePushReceived (userInfo);
			Mvx.Resolve<IPushwooshService> ().OnMessageReceive (userInfo.Description);
		}

	}
}

