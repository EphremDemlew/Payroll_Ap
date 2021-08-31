using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payroll_Ap.Models;


namespace Payroll_Ap.Views.Repository
{
    public class EmployeeRepository : IEmployeeRepository
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
        public async Task<Employee> AddNewEmployeeById(Employee model)
        {
            var newEmployee = await _context.Employee.FirstOrDefaultAsync(e => e.Id == model.Id);
            if(newEmployee != null)
            {
                newEmployee.Id = model.Id;
                newEmployee.fullName = model.fullName;
                newEmployee.email = model.email;
                newEmployee.phoneNumber = model.phoneNumber;
                newEmployee.gender = model.gender;
                newEmployee.age = model.age;
                newEmployee.salary = model.salary;
                newEmployee.department = model.department;
                newEmployee.fuculity = model.fuculity;
                newEmployee.date = DateTime.UtcNow;
                newEmployee.jobTitle = model.jobTitle;
                newEmployee.userName = model.userName;

                await _context.SaveChangesAsync();

                return newEmployee;
            }

            return null;
          
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            var employees = new List<Employee>();
            var allemployee = await _context.Employee.ToListAsync();
            if (allemployee?.Any() == true)
            {
                foreach (var employee in allemployee)
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
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employees = new List<Employee>();
            var employee = await _context.Employee.FindAsync(id);

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
            return employee;
        }

        public async Task<Employee> GetBookById(int id)
        {
            return await _context.Employee.Where(x => x.Id == id)
                 .Select(emp => new Employee()
                 {
                     Id = emp.Id,
                     fullName = emp.fullName,
                     email = emp.email,
                     phoneNumber = emp.phoneNumber,
                     gender = emp.gender,
                     age = emp.age,
                     salary = emp.salary,
                     department = emp.department,
                     fuculity = emp.fuculity,
                     date = DateTime.UtcNow,
                     jobTitle = emp.jobTitle,
                     userName = emp.userName
                 }).FirstOrDefaultAsync();
        }



        public List<Employee> SearchEmployee(string userName, string departmentName)
        {
            return null;
        }

        //Task<Employee> IEmployeeRepository.AddNewEmployeeById(Employee model)
        //{
        //    var newEmployee =  _context.Employee.FirstOrDefaultAsync(e => e.Id == model.Id);
        //    if (newEmployee != null)
        //    {
        //        newEmployee.Id = model.Id;
        //        newEmployee.fullName = model.fullName;
        //        newEmployee.email = model.email;
        //        newEmployee.phoneNumber = model.phoneNumber;
        //        newEmployee.gender = model.gender;
        //        newEmployee.age = model.age;
        //        newEmployee.salary = model.salary;
        //        newEmployee.department = model.department;
        //        newEmployee.fuculity = model.fuculity;
        //        newEmployee.date = DateTime.UtcNow;
        //        newEmployee.jobTitle = model.jobTitle;
        //        newEmployee.userName = model.userName;

        //         _context.SaveChangesAsync();

        //        return newEmployee;
        //    }

        //    return null;
        //}

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _context.Employee.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Id = employeeChanges.Id;
                employee.fullName = employeeChanges.fullName;
                employee.email = employeeChanges.email;
                employee.phoneNumber = employeeChanges.phoneNumber;
                employee.gender = employeeChanges.gender;
                employee.age = employeeChanges.age;
                employee.salary = employeeChanges.salary;
                employee.department = employeeChanges.department;
                employee.fuculity = employeeChanges.fuculity;
                employee.jobTitle = employeeChanges.jobTitle;
                employee.userName = employeeChanges.userName;
                employee.fullName = employeeChanges.fullName;
                
                
                
                _context.Employee.Update(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _context.Employee.FirstOrDefault(e => e.Id == id);
            if(employee != null)
            {
                _context.Employee.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmp(int id)
        {
            throw new NotImplementedException();
        }

       async Task<int> IEmployeeRepository.AddNewEmployeeById(Employee model)
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
    }
}
