using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using SoToGo.Plugins.Pushwoosh.Droid;
using SoToGo.Plugins.Pushwoosh.Sample.Core.ViewModels;

namespace SoToGo.Plugins.Pushwoosh.Sample.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
	public class FirstView : MvxActivity<FirstViewModel>
    {
       protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.FirstView);

			Mvx.Resolve<IPushwooshService>().Register();
		}

		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();

			Mvx.Resolve<IPushwooshService>().MessageReceiveEvent = (n) =>
			{
				RunOnUiThread(() =>
				{
					Toast.MakeText(this, n.Message, ToastLength.Long).Show();
				});
			};

			ViewModel.HandleQueuedMessages();
		}

		protected override void OnNewIntent(Intent intent)
		{
			(Mvx.Resolve<IPushwooshService>() as PushwooshServiceDroid).CheckIntent(intent);
		}
    }
}
