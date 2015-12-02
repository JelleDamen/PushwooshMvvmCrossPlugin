using Foundation;
using UIKit;
using SoToGo.Plugins.Pushwoosh.Touch;
using SoToGo.Plugins.Pushwoosh.Sample.Touch.Views;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using SoToGo.Plugins.Pushwoosh.Sample.Core;

namespace SoToGo.Plugins.Pushwoosh.Sample.Touch
{
	[Register("AppDelegate")]
	public partial class AppDelegate : MvxPushwooshApplicationDelegate
	{
		UIWindow _window;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			_window = new UIWindow(UIScreen.MainScreen.Bounds);

			var setup = new Setup(this, _window);
			setup.Initialize();

			//Publish all incoming messages through MvxMessenger
			Mvx.Resolve<IPushwooshService> ().MessageReceiveEvent = (n) => {
				InvokeOnMainThread (() => {
					new UIAlertView ("Notification", n.Message, null, "Ok").Show ();
				});
			};

			var startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();

			_window.MakeKeyAndVisible();

			var r = base.FinishedLaunching (app, options);

			return r;
		}
	}
}


