using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modules.Catalogs.Application;
using Modules.Catalogs.Domain;
using Modules.Catalogs.Infrastructure;

namespace Module.Catalogs
{
    public static class AddCatalogModule
    {
        public static void AddCatalogServices(this IServiceCollection services,string connectionString)
        {
            services.AddTransient<CatalogDomainService>();
            services.AddTransient<CatalogAppService>();
            services.AddDbContext<CatalogDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
