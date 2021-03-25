using HORTI.USER.CROSSCUTTING.DBBASEMONGO.CONNECTION;
using MongoDB.Driver;
using System;

namespace HORTI.USER.CROSSCUTTING.DBBASEMONGO
{
    public abstract class _BaseMongoRepository<T> where T : class
    {
        protected readonly IMongoCollection<T> _mongoCollection;

        public _BaseMongoRepository(IMongoDBHortiConnection connection)
        {
            try
            {
                var mongoClient = new MongoClient(connection.ConnectionString);
                var mongoDatabase = mongoClient.GetDatabase(connection.DatabaseName);

                _mongoCollection = mongoDatabase.GetCollection<T>(connection.SessionCollectionName);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
