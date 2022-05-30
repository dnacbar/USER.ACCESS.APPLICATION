using Microsoft.EntityFrameworkCore;
using MIDDLEWARE.LOG.APPLICATION.MODEL.EXCEPTION;
using System.Linq.Expressions;

namespace USER.ACCESS.COMMAND.REPOSITORY.CONTEXT.DBCONTEXTBASE
{
    public abstract class _BaseEFQueryRepository<T> where T : class
    {
        protected readonly DbContext _DBCONTEXT;
        protected _BaseEFQueryRepository(DbContext DBCONTEXT)
        {
            _DBCONTEXT = DBCONTEXT;
        }

        protected Task<T> EntityByFilter(Expression<Func<T, T>> Select, Expression<Func<T, bool>> Where)
        {
            try
            {
                return _DBCONTEXT.Set<T>().Where(Where).Select(Select).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateException)
                    throw new DataBaseException(ex.Message, ex);

                throw new Exception(ex.Message);
            }
        }

        protected Task<List<T>> FullListOfEntity<TResult>(Expression<Func<T, T>> Select, Expression<Func<T, TResult>> OrderBy)
        {
            try
            {
                return _DBCONTEXT.Set<T>().OrderBy(OrderBy).Select(Select).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateException)
                    throw new DataBaseException(ex.Message, ex);

                throw new Exception(ex.Message);
            }
        }

        protected Task<List<T>> ListOfEntity<TResult>(Expression<Func<T, T>> Select, Expression<Func<T, bool>> Where, int Page, int Pagesize, Expression<Func<T, TResult>> OrderBy)
        {
            try
            {
                return _DBCONTEXT.Set<T>().Where(Where).OrderBy(OrderBy).Skip(Page * Pagesize).Take(Pagesize).Select(Select).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateException)
                    throw new DataBaseException(ex.Message, ex);

                throw new Exception(ex.Message);
            }
        }
    }
}