using System.Text.Json.Serialization;
using VALUEOBJECT.APPLICATION;

namespace USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class UserSignature
    {
        public Guid IdSystem { get; set; }
        public string Login { get; set; } = null!;
        public string? Email { get; set; }
        public string? User { get; set; }
        public string? Phone { get; set; }

        [JsonIgnore]
        public bool LoginMustBeTheEmail { get; set; }

        [JsonIgnore]
        public PhoneObject PhoneObject => new PhoneObject(Phone);
        [JsonIgnore]
        public EmailObject EmailObject => new EmailObject(Email);
    }
}
