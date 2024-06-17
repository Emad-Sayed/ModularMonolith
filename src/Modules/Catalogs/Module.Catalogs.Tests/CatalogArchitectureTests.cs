using Modules.Catalogs.Application.Commands.AddCatalog;
using Modules.Catalogs.Domain;
using Modules.Catalogs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module.Catalogs.Tests
{
    public class CatalogArchitectureTests
    {
        private const string DomainNamespace = "Module.Catalogs.Domain";
        private const string ApplicationNamespace = "Module.Catalogs.Application";
        private const string InfrastructureNamespace = "Module.Catalogs.Infrastructure";

        [Fact]
        public void Domain_ShouldNotReference_ApplicationOrInfrastructure()
        {
            var domainAssembly = typeof(Catalog).Assembly;


            var referencedAssemblies = domainAssembly.GetReferencedAssemblies()
                .Select(a => a.Name)
                .ToList();

            Assert.DoesNotContain(ApplicationNamespace, referencedAssemblies);
            Assert.DoesNotContain(InfrastructureNamespace, referencedAssemblies);
        }

        [Fact]
        public void Application_ShouldReference_DomainAndNotInfrastructure()
        {
            var applicationAssembly = typeof(CreateCatalogCommand).Assembly;

            var referencedAssemblies = applicationAssembly.GetReferencedAssemblies()
                .Select(a => a.Name)
                .ToList();

            Assert.Contains(DomainNamespace, referencedAssemblies);
            Assert.DoesNotContain(InfrastructureNamespace, referencedAssemblies);
        }

        [Fact]
        public void Infrastructure_ShouldReference_Domain()
        {
            var infrastructureAssembly = typeof(CatalogDbContext).Assembly;


            var referencedAssemblies = infrastructureAssembly.GetReferencedAssemblies()
                .Select(a => a.Name)
                .ToList();

            Assert.Contains(DomainNamespace, referencedAssemblies);
        }
    }
}
