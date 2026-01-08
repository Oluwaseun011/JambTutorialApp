using Application.Dtos;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]

        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            BaseResponse<LoginResponseModel> response = await _userService.Login(model);

            if (response.IsSuccessful == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }
    }
}
