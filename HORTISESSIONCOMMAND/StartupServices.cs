using HORTI.USER.CROSSCUTTING.DBBASEMONGO.CONNECTION;
using HORTICORE.PROXY;
using HORTICORE.PROXY.INTERFACE;
using HORTIUSERCOMMAND.APP;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.APP;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTIUSERCOMMAND.DOMAIN.SERVICE;
using HORTIUSERCOMMAND.DOMAIN.VALIDATION;
using HORTIUSERCOMMAND.REPOSITORY;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HORTIUSERCOMMAND
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
            ServicesProxy(service);
        }

        private static void ServicesApp(IServiceCollection service)
        {
            service.AddScoped<IUserCommandApp, UserCommandApp>();
        }

        private static void ServicesDomain(IServiceCollection service)
        {
            service.AddScoped<IUserCommandService, UserCommandService>();
        }

        private static void ServicesRepository(IServiceCollection service)
        {
            service.AddScoped<ISessionCommandRepository, SessionCommandRepository>();
            service.AddScoped<IUserCommandRepository, UserCommandRepository>();
        }

        private static void ServicesValidation(IServiceCollection service)
        {
            service.AddScoped<CreateUserCommandValidation>();
            service.AddScoped<DeleteUserCommandValidation>();
            service.AddScoped<UpdateUserCommandValidation>();
        }

        private static void ServicesProxy(IServiceCollection service)
        {
            service.AddScoped<IHortiCoreProxy, HortiCoreProxy>();
        }
    }
}
