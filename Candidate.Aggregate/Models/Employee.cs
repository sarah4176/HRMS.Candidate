using HRMS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Aggregate.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
   
        public required string Name { get; set; }
        public int NationalIdNumber { get; set; }

        public required string Address { get; set; }
 
        public required string Phone { get; set; }

        public required string Email { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;
        public string? Position { get; set; }
  
        public required string Salary { get; set; }
        public int? JobId { get; set; }
        public virtual Job? Job { get; set; }
        public EmployeeDTO ToDTO()
        {
            return new EmployeeDTO
            {
                Id = this.Id,
                Name = this.Name,
                NationalIdNumber = this.NationalIdNumber,
                Address = this.Address,
                Phone = this.Phone,
                Email = this.Email,
                Position = this.Position,
                Salary = this.Salary,
                JobId = this.JobId
            };
        }

        // FromDTO Method
        public static Employee FromDTO(EmployeeDTO dto)
        {
            return new Employee
            {
                Id = dto.Id,
                Name = dto.Name,
                NationalIdNumber = dto.NationalIdNumber,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                Position = dto.Position,
                Salary = dto.Salary,
                JobId = dto.JobId
            };
        }
        public static Employee FromCandidate(Candidate candidate)
        {
            return new Employee
            {
                Name = candidate.Name,
                NationalIdNumber = candidate.NationalIdNumber,
                Address = candidate.Address,
                Phone = candidate.Phone,
                Email = candidate.Email,
                Position = candidate.Job?.Title, // Map Job title to Position
                Salary = candidate.ExpectedSalary,
                JobId = candidate.JobId
            };
        }
        public bool IsValid(out List<ValidationResult> validationResults)
        {
            var context = new ValidationContext(this);
            validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(this, context, validationResults, validateAllProperties: true);
        }
    }

}
