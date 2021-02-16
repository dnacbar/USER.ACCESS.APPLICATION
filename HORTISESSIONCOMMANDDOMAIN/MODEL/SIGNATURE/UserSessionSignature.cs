using HORTIUSERCOMMAND.DOMAIN.INTERFACE.SIGNATURE;
using System;
using System.Net;
using System.Text.Json.Serialization;

namespace HORTIUSERCOMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class UserSessionSignature : IUserSessionSignature
    {
        public Guid IdUser { get; set; }
        public bool SessionExpire { get; set; }
        [JsonIgnore]
        public DateTime SessionLimit { get; private set; }
        [JsonIgnore]
        public IPAddress IPAddress { get; private set; }

        public void CreateSession(IPAddress iPAddress)
        {
            IPAddress = iPAddress;
            if (SessionExpire)
                SessionLimit = DateTime.Now.AddMinutes(10);
        }

    }
}