using System;
using System.IO;
using Cirrious.CrossCore.Platform;

namespace SoToGo.Plugins.Pushwoosh.Touch
{
	public class TouchNotificationParser : INotificationParser
	{
		private class NotificationInnerObject
		{
			public string alert { get; set; }
			public string sound { get; set; }
		}

		private class NotificationObject
		{
			public NotificationObject ()
			{
				aps = new NotificationInnerObject();
			}

			public string p { get; set; }
			public NotificationInnerObject aps { get; set; }
			public string u { get; set;}
		}

		public Notification Parse (string data)
		{
			string msg = string.Empty;
			string custom = string.Empty;

			try {
				var reader = new Newtonsoft.Json.JsonTextReader (new StringReader(data));
				var serializer = new Newtonsoft.Json.JsonSerializer ();
				var obj = serializer.Deserialize<NotificationObject> (reader);

				msg = obj.aps.alert;
				custom = obj.u;

			} catch (Exception ex) {
				MvxTrace.Error ("Failed to parse incoming data: {0}", ex.Message);

				//TODO: remove this:
				return new Notification (msg, data, ex.Message);
			}

			return new Notification (msg, data, custom);
		}
		
	}
}

