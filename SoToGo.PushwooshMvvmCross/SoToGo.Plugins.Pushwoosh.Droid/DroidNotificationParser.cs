using System;
using Cirrious.CrossCore.Platform;
using System.IO;

namespace SoToGo.Plugins.Pushwoosh.Droid
{
	public class DroidNotificationParser : INotificationParser
	{
		private class NotificationObject
		{
			public string vib { get; set; }
			public string title { get; set;}
			public string pri { get; set;}
			public string collapse_key { get; set;}
			public string pw_msg { get; set;}
			public string p { get; set;}
			public string u { get; set;}
			//public string userdata { get; set;}
			public bool onStart { get; set;}
			public bool foreground { get; set;}
		}


		public Notification Parse (string data)
		{
			string msg = string.Empty;
			string custom = string.Empty;

			try {
				var reader = new Newtonsoft.Json.JsonTextReader (new StringReader(data));
				var serializer = new Newtonsoft.Json.JsonSerializer ();
				var obj = serializer.Deserialize<NotificationObject> (reader);

				msg = obj.title;
				custom = obj.u;

			} catch (Exception ex) {
				MvxTrace.Error ("Failed to parse incoming data: {0}", ex.Message);
			}

			return new Notification (msg, data, custom);
		}
		
	}
}

