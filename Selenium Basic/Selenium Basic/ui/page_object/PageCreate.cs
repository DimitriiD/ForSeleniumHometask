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
        private string categoryXpath;
        private string supplierXpath;
        private IWebElement productName => driver.FindElement(By.XPath("//input[@id='ProductName']"));
        private IWebElement categoryId => driver.FindElement(By.XPath(categoryXpath));
        private IWebElement supplierId => driver.FindElement(By.XPath(supplierXpath));
        private IWebElement unitPrice => driver.FindElement(By.XPath("//input[@id='UnitPrice']"));
        private IWebElement quantityPerUnit => driver.FindElement(By.XPath("//input[@id='QuantityPerUnit']"));
        private IWebElement unitsInStock => driver.FindElement(By.XPath("//input[@id='UnitsInStock']"));
        private IWebElement unitsOnOrder => driver.FindElement(By.XPath("//input[@id='UnitsOnOrder']"));
        private IWebElement reorderLevel => driver.FindElement(By.XPath("//input[@id='ReorderLevel']"));
        private IWebElement discontinued => driver.FindElement(By.XPath("//input[@id='Discontinued']"));
        private IWebElement buttonCreate => driver.FindElement(By.XPath("//input[@class='btn btn-default']"));
        
        public PageAllProducts CreateNewProduct(AddProductForTest productForTest)
        {
            categoryXpath = $"//select[@id='CategoryId']//option[@value=\"{productForTest.categoryValue}\"]";
            supplierXpath = $"//select[@id='SupplierId']//option[@value=\"{productForTest.supplierValue}\"]";
            productName.SendKeys(productForTest.productName);
            categoryId.Click();
            supplierId.Click();
            unitPrice.SendKeys(productForTest.unitPrice);
            quantityPerUnit.SendKeys(productForTest.quantityPerUnit);
            unitsInStock.SendKeys(productForTest.unitsInStock);
            unitsOnOrder.SendKeys(productForTest.unitsOnOrder);
            reorderLevel.SendKeys(productForTest.reorderLevel);
            if (productForTest.discontinued == "true")
            {
               discontinued.Click();
            }
            buttonCreate.Click();
            return new PageAllProducts(driver);
        }
        
    }
}
