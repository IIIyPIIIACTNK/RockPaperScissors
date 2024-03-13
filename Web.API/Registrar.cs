using BuisnessLogic.Services.Abstractions;
using BuisnessLogic.Services.Implementations;
using DataAccess.Context;
using DataAccess.Repositories.Abstractions;
using DataAccess.Repositories.Implementations;
namespace Web.API
{
    public static class Registrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration.Get<ApplicationSettings>();
            return services.AddSingleton((IConfigurationRoot)configuration)
                .InstallServices()
                .ConfigureContext(applicationSettings.ConnectionString)
                .InstallRepositories()
                ;
        }

        private static IServiceCollection InstallServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IUserService, UserService>()
                .AddTransient<IMatchHistoryService, MatchHistoryService>()
                .AddTransient<IMatchService, MatchService>()
                .AddTransient<IGameTransactionService, GameTransactionService>()
                .AddTransient<ITransactionService,TransactionService>();
        }

        private static IServiceCollection InstallRepositories(this IServiceCollection services)
        {
            return services
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IMatchRepository,MatchRepository>()
                .AddTransient<IMatchHistoryRepository, MatchHistoryRepository>()
                .AddTransient<IGameTransactionsRepository, GameTransactionsRepository>()
                .AddTransient<ITransactionRepository,TransactionRepository>();
        }
    }
}
