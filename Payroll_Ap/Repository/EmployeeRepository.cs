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
            float tx = 0;
            if (model.salary <= 600 && model.salary > 0)
            {
                tx = 0;
            }
            else if(model.salary <= 1650 && model.salary > 600)
            {
                tx = (float)(model.salary * 0.1);
            }
            else if (model.salary <= 3200 && model.salary > 1650)
            {
                tx = (float)(model.salary * 0.15);
            }
            else if (model.salary <= 5250 && model.salary > 3200)
            {
                tx = (float)(model.salary * 0.2);
            }
            else if (model.salary <= 7800 && model.salary > 5250)
            {
                tx = (float)(model.salary * 0.25);
            }
            else if(model.salary <= 10900 && model.salary > 7800)
            {
                tx = (float)(model.salary * 0.3);
            }
            else
            {
                tx = (float)(model.salary * 0.35);

            }


            float pen18 = (float)(model.salary * 0.18);
            float pen11 = (float)(model.salary * 0.11);

            float anual = (float)(model.salary * 0.2);


            float gros = ((float)(model.allowance + model.houseAllowance + anual + model.salary));



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
                faculity = model.faculity,
                date = DateTime.UtcNow,
                jobTitle = model.jobTitle,
                account_number = model.account_number,


                advance = model.advance,
                tax = tx,
                pension18 = pen18,
                saving = model.saving,
                guard = model.guard,
                others = model.others,
                ourt = model.ourt,
                totalDeduction = (model.advance + tx + model.guard + model.others + model.ourt + pen18),


                annualization = anual,
                allowance = model.allowance,
                houseAllowance = model.houseAllowance,
                gross = gros,
                pension11 = pen11,
                totalEarning = (gros + pen11 ),

                netSalary = ((gros + pen11)  - (model.advance + tx + model.guard + model.others + model.ourt + pen18))


            };

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return newEmployee.Id;
        }


        public async Task<List<Employee>> GetAllEmployee()
        {
            var employees = new List<Employee>();
            var allemployee = await _context.Employees.ToListAsync();
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
                        faculity = employee.faculity,
                        date = DateTime.UtcNow,
                        jobTitle = employee.jobTitle,
                        account_number = employee.account_number,
                        annualization = employee.annualization,
                        gross = employee.gross,
                        pension11 = employee.pension11,
                        totalEarning = employee.totalEarning,
                        tax = employee.tax,
                        pension18 = employee.pension18,
                        totalDeduction = employee.totalDeduction,
                        netSalary = employee.netSalary



                    });
                }
            }

            return employees;
        }


        public async Task<Employee> GetEmployeById(int id)
        {
            return await _context.Employees.Where(x => x.Id == id)
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
                     faculity = emp.faculity,
                     date = DateTime.UtcNow,
                     jobTitle = emp.jobTitle,
                     account_number = emp.account_number,
                     advance = emp.advance,
                     others = emp.others,
                     saving = emp.saving,
                     ourt = emp.ourt,
                     guard = emp.guard,
                     allowance = emp.houseAllowance,
                     houseAllowance = emp.houseAllowance


                 }).FirstOrDefaultAsync();
        }


        public List<Employee> SearchEmployee(string userName, string departmentName)
        {
            return null;
        }


        public async Task<Employee> Update(Employee employeeChanges)
        {
            Employee employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeChanges.Id);

            float tx = 0;
            if (employeeChanges.salary <= 600 && employeeChanges.salary > 0)
            {
                tx = 0;
            }
            else if (employeeChanges.salary <= 1650 && employeeChanges.salary > 600)
            {
                tx = (float)(employeeChanges.salary * 0.1);
            }
            else if (employeeChanges.salary <= 3200 && employeeChanges.salary > 1650)
            {
                tx = (float)(employeeChanges.salary * 0.15);
            }
            else if (employeeChanges.salary <= 5250 && employeeChanges.salary > 3200)
            {
                tx = (float)(employeeChanges.salary * 0.2);
            }
            else if (employeeChanges.salary <= 7800 && employeeChanges.salary > 5250)
            {
                tx = (float)(employeeChanges.salary * 0.25);
            }
            else if (employeeChanges.salary <= 10900 && employeeChanges.salary > 7800)
            {
                tx = (float)(employeeChanges.salary * 0.3);
            }
            else
            {
                tx = (float)(employeeChanges.salary * 0.35);

            }


            float pen18 = (float)(employeeChanges.salary * 0.18);
            float pen11 = (float)(employeeChanges.salary * 0.11);

            float anual = (float)(employeeChanges.salary * 0.2);


            float gros = ((float)(employeeChanges.allowance + employeeChanges.houseAllowance + anual + employeeChanges.salary));
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
                employee.faculity = employeeChanges.faculity;
                employee.jobTitle = employeeChanges.jobTitle;
                employee.account_number = employeeChanges.account_number;

                employee.advance = employeeChanges.advance;
                employee.tax = tx;
                employee.pension18 = pen18;
                employee.saving = employeeChanges.saving;
                employee.guard = employeeChanges.guard;
                employee.others = employeeChanges.others;
                employee.ourt = employeeChanges.ourt;
                employee.totalDeduction = (employeeChanges.advance + tx + employeeChanges.guard + employeeChanges.others + employeeChanges.ourt + pen18);


                employee.annualization = anual;
                employee.allowance = employeeChanges.allowance;
                employee.houseAllowance = employeeChanges.houseAllowance;
                employee.gross = gros;
                employee.pension11 = pen11;
                employee.totalEarning = (gros + pen11);

                employee.netSalary = ((gros + pen11) - (employeeChanges.advance + tx + employeeChanges.guard + employeeChanges.others + employeeChanges.ourt + pen18));



                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
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
                faculity = model.faculity,
                date = DateTime.UtcNow,
                jobTitle = model.jobTitle,
                account_number = model.account_number
            };

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return newEmployee.Id;
        }



    }
}
