using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.DOMAIN.INTERFACE.APP
{
    public interface IUserApp
    {
        Task<IEnumerable<IUserQueryResult>> GetListOfUser(IUserQuerySignature signature);
    }
}
