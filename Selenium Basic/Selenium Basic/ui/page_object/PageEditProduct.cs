using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Selenium_Basic
{
    class PageEditProduct
    {
        private IWebDriver driver;
        public PageEditProduct(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement productName => driver.FindElement(By.XPath("//input[@id='ProductName']"));
        private IWebElement categoryId => driver.FindElement(By.XPath("//select[@id='CategoryId']//option[@selected='selected']"));
        private IWebElement supplierId => driver.FindElement(By.XPath("//select[@id='SupplierId']//option[@selected='selected']"));
        private IWebElement unitPrice => driver.FindElement(By.XPath("//input[@id='UnitPrice']"));
        private IWebElement quantityPerUnit => driver.FindElement(By.XPath("//input[@id='QuantityPerUnit']"));
        private IWebElement unitsInStock => driver.FindElement(By.XPath("//input[@id='UnitsInStock']"));
        private IWebElement unitsOnOrder => driver.FindElement(By.XPath("//input[@id='UnitsOnOrder']"));
        private IWebElement reorderLevel => driver.FindElement(By.XPath("//input[@id='ReorderLevel']"));
        private IWebElement discontinued => driver.FindElement(By.XPath("//input[@id='Discontinued']"));
        public string GetProductName ()
        {
            return productName.GetAttribute("value");
        }
        public string GetCategoryId()
        {
            return categoryId.GetAttribute("value");
        }
        public string GetSupplierId()
        {
            return supplierId.GetAttribute("value");
        }
        public string GetUnitPrice()
        {
            return unitPrice.GetAttribute("value");
        }
        public string GetQuantityPerUnit()
        {
            return quantityPerUnit.GetAttribute("value");
        }
        public string GetUnitsInStock()
        {
            return unitsInStock.GetAttribute("value");
        }
        public string GetUnitsOnOrder()
        {
            return unitsOnOrder.GetAttribute("value");
        }
        public string GetReorderLevel()
        {
            return reorderLevel.GetAttribute("value");
        }
        public string GetDiscontinued()
        {
            return discontinued.GetAttribute("value");
        }
    }
}
