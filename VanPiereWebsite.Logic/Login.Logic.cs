using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace VanPiereWebsite.Logic
{
    public class Login
    {
        private readonly IConfiguration _configuration;

        public Login(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
