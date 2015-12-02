using System;
using Cirrious.CrossCore;
using System.Collections.Generic;

namespace SoToGo.Plugins.Pushwoosh
{
	public abstract class BasePushwooshService
	{
		protected virtual Queue<string> messageQueue { get; set; } = new Queue<string> ();

		/// <summary>
		/// Gets or sets the message receive event.
		/// Notification argument represents incoming message
		/// </summary>
		/// <value>The message receive event.</value>
		public Action<Notification> MessageReceiveEvent { get; set; }
		/// <summary>
		/// Gets or sets the registered event.
		/// String argument represents registrationID
		/// </summary>
		/// <value>The registered event.</value>
		public Action<string> RegisteredEvent { get; set; }
		/// <summary>
		/// Gets or sets the unregistered event.
		/// String argument represents registrationID
		/// </summary>
		/// <value>The unregistered event.</value>
		public Action<string> UnregisteredEvent { get; set; }

		/// <summary>
		/// Gets or sets the unregistered error event.
		/// String argument represents error message
		/// </summary>
		/// <value>The unregistered error event.</value>
		public Action<string> UnregisteredErrorEvent { get; set; }
		/// <summary>
		/// Gets or sets the registered error event.
		/// String argument represents error message
		/// </summary>
		/// <value>The registered error event.</value>
		public Action<string> RegisteredErrorEvent { get; set; }


		public virtual void OnMessageReceive(string data)
		{
			MessageReceiveEvent?.Invoke(Mvx.Resolve<INotificationParser> ().Parse (data));
		}

		public virtual void StoreInMessageQueue(string data)
		{
			messageQueue.Enqueue (data);
		}

		public virtual void FlushMessageQueue()
		{
			//Dequeue all items from internal storage (should be only one message)
			while (messageQueue.Count > 0) {
				OnMessageReceive (messageQueue.Dequeue ());
			}
		}

		public virtual void OnRegistered(String registrationId)
		{
			RegisteredEvent?.Invoke(registrationId);
		}

		public virtual void OnUnregistered(String registrationId)
		{
			UnregisteredEvent?.Invoke(registrationId);
		}

		public virtual void OnUnregisteredError(String errorId)
		{
			UnregisteredErrorEvent?.Invoke(errorId);
		}

		public virtual void OnRegisteredError(String errorId)
		{
			RegisteredErrorEvent?.Invoke(errorId);
		}
	}
}

