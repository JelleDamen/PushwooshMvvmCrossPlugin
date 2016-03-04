using System;
using Pushwoosh;
using Android.Runtime;
using Android.App;
using MvvmCross.Droid.Platform;

namespace SoToGo.Plugins.Pushwoosh.Droid
{
	[Register ("sotogo/plugins/pushwoosh/GCMListenerService")]
	public class MvxGCMListenerService : GCMListenerService
	{
		public override void OnCreate ()
		{
			base.OnCreate ();

			var setupSingleton = MvxAndroidSetupSingleton.EnsureSingletonAvailable(ApplicationContext);
			setupSingleton.EnsureInitialized();
		}
	}
}

