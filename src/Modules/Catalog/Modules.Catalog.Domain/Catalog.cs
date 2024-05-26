namespace Modules.Catalogs.Domain
{
    public class Catalog
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Catalog(string name)
        {
            Name = name;
        }
        private Catalog()
        {
            
        }
    }
}
