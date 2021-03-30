using autoDemo.Drivers;
using OpenQA.Selenium;
using System;
using System.Configuration;

namespace autoDemo.Pages
{
    class GooglePage
    {
        WebDriver _browser;

        public GooglePage(WebDriver browser)
        {
            _browser = browser;
        }

        public void GoToGooglePage()
        {
            _browser.Driver.Url = ConfigurationManager.AppSettings["googleUrl"];
        }

        public void SetTerm(string term)
        {
            _browser.SetElement(_browser.GetElement("//*[@class='gLFyf gsfi']"), term);
        }

        public void ClickSearch()
        {
            _browser.SetElement(_browser.GetElement("//*[@class='gLFyf gsfi']"), Keys.Enter);
        }

        public bool VerifySearchResultExists(string term)
        {
            return _browser.Driver.FindElements(By.XPath("//*[@class='g']")).Count > 0 &&
                _browser.GetElement("//h3[contains(text(),'" + term + "')]").Displayed;
        }

        public bool VerifyNoSearchResultMessage(string term)
        {
            return _browser.GetElement("//p[@role='heading']").Text.Equals("Your search - " + term + " - did not match any documents.z");
        }
    }
}
