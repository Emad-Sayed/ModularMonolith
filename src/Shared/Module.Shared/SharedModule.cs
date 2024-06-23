using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Shared.Application.Cache.Intefaces;
using Module.Shared.Application.CommandPipelines;
using Module.Shared.Infrastructure.Cache;

namespace Module.Shared
{
    public static class SharedModule
    {
        public static void AddSharedServices(this IServiceCollection services, IConfiguration configuration)
        {
            var isRedisEnabled = bool.Parse(configuration["Redis:Enabled"] ?? "false");

            if (isRedisEnabled)
            {
                // Configure Redis if the flag is enabled
                string redisConnectionString = configuration["Redis:RedisConnection"] ?? "";
                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = redisConnectionString;
                });

            }
            else
            {
                services.AddDistributedMemoryCache();
            }
            services.AddSingleton<IBussinessDistributedCache, BussinessDistributedCache>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CommandUnitOfWork<,>).Assembly));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandUnitOfWork<,>));

        }
    }
}
