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
    public class UserAccessController : ControllerBase
    {
        private readonly IUserAccessQueryApp _userAccessQueryApp;
        private readonly UserAccessQuerySignatureValidation _userAccessQuerySignatureValidation;
        
        public UserAccessController(IUserAccessQueryApp userAccessQueryApp,
                                    UserAccessQuerySignatureValidation userAccessQuerySignatureValidation)
        {
            _userAccessQueryApp = userAccessQueryApp;
            _userAccessQuerySignatureValidation = userAccessQuerySignatureValidation;
        }

        [HttpPost(nameof(AuthenticateUserAcess))]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateUserAcess([FromBody] UserAccessQuerySignature signature)
        {
            _userAccessQuerySignatureValidation.ValidateHorti(signature);
            signature.IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            var result = await _userAccessQueryApp.AuthenticateUserAccess(signature);
            return Ok(result);
        }

        [HttpPost(nameof(LogoutUserAcess))]
        [Authorize]
        public async Task<IActionResult> LogoutUserAcess([FromBody] UserAccessQuerySignature signature)
        {
            //_userAccessQuerySignatureValidation.ValidateHorti(signature);

            //var result = await _userAccessQueryApp.AuthenticateUserAccess(signature, HttpContext);
            return Ok();
        }
    }
}
