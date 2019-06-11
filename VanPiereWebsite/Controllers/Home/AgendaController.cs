using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace VanPiereWebsite.Controllers.Home
{
    public class AgendaController : Controller
    {
        private IConfiguration _configuration;

        public AgendaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult ViewEvent(int eventID)
        {
            var agendaItem = new Logic.Agenda(_configuration).GetAgendaItem(eventID);
            agendaItem.SetRegisteredUsers(new Logic.Agenda(_configuration).GetRegisteredUsers(eventID));

            return View(agendaItem);
        }

        public IActionResult RegisterUser(int EventID, int UserID)
        {
            new Logic.Agenda(_configuration).RegisterUser(EventID, UserID);

            return RedirectToAction("ViewEvent", new { eventID = EventID });
        }

        public IActionResult RemoveUser(int EventID, int UserID)
        {
            new Logic.Agenda(_configuration).RemoveUser(EventID, UserID);

            return RedirectToAction("ViewEvent", new { eventID = EventID });
        }
    }
}