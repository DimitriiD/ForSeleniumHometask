using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_Basic.business_object;
using Selenium_Basic.service.ui;
using System;

namespace Selenium_Basic.Test
{
    public class BaseTest
    {
        private string baseUrl;
        protected IWebDriver driver;
        public static WebDriverWait wait;
        User user = new User("user", "user");
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            baseUrl = "http://localhost:5000/Account/Login?ReturnUrl=%2F";
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
        [SetUp]
        public void Login()
        {
            WorkWithDataBase.LoginToDataBase(user, driver);
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}

