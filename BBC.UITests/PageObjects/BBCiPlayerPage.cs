using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace UITests.PageObjects
{
    class BBCiPlayerPage
    {
        private readonly IWebDriver Driver;
        private const string iPlayerPageURL = "https://www.bbc.co.uk/iplayer";
        private const string iPlayerPageTitle = "BBC iPlayer";

        public BBCiPlayerPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement SearchField
        {
            get { return Driver.FindElement(By.Id("orb-search-q")); }
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(iPlayerPageURL);
            HasBBCiPlayerPageLoaded();
        }

        private void HasBBCiPlayerPageLoaded()
        {
            bool pageHasLoaded = (Driver.Url == iPlayerPageURL) && (Driver.Title == iPlayerPageTitle);

            if (!pageHasLoaded)
            {
                throw new Exception($"Failed to load BBC iPLayer Page. Page URL = '{Driver.Url}' PageSource: \r\n {Driver.PageSource}");
            }
        }

        public void WaitUntilPlanetEarthPageHasLoaded()
        {
            WebDriverWait wait = new WebDriverWait(Driver, timeout: TimeSpan.FromSeconds(1));
            IWebElement watchButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-bbc-content-label='start-watching']")));
        }

        // UI Elements
        public IWebElement searchSuggestions => Driver.FindElement(By.ClassName("se-search-suggestion"));

        public IWebElement searchField => Driver.FindElement(By.Id("orb-search-q"));

        public IWebElement planetEarth => Driver.FindElement(By.LinkText("Planet Earth"));

        public IWebElement watchButton => Driver.FindElement(By.CssSelector("[data-bbc-content-label='start-watching']"));

        public IWebElement ButtonTitle => Driver.FindElement(By.PartialLinkText("Planet Earth"));

    }
}
