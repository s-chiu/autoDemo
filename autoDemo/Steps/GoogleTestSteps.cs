using autoDemo.Drivers;
using autoDemo.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace autoDemo.Steps
{
    [Binding]
    class GoogleTestSteps
    {
        static WebDriver _browser;
        ScenarioContext _scenarioContext;
        public GoogleTestSteps(WebDriver browser, ScenarioContext scenarioContext)
        {
            _browser = browser;
            _scenarioContext = scenarioContext;
        }

        GooglePage googlePage => new GooglePage(_browser);

        [Given(@"the user is on the google page")]
        public void GivenTheUserIsOnTheGooglePage()
        {
            googlePage.GoToGooglePage();
        }

        [When(@"the user googles the term ""(.*)""")]
        public void WhenTheUserGooglesTheTerm(string term)
        {
            _scenarioContext.Add("searchTerm", term);
            googlePage.SetTerm(term);
            googlePage.ClickSearch();
        }

        [Then(@"google search results are displayed")]
        public void ThenGoogleSearchResultsAreDisplayed()
        {
            Assert.IsTrue(googlePage.VerifySearchResultExists(_scenarioContext.Get<string>("searchTerm")));
        }

        [Then(@"no google search results are displayed")]
        public void ThenNoGoogleSearchResultsAreDisplayed()
        {
            Assert.IsTrue(googlePage.VerifyNoSearchResultMessage(_scenarioContext.Get<string>("searchTerm")));
        }


    }
}
