using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.CrossCore;
using SoToGo.Plugins.Pushwoosh.Droid;
using SoToGo.Plugins.Pushwoosh.Sample.Core.ViewModels;
using Android.Content;

namespace SoToGo.Plugins.Pushwoosh.Sample.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
	[IntentFilter (new string[]{"pushwoosh.sample.droid.MESSAGE"}, Categories = new string[]{"android.intent.category.DEFAULT"})]
	public class FirstView : MvxActivity<FirstViewModel>
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			//ViewModel.Initialize ();

            SetContentView(Resource.Layout.FirstView);
        }

		protected override void OnResume ()
		{
			base.OnResume ();
			(Mvx.Resolve<IPushwooshService> () as PushwooshServiceDroid).Initialize (this);
			Mvx.Resolve<IPushwooshService>().Register ();
		}

		protected override void OnNewIntent(Intent intent)
		{
			(Mvx.Resolve<IPushwooshService> () as PushwooshServiceDroid).CheckIntent (intent);
		}
    }
}