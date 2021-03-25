using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Net;
using System.Text.Json.Serialization;

namespace HORTIUSERCOMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class SessionCommandSignature : ISessionCommandSignature
    {
        public string Login { get; set; }
        public bool SessionExpire { get; set; }
        [JsonIgnore]
        public string IpAddress { get; set; }
    }
}