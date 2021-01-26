using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BunningSearchAcceptance.Helpers
{
    public class ProductsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "*[@id=\"main\"]/div[6]/div[1]/div/div[2]/div[1]/div/div[1]/p/span[1]")]
        public static IWebElement ProductResults;

        public ProductsPage()
        {
            PageFactory.InitElements(driver, this);
        }
     
        public static bool WaitForElement(IWebDriver driver, By locator, int timeToWait = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return wait.Until(ctx => driver.FindElement(locator).Displayed);
        }

        public static void VerifyCountOfRecordsExist(string searchText, int cntOfRecords)
        {
            WaitForElement(driver, By.XPath("//*[@id=\"main\"]/div[4]/div/h1/span[1]"), 1000);
            var cntOfSearchResults = driver.FindElement(By.XPath("/html/body/form/div/main/div[4]/div/h1/span[1]"));
            Assert.AreEqual(cntOfRecords + " " + TestData.MainPage.SearchResults + " " + searchText, cntOfSearchResults.Text + " " + TestData.MainPage.SearchResults + " " + searchText);
        }

        public static void VerifyRecordsExist(string searchText, int cntOfRecords, int cntOfProducts)
        {
            //Thread.Sleep(3000);
            WaitForElement(driver, By.XPath("//*[@id=\"main\"]/div[4]/div/h1/span[1]"), 3000);
            VerifyCountOfRecordsExist(searchText, cntOfRecords);
            var ProductResults = driver.FindElement(By.XPath("//*[@id=\"main\"]/div[6]/div[1]/div/div[2]/div[1]/div/div[1]/p/span[1]"));
            Assert.AreEqual(cntOfProducts + " " + TestData.MainPage.ProductResults, ProductResults.Text + " " + TestData.MainPage.ProductResults);
        }
    }
}