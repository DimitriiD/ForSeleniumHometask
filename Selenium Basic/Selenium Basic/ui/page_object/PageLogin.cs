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
        private IWebElement loginName => driver.FindElement(By.XPath("//input[@id='Name']"));
        private IWebElement loginPassword => driver.FindElement(By.XPath("//input[@id='Password']"));
        private IWebElement loginButton => driver.FindElement(By.XPath("//input[@class='btn btn-default']"));
        private IWebElement titelLogin => driver.FindElement(By.XPath("//h2[contains(text(),'Login')]"));
        public PageHomePage LoginNwApp (User userdata)
        {
            new Actions(driver).Click(loginName).SendKeys(userdata.login).Build().Perform();
            new Actions(driver).Click(loginPassword).SendKeys(userdata.password).Build().Perform();
            new Actions(driver).Click(loginButton).Build().Perform();
            return new PageHomePage(driver);
        }
        public string TitelLogin()
        {
            return titelLogin.Text;
        }
    }
}
