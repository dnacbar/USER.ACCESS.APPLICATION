using HORTI.USER.CROSSCUTTING.DBBASEMONGO;
using HORTI.USER.CROSSCUTTING.DBBASEMONGO.CONNECTION;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERCOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.REPOSITORY
{
    public sealed class SessionCommandRepository : _BaseMongoCommandRepository<UserSession>, ISessionCommandRepository
    {
        public SessionCommandRepository(IMongoDBHortiConnection connection) : base(connection) { }

        public Task<UserSession> CreateSessionAsync(UserSession userSession) => CreateDocument(userSession);

        public Task DeleteSessionAsync(UserSession userSession) => DeleteDocument(x => x.Id == userSession.Id && x.DsToken == userSession.DsToken && x.DsLogin == userSession.DsLogin);
    }
}
