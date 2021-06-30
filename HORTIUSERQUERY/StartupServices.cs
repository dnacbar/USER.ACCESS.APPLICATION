using HORTI.USER.CROSSCUTTING.DBBASEMONGO.CONNECTION;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTIUSERCOMMAND.DOMAIN.SERVICE;
using HORTIUSERCOMMAND.REPOSITORY;
using HORTIUSERQUERY.APP;
using HORTIUSERQUERY.DOMAIN.INTERFACE.APP;
using HORTIUSERQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERQUERY.DOMAIN.INTERFACE.SERVICE;
using HORTIUSERQUERY.DOMAIN.SERVICE;
using HORTIUSERQUERY.DOMAIN.VALIDATION;
using HORTIUSERQUERY.REPOSITORY;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HORTIUSERQUERY
{
    public static class StartupServices
    {
        public static void Services(IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<MongoDBHortiConnection>(configuration.GetSection(nameof(MongoDBHortiConnection)));

            service.AddSingleton<IMongoDBHortiConnection>(x => x.GetRequiredService<IOptions<MongoDBHortiConnection>>().Value);

            ServicesApp(service);
            ServicesDomain(service);
            ServicesRepository(service);
            ServicesValidation(service);
        }

        private static void ServicesApp(IServiceCollection service)
        {
            service.AddScoped<IUserApp, UserApp>();
            service.AddScoped<IUserAccessApp, UserAccessApp>();
        }

        private static void ServicesDomain(IServiceCollection service)
        {
            service.AddScoped<DOMAIN.INTERFACE.SERVICE.IUserService, DOMAIN.SERVICE.UserService>();
            service.AddScoped<IUserAccessService, UserAccessService>();

            service.AddScoped<HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE.IUserSessionService, HORTIUSERCOMMAND.DOMAIN.SERVICE.UserSessionService>();
        }

        private static void ServicesRepository(IServiceCollection service)
        {
            service.AddScoped<DOMAIN.INTERFACE.REPOSITORY.IUserRepository, REPOSITORY.UserRepository>();

            service.AddScoped<IUserSessionRepository, HORTIUSERCOMMAND.REPOSITORY.UserSessionRepository>();
        }

        private static void ServicesValidation(IServiceCollection service)
        {
            service.AddScoped<UserSignatureValidation>();
            service.AddScoped<UserAccessQuerySignatureValidation>();
            service.AddScoped<UserLogoutQuerySignatureValidation>();
        }
    }
}
