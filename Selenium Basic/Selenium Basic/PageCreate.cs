using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Selenium_Basic
{
    class PageCreate
    {
        private IWebDriver driver;
        public PageCreate(IWebDriver driver)
        {
            this.driver = driver;
        }
        private string catXpath = "//select[@id='CategoryId']//option[@value='2']";
        private string supXpath = "//select[@id='SupplierId']//option[@value='3']";
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
        
        public PageAllProducts CreateNewProduct(string pName, string catV, string supV, string uPrice,
             string qPerUnit, string uInStock, string uOnOrder, string rLevel, string discont)
        {
            catXpath = "//select[@id='CategoryId']//option[@value='" + catV + "']";
            supXpath = "//select[@id='SupplierId']//option[@value='" + supV + "']";
            productName.SendKeys(pName);
            categoryId.Click();
            supplierId.Click();
            unitPrice.SendKeys(uPrice);
            quantityPerUnit.SendKeys(qPerUnit);
            unitsInStock.SendKeys(uInStock);
            unitsOnOrder.SendKeys(uOnOrder);
            reorderLevel.SendKeys(rLevel);
            if (discont == "true")
            {
               discontinued.Click();
            }
            buttonCreate.Click();
            return new PageAllProducts(driver);
        }
        
    }
}
