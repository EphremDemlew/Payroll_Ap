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
        [Required]
        public string fullName { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string jobTitle { get; set; }
        [Required]
        public float salary { get; set; }
        [Required]
        public string fuculity { get; set; }
        [Required]
        public string department { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        
        public string email { get; set; }
        [Required]
        public DateTime date { get; set; }
    }
}
