using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_Ap.Models
{
    public class Payroll
    {

        public int Id { get; set; }
        [Required]
        public string Gross { get; set; }
        [Required]
        public float Allowance { get; set; }
        [Required]
        public float Deduction { get; set; }
        [Required]
        public int Absent { get; set; }
        [Required]
        public float NetSalary { get; set; }
    }
}
