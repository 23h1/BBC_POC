using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using Xunit;

namespace UITests.PageObjects
{
    class BBCNewsPage
    {
        private readonly IWebDriver Driver;
        private const string newsPageURL = "https://www.bbc.co.uk/news";
        private const string newsPageTitle = "Home - BBC News";

        public BBCNewsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement SearchField
        {
            get { return Driver.FindElement(By.Id("orb-search-q")); }
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(newsPageURL);
            HasBBCNewsPageLoaded();
            //HaveAllSectionsPopulated();
        }

        private void HasBBCNewsPageLoaded()
        {
            bool pageHasLoaded = (Driver.Url == newsPageURL) && (Driver.Title == newsPageTitle);

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
