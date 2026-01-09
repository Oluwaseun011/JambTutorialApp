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
        public async Task<IActionResult> CreateSession(CreateSessionRequestModel model)
        {
            var response = await _sessionService.Create(model);
            if (response is null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetSession(Guid id)
        {
            var response = await _sessionService.Get(id);
            if (response is null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetSessions()
        {
            var response = await _sessionService.GetSessions();
            if (response is null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
