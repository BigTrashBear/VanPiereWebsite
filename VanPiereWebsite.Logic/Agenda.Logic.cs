using System;
using System.Collections.Generic;
using System.Text;
using VanPiereWebsite.Models;
using Microsoft.Extensions.Configuration;
using VanPiereWebsite.Data.AgendaData;

namespace VanPiereWebsite.Logic
{
    public class Agenda
    {
        private IConfiguration _configuration;

        public Agenda(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<AgendaItem> GetHomeAgenda()
        {
            return new AgendaRepository(_configuration).GetHomeAgenda();
        }

        public AgendaItem GetAgendaItem(int eventID)
        {
            return new AgendaRepository(_configuration).GetAgendaItem(eventID);
        }

        public void RegisterUser(int EventID, int UserID)
        {
            new AgendaRepository(_configuration).RegisterUser(EventID, UserID);
        }

        public void RemoveUser(int EventID, int UserID)
        {
            new AgendaRepository(_configuration).RemoveUser(EventID, UserID);
        }

        public List<Models.Users.UserModel> GetRegisteredUsers(int EventID)
        {
            return new AgendaRepository(_configuration).GetRegisteredUsers(EventID);
        }
    }
}
