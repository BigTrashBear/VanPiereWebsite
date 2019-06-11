using System;
using System.Collections.Generic;
using System.Text;
using VanPiereWebsite.Models;

namespace VanPiereWebsite.Data.UserData
{
    public interface IUserContext
    {
        Models.Users.UserModel Login(string username, string password);
        Models.Users.UserModel GetUser(int UserID);
        Models.Users.UserModel Register(string email, string username, string password);
    }
}
