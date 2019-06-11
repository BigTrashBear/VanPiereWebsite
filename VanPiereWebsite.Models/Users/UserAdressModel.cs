using System;
using System.Collections.Generic;
using System.Text;

namespace VanPiereWebsite.Models.Users
{
    public class UserAdressModel
    {
        private string UserID { get; set; }
        public string AdressName { get; private set; }
        public string StreetName { get; private set; }
        public int StreetNmbr { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }

        public UserAdressModel(string _UserID, string _AdressName, string _StreetName, int _StreetNmbr, string _ZipCode, string _Country)
        {
            UserID = _UserID;
            AdressName = _AdressName;
            StreetName = _StreetName;
            StreetNmbr = _StreetNmbr;
            ZipCode = _ZipCode;
            Country = _Country;
        }
    }
}
