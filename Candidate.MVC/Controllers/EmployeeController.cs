using HRMS.DTO;
using HRMS.Handler;
using HRMS.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HRMS.MVC.Controllers
    {
        public class EmployeeController : Controller
        {
            private readonly IEmployeeService _employeeService;

            public EmployeeController(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }

            // GET: Employee
            public IActionResult Index()
            {
                IEnumerable<EmployeeDTO> employees = _employeeService.GetAllEmployees();
                return View(employees);
            }
        public IActionResult SearchEmployee(string searchTerm)
        {
            IEnumerable<EmployeeDTO> employees = _employeeService.SearchEmployees(searchTerm);
            return View(employees);
        }

        // GET: Employee/Details/5
        public IActionResult Details(int id)
            {
                var employee = _employeeService.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }

            //// GET: Employee/Create
            //public IActionResult Create()
            //{
            //    return View();
            //}

            //// POST: Employee/Create
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public IActionResult Create(EmployeeDTO employeeDTO)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        _employeeService.AddEmployee(employeeDTO);
            //        return RedirectToAction(nameof(Index));
            //    }
            //    return View(employeeDTO);
            //}

            //// GET: Employee/Edit/5
            //public IActionResult Edit(int id)
            //{
            //    var employee = _employeeService.GetEmployeeById(id);
            //    if (employee == null)
            //    {
            //        return NotFound();
            //    }
            //    return View(employee);
            //}

            //// POST: Employee/Edit/5
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public IActionResult Edit(int id, EmployeeDTO employeeDTO)
            //{
            //    if (id != employeeDTO.Id)
            //    {
            //        return NotFound();
            //    }

            //    if (ModelState.IsValid)
            //    {
            //        _employeeService.UpdateEmployee(employeeDTO);
            //        return RedirectToAction(nameof(Index));
            //    }
            //    return View(employeeDTO);
            //}

            //// GET: Employee/Delete/5
            //public IActionResult Delete(int id)
            //{
            //    var employee = _employeeService.GetEmployeeById(id);
            //    if (employee == null)
            //    {
            //        return NotFound();
            //    }
            //    return View(employee);
            //}

            //// POST: Employee/Delete/5
            //[HttpPost, ActionName("Delete")]
            //[ValidateAntiForgeryToken]
            //public IActionResult DeleteConfirmed(int id)
            //{
            //    _employeeService.DeleteEmployee(id);
            //    return RedirectToAction(nameof(Index));
            //}
        }
    }



