using System;

namespace CQRSInv.Events
{
	[Serializable]
	public class OrderCreated : CQRSInv.Events.DomainEvent
	{
		public Guid OrderId { get; private set; }
		public string Description { get; private set; }

		public OrderCreated(
			Guid id,
			string description)
		{
			// DBC checks here

			this.OrderId = id;
			this.Description = description;
		}
	}
}