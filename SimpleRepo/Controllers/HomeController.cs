using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleRepo.Data;
using SimpleRepo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRepo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context  = context;
        }

        public IActionResult Index()
        {
            var result = _context.Employees
              .Include(e => e.Department)
              .Include(e => e.EmployeeCV);
            return View(result);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _context.Employees
              .Include(e => e.Department)
              .Include(e => e.EmployeeCV)
              .FirstOrDefault(e => e.EmployeeId == id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            var employee = _context.Employees
              .Include(e => e.Department)
              .Include(e => e.EmployeeCV)
              .FirstOrDefault(e => e.EmployeeId == emp.EmployeeId);

            //Update
            employee.FirstName = emp.FirstName;
            employee.LastName = emp.LastName;

            var find = _context.EmployeeCVs.Find(emp.EmployeeCV.EmployeeId);

            if (find != null)
            {
                employee.EmployeeCV.Skills = emp.EmployeeCV.Skills;
                employee.EmployeeCV.Nationality = emp.EmployeeCV.Nationality;
                employee.DepartmentId = emp.DepartmentId;
            }
            else
            {
                EmployeeCV cv = new EmployeeCV();
                cv.EmployeeId = emp.EmployeeId; 
                cv.Nationality = emp.EmployeeCV.Nationality;
                cv.Skills = emp.EmployeeCV.Skills;
                employee.DepartmentId = emp.DepartmentId;
                _context.EmployeeCVs.Add(cv);
            }

            _context.SaveChanges();

            return View(employee);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
