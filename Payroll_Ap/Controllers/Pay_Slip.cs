﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_Ap.Controllers
{
    public class Pay_Slip : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
