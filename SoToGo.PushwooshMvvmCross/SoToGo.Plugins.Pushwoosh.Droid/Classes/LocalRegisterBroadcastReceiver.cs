using System;
using Pushwoosh;
using Android.Content;
using Cirrious.CrossCore;

namespace SoToGo.Plugins.Pushwoosh.Droid
{
	class LocalRegisterBroadcastReceiver : BaseRegistrationReceiver
	{
		protected override void OnRegisterActionReceive (Context p0, Intent intent)
		{
			PushwooshMessageHelper.CheckMessage (intent);
		}
	}
}

