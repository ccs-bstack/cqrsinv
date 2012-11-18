using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CQRSInv.Domain
{
	public class Order : CQRSInv.EventStore.BaseAggregateRoot<CQRSInv.Events.IDomainEvent>
	{
		public Order()
		{
			// init methods
			// register events
		}


		private Order(
			Guid id,
			string description): this()
		{
			Apply(new CQRSInv.Events.OrderCreated(Guid.NewGuid(), description));
		}

		public static Order CreateNew(
			string description)
		{
			return new Order(Guid.NewGuid(), description);
		}
	}
}
