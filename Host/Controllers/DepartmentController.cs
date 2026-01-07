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
        public ActionResult<DepartmentResponseModel> CreateDepartment(DepartmentRequestModel model)
        {
            DepartmentResponseModel department = _departmentService.Add(model);
            if (department == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(department);
            }

        }
        [HttpGet("id")]
        public async Task<ActionResult> GetDepartment(Guid id)
        {
           var departmentDto = _departmentService.GetDepartment(id);
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
            var departmentDtos = _departmentService.GetAllDepartment();
            if (departmentDtos.Count < 1)
            {
                return BadRequest();
            }
            return Ok(departmentDtos);
        }



    }
}
