using Application.Dtos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        //IDepartmentRepository _repository = new DepartmentRepository();
        public BaseResponse<DepartmentResponseModel> Add(DepartmentRequestModel departmentRequestModel)
        {
            Department department = new Department
            {
                ExamType = departmentRequestModel.ExamType,
                Name = departmentRequestModel.Name,
                Subjects = departmentRequestModel.Subjects,
            };
            _repository.AddAsync(department);

            return new BaseResponse<DepartmentResponseModel>
            {
                Status = true,
                Message = $"Department {departmentRequestModel.Name} created successfully.",
                Data = new DepartmentResponseModel
                (
                    departmentRequestModel.Name,
                    departmentRequestModel.Subjects
                    )
            };
        }


        public ICollection<Department> GetAllDepartments()
        {
            ICollection<Department> departments = (ICollection<Department>) _repository.GetDepartmentsAsync();
            return departments;
        }

        public Department? GetDepartment(Guid id)
        {
            _repository.GetDepartmentAsync(id);
            
        }

        public ICollection<Department> GetDepartmentsByExamType(Guid examTypeId)
        {
            _repository.GetDepartmentsAsyncByExamType(examTypeId);
        }
    }
}
