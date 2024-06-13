using Modules.Catalogs.Domain.Base;
using Modules.Catalogs.Domain.Events;

namespace Modules.Catalogs.Domain
{
    public class Catalog : AggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Catalog(Guid id, string name)
        {
            Id = id;
            Name = name;
            AddDomainEvent(new CatalogCreated(name));
        }
        private Catalog()
        {

        }
    }
}
