using NUnit.Framework;
using OpenQA.Selenium;
using Selenium_Basic.business_object;
using Selenium_Basic.service.ui;
using Selenium_Basic.Test;
using Selenium_Basic.ui.page_elements;
namespace Selenium_Basic
{
    public class Tests: BaseTest
    {
        private ForMetods forMetods;
        ProductForTest productToAdd = new ProductForTest( "addfortest", "3", "4", "300", "35","1", "1321",
        "1", "true");
        AllProdPageElm pageElmAllProd = new AllProdPageElm("All Products");
        LoginPageElm loginPageElm = new LoginPageElm("Login");
        HomePagePageElm homePagePageElm = new HomePagePageElm("Home page");


        [Test,Order(1)]
        public void TestLogAndCreat()
        {
            Assert.IsTrue(homePagePageElm.homePageElement == GetData.GetHomePage(productToAdd,driver));
            WorkWithBD.CreatProd(productToAdd, driver);
            Assert.IsTrue(pageElmAllProd.allProdElement == GetData.GetAllProducts(productToAdd, driver));
        }
        [Test, Order(2)]
        public void TestOpenProduct()
        {
            WorkWithBD.OpenPageEditProd(productToAdd, driver);
            Assert.IsTrue(productToAdd.prName == GetData.GetProductName(productToAdd, driver));
            Assert.IsTrue(productToAdd.catVal == GetData.GetCategoryId(productToAdd, driver));
            Assert.IsTrue(productToAdd.supVal == GetData.GetSupplierId(productToAdd, driver));
            Assert.IsTrue(productToAdd.unPrice + ",0000" == GetData.GetUnitPrice(productToAdd, driver));
            Assert.IsTrue(productToAdd.quPerUnit == GetData.GetQuantityPerUnit(productToAdd, driver));
            Assert.IsTrue(productToAdd.unInStock == GetData.GetUnitsInStock(productToAdd, driver));
            Assert.IsTrue(productToAdd.unOnOrder == GetData.GetUnitsOnOrder(productToAdd, driver));
            Assert.IsTrue(productToAdd.reLevel == GetData.GetReorderLevel(productToAdd, driver));
            Assert.IsTrue(productToAdd.discont == GetData.GetDiscontinued(productToAdd, driver));
        }
        [Test, Order(3)]
        public void TestDeleteLogout()
        {
            forMetods = new ForMetods(driver);
            WorkWithBD.DelProd(productToAdd, driver);
            Assert.False(forMetods.IsElementPresent(By.XPath(GetData.xpathProduct(productToAdd, driver))));
            WorkWithBD.LogoutBD(productToAdd, driver);
            Assert.IsTrue(loginPageElm.ttlLogin == GetData.TitelLogin(productToAdd, driver));
        }
    }
}