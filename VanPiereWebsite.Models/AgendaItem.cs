using System;
using System.Collections.Generic;
using System.Text;

namespace VanPiereWebsite.Models
{
    public class AgendaItem
    {
        public int EventID { get; private set; }
        public string Name { get; private set; }
        public string Category { get; private set; }
        public DateTime Date { get; private set; }
        public string ShortDesc { get; private set; }
        public string LongDesc { get; private set; }
        public string HostName { get; private set; }
        public string HostInfo { get; private set; }
        public string ImgLink { get; private set; }
        public List<Users.UserModel> RegisteredUsers { get; set; }

        public AgendaItem(int _EventID, string _Name, string _Category, string _Date, string _ShortDesc, string _LongDesc, string _HostName, string _HostInfo, string _ImgLink)
        {
            EventID = _EventID;
            Name = _Name;
            Category = _Category;
            Date = ConvertDateString(_Date);
            ShortDesc = _ShortDesc;
            LongDesc = _LongDesc;
            HostName = _HostName;
            HostInfo = _HostInfo;
            ImgLink = _ImgLink;
            RegisteredUsers = new List<Users.UserModel>();
        }

        private DateTime ConvertDateString(string _Date)
        {
            return Convert.ToDateTime(_Date);
        }

        public void SetRegisteredUsers(List<Models.Users.UserModel> Users)
        {
            RegisteredUsers = Users;
        }
    }
}
