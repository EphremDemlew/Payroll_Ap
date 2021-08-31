﻿using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Delete(int id)
        {

            var delt = _employeeRepository.Delete(id);
            return RedirectToAction(actionName: nameof(Index));


        }

        [Route("/Employee/Edit")]
        public async Task<ViewResult> Edit(int id)
        {
            var data = await _employeeRepository.GetBookById(id);
            return View(data);
        }

        public ViewResult AddNewEmployee()
        {

            return View();
        }

        //public Employee GetEmployee(int id)
        //{
        //    return _employeeRepository.GetEmployeeByIdAsync(id);
        //}
        //public List<Employee> SearchEmployees(string fullname, string departmentname)
        //{
        //    return _employeeRepository.SearchEmployee(fullname, departmentname);
        //}



        [HttpPost]
        public async Task<IActionResult> AddNewEmployee(Employee employeeModel)
        {
            if (ModelState.IsValid)
            {

                int eid = await _employeeRepository.AddNewEmployee(employeeModel);
                if ( eid > 0 )
                {
                    return RedirectToAction(nameof(AddNewEmployee) , new { isSucess = true } );

                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(Employee employeeModel)
        {
            if (ModelState.IsValid)
            {

                var eid =  _employeeRepository.Update(employeeModel);
                if (eid != null)
                {
                    return RedirectToAction(nameof(Index));

                }
            }
            return View();
        }




        //public IActionResult Upsert(int? id)
        //{
        //    Employee = new Employee();
        //    if(id == null)
        //    {
        //        //create
        //        return View(Employee);
        //    }
        //    //update
        //    Employee = _db.Employees.FirstOrDefault(u => u.Id == id);
        //    if(Employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(Employee);
        ////}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Upsert()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Employee.Id == 0)
        //        {
        //            //create
        //            _db.Employees.Add(Employee);
        //        }
        //        else
        //        {
        //            _db.Employees.Update(Employee);
        //        }
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(Employee);
        //}


        //#region API Calls
        //[HttpGet]
        //    public async Task<IActionResult> GetAll()
        //    {
        //        return Json(new { data = await _db.Employees.ToListAsync() });
        //    }

        //    [HttpDelete]
        //    public async Task<IActionResult> Delete(int id)   
        //    {
        //        var empFromDb = await _db.Employees.FirstOrDefaultAsync(u => u.Id == id);
        //        if (empFromDb == null)
        //        {
        //            return Json(new { success = false, message = "Error while Deleting" });
        //        }
        //        _db.Employees.Remove(empFromDb);
        //        await _db.SaveChangesAsync();
        //        return Json(new { success = true, message = "Delete successful" });
        //    }

        //    #endregion
    }
}
