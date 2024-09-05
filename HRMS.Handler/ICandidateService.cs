using HRMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Handler
{
    public interface ICandidateService
    {
        IEnumerable<CandidateDTO> GetAllCandidates(string searchTerm = null);
        CandidateDTO GetCandidateById(int id);
        void AddCandidate(CandidateDTO candidateDTO);
        void UpdateCandidate(CandidateDTO candidateDTO);
        void DeleteCandidate(int id);
        IEnumerable<CandidateDTO> SearchCandidates(string searchTerm = null);
        void ExportToEmployee(int candidateId);
    }
}
