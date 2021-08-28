using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_Ap.Models
{
    public class SignUpEmployeeModel 
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required (ErrorMessage ="Please enter Email")]
        [Display(Name ="Email address ")]
        [EmailAddress (ErrorMessage ="Please enter a valid email")]
        public string  Email { get; set; }

        [Required(ErrorMessage = "Please Enter a strong Password")]
        [Compare("ConfirmPassword", ErrorMessage ="Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)] 
        public string ConfirmPassword { get; set; }

    }
}
