using Android.App;
using Android.Content.PM;
using Android.Content;
using MvvmCross.Droid.Views;

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