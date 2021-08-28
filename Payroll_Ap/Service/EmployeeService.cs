using Payroll_Ap.IService;
using Payroll_Ap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_Ap.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        string IEmployeeService.Delete(int Id)
        {
            var employee = _context.Employee.FirstOrDefault(x=>x.Id == Id);  
            if (employee != null)
            {
                _context.Employee.Remove(employee);
                _context.SaveChanges();
            }
            return "Deleted";
        }

        Employee IEmployeeService.GetById(int Id)
        {
            return _context.Employee.SingleOrDefault(x => x.Id == Id);
        }

        List<Employee> IEmployeeService.GetEmployee()
        {
            return _context.Employee.ToList();
        }

        void IEmployeeService.Save(Employee oEmployee)
        {
            _context.Employee.Add(oEmployee);
            _context.SaveChanges();
        }

        void IEmployeeService.Update(Employee oEmployee)
        {
            _context.Employee.Update(oEmployee);
            _context.SaveChanges();
        }
    }
}
