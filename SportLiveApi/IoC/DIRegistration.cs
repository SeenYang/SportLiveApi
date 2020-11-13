using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportLiveApi.Repository;

namespace SportLiveApi.IoC
{
    public static class DIRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISportLiveRepository, SportLiveRepository>();
            // services.AddMediatR(Assembly.GetExecutingAssembly());
            // services.AddTransient<ITransactionsServices, TransactionsServices>();
        }
    }
}