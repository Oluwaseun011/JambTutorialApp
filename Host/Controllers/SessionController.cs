using Application.Dtos;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using System.Threading.Tasks.Dataflow;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]

        public async Task<IActionResult> Add(SessionRequestModel model)
        {
            await _sessionService.AddSession(model);
            return Ok();
        }

        [HttpDelete]

        public ActionResult<ISessionService> Delete(Guid id)
        {
            var response = _sessionService.Delete(id);

            if (response == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        public async Task<IActionResult> GetSessions()
        {
            var sessions = await _sessionService.GetAllSessions();

            if (sessions.Count < 1)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
