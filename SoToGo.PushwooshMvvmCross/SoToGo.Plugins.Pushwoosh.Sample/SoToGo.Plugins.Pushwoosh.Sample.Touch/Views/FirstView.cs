using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using SoToGo.Plugins.Pushwoosh.Sample.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform;

namespace SoToGo.Plugins.Pushwoosh.Sample.Touch.Views
{
    [Register("FirstView")]
	public class FirstView : MvxViewController<FirstViewModel>
    {

        public override void ViewDidLoad()
        {
            View = new UIView { BackgroundColor = UIColor.White };
            base.ViewDidLoad();

			// ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
            {
               EdgesForExtendedLayout = UIRectEdge.None;
            }
			   
            var label = new UILabel(new CGRect(10, 10, 300, 40));
            Add(label);
            var textField = new UITextField(new CGRect(10, 50, 300, 40));
            Add(textField);

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(label).To(vm => vm.Hello);
            set.Bind(textField).To(vm => vm.Hello);
            set.Apply();

			Mvx.Resolve<IPushwooshService>().Register ();
        }

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			ViewModel.HandleQueuedMessages ();
		}

    }
}