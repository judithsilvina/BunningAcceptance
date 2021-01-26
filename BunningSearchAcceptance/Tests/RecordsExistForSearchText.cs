using BunningSearchAcceptance.Helpers;
using BunningSearchAcceptance.PageObjects;
using NUnit.Framework;
using StoryQ;

namespace BunningSearchAcceptance.Tests
{
    internal class RecordsExistForSearchText : BasePage
    {
        private readonly string _searchText = "tools";
        private readonly int _cntOfRecords = 5185;
        private readonly int _cntOfProducts = 5027;

        [Test]
        public void RecordsReturnedForSearchText()
        {
            new Story("Verify Search Results and Product Results count")
                    .InOrderTo("Verify Search Results and Product Results count")
                    .AsA("User")
                    .IWant("$To Enter valid search criteria and click on Search button")
                    .WithScenario("Valid Matching results exist")
                    .Given(OpenURL)
                    .When(SearchPage.EnterSearchTextAndClickOnSearchButton, _searchText)
                    .Then(ProductsPage.VerifyRecordsExist, _searchText, _cntOfRecords, _cntOfProducts)
                    .And(SearchPage.CloseTheBrowser)
                    .Execute();
        }
    }
}