using OpenQA.Selenium;
using Selenium_Basic.business_object;

namespace Selenium_Basic.service.ui
{
    class GetData
    {
        public static string GetHomePage(ProductForTest productToAdd, IWebDriver driver)
        {
            PageHomePage pageHomePage = new PageHomePage(driver);
            return pageHomePage.GetHomePage();
        }
        public static string GetAllProducts(ProductForTest productToAdd, IWebDriver driver)
        {
            PageAllProducts pageAllProducts = new PageAllProducts(driver);
            return pageAllProducts.GetAllProducts();
        }
        public static string GetProductName(ProductForTest productToAdd, IWebDriver driver)
        {
            PageEditProduct pageEditProduct = new PageEditProduct(driver);
            return pageEditProduct.GetProductName();
        }
        public static string GetCategoryId(ProductForTest productToAdd, IWebDriver driver)
        {
            PageEditProduct pageEditProduct = new PageEditProduct(driver);
            return pageEditProduct.GetCategoryId();
        }
        public static string GetSupplierId(ProductForTest productToAdd, IWebDriver driver)
        {
            PageEditProduct pageEditProduct = new PageEditProduct(driver);
            return pageEditProduct.GetSupplierId();
        }
        public static string GetUnitPrice(ProductForTest productToAdd, IWebDriver driver)
        {
            PageEditProduct pageEditProduct = new PageEditProduct(driver);
            return pageEditProduct.GetUnitPrice();
        }
        public static string GetQuantityPerUnit(ProductForTest productToAdd, IWebDriver driver)
        {
            PageEditProduct pageEditProduct = new PageEditProduct(driver);
            return pageEditProduct.GetQuantityPerUnit();
        }
        public static string GetUnitsInStock(ProductForTest productToAdd, IWebDriver driver)
        {
            PageEditProduct pageEditProduct = new PageEditProduct(driver);
            return pageEditProduct.GetUnitsInStock();
        }
        public static string GetUnitsOnOrder(ProductForTest productToAdd, IWebDriver driver)
        {
            PageEditProduct pageEditProduct = new PageEditProduct(driver);
            return pageEditProduct.GetUnitsOnOrder();
        }
        public static string GetReorderLevel(ProductForTest productToAdd, IWebDriver driver)
        {
            PageEditProduct pageEditProduct = new PageEditProduct(driver);
            return pageEditProduct.GetReorderLevel();
        }
        public static string GetDiscontinued(ProductForTest productToAdd, IWebDriver driver)
        {
            PageEditProduct pageEditProduct = new PageEditProduct(driver);
            return pageEditProduct.GetDiscontinued();
        }
        public static string TitelLogin(ProductForTest productToAdd, IWebDriver driver)
        {
            PageLogin pageLogin = new PageLogin(driver);
            return pageLogin.TitelLogin();
        }
        public static string xpathProduct(ProductForTest productToAdd, IWebDriver driver)
        {
            PageAllProducts pageAllProducts = new PageAllProducts(driver);
            return pageAllProducts.xpathProduct(productToAdd);
        }
        
    }
}
