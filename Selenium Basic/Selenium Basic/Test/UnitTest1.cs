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
        AllProductPageElement pageElementAllProduct = new AllProductPageElement("All Products");
        LoginPageElement loginPageElement = new LoginPageElement("Login");
        HomePagePageElement homePagePageElement = new HomePagePageElement("Home page");


        [Test,Order(1)]
        public void TestLogAndCreat()
        {
            Assert.IsTrue(homePagePageElement.homePageElement == GetData.GetHomePage(driver));
            WorkWithDataBase.CreatProd(productToAdd, driver);
            Assert.IsTrue(pageElementAllProduct.allProductElement == GetData.GetAllProducts(driver));
        }
        [Test, Order(2)]
        public void TestOpenProduct()
        {
            WorkWithDataBase.OpenPageEditProd(productToAdd, driver);
            ProductForTest productForTest = GetData.ReadProduct(driver);
            Assert.AreEqual(productToAdd.productName,productForTest.productName);
            Assert.AreEqual(productToAdd.categoryValue, productForTest.categoryValue);
            Assert.AreEqual(productToAdd.supplierValue, productForTest.supplierValue);
            Assert.AreEqual(productToAdd.unitPrice, productForTest.unitPrice);
            Assert.AreEqual(productToAdd.quantityPerUnit, productForTest.quantityPerUnit);
            Assert.AreEqual(productToAdd.unitsInStock, productForTest.unitsInStock);
            Assert.AreEqual(productToAdd.unitsOnOrder, productForTest.unitsOnOrder);
            Assert.AreEqual(productToAdd.reorderLevel, productForTest.reorderLevel);
            Assert.AreEqual(productToAdd.discontinued, productForTest.discontinued);
        }
        [Test, Order(3)]
        public void TestDeleteLogout()
        {
            forMetods = new ForMetods(driver);
            WorkWithDataBase.DeleteProd(productToAdd, driver);
            Assert.False(forMetods.IsElementPresent(By.XPath(GetData.xpathProduct(productToAdd, driver))));
            WorkWithDataBase.LogoutDataBase(productToAdd, driver);
            Assert.IsTrue(loginPageElement.titelLogin == GetData.TitelLogin(driver));
        }
    }
}