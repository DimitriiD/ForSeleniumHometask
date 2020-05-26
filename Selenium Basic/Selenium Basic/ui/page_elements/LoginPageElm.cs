using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Basic.ui.page_elements
{
    class LoginPageElm
    {
        public string ttlLogin { get; set; }

        public LoginPageElm (string ttlLogin)
        {
            this.ttlLogin = ttlLogin;
        }
    }
}
