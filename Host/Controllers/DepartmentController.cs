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
        public async Task<IActionResult> CreateDepartment(DepartmentRequestModel model)
        {
            var respone = await _departmentService.Add(model);
            if (respone == null)
            {
                return BadRequest();
            }
            return Ok(respone);

        }
        [HttpGet("id")]
        public async Task<ActionResult> GetDepartment(Guid id)
        {
           var departmentDto = await _departmentService.GetDepartment(id);
            if (departmentDto == null)
            {
                return BadRequest();
            }
            return Ok(departmentDto);
        }

        [HttpGet("examTypeId")]
        public async Task<ActionResult> GetDepartmentsByExamType(Guid examTypeId)
        {
            var departmentDto = _departmentService.GetDepartmentsByExamType(examTypeId);
            if (departmentDto == null)
            {
                return BadRequest();
            }
            return Ok(departmentDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var response = await _departmentService.GetAllDepartments();
            if (response.Data == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }



    }
}
