using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportLiveApi.Repository;
using SportLiveApi.Services;

namespace SportLiveApi.IoC
{
    public static class DIRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISportLiveRepository, SportLiveRepository>();
            services.AddScoped<IGameServices, GameServices>();
            // services.AddMediatR(Assembly.GetExecutingAssembly());
            // services.AddTransient<ITransactionsServices, TransactionsServices>();
        }
    }
}