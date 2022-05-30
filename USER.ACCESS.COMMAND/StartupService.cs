using USER.ACCESS.COMMAND.APP;
using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.APP;
using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.REPOSITORY;
using USER.ACCESS.COMMAND.REPOSITORY;
using USER.ACCESS.COMMAND.VALIDATION;

namespace USER.ACCESS.COMMAND
{
    public static class StartupService
    {
        public static void Service(IServiceCollection services)
        {
            ServiceApp(services);
            //ServiceDomain(services);
            ServiceRepository(services);
            ServiceValidation(services);

            ServiceRepositoryQuery(services);
        }

        private static void ServiceApp(IServiceCollection services)
        {
            services.AddScoped<IUserApp, UserApp>();
            services.AddScoped<IUserKeyApp, UserKeyApp>();
        }

        private static void ServiceDomain(IServiceCollection services)
        {
            
        }

        private static void ServiceRepository(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserKeyRepository, UserKeyRepository>();
        }

        private static void ServiceValidation(IServiceCollection services)
        {
            services.AddScoped<CreateUserValidation>();
            services.AddScoped<DeleteUserValidation>();
            services.AddScoped<UpdateUserValidation>();
            services.AddScoped<UpdateFilledFieldUserValidation>();
        }

        private static void ServiceRepositoryQuery(IServiceCollection services)
        {
            services.AddScoped<ACCESSQUERY.REPOSITORY.USER.INTERFACE.IUserRepository, ACCESSQUERY.REPOSITORY.USER.UserRepository>();
        }
    }
}
