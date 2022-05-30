using Microsoft.EntityFrameworkCore;
using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE.QUERY;
using USER.ACCESS.COMMAND.DOMAIN.MODEL;
using USER.ACCESS.COMMAND.REPOSITORY.CONTEXT;
using USER.ACCESS.COMMAND.REPOSITORY.CONTEXT.DBCONTEXTBASE;
using USER.ACCESSQUERY.REPOSITORY.USER.INTERFACE;

namespace USER.ACCESSQUERY.REPOSITORY.USER
{
    public sealed class UserRepository : _BaseEFQueryRepository<User>, IUserRepository
    {
        public UserRepository(DBUSERCONTEXT DBCONTEXT) : base(DBCONTEXT) { }

        public Task<User> GetActiveUserByFilter(UserQuerySignature signature)
        {
            return EntityByFilter(Select: x => User.SelectUser(x),
                                  Where: x => x.IdSystem == signature.IdSystem
                                           && x.BoActive == true
                                           && x.DsLogin == signature.DsLogin);
        }

        public Task<List<User>> GetListOfActiveUser(UserQuerySignature signature)
        {
            return ListOfEntity(Select: x => User.SelectUser(x),
                                Where: x => x.IdSystem == signature.IdSystem
                                         && x.BoActive == true,
                                signature.PageNumber, signature.PageSize,
                                OrderBy: x => x.DsUser);
        }

        

        public Task<bool> VerifyActiveUserExists(User user)
        {
            return _DBCONTEXT.Set<User>().AnyAsync(x => x.IdSystem == x.IdSystem
                                                     && x.DsLogin == user.DsLogin
                                                     && x.BoActive == true);
        }
    }
}