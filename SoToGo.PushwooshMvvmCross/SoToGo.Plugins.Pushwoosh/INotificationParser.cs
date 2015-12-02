using System;

namespace SoToGo.Plugins.Pushwoosh
{
	public interface INotificationParser
	{
		Notification Parse (string data);
	}
}

