using USER.ACCESS.COMMAND.DOMAIN.MODEL;

namespace USER.ACCESS.COMMAND.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IUserSystemRepository
    {
        Task CreateSystem(UserSystem userSystem);
        Task DeleteSystem(UserSystem userSystem);
        Task UpdateSystem(UserSystem userSystem);
    }
}
