using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.REPOSITORY;
using USER.ACCESS.COMMAND.DOMAIN.MODEL;
using USER.ACCESS.COMMAND.REPOSITORY.CONTEXT;
using USER.ACCESS.COMMAND.REPOSITORY.CONTEXT.DBCONTEXTBASE;

namespace USER.ACCESS.COMMAND.REPOSITORY
{
    public sealed class UserRepository : BaseEFCommandRepository<User>, IUserRepository
    {
        public UserRepository(DBUSERCONTEXT DBCONTEXT) : base(DBCONTEXT) { }

        public Task CreateUser(User user)
        {
            return CreateEntity(user);
        }

        public Task DeleteUser(User user)
        {
            return DeleteEntity(user);
        }

        public Task UpdateUser(User user)
        {
            return UpdateEntity(user);
        }

        public Task UpdateUserOnlyFilledField(User user)
        {
            try
            {
                var entityEntry = _DBCONTEXT.Set<User>().Update(user);

                entityEntry.Property(e => e.DtAtualization).CurrentValue = DateTime.Now;

                entityEntry.Property(e => e.DtCreation).IsModified = false;
                entityEntry.Property(e => e.BoActive).IsModified = false;
  
                if (string.IsNullOrEmpty(user.DsEmail))
                    entityEntry.Property(e => e.DsEmail).IsModified = false;

                if (string.IsNullOrEmpty(user.DsUser))
                    entityEntry.Property(e => e.DsUser).IsModified = false;

                if (string.IsNullOrEmpty(user.DsPhone))
                    entityEntry.Property(e => e.DsPhone).IsModified = false;

                return _DBCONTEXT.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var varT = JsonSerializer.Serialize(user);

                if (ex is DbUpdateException)
                    throw new DbUpdateException(varT + " " + ex.Message, ex);

                throw new Exception(varT + " " + ex.Message);
            }
        }
    }
}
