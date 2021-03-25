using HORTIUSERCOMMAND.DOMAIN.MODEL;
using HORTIUSERQUERY.DOMAIN.MODEL.RESULT;
using System;
using System.Collections.Generic;

namespace HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.RESULT
{
    public interface IUserQueryResult
    {
        Guid Id { get; }
        string Login { get; }
        string Phone { get; }
        bool IsActive { get; }
    }
}
