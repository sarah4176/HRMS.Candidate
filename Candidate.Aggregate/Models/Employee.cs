using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Aggregate.Models
{
    public class Employee
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
        public DateTime HireDate { get; set; } = DateTime.Now;
        public string? Position { get; set; }
        [Required]
        public string Salary { get; set; }
        public int? JobId { get; set; }
        public virtual Job? Job { get; set; }
    }
}
