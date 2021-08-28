﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payroll_Ap.Models;

namespace Payroll_Ap.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<FinanceStaff> FinanceStaffs { get; set; }
        public DbSet<Payroll>Payrolls { get; set; }
        public DbSet<Tax> Taxs { get; set; }
    }
}
