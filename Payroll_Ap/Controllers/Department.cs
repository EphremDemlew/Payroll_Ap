﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Payroll_Ap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_Ap.Controllers
{
    [Authorize]
    public class Department : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
