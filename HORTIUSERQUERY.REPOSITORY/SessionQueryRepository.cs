using HORTI.USER.CROSSCUTTING.DBBASEMONGO;
using HORTI.USER.CROSSCUTTING.DBBASEMONGO.CONNECTION;
using HORTIUSERCOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.REPOSITORY
{
    public sealed class SessionQueryRepository : _BaseMongoQueryRepository<UserSession>
    {
        public SessionQueryRepository(IMongoDBHortiConnection connection) : base(connection) { }

        public Task<UserSession> UserSessionByFilter(UserSession userSession)
        {
            return DocumentByFilter(x => x.Id == userSession.Id && x.DsToken == userSession.DsToken && x.DsLogin == userSession.DsLogin);
        }
    }
}
