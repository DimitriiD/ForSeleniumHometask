using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Basic.ui.page_elements
{
    class LoginPageElement
    {
        public string titelLogin { get; set; }

        public LoginPageElement (string titelLogin)
        {
            this.titelLogin = titelLogin;
        }
    }
}
