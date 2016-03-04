using Android.App;
using Android.OS;
using SoToGo.Plugins.Pushwoosh.Droid;
using SoToGo.Plugins.Pushwoosh.Sample.Core.ViewModels;
using Android.Content;
using Android.Widget;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;

namespace SoToGo.Plugins.Pushwoosh.Sample.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
	[IntentFilter (new string[]{"pushwoosh.sample.droid.MESSAGE"}, Categories = new string[]{"android.intent.category.DEFAULT"})]
	public class FirstView : MvxActivity<FirstViewModel>
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.FirstView);

			Mvx.Resolve<IPushwooshService> ().Register ();
        }

		protected override void OnViewModelSet ()
		{
			base.OnViewModelSet ();

			Mvx.Resolve<IPushwooshService> ().MessageReceiveEvent = (n) => {
				RunOnUiThread (() => {
					Toast.MakeText (this, n.Message, ToastLength.Long).Show ();
				});	
			};

			ViewModel.HandleQueuedMessages ();
		}

		protected override void OnNewIntent(Intent intent)
		{
			(Mvx.Resolve<IPushwooshService> () as PushwooshServiceDroid).CheckIntent (intent);
		}
    }
}