using Microsoft.AspNetCore.Mvc;
using MIDDLEWARE.LOG.APPLICATION.MODEL.EXCEPTION;
using System.Net;
using System.Text.Json;
using USER.ACCESS.COMMAND.DOMAIN.MODEL.RESULT.QUERY;
using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE.QUERY;
using USER.ACCESSQUERY.REPOSITORY.USER.INTERFACE;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace USER.ACCESSQUERY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet(nameof(GetListOfActiveUserAsync) + "/{idSystem}")]
        public async Task<IActionResult> GetListOfActiveUserAsync(Guid idSystem, int pageNumber = 0, int PageSize = 10)
        {
            var signature = new UserQuerySignature
            {
                IdSystem = idSystem,
                PageNumber = pageNumber,
                PageSize = PageSize
            };

            var listOfUser = (await _userRepository.GetListOfActiveUser(signature)).ListOfUserExtension();

            if (listOfUser == null)
                throw new NotFoundException(JsonSerializer.Serialize(signature).ToUpperInvariant());

            return Ok(listOfUser);
        }

        [HttpGet(nameof(GetActiveUserByFilterAsync) + "/{idSystem}/{dsLogin}")]
        public async Task<IActionResult> GetActiveUserByFilterAsync(Guid idSystem, string dsLogin)
        {
            var signature = new UserQuerySignature
            {
                IdSystem = idSystem,
                DsLogin = dsLogin
            };

            var user = await _userRepository.GetActiveUserByFilter(signature);

            if (user == null)
                throw new NotFoundException(JsonSerializer.Serialize(signature).ToUpperInvariant());

            return Ok(user);
        }
    }
}