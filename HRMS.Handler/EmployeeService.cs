using HRMS.Aggregate.Models;
using HRMS.DTO;
using HRMS.Handler;
using HRMS.Repository;
using System.Collections.Generic;
using System.Linq;

namespace HRMS.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;

        public EmployeeService(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEnumerable<EmployeeDTO> SearchEmployees(string searchTerm = null)
        {
            var employees = string.IsNullOrEmpty(searchTerm)
                ? _employeeRepository.GetAll()
                : _employeeRepository.Find(e => e.Name.Contains(searchTerm) ||
                                                 e.Email.Contains(searchTerm) ||
                                                 e.Position.Contains(searchTerm));

            return employees.Select(e => new EmployeeDTO
            {
                Id = e.Id,
                Name = e.Name,
                NationalIdNumber = e.NationalIdNumber,
                Address = e.Address,
                Phone = e.Phone,
                Email = e.Email,
                Position = e.Position,
                Salary = e.Salary,
                JobId = e.JobId
            });
        }


        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();

            return employees.Select(e => new EmployeeDTO
            {
                Id = e.Id,
                Name = e.Name,
                NationalIdNumber = e.NationalIdNumber,
                Address = e.Address,
                Phone = e.Phone,
                Email = e.Email,
                Position = e.Position,
                Salary = e.Salary,
                JobId = e.JobId
            });
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                throw new System.Exception("Employee not found.");
            }

            return new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                NationalIdNumber = employee.NationalIdNumber,
                Address = employee.Address,
                Phone = employee.Phone,
                Email = employee.Email,
                Position = employee.Position,
                Salary = employee.Salary,
                JobId = employee.JobId
            };
        }

        //public void AddEmployee(EmployeeDTO employeeDTO)
        //{
        //    var employee = new Employee
        //    {
        //        Name = employeeDTO.Name,
        //        NationalIdNumber = employeeDTO.NationalIdNumber,
        //        Address = employeeDTO.Address,
        //        Phone = employeeDTO.Phone,
        //        Email = employeeDTO.Email,
        //        Position = employeeDTO.Position,
        //        Salary = employeeDTO.Salary,
        //        JobId = employeeDTO.JobId
        //    };

        //    _employeeRepository.Add(employee);
        //}

        //public void UpdateEmployee(EmployeeDTO employeeDTO)
        //{
        //    var employee = new Employee
        //    {
        //        Id = employeeDTO.Id,
        //        Name = employeeDTO.Name,
        //        NationalIdNumber = employeeDTO.NationalIdNumber,
        //        Address = employeeDTO.Address,
        //        Phone = employeeDTO.Phone,
        //        Email = employeeDTO.Email,
        //        Position = employeeDTO.Position,
        //        Salary = employeeDTO.Salary,
        //        JobId = employeeDTO.JobId
        //    };

        //    _employeeRepository.Update(employee);
        //}

        //public void DeleteEmployee(int id)
        //{
        //    _employeeRepository.Delete(id);
        //}
    }
}
