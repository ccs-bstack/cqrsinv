using System;
using CQRSInv.Domain.Momento;


namespace CQRSInv.Domain
{
	public class Order : CQRSInv.Domain.BaseAggregateRoot<CQRSInv.Events.IDomainEvent>, CQRSInv.Domain.Momento.IBehaviour
	{
		private string c_description;


		public Order()
		{
			// init methods

			this.RegisterEvents();
		}


		private Order(
			string description): this()
		{
			Apply(new CQRSInv.Events.OrderCreated(Guid.NewGuid(), description));
		}


		public static Order CreateNew(
			string description)
		{
			return new Order(description);
		}


		private void RegisterEvents()
		{
			this.RegisterEvent<CQRSInv.Events.OrderCreated>(OnNewOrderCreated);
		}


		private void OnNewOrderCreated(
			CQRSInv.Events.OrderCreated @event)
		{
			this.Id = @event.Id;
			this.c_description = @event.Description;
		}


		public CQRSInv.Domain.Momento.IMemento CreateMemento()
		{
			return new CQRSInv.Domain.Momento.Order(
				base.Id,
				this.c_description);
		}


		public void SetMemento(
			CQRSInv.Domain.Momento.IMemento memento)
		{
			// TODO: Pending ...
			throw new NotImplementedException();
		}
	}
}