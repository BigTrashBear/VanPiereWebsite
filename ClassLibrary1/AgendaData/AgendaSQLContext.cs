using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using VanPiereWebsite.Models;
using Microsoft.Extensions.Configuration;

namespace VanPiereWebsite.Data.AgendaData
{
    class AgendaSQLContext : IAgendaContext
    {
        private readonly IConfiguration _configuration;
        private SqlConnection _conn;
        private bool firsttimeconn = true;
        private string _connectstring;
        private List<AgendaItem> agendaItems { get; set; }

        public AgendaSQLContext(IConfiguration configuration)
        {
            _configuration = configuration;
            SetupConnection(_configuration);
        }

        public List<AgendaItem> GetHomeAgenda()
        {
            agendaItems = new List<AgendaItem>();

            string dateNow = DateTime.Now.ToShortDateString();

            var query = "SELECT * FROM dbo.Events WHERE ItemDate >= @dateNow";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@dateNow", dateNow);

            _conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int eventID = reader.GetInt32(0);
                    string eventName = reader.GetString(1);
                    string eventCat = reader.GetString(2);
                    DateTime eventDate = reader.GetDateTime(3);
                    string ShortDesc = reader.GetString(4);
                    string LongDesc = reader.GetString(5);
                    string HostName = reader.GetString(6);
                    string HostInfo = reader.GetString(7);

                    agendaItems.Add(new AgendaItem(eventID, eventName, eventCat, eventDate.ToShortDateString(), ShortDesc, LongDesc, HostName, HostInfo, "dbtest"));
                }
            }

            _conn.Close();
            return agendaItems;
        }

        public AgendaItem GetAgendaItem(int _eventID)
        {
            AgendaItem item = null;
            var query = "SELECT * FROM dbo.Events WHERE ItemID = @_eventID";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@_eventID", _eventID);

            _conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int eventID = reader.GetInt32(0);
                    string eventName = reader.GetString(1);
                    string eventCat = reader.GetString(2);
                    DateTime eventDate = reader.GetDateTime(3);
                    string ShortDesc = reader.GetString(4);
                    string LongDesc = reader.GetString(5);
                    string HostName = reader.GetString(6);
                    string HostInfo = reader.GetString(7);
                    item = new AgendaItem(eventID, eventName, eventCat, eventDate.ToShortDateString(), ShortDesc, LongDesc, HostName, HostInfo, "dbtest");
                }
            }

            _conn.Close();
            return item;
        }

        public void RegisterUser(int EventID, int UserID)
        {
            var query = "INSERT INTO dbo.EventRegistrations(EventID, UserID) VALUES (@EventID, @UserID)";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@EventID", EventID);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            _conn.Open();
            cmd.ExecuteNonQuery();
            _conn.Close();

        }

        public void RemoveUser(int EventID, int UserID)
        {
            var query = "DELETE FROM dbo.EventRegistrations WHERE EventID = @EventID AND UserID = @UserID";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@EventID", EventID);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            _conn.Open();
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public List<Models.Users.UserModel> GetRegisteredUsers(int EventID)
        {
            List<int> UserKeys = new List<int>();

            var query1 = "SELECT UserID FROM dbo.EventRegistrations WHERE EventID = @EventID";
            var cmd1 = new SqlCommand(query1, _conn);
            cmd1.Parameters.AddWithValue("@EventID", EventID);

            _conn.Open();
            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                while (reader.Read())
                {
                    var UserKey = reader.GetInt32(0);
                    UserKeys.Add(UserKey);
                }
            }
            _conn.Close();

            List<Models.Users.UserModel> RegisteredUsers = new List<Models.Users.UserModel>();
            foreach (var Key in UserKeys)
            {
                RegisteredUsers.Add(new UserData.UserRepository(_configuration).GetUser(Key));
            }

            return RegisteredUsers;
        }

        public List<AgendaItem> GetUserAgendaItems(int UserID)
        {
            List<int> EventKeys = new List<int>();

            var query1 = "SELECT EventID FROM dbo.EventRegistrations WHERE UserID = @UserID";
            var cmd1 = new SqlCommand(query1, _conn);
            cmd1.Parameters.AddWithValue("@UserID", UserID);

            _conn.Open();
            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                while (reader.Read())
                {
                    var EventKey = reader.GetInt32(0);
                    EventKeys.Add(EventKey);
                }
            }
            _conn.Close();

            List<AgendaItem> UserEvents = new List<AgendaItem>();

            foreach (var Key in EventKeys)
            {
                UserEvents.Add(GetAgendaItem(Key));
            }

            return UserEvents;
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
    }
}
