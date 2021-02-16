using System;
using System.Net;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.SIGNATURE
{
    public interface IUserSessionSignature
    {
        Guid IdUser { get; set; }
        bool SessionExpire { get; set; }
        DateTime SessionLimit { get; }
        IPAddress IPAddress { get; }

    }
}
