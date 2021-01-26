using BunningSearchAcceptance.Helpers;
using BunningSearchAcceptance.PageObjects;
using NUnit.Framework;
using StoryQ;

namespace BunningSearchAcceptance.Tests
{
    internal class NoRecordsExistForSearchText : BasePage
    {
        [Test]
        [TestCase("txt")]
        [TestCase("@@@$$%^")]
        public void NoRecordsReturnedForSearchText(string searchText)
        {
            new Story("Verify no records exist is displayed for no matching search criteria")
                    .InOrderTo("Verify no records exist is displayed for no matching search criteria")
                    .AsA("User")
                    .IWant($"To Enter search criteria {searchText} and click on Search button")
                    .WithScenario("No Matching Results exist")
                    .Given(OpenURL)
                    .When(SearchPage.EnterSearchTextAndClickOnSearchButton, searchText)
                    .Then(ProductsPage.VerifyCountOfRecordsExist, searchText, 0)
                    .And(SearchPage.CloseTheBrowser)
                    .Execute();
        }
    }
}