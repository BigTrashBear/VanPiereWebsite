using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VanPiereWebsite.Logic;
using VanPiereWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace VanPiereWebsite.Controllers.Home
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly Login logic;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
            logic = new Login(_configuration);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string username, string password)
        {
            if (HttpContext.Session.GetString("currentUser") != null)
            {
                TempData["Message"] =  "already logged in!";
                return RedirectToAction("Index", "Home", TempData);
            }

            var user = new User(_configuration).Login(username, password);

            if (user == null)
            {
                TempData["Message"]= "details incorrect!";
                return RedirectToAction("Index", "Home", TempData);
            }

            HttpContext.Session.SetString("currentUser", JsonConvert.SerializeObject(user));
            return View("LoginSucceeded");
        }

        public IActionResult Logout()
        {
            var userJson = HttpContext.Session.GetString("currentUser");
            var user = JsonConvert.DeserializeObject<Models.Users.UserModel>(userJson);

            TempData["Message"] = $"{user.UserName} just logged out";
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home", TempData);
        }

        public IActionResult LoginSucceeded()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}