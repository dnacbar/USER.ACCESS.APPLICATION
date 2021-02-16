using HORTISESSIONCOMMANDREPOSITORY.MONGODBCONNECTION;
using HORTIUSERCOMMAND.DOMAIN.DOMAIN;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.REPOSITORY
{
    public sealed class SessionRepository : ISessionRepository
    {
        private readonly IMongoCollection<UserSession> _userSession;
        public SessionRepository(IMongoDBHortiConnection hortiConnection)
        {
            try
            {
                var client = new MongoClient(hortiConnection.ConnectionString);
                var database = client.GetDatabase(hortiConnection.DatabaseName);

                _userSession = database.GetCollection<UserSession>(hortiConnection.SessionCollectionName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateSessionAsync(UserSession userSession) => await _userSession.InsertOneAsync(userSession);
        public async Task<UserSession> GetSessionAsync() => (await _userSession.FindAsync(x => x.IdUser == "3fa85f64-5717-4562-b3fc-2c963f66afa6")).FirstOrDefault();
    }
}
