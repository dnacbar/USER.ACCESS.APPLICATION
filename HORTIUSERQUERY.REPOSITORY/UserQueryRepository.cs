using HORTI.CORE.CROSSCUTTING.DBBASEEF;
using HORTI.CORE.CROSSCUTTING.ENCRYPTING;
using HORTIUSERCOMMAND.DOMAIN.MODEL;
using HORTIUSERCOMMAND.REPOSITORY;
using HORTIUSERQUERY.DOMAIN.INTERFACE.REPOSITORY;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.REPOSITORY
{
    public sealed class UserQueryRepository : _BaseEFQueryRepository<User>, IUserQueryRepository
    {
        public UserQueryRepository(DBHORTIUSERCONTEXT DBHORTIUSERCONTEXT) : base(DBHORTIUSERCONTEXT) { }

        public Task<List<User>> ListOfUser(User user)
        {
            return ListOfEntity(Select: x => new User
            {
                DsLogin = x.DsLogin,
                BoActive = x.BoActive
            },
            Where: p => p.BoActive == user.BoActive,
            Page: user.Page,
            Quantity: user.Quantity,
            OrderBy: o => o.DsLogin);
        }

        public Task<bool> VerifyUserExists(User user)
        {
            var result = _DBCONTEXT.Set<User>()
                                   .Where(x => x.BoActive == true
                                            && x.DsLogin == user.DsLogin)
                                   .Select(x => user.DsPassword.ToDecryptPasswordText(x.DsPassword))
                                   .FirstOrDefaultAsync();

             return result;
        }
    }
}
