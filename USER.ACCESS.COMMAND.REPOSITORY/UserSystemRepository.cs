using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.REPOSITORY;
using USER.ACCESS.COMMAND.DOMAIN.MODEL;
using USER.ACCESS.COMMAND.REPOSITORY.CONTEXT;
using USER.ACCESS.COMMAND.REPOSITORY.CONTEXT.DBCONTEXTBASE;

namespace USER.ACCESS.COMMAND.REPOSITORY
{
    public sealed class UserSystemRepository : BaseEFCommandRepository<UserSystem>, IUserSystemRepository
    {
        public UserSystemRepository(DBUSERCONTEXT DBCONTEXT) : base(DBCONTEXT) { }

        public Task CreateSystem(UserSystem userSystem)
        {
            return CreateEntity(userSystem);
        }

        public Task DeleteSystem(UserSystem userSystem)
        {
            return DeleteEntity(userSystem);
        }

        public Task UpdateSystem(UserSystem userSystem)
        {
            return UpdateEntity(userSystem);
        }
    }
}
