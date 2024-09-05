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
        [Required]
        public string Name { get; set; }
        public int NationalIdNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        public string? LinkedinProfile { get; set; }
        [Required]
        public string ExpectedSalary { get; set; }
        public string? Status { get; set; }
        public string? ResumePath { get; set; }
        public string? Source { get; set; }

        // Foreign Key
        public int? JobId { get; set; }
        public virtual Job? Job { get; set; }
    }
}
