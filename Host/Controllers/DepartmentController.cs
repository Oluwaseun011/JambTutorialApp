using Application.Dtos;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentRequestModel model)
        {
            var respone = await _departmentService.Create(model);
            if (!respone.IsSuccessful)
            {
                return BadRequest();
            }
            return Ok(respone);

        }
        [HttpGet("id")]
        public async Task<IActionResult> GetDepartment(Guid id)
        {
           var departmentDto = await _departmentService.GetDepartment(id);
            if (departmentDto == null)
            {
                return BadRequest();
            }
            return Ok(departmentDto);
        }

        [HttpGet("examType/examTypeId")]
        public async Task<IActionResult> GetDepartmentsByExamType(Guid examTypeId)
        {
            var response = await _departmentService.GetDepartmentsByExamType(examTypeId);
            if (!response.IsSuccessful)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var response = await _departmentService.GetDepartments();
            if (!response.IsSuccessful)
            {
                return BadRequest();
            }
            return Ok(response);
        }



    }
}
