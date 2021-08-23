using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_Ap.Controllers
{
    public class Department : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
