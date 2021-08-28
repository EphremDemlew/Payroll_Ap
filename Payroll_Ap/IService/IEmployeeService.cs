using Payroll_Ap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_Ap.IService
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployee();
        Employee GetById(int Id);
        void Save(Employee oEmployee);
        void Update(Employee oEmployee);
        String Delete(int Id);

    }
}
