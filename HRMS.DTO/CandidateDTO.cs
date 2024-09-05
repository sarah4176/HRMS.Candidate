using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DTO
{
    public class CandidateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NationalIdNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string? LinkedinProfile { get; set; }
        public string ExpectedSalary { get; set; }
        public string? Status { get; set; }
        public string? ResumePath { get; set; }
        public string? Source { get; set; }
        public int? JobId { get; set; }
        public string? JobTitle { get; set; }
    }
}
