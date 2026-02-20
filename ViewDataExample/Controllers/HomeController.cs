using Microsoft.AspNetCore.Mvc;
using ViewDataExample.Models;

namespace ViewDataExample.Controllers
{
    [Controller]
    public class HomeController: Controller
    {
        [Route("/home")]
        public IActionResult getEmployeeInfo()
        {
            ViewData["title"] = "ASP Demo";
            ViewData["heading"] = "Welcome to my application";
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Name = "Alice", DateOfBirth = new DateTime(2000,01,01), Dept = "cse" },
                new Employee() { Name = "Bob", DateOfBirth = new DateTime(2000,01,01), Dept = "eee" },
            };
            ViewData["employees"] = employees;
            return View("EmployeeInfo");
        }
        // viewBag example
        [Route("/home/view-bag")]
        public IActionResult getEmployeeInfoWithViewBag()
        {
            ViewData["title"] = "ASP Demo";
            ViewBag.heading = "Welcome to my application to show example of view-bag";
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Name = "Alice", DateOfBirth = new DateTime(2000,01,01), Dept = "cse" },
                new Employee() { Name = "Bob", DateOfBirth = new DateTime(2000,01,01), Dept = "eee" },
            };
            ViewBag.employees = employees;
            return View("EmployeeInfoWithViewBag");
        }
        // strongly typed view example
        [Route("/detail-page/{name}")]
        public IActionResult employeeDetails(string name)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Name = "Alice", DateOfBirth = new DateTime(2000,01,01), Dept = "cse" },
                new Employee() { Name = "Bob", DateOfBirth = new DateTime(2000,01,01), Dept = "eee" },
            };
            var matchingEmployee = employees.Where(x => x.Name == name).FirstOrDefault();
            if(matchingEmployee != null)
            {
                return View("EmployeeDetails", matchingEmployee);
            }
            else return NotFound(name);
        }
    }
}
