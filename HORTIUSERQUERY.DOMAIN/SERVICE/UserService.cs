using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIUSERQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERQUERY.DOMAIN.INTERFACE.SERVICE;
using HORTIUSERQUERY.DOMAIN.MODEL.EXTENSION;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.DOMAIN.SERVICE
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _userQueryRepository;
        public UserService(IUserRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }

        public async Task<IEnumerable<IUserQueryResult>> CreateListOfUserResult(IUserQuerySignature signature)
        {
            return (await _userQueryRepository.ListOfUser(signature.ToUser())).ToListOfUserResult();
        }
    }
}