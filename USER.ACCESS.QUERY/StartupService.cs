using USER.ACCESSQUERY.REPOSITORY.USER;
using USER.ACCESSQUERY.REPOSITORY.USER.INTERFACE;

namespace USER.ACCESSQUERY
{
    public static class StartupService
    {
        public static void Service(IServiceCollection services)
        {
            ServiceRepository(services);
        }

        private static void ServiceRepository(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
