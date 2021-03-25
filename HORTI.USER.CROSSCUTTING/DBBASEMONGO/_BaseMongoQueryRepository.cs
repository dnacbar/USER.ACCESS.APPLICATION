using HORTI.USER.CROSSCUTTING.DBBASEMONGO.CONNECTION;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace HORTI.USER.CROSSCUTTING.DBBASEMONGO
{
    public abstract class _BaseMongoQueryRepository<T> : _BaseMongoRepository<T> where T : class
    {
        public _BaseMongoQueryRepository(IMongoDBHortiConnection connection) : base(connection) { }

        public Task<IAsyncCursor<T>> DocumentByFilter(FilterDefinition<T> filter) => _mongoCollection.FindAsync(filter);

        public Task<IAsyncCursor<T>> ListOfDocument() => _mongoCollection.FindAsync(x => true);
    }
}
