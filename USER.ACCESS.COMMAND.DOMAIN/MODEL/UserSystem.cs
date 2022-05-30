using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;

namespace USER.ACCESS.COMMAND.DOMAIN.MODEL
{
    public class UserSystem
    {
        public UserSystem()
        {
            Users = new HashSet<User>();
        }

        public UserSystem(UserSystemSignature signature)
        {
            Users = new HashSet<User>();

            IdSystem = signature.IdSystem;
            DsSystem = signature.System;
            DsDescription = signature.Description;
        }

        public UserSystem(DeleteUserSystemSignature signature)
        {
            Users = new HashSet<User>();

            IdSystem = signature.IdSystem;
        }

        public Guid IdSystem { get; set; }
        public string DsSystem { get; set; } = null!;
        public string DsDescription { get; set; } = null!;
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
