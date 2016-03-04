using UIKit;
using SoToGo.Plugins.Pushwoosh.Sample.Core;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;

namespace SoToGo.Plugins.Pushwoosh.Sample.Touch
{
	public class Setup : MvxIosSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
			: base(applicationDelegate, window)
		{
		}
		
		public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
			: base(applicationDelegate, presenter)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}
		
		protected override IMvxTrace CreateDebugTrace()
		{
			return new DebugTrace();
		}

	}
}
