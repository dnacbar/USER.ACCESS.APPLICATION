using Microsoft.AspNetCore.Mvc;
using USER.ACCESS.CROSSCUTTING.VALIDATION.EXTENSION;
using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.APP;
using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;
using USER.ACCESS.COMMAND.VALIDATION;

namespace USER.ACCESS.COMMAND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UserController : ControllerBase
    {
        private readonly IUserApp _userApp;

        private readonly CreateUserValidation _createUserValidation;
        private readonly DeleteUserValidation _deleteUserValidation;
        private readonly UpdateUserValidation _updateUserValidation;
        private readonly UpdateFilledFieldUserValidation _updateFilledFieldUserValidation;

        public UserController(IUserApp createUserApp,
                              CreateUserValidation createUserValidation,
                              DeleteUserValidation deleteUserValidation,
                              UpdateUserValidation updateUserValidation,
                              UpdateFilledFieldUserValidation updateFilledFieldUserValidation)
        {
            _userApp = createUserApp;

            _createUserValidation = createUserValidation;
            _deleteUserValidation = deleteUserValidation;
            _updateUserValidation = updateUserValidation;
            _updateFilledFieldUserValidation = updateFilledFieldUserValidation;
        }

        [HttpPost(nameof(CreateUserAsync))]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserSignature signature, [FromHeader] bool loginMustBeTheEmail)
        {
            signature.LoginMustBeTheEmail = loginMustBeTheEmail;
            _createUserValidation.ValidateHorti(signature);

            await _userApp.CreateUser(signature);
            return Created("", null);
        }

        [HttpDelete(nameof(DeleteUserAsync))]
        public async Task<IActionResult> DeleteUserAsync([FromBody] DeleteUserSignature signature)
        {
            _deleteUserValidation.ValidateHorti(signature);

            await _userApp.DeleteUser(signature);
            return NoContent();
        }

        [HttpPut(nameof(UpdateUserAsync))]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserSignature signature, [FromHeader] bool loginMustBeTheEmail)
        {
            signature.LoginMustBeTheEmail = loginMustBeTheEmail;
            _updateUserValidation.ValidateHorti(signature);

            await _userApp.UpdateUser(signature);
            return Ok();
        }

        [HttpPut(nameof(UpdateUserOnlyFilledFieldAsync))]
        public async Task<IActionResult> UpdateUserOnlyFilledFieldAsync([FromBody] UserSignature signature, [FromHeader] bool loginMustBeTheEmail)
        {
            signature.LoginMustBeTheEmail = loginMustBeTheEmail;
            _updateFilledFieldUserValidation.ValidateHorti(signature);

            await _userApp.UpdateUser(signature);
            return Ok();
        }

    }
}
