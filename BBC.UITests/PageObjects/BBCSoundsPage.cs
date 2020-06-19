using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace UITests.PageObjects
{
    class BBCSoundsPage
    {
        private readonly IWebDriver Driver;
        private const string soundsPageURL = "https://www.bbc.co.uk/sounds";
        private const string soundsPageTitle = "BBC Sounds - Music. Radio. Podcasts";

        public BBCSoundsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement SearchField
        {
            get { return Driver.FindElement(By.Id("orb-search-q")); }
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(soundsPageURL);
            HasBBCSoundsPageLoaded();
            //HaveAllSectionsPopulated();
        }

        private void HasBBCSoundsPageLoaded()
        {
            bool pageHasLoaded = (Driver.Url == soundsPageURL) && (Driver.Title == soundsPageTitle);

            if (!pageHasLoaded)
            {
                throw new Exception($"Failed to load BBC Sounds Page. Page URL = '{Driver.Url}' PageSource: \r\n {Driver.PageSource}");
            }
        }

        private void HaveAllSectionsPopulated()
        {
            // Need to fill in
        }
    }
}
