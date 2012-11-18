using System;


namespace CQRSInv.Events
{
	public interface IDomainEvent
	{
		Guid Id { get; }
		Guid AggregateId { get; set; }
		int Version { get; set; }
	}
}