using HORTIUSERCOMMAND.DOMAIN.MODEL;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERCOMMAND.DOMAIN.MODEL.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HORTIUSERCOMMAND.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionCommandRepository _sessionRepository;

        public SessionController(ISessionCommandRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        [HttpGet(nameof(GetSession))]
        [Authorize]
        public async Task<IActionResult> GetSession()
        {
            //var session = await _sessionRepository.GetSessionAsync();
            //var retorno = JsonSerializer.Serialize(session);            
            return Ok();
        }
    }
}
