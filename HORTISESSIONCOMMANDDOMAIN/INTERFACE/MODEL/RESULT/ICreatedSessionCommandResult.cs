using HORTIUSERCOMMAND.DOMAIN.MODEL;
using System;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.RESULT
{
    public interface ICreatedSessionCommandResult
    {
        string IdSession { get; set; }
        bool SessionExpire { get; set; }
        DateTime SessionLimit { get; set; }
        string Login { get; set; }
    }
}
