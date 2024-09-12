using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public int NationalIdNumber { get; set; }

        public required string Address { get; set; }

        public required string Phone { get; set; }

        public required string Email { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;
        public string? Position { get; set; }

        public required string Salary { get; set; }
        public int? JobId { get; set; }
        public string? JobTitle { get; set; }
    }
}
