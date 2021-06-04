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
        private readonly UserLogoutQuerySignatureValidation _userLogoutQuerySignatureValidation;

        public UserAccessController(IUserAccessQueryApp userAccessQueryApp,
                                    UserAccessQuerySignatureValidation userAccessQuerySignatureValidation,
                                    UserLogoutQuerySignatureValidation userLogoutQuerySignatureValidation)
        {
            _userAccessQueryApp = userAccessQueryApp;
            _userAccessQuerySignatureValidation = userAccessQuerySignatureValidation;
            _userLogoutQuerySignatureValidation = userLogoutQuerySignatureValidation;
        }

        [HttpPost(nameof(AuthenticateUserAccess))]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateUserAccess([FromBody] UserAccessQuerySignature signature)
        {
            _userAccessQuerySignatureValidation.ValidateHorti(signature);
            signature.IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            var result = await _userAccessQueryApp.AuthenticateUserAccess(signature);
            return Ok(result);
        }

        [HttpPost(nameof(LogoutUserAccess))]
        [Authorize]
        public async Task<IActionResult> LogoutUserAccess([FromBody] UserLogoutQuerySignature signature)
        {
            _userLogoutQuerySignatureValidation.ValidateHorti(signature);

            await _userAccessQueryApp.LogoutUserAccess(signature);
            return NoContent();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
