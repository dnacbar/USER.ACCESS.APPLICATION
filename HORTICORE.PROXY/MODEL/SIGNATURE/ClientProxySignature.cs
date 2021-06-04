using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE.HORTICORE.PROXY;
using System;

namespace HORTICORE.PROXY.MODEL.SIGNATURE
{
    public sealed class ClientProxySignature : IClientProxySignature
    {
        public ClientProxySignature(ICreateUserCommandSignature signature)
        {
            Email = signature.Login;
            Client = signature.UserName;
            Phone = signature.Phone;
        }

        public string Email { get; set; }
        public string Client { get; set; }
        public string Phone { get; set; }
    }
}
