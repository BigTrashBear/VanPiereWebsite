using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace VanPiereWebsite.Data.UserData
{
    public class UserRepository
    {
        private IUserContext _context;

        public UserRepository(IConfiguration configuration)
        {
            _context = new UserSQLContext(configuration);
        }

        public Models.Users.UserModel Login(string username, string password)
        {
            return _context.Login(username, password);
        }

        public Models.Users.UserModel GetUser(int UserID)
        {
            return _context.GetUser(UserID);
        }

        public Models.Users.UserModel Register(string email, string username, string password)
        {
            return _context.Register(email, username, password);
        }
    }
}
