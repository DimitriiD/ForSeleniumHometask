using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Selenium_Basic
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public bool IsElementPresent(By xpath)
        {
            try
            {
                return driver.FindElement(xpath).Displayed;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Login?ReturnUrl=%2F");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.FindElement(By.XPath("//input[@id='Name']")).SendKeys("user");
            driver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("user");
            driver.FindElement(By.XPath("//input[@class='btn btn-default']")).Click();
        }
        [Test,Order(1)]
        public void Testlogandcreat()
        {
            var element = driver.FindElement(By.XPath("//h2[contains(text(),'Home page')]"));
            Assert.IsTrue("Home page"== element.Text);
            driver.FindElement(By.XPath("//div[2]/div[1]/a[@href='/Product']")).Click();
            driver.FindElement(By.XPath("//a[@href='/Product/Create']")).Click();
            driver.FindElement(By.XPath("//input[@id='ProductName']")).SendKeys("addfortest");
            driver.FindElement(By.XPath("//select[@id='CategoryId']//option[@value='2']")).Click();
            driver.FindElement(By.XPath("//select[@id='SupplierId']//option[@value='3']")).Click();
            driver.FindElement(By.XPath("//input[@id='UnitPrice']")).SendKeys("300");
            driver.FindElement(By.XPath("//input[@id='QuantityPerUnit']")).SendKeys("35");
            driver.FindElement(By.XPath("//input[@id='UnitsInStock']")).SendKeys("1");
            driver.FindElement(By.XPath("//input[@id='UnitsOnOrder']")).SendKeys("1321");
            driver.FindElement(By.XPath("//input[@id='ReorderLevel']")).SendKeys("1");
            driver.FindElement(By.XPath("//input[@id='Discontinued']")).Click();
            driver.FindElement(By.XPath("//input[@class='btn btn-default']")).Click();
            element = driver.FindElement(By.XPath("//h2[contains(text(),'All Products')]"));
            Assert.IsTrue("All Products" == element.Text);
        }
        [Test, Order(2)]
        public void TestOpenProduct()
        {
            driver.FindElement(By.XPath("//div[2]/div[1]/a[@href='/Product']")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'addfortest')]")).Click();
            var element = driver.FindElement(By.XPath("//input[@id='ProductName']"));
            Assert.IsTrue("addfortest" == element.GetAttribute("value"));
            element = driver.FindElement(By.XPath("//select[@id='CategoryId']//option[@selected='selected']"));
            Assert.IsTrue("2" == element.GetAttribute("value"));
            element = driver.FindElement(By.XPath("//select[@id='SupplierId']//option[@selected='selected']"));
            Assert.IsTrue("3" == element.GetAttribute("value"));
            element = driver.FindElement(By.XPath("//input[@id='UnitPrice']"));
            Assert.IsTrue("300,0000" == element.GetAttribute("value"));
            element = driver.FindElement(By.XPath("//input[@id='QuantityPerUnit']"));
            Assert.IsTrue("35" == element.GetAttribute("value"));
            element = driver.FindElement(By.XPath("//input[@id='UnitsInStock']"));
            Assert.IsTrue("1" == element.GetAttribute("value"));
            element = driver.FindElement(By.XPath("//input[@id='UnitsOnOrder']"));
            Assert.IsTrue("1321" == element.GetAttribute("value"));
            element = driver.FindElement(By.XPath("//input[@id='ReorderLevel']"));
            Assert.IsTrue("1" == element.GetAttribute("value"));
            element = driver.FindElement(By.XPath("//input[@id='Discontinued']"));
            Assert.IsTrue("true" == element.GetAttribute("value"));
        }
        [Test, Order(3)]
        public void TestDeleteLogout()
        {
            driver.FindElement(By.XPath("//div[2]/div[1]/a[@href='/Product']")).Click();
            driver.FindElement(By.XPath("//following-sibling::tr/td[contains(.,'addfortest')]/../td/a[contains(text(),'Remove')]")).Click();
            driver.SwitchTo().Alert().Accept();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//td[contains(.,'addfortest')]")));
            Assert.False(IsElementPresent(By.XPath("//td[contains(.,'addfortest')]")));
            driver.FindElement(By.XPath("//a[@href='/Account/Logout']")).Click();
            var element = driver.FindElement(By.XPath("//h2[contains(text(),'Login')]"));
            Assert.IsTrue("Login" == element.Text);
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}