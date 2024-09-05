using HRMS.Aggregate.Models;
using HRMS.DTO;
using HRMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Handler
{
    public class CandidateService : ICandidateService
    {
        private readonly IGenericRepository<Candidate> _candidateRepository;
        private readonly IGenericRepository<Employee> _employeeRepository;

        public CandidateService(IGenericRepository<Candidate> candidateRepository,
                                IGenericRepository<Employee> employeeRepository)
        {
            _candidateRepository = candidateRepository;
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<CandidateDTO> GetAllCandidates(string searchTerm = null)
        {
            var candidates = string.IsNullOrEmpty(searchTerm)
                ? _candidateRepository.GetAll()
                : _candidateRepository.Find(c => c.Name.Contains(searchTerm) ||
                                                 c.Email.Contains(searchTerm) ||
                                                 c.Job.Title.Contains(searchTerm));

            return candidates.Select(c => new CandidateDTO
            {
                Id = c.Id,
                Name = c.Name,
                NationalIdNumber = c.NationalIdNumber,
                Address = c.Address,
                Phone = c.Phone,
                Email = c.Email,
                ApplicationDate = c.ApplicationDate,
                LinkedinProfile = c.LinkedinProfile,
                ExpectedSalary = c.ExpectedSalary,
                Status = c.Status,
                ResumePath = c.ResumePath,
                Source = c.Source,
                JobId = c.JobId,
                JobTitle = c.Job?.Title
            });
        }
        public IEnumerable<CandidateDTO> SearchCandidates(string searchTerm = null)
        {
            var candidates = string.IsNullOrEmpty(searchTerm)
                ? _candidateRepository.GetAll()
                : _candidateRepository.Find(c => c.Name.Contains(searchTerm) ||
                                                 c.Email.Contains(searchTerm) ||
                                                 c.Job.Title.Contains(searchTerm));

            return candidates.Select(c => new CandidateDTO
            {
                Id = c.Id,
                Name = c.Name,
                NationalIdNumber = c.NationalIdNumber,
                Address = c.Address,
                Phone = c.Phone,
                Email = c.Email,
                ApplicationDate = c.ApplicationDate,
                LinkedinProfile = c.LinkedinProfile,
                ExpectedSalary = c.ExpectedSalary,
                Status = c.Status,
                ResumePath = c.ResumePath,
                Source = c.Source,
                JobId = c.JobId,
                JobTitle = c.Job?.Title
            });
        }


        public CandidateDTO GetCandidateById(int id)
        {
            var candidate = _candidateRepository.GetById(id);
            if (candidate == null)
            {
                throw new System.Exception("Candidate not found.");
            }

            return new CandidateDTO
            {
                Id = candidate.Id,
                Name = candidate.Name,
                NationalIdNumber = candidate.NationalIdNumber,
                Address = candidate.Address,
                Phone = candidate.Phone,
                Email = candidate.Email,
                ApplicationDate = candidate.ApplicationDate,
                LinkedinProfile = candidate.LinkedinProfile,
                ExpectedSalary = candidate.ExpectedSalary,
                Status = candidate.Status,
                ResumePath = candidate.ResumePath,
                Source = candidate.Source,
                JobId = candidate.JobId,
                JobTitle = candidate.Job?.Title
            };
        }

        public void AddCandidate(CandidateDTO candidateDTO)
        {
            var candidate = new Candidate
            {
                Name = candidateDTO.Name,
                NationalIdNumber = candidateDTO.NationalIdNumber,
                Address = candidateDTO.Address,
                Phone = candidateDTO.Phone,
                Email = candidateDTO.Email,
                ApplicationDate = candidateDTO.ApplicationDate,
                LinkedinProfile = candidateDTO.LinkedinProfile,
                ExpectedSalary = candidateDTO.ExpectedSalary,
                Status = candidateDTO.Status,
                ResumePath = candidateDTO.ResumePath,
                Source = candidateDTO.Source,
                JobId = candidateDTO.JobId
            };

            _candidateRepository.Add(candidate);
        }

        public void UpdateCandidate(CandidateDTO candidateDTO)
        {
            var candidate = new Candidate
            {
                Id = candidateDTO.Id,
                Name = candidateDTO.Name,
                NationalIdNumber = candidateDTO.NationalIdNumber,
                Address = candidateDTO.Address,
                Phone = candidateDTO.Phone,
                Email = candidateDTO.Email,
                ApplicationDate = candidateDTO.ApplicationDate,
                LinkedinProfile = candidateDTO.LinkedinProfile,
                ExpectedSalary = candidateDTO.ExpectedSalary,
                Status = candidateDTO.Status,
                ResumePath = candidateDTO.ResumePath,
                Source = candidateDTO.Source,
                JobId = candidateDTO.JobId
            };

            _candidateRepository.Update(candidate);
        }

        public void DeleteCandidate(int id)
        {
            _candidateRepository.Delete(id);
        }

        public void ExportToEmployee(int candidateId)
        {
            var candidate = _candidateRepository.GetById(candidateId);
            if (candidate == null)
            {
                throw new System.Exception("Candidate not found.");
            }

            var employee = new Employee
            {
                Name = candidate.Name,
                NationalIdNumber = candidate.NationalIdNumber,
                Address = candidate.Address,
                Phone = candidate.Phone,
                Email = candidate.Email,
                Position = candidate.Job?.Title,
                Salary = candidate.ExpectedSalary,
                JobId = candidate.JobId
            };

            _employeeRepository.Add(employee);
        }
    }
}
