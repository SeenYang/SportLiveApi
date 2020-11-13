using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SportLiveApi.IoC
{
    public static class DIRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddMediatR(Assembly.GetExecutingAssembly());
            // services.AddTransient<ITransactionsServices, TransactionsServices>();
        }
    }
}