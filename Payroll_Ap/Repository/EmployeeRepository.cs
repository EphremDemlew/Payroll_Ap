using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payroll_Ap.Models;


namespace Payroll_Ap.Views.Repository
{
    public class EmployeeRepository
    {
        private readonly ApplicationDbContext _context = null;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewEmployee(Employee model)
        {
            var newEmployee = new Employee()
            {
                Id = model.Id,
                fullName = model.fullName,
                email = model.email,
                phoneNumber = model.phoneNumber,
                gender = model.gender,
                age = model.age,
                salary = model.salary,
                department = model.department,
                fuculity = model.fuculity,
                date = DateTime.UtcNow,
                jobTitle = model.jobTitle,
                userName = model.userName
            };

            await _context.Employee.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return newEmployee.Id; 
        }

        public async  Task<List<Employee>> GetAllEmployee()
        {
            var employees = new List<Employee>();
            var allemployee = await _context.Employee.ToListAsync();
            if (allemployee?.Any() == true)
            {
                foreach(var employee in allemployee)
                {
                    employees.Add(new Employee()
                    {
                        Id = employee.Id,
                        fullName = employee.fullName,
                        email = employee.email,
                        phoneNumber = employee.phoneNumber,
                        gender = employee.gender,
                        age = employee.age,
                        salary = employee.salary,
                        department = employee.department,
                        fuculity = employee.fuculity,
                        date = DateTime.UtcNow,
                        jobTitle = employee.jobTitle,
                        userName = employee.userName
                    });
                }
            }

            return employees;
        }
        public Employee GetEmployeeById(int id)
        {
            return null;
        } 
        public List<Employee> SearchEmployee(string userName, string departmentName)
        {
            return null;
        }
    }
}
