# Pushwoosh plugin for MvvmCross
MvvmCross plugin that wraps the native Pushwoosh SDK

## iOS
On iOS use the MvxPushwooshApplicationDelegate as a base class for your AppDelegate

	[Register("AppDelegate")]
	public partial class AppDelegate : MvxPushwooshApplicationDelegate
	{
		UIWindow _window;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			_window = new UIWindow(UIScreen.MainScreen.Bounds);

			var setup = new Setup(this, _window);
			setup.Initialize();

			var startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();

			_window.MakeKeyAndVisible();

			return base.FinishedLaunching (app, options);
		}
	}
	
## Android
On android you have to set some permissions in the AndroidManifest.xml (See sample project or Pushwoosh documentation). On the main activity you have to set an intent filter and you have to override the OnNewIntent method in the main activity.

	[Activity(Label = "View for FirstViewModel")]
		[IntentFilter (new string[]{"pushwoosh.sample.droid.MESSAGE"}, Categories = new string[]{"android.intent.category.DEFAULT"})]
		public class FirstView : MvxActivity<FirstViewModel>
	    {
	
	        protected override void OnCreate(Bundle bundle)
	        {
	            base.OnCreate(bundle);
	
	            SetContentView(Resource.Layout.FirstView);
	        }
	
			protected override void OnNewIntent(Intent intent)
			{
				(Mvx.Resolve<IPushwooshService> () as PushwooshServiceDroid).CheckIntent (intent);
			}
	    }

## Cross
In your viewmodel you can now register for push notifications.

	public class FirstViewModel : MvxViewModel
    {
		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}


		public override void Start ()
		{
			base.Start ();

			Mvx.Resolve<IPushwooshService>().Register ();
		}

    }
