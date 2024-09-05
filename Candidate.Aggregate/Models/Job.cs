using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Aggregate.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Department { get; set; }
        public string? JobLocation { get; set; }
        [Required]
        public string EmploymentType { get; set; }
        [Required]
        public string Requirements { get; set; }
        public DateTime PostingDate { get; set; } = DateTime.Now;
        public DateTime ClosingDate { get; set; }
        [Required]
        public string SalaryRange { get; set; }

        // Navigation Property
        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
