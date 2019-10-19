using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontPage.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace FrontPage.Controllers
{
    [LoginFilterAttribute]
    public class LoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CurrentLoans()
        {
            return View();
        }

        public IActionResult LoanDetail(int id)
        {
            return View();
        }
    }
}