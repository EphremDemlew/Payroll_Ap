using Payroll_Ap.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payroll_Ap.Views.Repository
{
    public interface IEmployeeRepository
    {
        Task<int> AddNewEmployee(Employee model);
        Task<int> AddNewEmployeeById(Employee model);
        Task<List<Employee>> GetAllEmployee();
        Task<Employee> GetEmployeById(int id);
        List<Employee> SearchEmployee(string userName, string departmentName);
        Task<Employee> Update(Employee employeeChanges);
        Employee Delete(int id);


    }
}