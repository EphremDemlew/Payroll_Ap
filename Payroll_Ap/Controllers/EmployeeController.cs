using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payroll_Ap.Models;
using Payroll_Ap.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_Ap.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository = null;
        
            public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Route("/Employee")]
        
        public async Task<ViewResult> Index()
        {
            var data = await _employeeRepository.GetAllEmployee();
            return View(data);
        }

        [Route("/Employee/Delete")]
        public IActionResult Delete(int id, bool isSucess = false)
        {
            ViewBag.IsSucess = isSucess;
            var delt = _employeeRepository.Delete(id);
            return RedirectToAction(actionName: nameof(Index) , new { isSucess = true} );
            
        }

        [Route("/Employee/Edit")]
        public async Task<ViewResult> Edit(int id)
        {
            var data = await _employeeRepository.GetEmployeById(id);
            return View(data);
        }

        public ViewResult AddNewEmployee(bool isSucess = false)
        {
            ViewBag.IsSucess = isSucess;
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewEmployee(Employee employeeModel)
        {
            if (ModelState.IsValid)
            {
                int eid = await _employeeRepository.AddNewEmployee(employeeModel);
                if ( eid > 0 )
                {
                    return RedirectToAction(nameof(AddNewEmployee) , new { isSucess = true });
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Employee employeeModel)
        {
            if (ModelState.IsValid)
            {

                var eid = await _employeeRepository.Update(employeeModel);
                if (eid != null)
                {
                    return RedirectToAction(nameof(Index));

                }
            }
            return View();
        }

    }
}
