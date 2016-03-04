using System;
using Android.App;
using Android.Content;
using Pushwoosh;
using Android.Widget;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace SoToGo.Plugins.Pushwoosh.Droid
{
	public class PushwooshServiceDroid : BasePushwooshService, IPushwooshService
	{
		public class NotInizializedException : Exception
		{
			public NotInizializedException () : base("This Pushwoosh service schould be initialised before using it")
			{
				
			}
		}

		private LocalMessageBroadcastReceiver _localMessageBroadcastReceiver;
		private LocalRegisterBroadcastReceiver _localRegisterBroadcastReceiver;
		private bool _isInitialized;

		public virtual Activity MainActivity {
			get;
			private set;
		}

		public virtual PushManager CurrentManager {
			get;
			private set;
		}

		public PushwooshServiceDroid ()
		{
			_localMessageBroadcastReceiver = new LocalMessageBroadcastReceiver ();
			_localRegisterBroadcastReceiver = new LocalRegisterBroadcastReceiver ();
		}

		public virtual void Initialize(Activity activity)
		{
			//Initialize 
			MainActivity = activity;

			//Register both receivers
			RegisterReceivers ();

			CurrentManager = PushManager.GetInstance (MainActivity);
			CurrentManager.OnStartup (MainActivity);

			//Check initial intent for push messages
			CheckIntent(activity.Intent, true);

			_isInitialized = true;
		}

		public virtual void RegisterReceivers()
		{
			IntentFilter intentFilter = new IntentFilter(MainActivity.PackageName + ".action.PUSH_MESSAGE_RECEIVE");
			MainActivity.RegisterReceiver (_localMessageBroadcastReceiver, intentFilter);//, MainActivity.PackageName +".permission.C2D_MESSAGE", null);
			MainActivity.RegisterReceiver(_localRegisterBroadcastReceiver, new IntentFilter(MainActivity.PackageName + "." + PushManager.RegisterBroadCastAction));
		}

		public virtual void Register()
		{
			CheckInitialize ();

			CurrentManager.RegisterForPushNotifications ();
		}

		public virtual void UnRegister ()
		{
			CheckInitialize ();

			CurrentManager.UnregisterForPushNotifications ();
		}

		private void CheckInitialize()
		{
			if (!_isInitialized) {

				var activty = Mvx.Resolve<IMvxAndroidCurrentTopActivity> ();
				if (activty?.Activity != null) {
					Initialize (activty.Activity);
				} else {
					throw new NotInizializedException ();
				}
			}
		}

		public void CheckIntent(Intent intent, bool storeInQueue = false)
		{
			if (intent != null) {
				if (intent.HasExtra (PushManager.PushReceiveEvent)) {
					if(storeInQueue)
						StoreInMessageQueue (intent.Extras.GetString (PushManager.PushReceiveEvent));
					else
						OnMessageReceive (intent.Extras.GetString (PushManager.PushReceiveEvent));
				} else if (intent.HasExtra (PushManager.RegisterEvent)) {
					OnRegistered (intent.Extras.GetString (PushManager.RegisterEvent));
				} else if (intent.HasExtra (PushManager.UnregisterEvent)) {
					OnUnregisteredError (intent.Extras.GetString (PushManager.UnregisterEvent));
				} else if (intent.HasExtra (PushManager.RegisterErrorEvent)) {
					OnRegisteredError (intent.Extras.GetString (PushManager.RegisterErrorEvent));
				} else if (intent.HasExtra (PushManager.UnregisterErrorEvent)) {
					OnUnregistered (intent.Extras.GetString (PushManager.UnregisterErrorEvent));
				}

				resetIntentValues ();
			}
		}

		private void resetIntentValues()
		{
			var mainAppIntent = MainActivity.Intent;

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

			MainActivity.Intent = mainAppIntent;
		}

	}
}


