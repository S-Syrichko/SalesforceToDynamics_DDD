using Sentry.OpenTelemetry;
using Sentry;
using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Trace;
using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;
using CCI_SalesforceToDynamics.Infrastructure.Salesforce.Clients;
using CCI_SalesforceToDynamics.Domain.Repositories;
using CCI_SalesforceToDynamics.Infrastructure.Salesforce.Repositories;
using CCI_SalesforceToDynamics.Infrastructure.Dynamics.Clients;
using CCI_SalesforceToDynamics.Infrastructure.Dynamics.Repositories;
using CCI_SalesforceToDynamics.Application.Services;
using System.Threading.Tasks;

namespace CCI_SalesforceToDynamics
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var activitySource = new ActivitySource("OpenTelemetry.Console");

            Env.Load();

            string salesforceConsumerKey = Env.GetString("SALESFORCE_CONSUMER_KEY");
            string salesforceConsumerSecret = Env.GetString("SALESFORCE_CONSUMER_SECRET");
            string salesforceUsername = Env.GetString("SALESFORCE_USERNAME");
            string salesforcePassword = Env.GetString("SALESFORCE_PASSWORD");
            string salesforceLoginUrl = Env.GetString("SALESFORCE_LOGIN_URL");
            string dynamicsConnectionString = Env.GetString("DYNAMICS_CONNECTION_STRING");
            string sentryDSN = Env.GetString("SENTRY_DSN");

            SentrySdk.Init(options =>
            {
                options.Dsn = sentryDSN;

                options.Debug = true;
                options.TracesSampleRate = 1.0;
                options.UseOpenTelemetry();
            });

            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(activitySource.Name)
                .AddSentry()
                .Build();

            using (var activity = activitySource.StartActivity("Main"))
            {

                ITransactionTracer transaction = SentrySdk.StartTransaction("Program", "Main");
                SentrySdk.ConfigureScope(scope => scope.Transaction = transaction);

                var services = new ServiceCollection();

                services.AddSingleton<ISalesforceClient>(provider =>
                {
                    return SalesforceClient.CreateAsync(
                        salesforceConsumerKey,
                        salesforceConsumerSecret,
                        salesforceUsername,
                        salesforcePassword,
                        salesforceLoginUrl
                    ).GetAwaiter().GetResult();
                });

                services.AddScoped<ISalesforceAccountRepository, AccountRepository>();
                services.AddScoped<ISalesforceContactRepository, ContactRepository>();
                services.AddScoped<ISalesforceEventRepository, EventRepository>();
                services.AddScoped<ISalesforceOpportunityRepository, OpportunityRepository>();
                services.AddScoped<ISalesforceOpportunityLineRepository, OpportunityLineRepository>();
                services.AddScoped<ISalesforcePrestationRepository, PrestationRepository>();
                services.AddScoped<ISalesforceUserRepository, UserRepository>();

                services.AddSingleton<IDynamicsClient>(provider =>
                    new DynamicsCrmClient(dynamicsConnectionString)
                );

                services.AddScoped<IDynamicsAccountRepository, DynAccountRepository>();
                services.AddScoped<IDynamicsContactRepository, DynContactRepository>();
                services.AddScoped<IDynamicsDivisionRepository, DynDivisionRepository>();
                services.AddScoped<IDynamicsNAFCodeRepository, DynNAFCodeRepository>();
                services.AddScoped<IDynamicsPropositionRepository, DynPropositionRepository>();
                services.AddScoped<IDynamicsTeamRepository, DynTeamRepository>();
                services.AddScoped<IDynamicsUserRepository, DynUserRepository>();
                services.AddScoped<IDynamicsVisitCardRepository, DynVisitCardRepository>();
                services.AddScoped<IDynamicsPropositionProductRepository, DynPropositionProductRepository>();


                services.AddScoped<UtilisateurSyncService>();
                services.AddScoped<PropositionSyncService>();

                var serviceProvider = services.BuildServiceProvider();

                var userService = serviceProvider.GetRequiredService<UtilisateurSyncService>();
                await userService.SyncUtilisateursAsync();

                var propositionService = serviceProvider.GetRequiredService<PropositionSyncService>();
                await propositionService.SyncPropositionsAsync();

            }
        }
    }
}