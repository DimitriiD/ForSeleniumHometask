using OpenQA.Selenium;
using Selenium_Basic.business_object;

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
        public PageEditProduct MoveToProduct(ProductForTest productForTest)
        {
            proXpath = $"//a[contains(text(),\"{productForTest.prName }\")]";
            productName.Click();
            return new PageEditProduct(driver);
        }
        public string GetAllProducts()
        {
            return (allProducts.Text);
        }
        public void RemoveProduct (ProductForTest productForTest)
        {
            proXPathForRem = $"//following-sibling::tr/td[contains(.,\"{productForTest.prName }\")]/../td/a[contains(text(),'Remove')]";
            productRemove.Click();
            driver.SwitchTo().Alert().Accept();
        }
        public string xpathProduct (ProductForTest productForTest)
        {
            return proXpath = $"//a[contains(text(),\"{productForTest.prName }\")]";
        }
        public PageLogin Logout ()
        {
            lgout.Click();
            return new PageLogin(driver);
        }
    }
}
