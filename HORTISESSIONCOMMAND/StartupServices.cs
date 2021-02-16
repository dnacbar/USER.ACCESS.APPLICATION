using HORTISESSIONCOMMANDREPOSITORY.MONGODBCONNECTION;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERCOMMAND.REPOSITORY;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Threading;

namespace HORTISESSIONCOMMAND
{
    public static class StartupServices
    {
        public static void Services(IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<MongoDBHortiConnection>(configuration.GetSection(nameof(MongoDBHortiConnection)));
            
            service.AddSingleton<IMongoDBHortiConnection>(x => x.GetRequiredService<IOptions<MongoDBHortiConnection>>().Value);

            ServicesApp(service);
            ServicesDomainService(service);
            ServicesRepository(service);
        }
        
        private static void ServicesApp(IServiceCollection service)
        {

        }

        private static void ServicesDomainService(IServiceCollection service)
        {

        }

        private static void ServicesRepository(IServiceCollection service)
        {
            service.AddScoped<ISessionRepository, SessionRepository>();
        }
    }
}
