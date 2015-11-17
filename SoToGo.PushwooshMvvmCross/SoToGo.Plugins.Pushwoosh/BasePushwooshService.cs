using System;

namespace SoToGo.Plugins.Pushwoosh
{
	public abstract class BasePushwooshService
	{
		public virtual MessageReceiveDelegate MessageReceiveEvent { get; set; }
		public virtual RegisteredDelegate RegisteredEvent { get; set; }
		public virtual UnregisteredDelegate UnregisteredEvent { get; set; }
		public virtual UnregisteredErrorDelegate UnregisteredErrorEvent { get; set; }
		public virtual RegisteredErrorDelegate RegisteredErrorEvent { get; set; }

		public virtual void OnMessageReceive(string message)
		{
			MessageReceiveEvent?.Invoke(message);
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

