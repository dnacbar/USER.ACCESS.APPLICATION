using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.DOMAIN.INTERFACE.SERVICE
{
    public interface IUserQueryService
    {
        Task<IEnumerable<IUserQueryResult>> CreateListOfUserResult(IUserQuerySignature signature);
    }
}
