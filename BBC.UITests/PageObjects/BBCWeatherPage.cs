using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using Xunit;

namespace UITests.PageObjects
{
    class BBCWeatherPage
    {
        private readonly IWebDriver Driver;
        private const string weatherPageURL = "https://www.bbc.co.uk/weather";
        private const string weatherPageTitle = "BBC Weather";

        public BBCWeatherPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement SearchField
        {
            get { return Driver.FindElement(By.Id("orb-search-q")); }
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(weatherPageURL);
            HasBBCWeatherPageLoaded();
        }

        private void HasBBCWeatherPageLoaded()
        {
            bool pageHasLoaded = (Driver.Url == weatherPageURL) && (Driver.Title == weatherPageTitle);

            if (!pageHasLoaded)
            {
                throw new Exception($"Failed to load BBC Weather Page. Page URL = '{Driver.Url}' PageSource: \r\n {Driver.PageSource}");
            }
        }
    }
}
