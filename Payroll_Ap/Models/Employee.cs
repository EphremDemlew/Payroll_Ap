using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_Ap.Models
{

    public class Employee
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required (ErrorMessage ="Please Enter your FullName")]
        public string fullName { get; set; }

        [Required(ErrorMessage = "Please Enter your Email Address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please Enter your Account Number")]
        public long account_number { get; set; }


        [Required(ErrorMessage = "Please Enter your Phone Number")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Please Enter your Gender type")]
        public string gender { get; set; }
        [Required]
        public int age { get; set; }

        [Required]
        public string jobTitle { get; set; }

        [Required]
        public float salary { get; set; }

        [Required]
        public string faculity { get; set; }

        [Required]
        public string department { get; set; }

        public float? advance { get; set; } = 0;
        public float? tax { get; set; } = 0;
        public float pension18 { get; set; } = 0;
        public float? saving { get; set; } = 0;
        public float? guard { get; set; } = 0;
        public float? others { get; set; } = 0;
        public float? ourt { get; set; } = 0;
        public float? totalDeduction { get; set; } = 0;

        public float? annualization { get; set; } = 0;
        public float? allowance { get; set; } = 0;
        public float? houseAllowance { get; set; } = 0;
        public float? gross { get; set; } = 0;
        public float? pension11 { get; set; } = 0;
        public float? totalEarning { get; set; } = 0;


        public float? netSalary { get; set; } = 0;

        public DateTime? date { get; set; }


    }
}
