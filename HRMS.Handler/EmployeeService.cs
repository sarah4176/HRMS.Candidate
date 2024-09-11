using HRMS.Aggregate.Models;
using HRMS.DTO;
using HRMS.Handler;
using HRMS.Repository;

public class EmployeeService : IEmployeeService
{
    private readonly IGenericRepository<Employee> _employeeRepository;

    public EmployeeService(IGenericRepository<Employee> employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public IEnumerable<EmployeeDTO> SearchEmployees(string searchTerm = null)
    {
        var employees = string.IsNullOrEmpty(searchTerm)
            ? _employeeRepository.GetAll()
            : _employeeRepository.Find(e => e.Name.Contains(searchTerm) ||
                                             e.Email.Contains(searchTerm) ||
                                             e.Position.Contains(searchTerm));

        return employees.Select(e => e.ToDTO());
    }

    public IEnumerable<EmployeeDTO> GetAllEmployees()
    {
        return _employeeRepository.GetAll().Select(e => e.ToDTO());
    }

    public EmployeeDTO GetEmployeeById(int id)
    {
        var employee = _employeeRepository.GetById(id);
        if (employee == null)
        {
            throw new System.Exception("Employee not found.");
        }

        return employee.ToDTO();
    }
}
