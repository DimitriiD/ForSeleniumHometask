using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium_Basic.business_object;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Selenium_Basic
{
    class PageLogin
    {
        private IWebDriver driver;
        public PageLogin(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement logName => driver.FindElement(By.XPath("//input[@id='Name']"));
        private IWebElement logPassword => driver.FindElement(By.XPath("//input[@id='Password']"));
        private IWebElement logButton => driver.FindElement(By.XPath("//input[@class='btn btn-default']"));
        private IWebElement ttelLogin => driver.FindElement(By.XPath("//h2[contains(text(),'Login')]"));
        public PageHomePage LoginNwApp (User userdata)
        {
            new Actions(driver).Click(logName).SendKeys(userdata.login).Build().Perform();
            new Actions(driver).Click(logPassword).SendKeys(userdata.password).Build().Perform();
            new Actions(driver).Click(logButton).Build().Perform();
            return new PageHomePage(driver);
        }
        public string TitelLogin()
        {
            return ttelLogin.Text;
        }
    }
}
