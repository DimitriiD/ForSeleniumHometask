using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium_Basic.business_object;
using Selenium_Basic.service.ui;

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
        
        public ProductForTest ReadProduct()
        {
            ProductForTest getProductForTest = new ProductForTest(productName.GetAttribute("value"), categoryId.GetAttribute("value"), supplierId.GetAttribute("value"),
               unitPrice.GetAttribute("value").Replace(",0000",""), quantityPerUnit.GetAttribute("value"), unitsInStock.GetAttribute("value"),
               unitsOnOrder.GetAttribute("value"),reorderLevel.GetAttribute("value"), discontinued.GetAttribute("value"));
            return getProductForTest;
        }
    }
}
