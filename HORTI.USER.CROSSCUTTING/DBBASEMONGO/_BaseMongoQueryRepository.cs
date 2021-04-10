using HORTI.USER.CROSSCUTTING.DBBASEMONGO.CONNECTION;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HORTI.USER.CROSSCUTTING.DBBASEMONGO
{
    public abstract class _BaseMongoQueryRepository<T> : _BaseMongoRepository<T> where T : class
    {
        public _BaseMongoQueryRepository(IMongoDBHortiConnection connection) : base(connection) { }

        public Task<T> DocumentByFilter(Expression<Func<T, bool>> filter) => _mongoCollection.Find(filter).FirstOrDefaultAsync();

        public Task<List<T>> ListOfDocument() => _mongoCollection.Find(x => true).ToListAsync();
    }
}
