using System;
using UIKit;
using Foundation;
using Pushwoosh;
using System.Threading.Tasks;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;

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

					var data = (NSDictionary)options.ValueForKey (UIApplication.LaunchOptionsRemoteNotificationKey);

					HandleRemoteNotification (data, true);
				}
			}
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
			HandleRemoteNotification (userInfo);
		}

		private void HandleRemoteNotification(NSDictionary messageData, bool storeInQueue = false)
		{
			PushNotificationManager.PushManager.HandlePushReceived (messageData);
			NSError error;
			var data = NSJsonSerialization.Serialize (messageData, NSJsonWritingOptions.PrettyPrinted, out error);

			if(storeInQueue)
				Mvx.Resolve<IPushwooshService> ().StoreInMessageQueue (data.ToString());
			else
				Mvx.Resolve<IPushwooshService> ().OnMessageReceive (data.ToString());
		}

	}
}

