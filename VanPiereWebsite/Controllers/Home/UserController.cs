using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace VanPiereWebsite.Controllers.Home
{
    public class UserController : Controller
    {
        private Logic.User logic;
        private IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
            logic = new Logic.User(_configuration);
        }

        public IActionResult ViewUserProfile()
        {
            return View();
        }

        public void AddAdress(string adressname, string streetname, string streetnmbr, string zipcode, string country)
        {
            string check = adressname;
        }

        public IActionResult ViewRegister()
        {
            return View("RegisterUser");
        }

        public IActionResult CompleteRegistration(string email, string username, string password)
        {
            Models.Users.UserModel user;

            if (logic.Register(email, username, password) !=  null)
            {
                user = new Logic.User(_configuration).Register(email, username, password);

                HttpContext.Session.SetString("currentUser", JsonConvert.SerializeObject(user));
            }

            return RedirectToAction("Index", "Home");           
        }
    }
}