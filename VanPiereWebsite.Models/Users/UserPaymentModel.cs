using System;
using System.Collections.Generic;
using System.Text;

namespace VanPiereWebsite.Models.Users
{
    public class UserPaymentModel
    {
        public bool Set { get; private set; }
    
        public UserPaymentModel(bool _Set)
        {
            Set = _Set;
        }
    }
}
