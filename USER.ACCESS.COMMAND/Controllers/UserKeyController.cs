using Microsoft.AspNetCore.Mvc;
using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.APP;
using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace USER.ACCESS.COMMAND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserKeyController : ControllerBase
    {
        private readonly IUserKeyApp _userKeyApp;

        public UserKeyController(IUserKeyApp userKeyApp)
        {
            _userKeyApp = userKeyApp;
        }

        [HttpPost(nameof(CreateUserKeyAsync))]
        public async Task<IActionResult> CreateUserKeyAsync([FromBody] UserKeySignature signature)
        {
            await _userKeyApp.CreateUserKey(signature);

            return Created("", null);
        }

        [HttpPut(nameof(UpdateUserKeyAsync))]
        public async Task<IActionResult> UpdateUserKeyAsync([FromBody] UserKeySignature signature)
        {
            await _userKeyApp.UpdateUserKey(signature);

            return Ok();
        }

        [HttpDelete(nameof(DeleteUserKeyAsync))]
        public async Task<IActionResult> DeleteUserKeyAsync([FromBody] DeleteUserKeySignature signature)
        {
            await _userKeyApp.DeleteUserKey(signature);

            return NoContent();
        }
    }
}
