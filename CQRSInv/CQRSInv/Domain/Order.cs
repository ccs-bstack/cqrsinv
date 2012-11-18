using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CQRSInv.Domain
{
	public class Order : CQRSInv.Domain.BaseAggregateRoot<CQRSInv.Events.IDomainEvent>
	{
		private string c_description;


		public Order()
		{
			// init methods
			// register events
			this.RegisterEvents();
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


		private void RegisterEvents()
		{
			RegisterEvent<CQRSInv.Events.OrderCreated>(OnNewOrderCreated);
		}


		private void OnNewOrderCreated(
			CQRSInv.Events.OrderCreated @event)
		{
			this.Id = @event.Id;
			this.c_description = @event.Description;
		}
	}
}
