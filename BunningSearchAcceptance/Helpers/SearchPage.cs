using BunningSearchAcceptance.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace BunningSearchAcceptance.Helpers
{
    public class SearchPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "formLightboxContainer")]
        private IWebElement _pageHeader;

     
        [FindsBy(How = How.XPath, Using = "*[@id=\"main\"]/div[6]/div[1]/div/div[2]/div[1]/div/div[1]/p/span[1]")]
        public static IWebElement ProductResults;

        public SearchPage()
        {
            PageFactory.InitElements(driver, this);
        }

        public static void VerifySearchAutoCompleteList(int cntOfRecordsInAutoComplete)
        {
            var SearchAutocompleteList = driver.FindElement(By.Id("ui-id-1"));
            var isEnabled = SearchAutocompleteList.Enabled;
            var SearchAutocompleteListItems = SearchAutocompleteList.FindElements(By.ClassName("ui-menu-item"));
            Assert.IsTrue(isEnabled);
            Assert.AreEqual(SearchAutocompleteListItems.Count, cntOfRecordsInAutoComplete);
        }

        public static void SleepFor10Sec()
        {
            Thread.Sleep(1000);
        }

        public static void EnterSearchTextAndClickOnSearchButton(string searchText)
        {
            MainPage search = new MainPage();
            search.EnterSearchCriteriaAndSearchButton(searchText);
        }

        public static void EnterSearchText(string searchText)
        {
            MainPage search = new MainPage();
            search.EnterFirstfewCharacters(searchText);
        }
    }
}