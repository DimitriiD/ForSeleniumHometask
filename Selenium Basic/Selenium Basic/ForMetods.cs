using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_Basic
{
   class ForMetods
    {
        private IWebDriver driver;
        public ForMetods(IWebDriver driver)
        {
            this.driver = driver;
        }
        public bool IsElementPresent(By xpath)
        {
            try
            {
                return driver.FindElement(xpath).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
