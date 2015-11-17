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

			pushmanager.RegisterForPushNotifications ();
			pushmanager.StartLocationTracking ();

			return base.FinishedLaunching(app, options);
		}

		public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		{
			PushNotificationManager.PushManager.HandlePushRegistration (deviceToken);
			(Mvx.Resolve<IPushwooshService> () as PushwooshServiceTouch).OnRegistered (deviceToken.Description);
		}

		public override void FailedToRegisterForRemoteNotifications (UIApplication application , NSError error)
		{
			PushNotificationManager.PushManager.HandlePushRegistrationFailure (error);
			(Mvx.Resolve<IPushwooshService> () as PushwooshServiceTouch).OnRegisteredError (error.Description);
		}

		public override void ReceivedRemoteNotification (UIApplication application, NSDictionary userInfo)		
		{
			PushNotificationManager.PushManager.HandlePushReceived (userInfo);
			(Mvx.Resolve<IPushwooshService> () as PushwooshServiceTouch).OnMessageReceive (userInfo.Description);
		}
	}
}

