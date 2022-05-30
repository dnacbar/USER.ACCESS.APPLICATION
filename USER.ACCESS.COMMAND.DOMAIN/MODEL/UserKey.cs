using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.MODEL;
using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;

namespace USER.ACCESS.COMMAND.DOMAIN.MODEL
{
    public partial class Userkey : IEntity
    {
        public Userkey()
        {
            IdUserkeytypes = new HashSet<Userkeytype>();
        }

        public Userkey(UserKeySignature signature)
        {
            IdUserkeytypes = new HashSet<Userkeytype>();

            IdSystem = signature.IdSystem;
            DsLogin = signature.Login;
            DsKey = signature.Key;
        }

        public Userkey(DeleteUserKeySignature signature)
        {
            IdUserkeytypes = new HashSet<Userkeytype>();

            IdSystem = signature.IdSystem;
            DsLogin = signature.Login;
        }

        public Guid IdSystem { get; set; }
        public string DsLogin { get; set; } = null!;
        public string DsKey { get; set; } = null!;
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Userkeytype> IdUserkeytypes { get; set; }
    }
}
