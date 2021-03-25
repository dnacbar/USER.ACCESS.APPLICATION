using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HORTIUSERCOMMAND.DOMAIN.MODEL
{
    public sealed class User : _BaseQuantityModel
    {
        public User() { }

        public User(ICreateUserCommandSignature signature)
        {
            DsLogin = signature.Login;
            DsPassword = signature.Password;
            BoActive = true;
            DtAtualization = DateTime.Now;
        }

        public User(IDeleteUserCommandSignature signature)
        {
            IdUser = signature.Id;
            DsLogin = signature.Login;
            DsPassword = signature.Password;
            BoActive = false;
            DtAtualization = DateTime.Now;
        }

        public User(IUpdateUserCommandSignature signature)
        {
            IdUser = signature.Id;
            DsLogin = signature.Login;
            DsPassword = signature.Password;
            DsPhone = signature.Phone;
            BoActive = true;
            DtAtualization = DateTime.Now;
        }

        [NotMapped]
        public Guid IdUser { get; set; }
        public string DsLogin { get; set; }
        public string DsPassword { get; set; }
        public bool BoActive { get; set; }
        [NotMapped]
        public string DsPhone { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }
    }
}
