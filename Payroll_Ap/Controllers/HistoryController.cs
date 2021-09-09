
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Payroll_Ap.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_Ap.Controllers
{
    [Authorize]

    public class HistoryController : Controller
    {


        private readonly EmployeeRepository _employeeRepository = null;

        public HistoryController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Route("/History")]
        public async Task<ViewResult> Index()
        {
            var data = await _employeeRepository.GetAllEmployee();
            return View(data);
        }
    }
}
