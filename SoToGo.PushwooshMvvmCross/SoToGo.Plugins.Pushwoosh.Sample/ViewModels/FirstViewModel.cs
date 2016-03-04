using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

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

		public void HandleQueuedMessages()
		{
			//Handle potentially messages that are queued
			Mvx.Resolve<IPushwooshService> ().FlushMessageQueue ();
		}

    }
}
