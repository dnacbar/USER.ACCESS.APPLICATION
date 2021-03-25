using HORTI.USER.CROSSCUTTING.DBBASEMONGO.CONNECTION;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HORTI.USER.CROSSCUTTING.DBBASEMONGO
{
    public abstract class _BaseMongoCommandRepository<T> : _BaseMongoRepository<T> where T : class
    {

        public _BaseMongoCommandRepository(IMongoDBHortiConnection connection) : base(connection) { }

        protected async Task<T> CreateDocument(T document)
        {
            await _mongoCollection.InsertOneAsync(document);
            return document;
        }

        protected Task UpdateDocument(T document, Expression<Func<T, bool>> filter) => _mongoCollection.ReplaceOneAsync(filter, document);

        protected Task DeleteDocument(Expression<Func<T, bool>> filter) => _mongoCollection.DeleteOneAsync(filter);
    }
}
