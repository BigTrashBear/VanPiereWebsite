using System;
using System.Collections.Generic;
using System.Text;

namespace VanPiereWebsite.Models.Users
{
    public class UserModel
    {
        public List<UserAdressModel> Adresses { get; private set; }
        public List<UserPaymentModel> PaymentMethods { get; private set; }
        public List<AgendaItem> UserEvents { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }

        public UserModel(int _UserID, string _UserName)
        {
            UserID = _UserID;
            UserName = _UserName;
        }

        public void SetAdress(string AdressName, string StreetName, int StreetNmbr, string ZipCode, string Country)
        {
            Adresses.Add(new UserAdressModel(UserName, AdressName, StreetName, StreetNmbr, ZipCode, Country));
        }

        public void SetPaymentMethod(bool set)
        {
            PaymentMethods.Add(new UserPaymentModel(set));
        }
    }
}
