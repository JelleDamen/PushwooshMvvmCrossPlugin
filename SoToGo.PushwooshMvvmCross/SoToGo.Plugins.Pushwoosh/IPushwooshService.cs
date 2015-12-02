using System;

namespace SoToGo.Plugins.Pushwoosh
{
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

		/// <summary>
		/// Gets or sets the message receive event.
		/// Notification argument represents incoming message
		/// </summary>
		/// <value>The message receive event.</value>
		Action<Notification> MessageReceiveEvent { get; set; }
		/// <summary>
		/// Gets or sets the registered event.
		/// String argument represents registrationID
		/// </summary>
		/// <value>The registered event.</value>
		Action<string> RegisteredEvent { get; set; }
		/// <summary>
		/// Gets or sets the unregistered event.
		/// String argument represents registrationID
		/// </summary>
		/// <value>The unregistered event.</value>
		Action<string> UnregisteredEvent { get; set; }

		/// <summary>
		/// Gets or sets the unregistered error event.
		/// String argument represents error message
		/// </summary>
		/// <value>The unregistered error event.</value>
		Action<string> UnregisteredErrorEvent { get; set; }
		/// <summary>
		/// Gets or sets the registered error event.
		/// String argument represents error message
		/// </summary>
		/// <value>The registered error event.</value>
		Action<string> RegisteredErrorEvent { get; set; }

		void StoreInMessageQueue (string data);
		void FlushMessageQueue();

		void OnMessageReceive (string message);
		void OnRegistered (String registrationId);
		void OnUnregistered (String registrationId);
		void OnUnregisteredError (String errorId);
		void OnRegisteredError (String errorId);
	}
}

