using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HandyBusiness.Controllers
{
    public class EmployeeController : Controller
    {

        public IActionResult AddEmployeeFSB()
        {
            return View();
        }

        public IActionResult RemoveEmployeeFSB()
        {
            return View();
        }

        public IActionResult UpdateEmployeeFSB()
        {
            return View();
        }

        public IActionResult GetEmployeeByIdFSB(int? id)
        {
            return View();
        }
    }
}