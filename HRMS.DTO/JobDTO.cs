using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DTO
{
    public class JobDTO
    {

        public int Id { get; set; }

        public required string Title { get; set; }
 
        public required string Department { get; set; }
        public string? JobLocation { get; set; }

        public required string EmploymentType { get; set; }
      
        public required string Requirements { get; set; }
        public DateTime PostingDate { get; set; } = DateTime.Now;
        public DateTime ClosingDate { get; set; }
  
        public required string SalaryRange { get; set; }

        //// Navigation Property
        //public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
