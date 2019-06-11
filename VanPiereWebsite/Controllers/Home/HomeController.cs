using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace VanPiereWebsite.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];

            List<Models.AgendaItem> homeAgenda = new Logic.Agenda(_configuration).GetHomeAgenda();

            return View(homeAgenda);
        }
    }
}