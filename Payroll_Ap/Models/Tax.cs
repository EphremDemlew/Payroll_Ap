using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_Ap.Models
{
    public class Tax
    {
        [Key]
        public int Id { get; set; }
        public int initSalary { get; set; }
        [Required]
        public int finalSalary { get; set; }
        [Required]
        public int taxRate { get; set; }
        [Required]
        public float Deduction { get; set; }
       
    }
}
