using BunningSearchAcceptance.Helpers;
using NUnit.Framework;
using StoryQ;

namespace BunningSearchAcceptance.Tests
{
    internal class SearchCriteriaMatchingDropDownList : BasePage
    {
        private readonly string _searchText = "tool";
        private readonly int _cntOfRecordsInDropDownList = 10;


        [Test]
        public void SearchCriteriaMatchingDropDownListValuesDisplayed()
        {
            new Story("Verify Matching results are displayed in Drop down list")
                    .InOrderTo("Verify Matching results are displayed in Drop down list")
                    .AsA("User")
                    .IWant("$To Enter valid search criteria and click on back space key")
                    .WithScenario("Valid Matching results are displayed in Search drop down list ")
                    .Given(OpenURL)
                    .And(SearchPage.SleepFor10Sec)
                    .When(SearchPage.EnterSearchText, _searchText)
                    .And(SearchPage.SleepFor10Sec)
                    .And(SearchPage.VerifySearchAutoCompleteList, _cntOfRecordsInDropDownList)
                    .And(SearchPage.CloseTheBrowser)
                    .Execute();
        }
      
    }
}