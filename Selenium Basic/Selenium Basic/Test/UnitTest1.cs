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
        AddProductForTest productToAdd = new AddProductForTest( "addfortest", "3", "4", "300", "35","1", "1321",
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
            Assert.IsTrue(productToAdd.productName == GetData.ReadProduct(driver).getProductName);
            Assert.IsTrue(productToAdd.categoryValue == GetData.ReadProduct(driver).getCategoryValue);
            Assert.IsTrue(productToAdd.supplierValue == GetData.ReadProduct(driver).getSupplierValue);
            Assert.IsTrue(productToAdd.unitPrice + ",0000" == GetData.ReadProduct(driver).getUnitPrice);
            Assert.IsTrue(productToAdd.quantityPerUnit == GetData.ReadProduct(driver).getQuantityPerUnit);
            Assert.IsTrue(productToAdd.unitsInStock == GetData.ReadProduct(driver).getUnitsInStock);
            Assert.IsTrue(productToAdd.unitsOnOrder == GetData.ReadProduct(driver).getUnitsOnOrder);
            Assert.IsTrue(productToAdd.reorderLevel == GetData.ReadProduct(driver).getReorderLevel);
            Assert.IsTrue(productToAdd.discontinued == GetData.ReadProduct(driver).getDiscontinued);
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