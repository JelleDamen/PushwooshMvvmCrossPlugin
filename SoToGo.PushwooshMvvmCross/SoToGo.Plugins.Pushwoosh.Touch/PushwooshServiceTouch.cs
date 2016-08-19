using System;
using Pushwoosh;

namespace SoToGo.Plugins.Pushwoosh.Touch
{
	public class PushwooshServiceTouch : BasePushwooshService, IPushwooshService
	{
		public PushwooshServiceTouch ()
		{
			
		}

		public virtual PushNotificationManager CurrentManager {
			get{ return PushNotificationManager.PushManager; }
		}

		public bool DefaultStartLocationTrackingOnRegistraton { get; set; } = true;

		public virtual void StartLocationTracking(){
			CurrentManager.StartLocationTracking ();
		}

		public virtual void StopLocationTracking(){
			CurrentManager.StopLocationTracking ();
		}

		public virtual void Register()
		{
			CurrentManager.RegisterForPushNotifications ();

			if (DefaultStartLocationTrackingOnRegistraton) {
				StartLocationTracking ();
			}
		}

		public virtual void UnRegister()
		{
			CurrentManager.UnregisterForPushNotifications ();
		}
	}
}

