using Android.App;
using Android.Content.PM;
using Cirrious.MvvmCross.Droid.Views;
using Android.Content;

namespace SoToGo.Plugins.Pushwoosh.Sample.Droid
{
    [Activity(
		Label = "SoToGo.Plugins.Pushwoosh.Sample.Droid"
		, MainLauncher = true
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }


    }
}