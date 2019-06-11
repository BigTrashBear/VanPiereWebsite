using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VanPiereWebsite.Controllers.Store
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewFiction()
        {
            return View();
        }

        public IActionResult ViewNonFiction()
        {
            return View();
        }

        public IActionResult ViewYouthBooks()
        {
            return View();
        }

        public IActionResult ViewEBooks()
        {
            return View();
        }
    }
}