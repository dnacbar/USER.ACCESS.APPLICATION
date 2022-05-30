using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.REPOSITORY;
using USER.ACCESS.COMMAND.DOMAIN.MODEL;
using USER.ACCESS.COMMAND.REPOSITORY.CONTEXT;
using USER.ACCESS.COMMAND.REPOSITORY.CONTEXT.DBCONTEXTBASE;

namespace USER.ACCESS.COMMAND.REPOSITORY
{
    public sealed class UserKeyRepository : BaseEFCommandRepository<Userkey>, IUserKeyRepository
    {
        public UserKeyRepository(DBUSERCONTEXT DBCONTEXT) : base(DBCONTEXT) { }

        public Task CreateUserKey(Userkey userKey)
        {
            return CreateEntity(userKey);
        }

        public Task DeleteUserKey(Userkey userKey)
        {
            return DeleteEntity(userKey);
        }

        public Task UpdateUserKey(Userkey userKey)
        {
            return UpdateEntity(userKey);
        }
    }
}
