using OpenQA.Selenium;
using Selenium_Basic.business_object;
using Selenium_Basic.Test;

namespace Selenium_Basic.service.ui
{
    class WorkWithBD
    {


        public static PageHomePage LoginToBD(User user, IWebDriver driver)
        {
           PageLogin pageLogin = new PageLogin(driver);
           return pageLogin.LoginNwApp(user);
        }
        public static PageAllProducts CreatProd(ProductForTest productToAdd, IWebDriver driver)
        {
           PageAllProducts pageAllProducts = new PageAllProducts(driver);
           PageCreate pageCreate = new PageCreate(driver);
           PageHomePage pageHomePage = new PageHomePage(driver);
           pageHomePage.MoveToAllProducts();
           pageAllProducts.MoveToCreate();
           return pageCreate.CreateNewProduct(productToAdd);
        }
        public static PageEditProduct OpenPageEditProd(ProductForTest productToAdd, IWebDriver driver)
        {
            PageAllProducts pageAllProducts = new PageAllProducts(driver);
            PageHomePage pageHomePage = new PageHomePage(driver);
            pageHomePage.MoveToAllProducts();
            return pageAllProducts.MoveToProduct(productToAdd);
        }
        public static void DelProd(ProductForTest productToAdd, IWebDriver driver)
        {
            PageAllProducts pageAllProducts = new PageAllProducts(driver);
            PageHomePage pageHomePage = new PageHomePage(driver);
            pageHomePage.MoveToAllProducts();
            pageAllProducts.RemoveProduct(productToAdd);
            BaseTest.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(GetData.xpathProduct(productToAdd, driver))));
        }
        public static PageLogin LogoutBD(ProductForTest productToAdd, IWebDriver driver)
        {
            PageAllProducts pageAllProducts = new PageAllProducts(driver);
            return pageAllProducts.Logout();
        }

        
    }
}
