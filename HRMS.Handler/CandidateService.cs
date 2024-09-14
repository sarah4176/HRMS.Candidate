using HRMS.Aggregate;
using HRMS.Aggregate.Models;
using HRMS.DTO;
using HRMS.Handler;
using HRMS.Repository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class CandidateService : ICandidateService
{
    private readonly IGenericRepository<Candidate> _candidateRepository;
    private readonly IGenericRepository<Employee> _employeeRepository;
    private readonly IGenericRepository<Job> _jobRepository;

    public CandidateService(IGenericRepository<Candidate> candidateRepository,
                            IGenericRepository<Employee> employeeRepository,
                            IGenericRepository<Job> jobRepository)
    {
        _candidateRepository = candidateRepository;
        _employeeRepository = employeeRepository;
        _jobRepository = jobRepository;
    }

    public IEnumerable<CandidateDTO> GetAllCandidates(string searchTerm = null)
    {
        var candidates = string.IsNullOrEmpty(searchTerm)
            ? _candidateRepository.GetAllIncluding(c => c.Job)
            : _candidateRepository.FindIncluding(c => c.Name.Contains(searchTerm) ||
                                                      c.Email.Contains(searchTerm) ||
                                                      c.Job.Title.Contains(searchTerm), c => c.Job);

        return candidates.Select(c => c.ToDTO());
    }

    public CandidateDTO GetCandidateById(int id) //use object
    {
        var candidate = _candidateRepository.FindIncluding(c => c.Id == id, c => c.Job).FirstOrDefault();  //
        if (candidate == null)
        {
            throw new KeyNotFoundException("Candidate not found.");
        }

        return candidate.ToDTO();
    }

    public void AddCandidate(CandidateDTO candidateDTO)
    {
        var candidate = Candidate.FromDTO(candidateDTO);
        if (!candidate.IsValid(out var validationResults))
        {
            throw new ValidationException("Candidate validation failed.");
        }

        _candidateRepository.Add(candidate);
    }

    public void UpdateCandidate(CandidateDTO candidateDTO)
    {
        var candidate = Candidate.FromDTO(candidateDTO);
        if (!candidate.IsValid(out var validationResults))
        {
            throw new ValidationException("Candidate validation failed.");
        }

        _candidateRepository.Update(candidate);
    }

    public void ExportToEmployee(CandidateDTO candidatedto)
    {
        var candidate = _candidateRepository.GetById(candidatedto.Id);
        if (candidate == null)
        {
            throw new KeyNotFoundException("Candidate not found.");
        }

        var employee = Employee.FromCandidate(candidate); // Use the FromCandidate method for direct mapping
        _employeeRepository.Add(employee);
    }

    public void DeleteCandidate(int id)
    {
        var candidate = _candidateRepository.GetById(id);
        if (candidate == null)
        {
            throw new KeyNotFoundException("Candidate not found.");
        }

        _candidateRepository.Delete(id);
    }

    public IEnumerable<CandidateDTO> SearchCandidates(string searchTerm = null)
    {
        var candidates = string.IsNullOrEmpty(searchTerm)
            ? _candidateRepository.GetAll()
            : _candidateRepository.Find(c => c.Name.Contains(searchTerm) ||
                                             c.Email.Contains(searchTerm) ||
                                             c.Job.Title.Contains(searchTerm));

        return candidates.Select(c => c.ToDTO()); // Use the ToDTO method in Candidate model
    }
    public IEnumerable<JobDTO> GetJobList()
    {

        return _jobRepository.GetAll()  
                             .Select(job => new JobDTO
                             {
                                 Id = job.Id,
                                 Title = job.Title ?? string.Empty,
                                 SalaryRange = job.SalaryRange ?? string.Empty,
                                 Requirements = job.Requirements ?? string.Empty,
                                 EmploymentType = job.EmploymentType ?? string.Empty,
                                 Department = job.Department ?? string.Empty
                             })
                             .Distinct()
                             .ToList();
    }


}
