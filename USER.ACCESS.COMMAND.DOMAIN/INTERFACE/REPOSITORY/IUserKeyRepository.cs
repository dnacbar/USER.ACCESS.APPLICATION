using USER.ACCESS.COMMAND.DOMAIN.MODEL;

namespace USER.ACCESS.COMMAND.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IUserKeyRepository
    {
        Task CreateUserKey(Userkey userKey);
        Task DeleteUserKey(Userkey userKey);
        Task UpdateUserKey(Userkey userKey);
    }
}
