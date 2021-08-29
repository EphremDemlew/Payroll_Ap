using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll_Ap.Controllers
{
    [Authorize]

    public class Payment_Parameter : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
