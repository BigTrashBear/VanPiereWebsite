using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using VanPiereWebsite.Models.Users;
using System.Data.SqlClient;

namespace VanPiereWebsite.Data.UserData
{
    public class UserSQLContext : IUserContext
    {
        private readonly IConfiguration _configuration;
        private SqlConnection _conn;
        private bool firsttimeconn = true;
        private string _connectstring;

        public UserSQLContext(IConfiguration configuration)
        {
            _configuration = configuration;
            SetupConnection(_configuration);
        }

        public UserModel Login(string username, string password)
        {
            UserModel user = null;

            var query = "SELECT UserID, username FROM dbo.Users WHERE username = @username AND password = @password";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            _conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var _UserID = reader.GetInt32(0);
                    var _username = reader.GetString(1);
                    user = new UserModel(_UserID, _username);
                }
            }

            _conn.Close();

            /*if (username == "1234" && password == "1234")
            {
                user = new UserModel(username);
            }*/
            if (user != null)
            {
                user.UserEvents = GetUserAgendaItems(user.UserID);
            }
            return user;
        }

        public UserModel GetUser(int UserID)
        {
            UserModel user = null;

            var query = "SELECT username FROM dbo.Users WHERE UserID = @UserID";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            _conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var _UserID = UserID;
                    var _username = reader.GetString(0);
                    user = new UserModel(_UserID, _username);
                }
            }

            _conn.Close();

            /*if (username == "1234" && password == "1234")
            {
                user = new UserModel(username);
            }*/
            return user;
        }

        public Models.Users.UserModel Register(string email, string username, string password)
        {
            string query = "INSERT INTO dbo.Users (email, username, password) VALUES (@email, @username, @password)";
            SqlCommand cmd = new SqlCommand(query, _conn);

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            _conn.Open();
            cmd.ExecuteNonQuery();
            _conn.Close();

            UserModel user;
            user = Login(username, password);
              
            if (user != null)
            { return user; }
            else
            { return null; }
        }

        private void SetupConnection(IConfiguration configuration)
        {
            if (firsttimeconn)
            {
                SetConnectionString(configuration);
                SetConnection(_connectstring);
                firsttimeconn = false;
            }

        }

        private void SetConnectionString(IConfiguration configuration)
        {
            _connectstring = configuration.GetConnectionString("VanPiere");
        }

        private void SetConnection(string connectionString)
        {
            _conn = new SqlConnection(connectionString);
        }

        private List<Models.AgendaItem> GetUserAgendaItems(int UserID)
        {
            return new AgendaData.AgendaRepository(_configuration).GetUserAgendaItems(UserID);
        }

    }
}
