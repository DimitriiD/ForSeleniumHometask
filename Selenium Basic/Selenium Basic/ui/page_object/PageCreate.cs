using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium_Basic.business_object;

namespace Selenium_Basic
{
    class PageCreate
    {
        private IWebDriver driver;
        public PageCreate(IWebDriver driver)
        {
            this.driver = driver;
        }
        private string catXpath ;
        private string supXpath ;
        private IWebElement productName => driver.FindElement(By.XPath("//input[@id='ProductName']"));
        private IWebElement categoryId => driver.FindElement(By.XPath(catXpath));
        private IWebElement supplierId => driver.FindElement(By.XPath(supXpath));
        private IWebElement unitPrice => driver.FindElement(By.XPath("//input[@id='UnitPrice']"));
        private IWebElement quantityPerUnit => driver.FindElement(By.XPath("//input[@id='QuantityPerUnit']"));
        private IWebElement unitsInStock => driver.FindElement(By.XPath("//input[@id='UnitsInStock']"));
        private IWebElement unitsOnOrder => driver.FindElement(By.XPath("//input[@id='UnitsOnOrder']"));
        private IWebElement reorderLevel => driver.FindElement(By.XPath("//input[@id='ReorderLevel']"));
        private IWebElement discontinued => driver.FindElement(By.XPath("//input[@id='Discontinued']"));
        private IWebElement buttonCreate => driver.FindElement(By.XPath("//input[@class='btn btn-default']"));
        
        public PageAllProducts CreateNewProduct(ProductForTest productForTest)
        {
            catXpath = $"//select[@id='CategoryId']//option[@value=\"{productForTest.catVal}\"]";
            supXpath = $"//select[@id='SupplierId']//option[@value=\"{productForTest.supVal}\"]";
            productName.SendKeys(productForTest.prName);
            categoryId.Click();
            supplierId.Click();
            unitPrice.SendKeys(productForTest.unPrice);
            quantityPerUnit.SendKeys(productForTest.quPerUnit);
            unitsInStock.SendKeys(productForTest.unInStock);
            unitsOnOrder.SendKeys(productForTest.unOnOrder);
            reorderLevel.SendKeys(productForTest.reLevel);
            if (productForTest.discont == "true")
            {
               discontinued.Click();
            }
            buttonCreate.Click();
            return new PageAllProducts(driver);
        }
        
    }
}
