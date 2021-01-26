using BunningSearchAcceptance.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BunningSearchAcceptance.PageObjects
{
    public class MainPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"headerMainMenu\"]/div[2]/div/div[1]/div/div/input[1]")]
        public IWebElement SearchTectBox;

        [FindsBy(How = How.ClassName, Using = "search-container_icon-search")]
        private IWebElement BtnSearch;

        public MainPage()
        {
            PageFactory.InitElements(driver, this);
        }

        public ProductsPage EnterSearchCriteriaAndSearchButton(string searchText)
        {
            SearchTectBox.SendKeys(searchText);
            BtnSearch.Click();
            return new ProductsPage();
        }

        public MainPage EnterFirstfewCharacters(string searchText)
        {
            SearchTectBox.SendKeys(searchText);
            SearchTectBox.SendKeys(Keys.Backspace);
            SearchTectBox.SendKeys(Keys.ArrowDown);
            return this;
        }
    }
}