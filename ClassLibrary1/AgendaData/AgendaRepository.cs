using System;
using System.Collections.Generic;
using System.Text;
using VanPiereWebsite.Models;
using Microsoft.Extensions.Configuration;

namespace VanPiereWebsite.Data.AgendaData
{
    public class AgendaRepository
    {
        private IAgendaContext _context;

        public AgendaRepository(IConfiguration configuration)
        {
            _context = new AgendaSQLContext(configuration);
        }

        public List<AgendaItem> GetHomeAgenda()
        {
            return _context.GetHomeAgenda();
        }

        public AgendaItem GetAgendaItem(int eventID)
        {
            return _context.GetAgendaItem(eventID);
        }

        public void RegisterUser(int EventID, int UserID)
        {
            _context.RegisterUser(EventID, UserID);
        }

        public void RemoveUser(int EventID, int UserID)
        {
            _context.RemoveUser(EventID, UserID);
        }
        
        public List<Models.Users.UserModel> GetRegisteredUsers(int EventID)
        {
            return _context.GetRegisteredUsers(EventID);
        }

        public List<AgendaItem> GetUserAgendaItems(int UserID)
        {
            return _context.GetUserAgendaItems(UserID);
        }
    }
}
