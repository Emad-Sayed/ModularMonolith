using Modules.Catalogs.Domain;
using Modules.Catalogs.Domain.Events;

namespace Module.Catalogs.Tests
{
    public class CatalogAggregateTests
    {
        [Fact]
        public void CreateNewCatalalog_Must_Add_Domain_Event_From_Type_CatalogCreated()
        {
            //arrange
            var id = Guid.NewGuid();
            var name = "Catalog";
            //act
            var catalog = new Catalog(id, name);
            //assert
            var catalogCreatedEvent = catalog.DomainEvents
                                              .OfType<CatalogCreated>()
                                              .FirstOrDefault();
            Assert.NotNull(catalogCreatedEvent);
        }
    }
}