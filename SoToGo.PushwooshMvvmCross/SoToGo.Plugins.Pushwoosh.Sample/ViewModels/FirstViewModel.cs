using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using System;

namespace SoToGo.Plugins.Pushwoosh.Sample.Core.ViewModels
{
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

		public void HandleQueuedMessages()
		{
			//Handle potentially messages that are queued
			Mvx.Resolve<IPushwooshService> ().FlushMessageQueue ();
		}

    }
}
