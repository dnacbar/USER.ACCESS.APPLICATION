using HORTIUSERCOMMAND.DOMAIN.MODEL;
using HORTIUSERQUERY.DOMAIN.INTERFACE.SERVICE;
using System;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.DOMAIN.SERVICE
{
    public sealed class SessionQueryService : ISessionQueryService
    {
        public Task<bool> GetUserSession(UserSession userSession)
        {
            throw new NotImplementedException();
        }
    }
}
