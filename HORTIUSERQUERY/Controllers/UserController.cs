using HORTI.CORE.CROSSCUTTING.EXTENSION;
using HORTIUSERQUERY.DOMAIN.INTERFACE.APP;
using HORTIUSERQUERY.DOMAIN.MODEL.SIGNATURE;
using HORTIUSERQUERY.DOMAIN.VALIDATION;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserQueryApp _userQueryApp;
        private readonly UserQuerySignatureValidation _userQuerySignatureValidation;

        public UserController(IUserQueryApp userQueryApp,
                              UserQuerySignatureValidation userQuerySignatureValidation)
        {
            _userQueryApp = userQueryApp;
            _userQuerySignatureValidation = userQuerySignatureValidation;
        }

        [HttpPost(nameof(GetListOfUser))]
        [Authorize]
        public async Task<IActionResult> GetListOfUser([FromBody] UserQuerySignature signature)
        {
            _userQuerySignatureValidation.ValidateHorti(signature);
         
            var result = await _userQueryApp.GetListOfUser(signature);
            return Ok(result);
        }
    }
}
