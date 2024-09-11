using HRMS.Aggregate.Models;
using HRMS.DTO;
using HRMS.Handler;
using HRMS.Repository;

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
            ? _candidateRepository.GetAllIncluding(c => c.Job)
            : _candidateRepository.FindIncluding(c => c.Name.Contains(searchTerm) ||
                                                      c.Email.Contains(searchTerm) ||
                                                      c.Job.Title.Contains(searchTerm), c => c.Job);

        return candidates.Select(c => c.ToDTO());
    }

    public CandidateDTO GetCandidateById(int id)
    {
        var candidate = _candidateRepository.FindIncluding(c => c.Id == id, c => c.Job).FirstOrDefault();
        if (candidate == null)
        {
            throw new System.Exception("Candidate not found.");
        }
        return candidate.ToDTO();
    }

    public void AddCandidate(CandidateDTO candidateDTO)
    {
        var candidate = Candidate.FromDTO(candidateDTO);
        _candidateRepository.Add(candidate);
    }

    public void UpdateCandidate(CandidateDTO candidateDTO)
    {
        var candidate = Candidate.FromDTO(candidateDTO);
        _candidateRepository.Update(candidate);
    }

    public void ExportToEmployee(int candidateId)
    {
        var candidate = _candidateRepository.GetById(candidateId);
        if (candidate == null)
        {
            throw new System.Exception("Candidate not found.");
        }

        var employee = Employee.FromCandidate(candidate); // Use the FromCandidate method for direct mapping
        _employeeRepository.Add(employee);
    }

    public void DeleteCandidate(int id)
    {
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

}
