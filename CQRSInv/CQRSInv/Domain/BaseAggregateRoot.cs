using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CQRSInv.Domain
{
	public class BaseAggregateRoot<TDomainEvent> //:
		//IEventProvider<TDomainEvent>,
		//IRegisterChildEntities<TDomainEvent>
		where TDomainEvent : CQRSInv.Events.IDomainEvent
	{
		private readonly Dictionary<Type, Action<TDomainEvent>> c_registeredEvents;
		private readonly List<TDomainEvent> c_appliedEvents;
		//private readonly List<IEntityEventProvider<TDomainEvent>> _childEventProviders;

		public Guid Id { get; protected set; }
		public int Version { get; protected set; }
		public int EventVersion { get; protected set; }

		public BaseAggregateRoot()
		{
			this.c_registeredEvents = new Dictionary<Type, Action<TDomainEvent>>();
			this.c_appliedEvents = new List<TDomainEvent>();
			//_childEventProviders = new List<IEntityEventProvider<TDomainEvent>>();
		}

		protected void RegisterEvent<TEvent>(
			Action<TEvent> eventHandler) where TEvent : class, TDomainEvent
		{
			this.c_registeredEvents.Add(typeof(TEvent), theEvent => eventHandler(theEvent as TEvent));
		}


		protected void Apply<TEvent>(
			TEvent domainEvent) where TEvent : class, TDomainEvent
		{
			domainEvent.AggregateId = Id;
			domainEvent.Version = GetNewEventVersion();
			apply(domainEvent.GetType(), domainEvent);
			this.c_appliedEvents.Add(domainEvent);
		}


		private void apply(
			Type eventType,
			TDomainEvent domainEvent)
		{
			Action<TDomainEvent> handler;

			if (!this.c_registeredEvents.TryGetValue(eventType, out handler))
			{
				//throw new UnregisteredDomainEventException(string.Format("The requested domain event '{0}' is not registered in '{1}'", eventType.FullName, GetType().FullName));
			}

			handler(domainEvent);
		}

		//void IEventProvider<TDomainEvent>.LoadFromHistory(IEnumerable<TDomainEvent> domainEvents)
		//{
		//    if (domainEvents.Count() == 0)
		//        return;

		//    foreach (var domainEvent in domainEvents)
		//    {
		//        apply(domainEvent.GetType(), domainEvent);
		//    }

		//    Version = domainEvents.Last().Version;
		//    EventVersion = Version;
		//}

		

		//IEnumerable<TDomainEvent> IEventProvider<TDomainEvent>.GetChanges()
		//{
		//    return _appliedEvents.Concat(GetChildEventsAndUpdateEventVersion()).OrderBy(x => x.Version).ToList();
		//}

		//void IEventProvider<TDomainEvent>.Clear()
		//{
		//    _childEventProviders.ForEach(x => x.Clear());
		//    _appliedEvents.Clear();
		//}

		//void IEventProvider<TDomainEvent>.UpdateVersion(int version)
		//{
		//    Version = version;
		//}

		//void IRegisterChildEntities<TDomainEvent>.RegisterChildEventProvider(IEntityEventProvider<TDomainEvent> entityEventProvider)
		//{
		//    entityEventProvider.HookUpVersionProvider(GetNewEventVersion);
		//    _childEventProviders.Add(entityEventProvider);
		//}

		//private IEnumerable<TDomainEvent> GetChildEventsAndUpdateEventVersion()
		//{
		//    return _childEventProviders.SelectMany(entity => entity.GetChanges());
		//}

		private int GetNewEventVersion()
		{
			return ++EventVersion;
		}
	}
}
