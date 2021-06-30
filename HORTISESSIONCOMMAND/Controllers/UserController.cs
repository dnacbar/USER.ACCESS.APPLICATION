using HORTI.CORE.CROSSCUTTING.EXTENSION;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.APP;
using HORTIUSERCOMMAND.DOMAIN.MODEL.SIGNATURE;
using HORTIUSERCOMMAND.DOMAIN.VALIDATION;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApp _userCommandApp;
        private readonly CreateUserCommandValidation _createUserValidation;
        private readonly DeleteUserCommandValidation _deleteUserValidation;
        private readonly UpdateUserCommandValidation _updateUserValidation;

        public UserController(IUserApp userCommandApp,
                              CreateUserCommandValidation createUserValidation,
                              DeleteUserCommandValidation deleteUserValidation,
                              UpdateUserCommandValidation updateUserValidation)
        {
            _userCommandApp = userCommandApp;
            _createUserValidation = createUserValidation;
            _deleteUserValidation = deleteUserValidation;
            _updateUserValidation = updateUserValidation;
        }

        [HttpPost(nameof(CreateUser))]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandSignature signature)
        {
            _createUserValidation.ValidateHorti(signature);

            await _userCommandApp.CreateUser(signature);
            return Created(string.Empty, null);
        }

        [HttpDelete(nameof(InactiveUser))]
        [Authorize]
        public async Task<IActionResult> InactiveUser([FromBody] DeleteUserCommandSignature signature)
        {
            _deleteUserValidation.ValidateHorti(signature);

            await _userCommandApp.InactiveUser(signature);
            return NoContent();
        }

        [HttpPut(nameof(UpdateUser))]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandSignature signature)
        {
            _updateUserValidation.ValidateHorti(signature);

            await _userCommandApp.UpdateUser(signature);
            return Ok();
        }
    }
}
