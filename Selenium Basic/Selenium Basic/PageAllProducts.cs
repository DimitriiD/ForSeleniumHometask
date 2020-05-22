using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
namespace Selenium_Basic
{
    class PageAllProducts
    {
        private IWebDriver driver;
        public PageAllProducts(IWebDriver driver)
        {
            this.driver = driver;
        }
        private string proXpath = "//a[contains(text(),'addfortest')]";
        private string proXPathForRem = "//following-sibling::tr/td[contains(.,'addfortest')]/../td/a[contains(text(),'Remove')]";
        private IWebElement create => driver.FindElement(By.XPath("//a[@href='/Product/Create']"));
        private IWebElement allProducts => driver.FindElement(By.XPath("//h2[contains(text(),'All Products')]"));
        private IWebElement productName => driver.FindElement(By.XPath(proXpath));
        private IWebElement productRemove => driver.FindElement(By.XPath(proXPathForRem));
        private IWebElement lgout => driver.FindElement(By.XPath("//a[@href='/Account/Logout']"));

        public PageCreate MoveToCreate()
        {
            create.Click();
            return new PageCreate(driver);
        }
        public PageEditProduct MoveToProduct(string nProd)
        {
            proXpath = "//a[contains(text(),'" + nProd + "')]";
            productName.Click();
            return new PageEditProduct(driver);
        }
        public string GetAllProducts()
        {
            return (allProducts.Text);
        }
        public void RemoveProduct (string nProd)
        {
            proXPathForRem = "//following-sibling::tr/td[contains(.,'" + nProd + "')]/../td/a[contains(text(),'Remove')]";
            productRemove.Click();
            driver.SwitchTo().Alert().Accept();
        }
        public string XpathProduct (string nProd)
        {
            return proXpath = "//a[contains(text(),'" + nProd + "')]";
        }
        public PageLogin Logout ()
        {
            lgout.Click();
            return new PageLogin(driver);
        }
    }
}
