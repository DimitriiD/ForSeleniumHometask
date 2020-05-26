using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Basic.business_object
{
    class User
    {
        public string login { get; set; }
        public string password { get; set; }

        public User (string login, string password)
        {

            this.login = login;
            this.password = password;

        }
    }
}
