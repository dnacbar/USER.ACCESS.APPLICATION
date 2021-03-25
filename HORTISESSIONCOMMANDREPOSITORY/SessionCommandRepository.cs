using HORTI.USER.CROSSCUTTING.DBBASEMONGO;
using HORTI.USER.CROSSCUTTING.DBBASEMONGO.CONNECTION;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERCOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.REPOSITORY
{
    public sealed class SessionCommandRepository : _BaseMongoCommandRepository<UserSession>, ISessionCommandRepository
    {
        public SessionCommandRepository(IMongoDBHortiConnection hortiConnection) : base(hortiConnection) { }

        public Task<UserSession> CreateSessionAsync(UserSession userSession) => CreateDocument(userSession);

        public Task DeleteSessionAsync(string idSession) => DeleteDocument(x => x.Id == idSession);
    }
}
