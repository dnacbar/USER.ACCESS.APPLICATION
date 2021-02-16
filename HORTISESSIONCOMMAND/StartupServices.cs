using HORTISESSIONCOMMANDREPOSITORY.MONGODBCONNECTION;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.SIGNATURE;
using HORTIUSERCOMMAND.DOMAIN.MODEL.SIGNATURE;
using HORTIUSERCOMMAND.REPOSITORY;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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

        private static void ServicesModel(IServiceCollection service)
        {
            service.AddScoped<IUserSessionSignature, UserSessionSignature>();
        }
    }
}
