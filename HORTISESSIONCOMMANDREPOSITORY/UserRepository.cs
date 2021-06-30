using HORTI.CORE.CROSSCUTTING.DBBASEEF;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERCOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.REPOSITORY
{
    public sealed class UserRepository : _BaseEFCommandRepository<User>, IUserRepository
    {
        public UserRepository(DBHORTIUSERCONTEXT DBHORTIUSERCONTEXT) : base(DBHORTIUSERCONTEXT) { }

        public Task CreateUser(User user)
        {
            return CreateEntity(user);
        }

        public Task InactiveUser(User user)
        {
            return DeleteEntity(user, true);
        }

        public Task UpdateUser(User user)
        {
            return UpdateEntity(user);
        }
    }
}
