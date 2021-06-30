using HORTIUSERQUERY.DOMAIN.INTERFACE.APP;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIUSERQUERY.DOMAIN.INTERFACE.SERVICE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.APP
{
    public sealed class UserApp : IUserApp
    {
        private readonly IUserService _userQueryService;
        public UserApp(IUserService userQueryService)
        {
            _userQueryService = userQueryService;
        }

        public Task<IEnumerable<IUserQueryResult>> GetListOfUser(IUserQuerySignature signature)
        {
            return _userQueryService.CreateListOfUserResult(signature);
        }
    }
}