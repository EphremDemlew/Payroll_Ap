using Microsoft.AspNetCore.Mvc;
using Payroll_Ap.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_Ap.Controllers
{
    public class AllowanceController : Controller
    {
        private readonly EmployeeRepository _employeeRepository = null;

        public AllowanceController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Route("/Allowance")]
        [Route("/Allowance/index")]
        public async Task<ViewResult> Index()
        {
            var data = await _employeeRepository.GetAllEmployee();
            return View(data);
        }
    }
}
