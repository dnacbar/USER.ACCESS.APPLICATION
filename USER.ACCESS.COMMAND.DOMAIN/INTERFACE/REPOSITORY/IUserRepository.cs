using USER.ACCESS.COMMAND.DOMAIN.MODEL;

namespace USER.ACCESS.COMMAND.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task DeleteUser(User user);
        Task UpdateUser(User user);
        Task UpdateUserOnlyFilledField(User user);
    }
}
