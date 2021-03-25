using HORTI.CORE.CROSSCUTTING.DOMAINOBJECT;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;
using System.Text.Json.Serialization;

namespace HORTIUSERCOMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class CreateUserCommandSignature : ICreateUserCommandSignature
    {
        public bool IsProducer { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        [JsonIgnore]
        public EmailObject EmailObject => new EmailObject(Login);
        [JsonIgnore]
        public PhoneObject PhoneObject => new PhoneObject(Phone);
        [JsonIgnore]
        public PasswordObject PasswordObject => new PasswordObject(Password);
    }

    public sealed class DeleteUserCommandSignature : IDeleteUserCommandSignature
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public EmailObject EmailObject => new EmailObject(Login);
        [JsonIgnore]
        public PasswordObject PasswordObject => new PasswordObject(Password);
    }

    public sealed class UpdateUserCommandSignature : IUpdateUserCommandSignature
    {
        public Guid Id { get; set; }
        public bool IsProducer { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        [JsonIgnore]
        public EmailObject EmailObject => new EmailObject(Login);
        [JsonIgnore]
        public PhoneObject PhoneObject => new PhoneObject(Phone);
        [JsonIgnore]
        public PasswordObject PasswordObject => new PasswordObject(Password);
    }
}
