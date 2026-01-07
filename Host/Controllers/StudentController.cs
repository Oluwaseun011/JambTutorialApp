using Application.Dtos;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
    }
    [HttpPost]
    public async Task<IActionResult> RegisterAsync(RegisterStudentRequestModel model)
        {
            var response = await _studentService.RegisterAsync(model);
            return Created();
        }

    [HttpGet("username")]
    public async Task<IActionResult> GetStudentAsync(string username)
        {
            var response = await _studentService.GetStudentAsync(username);
            if(response is  null) return NotFound();
            return Ok(response);
        }
    [HttpGet]
    public async Task<IActionResult> GetAllStudentsAsync()
        {
            var response = await _studentService.GetAllStudentsAsync();
            return Ok(response);
        }
}
