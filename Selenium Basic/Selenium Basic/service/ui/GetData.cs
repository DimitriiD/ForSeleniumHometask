using OpenQA.Selenium;
using Selenium_Basic.business_object;

namespace Selenium_Basic.service.ui
{
    class GetData
    {
        public static string GetHomePage(IWebDriver driver)
        {
            PageHomePage pageHomePage = new PageHomePage(driver);
            return pageHomePage.GetHomePage();
        }
        public static string GetAllProducts(IWebDriver driver)
        {
            PageAllProducts pageAllProducts = new PageAllProducts(driver);
            return pageAllProducts.GetAllProducts();
        }
        public static ProductForTest ReadProduct(IWebDriver driver)
        {
            PageEditProduct pageEditProduct = new PageEditProduct(driver);
            return pageEditProduct.ReadProduct();
        }
        public static string TitelLogin(IWebDriver driver)
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
