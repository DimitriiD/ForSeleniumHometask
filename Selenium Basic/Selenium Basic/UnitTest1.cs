using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
namespace Selenium_Basic
{
    public class Tests
    {
        private string baseUrl;
        private const string baseName = "user";
        private const string basePassword = "user";
        private const string hPageElement = "Home page";
        private const string allPrElement = "All Products";
        private const string pName = "addfortest";
        private const string catV = "3";
        private const string supV = "4";
        private const string uPrice = "300";
        private const string qPerUnit = "35";
        private const string uInStock = "1";
        private const string uOnOrder = "1321";
        private const string rLevel = "1";
        private const string discontinued = "true";
        private const string titelLogin = "Login";
        private IWebDriver driver;
        private WebDriverWait wait;
        private ForMetods forMetods;
        private PageLogin pageLogin;
        private PageHomePage pageHomePage;
        private PageAllProducts pageAllProducts;
        private PageCreate pageCreate;
        private PageEditProduct pageEditProduct;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            baseUrl = "http://localhost:5000/Account/Login?ReturnUrl=%2F";
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));  
        }
        [SetUp]
        public void Login()
        {
            pageLogin = new PageLogin(driver);          
            pageLogin.LoginNwApp(baseName, basePassword);
        }
        [Test,Order(1)]
        public void TestLogAndCreat()
        {
            pageAllProducts = new PageAllProducts(driver);
            pageCreate = new PageCreate(driver);
            pageHomePage = new PageHomePage(driver);
            Assert.IsTrue(hPageElement == pageHomePage.GetHomePage());
            pageHomePage.MoveToAllProducts();
            pageAllProducts.MoveToCreate();
            pageCreate.CreateNewProduct(pName, catV, supV, uPrice, qPerUnit, uInStock, uOnOrder, rLevel, discontinued);
            Assert.IsTrue(allPrElement == pageAllProducts.GetAllProducts());
        }
        [Test, Order(2)]
        public void TestOpenProduct()
        {
            pageAllProducts = new PageAllProducts(driver);
            pageHomePage = new PageHomePage(driver);
            pageEditProduct = new PageEditProduct(driver);
            pageHomePage.MoveToAllProducts();
            pageAllProducts.MoveToProduct(pName);
            Assert.IsTrue(pName == pageEditProduct.GetProductName());
            Assert.IsTrue(catV == pageEditProduct.GetCategoryId());
            Assert.IsTrue(supV == pageEditProduct.GetSupplierId());
            Assert.IsTrue(uPrice + ",0000" == pageEditProduct.GetUnitPrice());
            Assert.IsTrue(qPerUnit == pageEditProduct.GetQuantityPerUnit());
            Assert.IsTrue(uInStock == pageEditProduct.GetUnitsInStock());
            Assert.IsTrue(uOnOrder == pageEditProduct.GetUnitsOnOrder());
            Assert.IsTrue(rLevel == pageEditProduct.GetReorderLevel());
            Assert.IsTrue(discontinued ==pageEditProduct.GetDiscontinued());
        }
        [Test, Order(3)]
        public void TestDeleteLogout()
        {
            forMetods = new ForMetods(driver);
            pageAllProducts = new PageAllProducts(driver);
            pageHomePage = new PageHomePage(driver);
            pageLogin = new PageLogin(driver);
            pageHomePage.MoveToAllProducts();
            pageAllProducts.RemoveProduct(pName);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(pageAllProducts.XpathProduct(pName))));
            Assert.False(forMetods.IsElementPresent(By.XPath(pageAllProducts.XpathProduct(pName))));
            pageAllProducts.Logout();
            Assert.IsTrue(titelLogin == pageLogin.TitelLogin());
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}