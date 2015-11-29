using System;

namespace SoToGo.Plugins.Pushwoosh
{
	public delegate void MessageReceiveDelegate(string message);
	public delegate void RegisteredDelegate(string registrationId);
	public delegate void UnregisteredDelegate(string registrationId);
	public delegate void UnregisteredErrorDelegate(string error);
	public delegate void RegisteredErrorDelegate(string error);

	public interface IPushwooshService
	{
		/// <summary>
		/// Register for push notifications
		/// </summary>
		void Register();
		/// <summary>
		/// Unregister for push notifications
		/// </summary>
		void UnRegister();

		MessageReceiveDelegate MessageReceiveEvent { get; set; }
		RegisteredDelegate RegisteredEvent { get; set; }
		UnregisteredDelegate UnregisteredEvent { get; set; }
		UnregisteredErrorDelegate UnregisteredErrorEvent { get; set; }
		RegisteredErrorDelegate RegisteredErrorEvent { get; set; }

		void OnMessageReceive (string message);
		void OnRegistered (String registrationId);
		void OnUnregistered (String registrationId);
		void OnUnregisteredError (String errorId);
		void OnRegisteredError (String errorId);
	}
}

