using HORTIUSERCOMMAND.DOMAIN.MODEL;
using HORTIUSERQUERY.DOMAIN.INTERFACE.SERVICE;
using System;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.DOMAIN.SERVICE
{
    public sealed class UserSessionService : IUserSessionService
    {
        public Task<bool> GetUserSession(UserSession userSession)
        {
            throw new NotImplementedException();
        }
    }
}
