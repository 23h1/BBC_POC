using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using Xunit;

namespace UITests.PageObjects
{
    class BBCSportPage
    {
        private readonly IWebDriver Driver;
        private const string sportPageURL = "https://www.bbc.co.uk/sport";
        private const string sportPageTitle = "Home - BBC Sport";

        public BBCSportPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement SearchField
        {
            get { return Driver.FindElement(By.Id("orb-search-q")); }
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(sportPageURL);
            HasBBCNewsPageLoaded();
            //HaveAllSectionsPopulated();
        }

        private void HasBBCNewsPageLoaded()
        {
            bool pageHasLoaded = (Driver.Url == sportPageURL) && (Driver.Title == sportPageTitle);

            if (!pageHasLoaded)
            {
                throw new Exception($"Failed to load BBC News Page. Page URL = '{Driver.Url}' PageSource: \r\n {Driver.PageSource}");
            }
        }

        private void HaveAllSectionsPopulated()
        {
            // Need to fill in
        }
    }
}
