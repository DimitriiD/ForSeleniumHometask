using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Selenium_Basic
{
    class PageHomePage
    {
        private IWebDriver driver;
        public PageHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement homePage => driver.FindElement(By.XPath("//h2[contains(text(),'Home page')]"));
        private IWebElement allProducts => driver.FindElement(By.XPath("//div[2]/div[1]/a[@href='/Product']"));
        public string GetHomePage()
        {
            return homePage.Text;
        }
        public PageAllProducts MoveToAllProducts ()
        {
            allProducts.Click();
            return new PageAllProducts(driver);
        }

    }
}
