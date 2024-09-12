using HRMS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Aggregate.Models
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }
     
        public required string Name { get; set; }
        public int NationalIdNumber { get; set; }
      
        public required string Address { get; set; }

        public required string Phone { get; set; }
     
        public required string Email { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        public string? LinkedinProfile { get; set; }

        public required string ExpectedSalary { get; set; }
        public string? Status { get; set; }
        public string? ResumePath { get; set; }
        public string? Source { get; set; }

        // Foreign Key
        public int? JobId { get; set; }
        public virtual Job? Job { get; set; }

        public CandidateDTO ToDTO()
        {
            return new CandidateDTO
            {
                Id = this.Id,
                Name = this.Name,
                NationalIdNumber = this.NationalIdNumber,
                Address = this.Address,
                Phone = this.Phone,
                Email = this.Email,
                ApplicationDate = this.ApplicationDate,
                LinkedinProfile = this.LinkedinProfile,
                ExpectedSalary = this.ExpectedSalary,
                Status = this.Status,
                ResumePath = this.ResumePath,
                Source = this.Source,
                JobId = this.JobId,
                JobTitle = this.Job?.Title // Job title mapping
            };
        }

        // Convert DTO to Candidate
        public static Candidate FromDTO(CandidateDTO dto)
        {
            return new Candidate
            {
                Id = dto.Id,
                Name = dto.Name,
                NationalIdNumber = dto.NationalIdNumber,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                ApplicationDate = dto.ApplicationDate,
                LinkedinProfile = dto.LinkedinProfile,
                ExpectedSalary = dto.ExpectedSalary,
                Status = dto.Status,
                ResumePath = dto.ResumePath,
                Source = dto.Source,
                JobId = dto.JobId
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
