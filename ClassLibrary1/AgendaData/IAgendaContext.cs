using System;
using System.Collections.Generic;
using System.Text;
using VanPiereWebsite.Models;

namespace VanPiereWebsite.Data.AgendaData
{
    interface IAgendaContext
    {
        List<AgendaItem> GetHomeAgenda();
        AgendaItem GetAgendaItem(int eventID);
        void RegisterUser(int EventID, int UserID);
        void RemoveUser(int EventID, int UserID);
        List<Models.Users.UserModel> GetRegisteredUsers(int EventID);
        List<AgendaItem> GetUserAgendaItems(int UserID);
    }
}
