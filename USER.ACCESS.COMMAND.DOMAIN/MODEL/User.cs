using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.MODEL;
using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;

namespace USER.ACCESS.COMMAND.DOMAIN.MODEL
{
    public class User : IEntity
    {
        public User() { }

        public User(UserSignature signature)
        {
            IdSystem = signature.IdSystem;
            DsLogin = signature.Login;
            DsEmail = signature.Email;
            DsUser = signature.User;
            DsPhone = signature.Phone;
            BoActive = true;
        }

        public User(DeleteUserSignature signature)
        {
            IdSystem = signature.IdSystem;
            DsLogin = signature.Login;
            BoActive = signature.Active;
        }

        public Guid? IdSystem { get; set; }
        public string DsLogin { get; set; } = null!;
        public string DsEmail { get; set; } = null!;
        public string DsUser { get; set; } = null!;
        public string? DsPhone { get; set; }
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }

        public virtual UserSystem IdSystemNavigation { get; set; } = null!;
        public virtual Userkey Userkey { get; set; } = null!;

        public static User SelectUser(User user)
        {
            return new User
            {
                IdSystem = user.IdSystem,
                DsUser = user.DsUser,
                BoActive = user.BoActive,
                DsEmail = user.DsEmail,
                DsLogin = user.DsLogin,
                DsPhone = user.DsPhone,
                DtAtualization = user.DtAtualization,
                DtCreation = user.DtCreation
            };
        }
    }
}
