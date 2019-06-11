using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using VanPiereWebsite.Data.UserData;

namespace VanPiereWebsite.Logic
{
    public class User
    {
        private readonly IConfiguration _configuration;

        public User(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Models.Users.UserModel Login(string username, string password)
        {
            return new UserRepository(_configuration).Login(username, password);
        }

        public Models.Users.UserModel Register(string email, string username, string password)
        {
            return new UserRepository(_configuration).Register(email, username, password);
        }

        public Models.Users.UserModel GetUser(int UserID)
        {
            return new UserRepository(_configuration).GetUser(UserID);
        }

        public void SetUserAdress(Models.Users.UserModel User, string AdressName, string StreetName, int StreetNmbr, string ZipCode, string Country)
        {
            Models.Users.UserModel user = User;
            user.SetAdress(AdressName, StreetName, StreetNmbr, ZipCode, Country);
        }

        public void SetPaymentMethod(Models.Users.UserModel User)
        {
            Models.Users.UserModel user = User;

            bool set = false;

            user.SetPaymentMethod(set);
        }

    }

}
