using HRMS.DTO;
using System.Collections.Generic;

public interface ICandidateService
{
    IEnumerable<CandidateDTO> GetAllCandidates(string searchTerm = null);

    CandidateDTO GetCandidateById(int id);

    void AddCandidate(CandidateDTO candidateDTO);

    void UpdateCandidate(CandidateDTO candidateDTO);

    void ExportToEmployee(int candidateId);

    void DeleteCandidate(int id);

    IEnumerable<CandidateDTO> SearchCandidates(string searchTerm = null);
    IEnumerable<JobDTO> GetJobList(); // This is the new method
}
