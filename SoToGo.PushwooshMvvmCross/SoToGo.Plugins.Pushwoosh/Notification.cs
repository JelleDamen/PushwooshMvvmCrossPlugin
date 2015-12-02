using System;

namespace SoToGo.Plugins.Pushwoosh
{
	public class Notification
	{
		public Notification (string message, string jsonData, string customData)
		{
			Message = message;
			JsonData = jsonData;
			CustomData = customData;
		}

		public string Message {
			get;
			private set;
		}

		public string CustomData {
			get;
			private set;
		}

		public string JsonData {
			get;
			private set;
		}
	}
}

