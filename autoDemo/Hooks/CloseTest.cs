using autoDemo.Drivers;
using OpenQA.Selenium;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace autoDemo.Hooks
{
    [Binding]
    class CloseTest
    {
        WebDriver _browser;
        ScenarioContext _scenarioContext;
        public CloseTest(WebDriver browser, ScenarioContext scenarioContext)
        {
            _browser = browser;
            _scenarioContext = scenarioContext;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TestError != null)
            {
                ITakesScreenshot screenShot = (ITakesScreenshot)_browser.Driver;
                string credPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\FailureScreenshots\\"));
                screenShot.GetScreenshot().SaveAsFile(credPath + _scenarioContext.ScenarioInfo.Title + ".png"); //Take Screenshot of failing screen and save it to this folder
                Console.WriteLine("Screenshot saved");
            }
            _browser.Driver.Dispose();
        }
    }
}
