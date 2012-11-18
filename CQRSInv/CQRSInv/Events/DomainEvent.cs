using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRSInv.Events
{
	[Serializable]
	public class DomainEvent : CQRSInv.Events.IDomainEvent
	{
		public Guid Id { get; private set; }
        public Guid AggregateId { get; set; }
		int CQRSInv.Events.IDomainEvent.Version { get; set; }

        public DomainEvent()
        {
            Id = Guid.NewGuid();
		}
	}
}
