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
        private readonly IUserApp _userQueryApp;
        private readonly UserSignatureValidation _userQuerySignatureValidation;

        public UserController(IUserApp userQueryApp,
                              UserSignatureValidation userQuerySignatureValidation)
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
