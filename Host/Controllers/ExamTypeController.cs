using Application.Dtos;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamTypeController : ControllerBase
    {
        private readonly IExamTypeService _examTypeService;
        public ExamTypeController(IExamTypeService examTypeService)
        {
            _examTypeService = examTypeService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync (ExamTypeRequestModel model)
        {
            var response = await _examTypeService.Create(model);
            return Created();
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetExamTypeById (Guid id)
        {
            var response = await _examTypeService.GetExamType(id);
            if (response == null) return NotFound();
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllExamType()
        {
            var response = _examTypeService.GetAllExamTypes();
            return Ok(response);
        }

    }
}
