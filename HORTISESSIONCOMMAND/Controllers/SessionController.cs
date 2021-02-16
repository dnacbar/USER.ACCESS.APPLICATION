using HORTIUSERCOMMAND.DOMAIN.DOMAIN;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERCOMMAND.DOMAIN.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace HORTISESSIONCOMMAND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        [HttpGet(nameof(GetSession))]
        public async Task<IActionResult> GetSession()
        {
            var session = await _sessionRepository.GetSessionAsync();
            var retorno = JsonSerializer.Serialize(session);            
            return Ok(retorno);
        }

        [HttpPost(nameof(CreateSession))]
        public IActionResult CreateSession([FromBody] UserSessionSignature signature)
        {
            signature.CreateSession(HttpContext.Connection.RemoteIpAddress);
            _sessionRepository.CreateSessionAsync(new UserSession
            {
                IdUser = signature.IdUser.ToString(),
                IpAddress = signature.IPAddress.ToString(),
                SessionExpire = signature.SessionExpire,
                SessionLimit = signature.SessionLimit
            });
            
            return Ok("{User: Created}");
        }

        [HttpPut]
        public void EditSession([FromBody] string value)
        {
        }

        [HttpDelete]
        public void Delete([FromBody] string id)
        {
        }
    }
}
