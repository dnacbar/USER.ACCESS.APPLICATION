using HORTI.CORE.CROSSCUTTING.DOMAINOBJECT;
using System;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface ICreateUserCommandSignature
    {
        bool IsProducer { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
        string Phone { get; set; }

        public EmailObject EmailObject { get; }
        public PhoneObject PhoneObject { get; }
        public PasswordObject  PasswordObject { get;  }
    }

    public interface IDeleteUserCommandSignature
    {
        Guid Id { get; set; } 
        string Login { get; set; }
        string Password { get; set; }

        public EmailObject EmailObject { get; }
        public PasswordObject PasswordObject { get; }
    }

    public interface IUpdateUserCommandSignature
    {
        Guid Id { get; set; }
        bool IsProducer { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
        string Phone { get; set; }

        public EmailObject EmailObject { get; }
        public PhoneObject PhoneObject { get; }
        public PasswordObject PasswordObject { get; }
    }
}