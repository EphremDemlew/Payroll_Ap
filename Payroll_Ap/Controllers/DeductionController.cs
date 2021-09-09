using Microsoft.AspNetCore.Mvc;
using Payroll_Ap.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_Ap.Controllers
{
    public class DeductionController : Controller
    {
       
        private readonly EmployeeRepository _employeeRepository = null;

        public DeductionController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Route("/Deduction")]
        [Route("/Deduction/index")]
        public async Task<ViewResult> Index()
        {
            var data = await _employeeRepository.GetAllEmployee();
            return View(data);
        }
    }
}
