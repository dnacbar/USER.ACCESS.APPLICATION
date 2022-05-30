using Microsoft.EntityFrameworkCore;
using MIDDLEWARE.LOG.APPLICATION.MODEL.EXCEPTION;
using System.Text.Json;

namespace USER.ACCESS.COMMAND.REPOSITORY.CONTEXT.DBCONTEXTBASE
{
    public abstract class BaseEFCommandRepository<T> where T : class
    {
        protected readonly DbContext _DBCONTEXT;

        protected BaseEFCommandRepository(DbContext DBCONTEXT)
        {
            _DBCONTEXT = DBCONTEXT;
        }

        protected Task CreateEntity(T TEntity)
        {
            try
            {
                _DBCONTEXT.Set<T>().Add(TEntity);

                return _DBCONTEXT.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var varT = JsonSerializer.Serialize(TEntity);

                if (ex is DbUpdateException)
                    throw new DataBaseException(varT + " " + ex.Message, ex);

                throw new Exception(varT + " " + ex.Message);
            }
        }

        /// <summary>
        /// Delete entity from database.
        /// </summary>
        /// <param name="TEntity">Entity to delete</param>
        /// <param name="bolLogicExclusion">Send false for delete from database or true for logic exclusion.</param>
        /// <returns></returns>
        /// <exception cref="DbUpdateException"></exception>
        /// <exception cref="Exception"></exception>
        protected Task DeleteEntity(T TEntity, bool bolLogicExclusion = true)
        {
            try
            {
                if (bolLogicExclusion)
                {
                    _DBCONTEXT.Entry(TEntity).Property("BoActive").IsModified = true;
                }
                else
                    _DBCONTEXT.Set<T>().Remove(TEntity);

                return _DBCONTEXT.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var varT = JsonSerializer.Serialize(TEntity);

                if (ex is DbUpdateException)
                    throw new DbUpdateException(varT + " " + ex.Message, ex);

                throw new Exception(varT + " " + ex.Message);
            }
        }

        protected Task UpdateEntity(T TEntity)
        {
            try
            {
                var entityEntry = _DBCONTEXT.Set<T>().Update(TEntity);

                entityEntry.Property("DtCreation").IsModified = false;
                entityEntry.Property("BoActive").IsModified = false;
                entityEntry.Property("DtAtualization").CurrentValue = DateTime.Now;

                return _DBCONTEXT.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var varT = JsonSerializer.Serialize(TEntity);

                if (ex is DbUpdateException)
                    throw new DbUpdateException(varT + " " + ex.Message, ex);

                throw new Exception(varT + " " + ex.Message);
            }
        }
    }
}
