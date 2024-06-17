using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Catalogs.Domain.Base
{
    public class AggregateRoot
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string? LastModifiedBy { get; set; }
        protected AggregateRoot()
        {
        }



        private List<INotification> _domainEvents;

        private List<INotification> _integrationEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();
        public IReadOnlyCollection<INotification> IntegrationEvents => _integrationEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void AddIntegrationEvent(INotification eventItem)
        {
            _integrationEvents = _integrationEvents ?? new List<INotification>();
            _integrationEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
        public void RemoveIntegrationEvent(INotification eventItem)
        {
            _integrationEvents?.Remove(eventItem);
        }
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
        public void ClearIntegrationEvents()
        {
            _integrationEvents?.Clear();
        }

    }
}
