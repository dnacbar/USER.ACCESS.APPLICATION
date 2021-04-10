﻿using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.DOMAIN.INTERFACE.APP
{
    public interface IUserAccessQueryApp
    {
        Task<IUserAccessQueryResult> AuthenticateUserAccess(IUserAccessQuerySignature signature);
        Task LogoutUserAccess(IUserLogoutQuerySignature signature);
    }
}
