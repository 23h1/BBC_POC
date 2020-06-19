using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using Xunit;

namespace UITests.PageObjects
{
    class BBCHomePage
    {
        private readonly IWebDriver Driver;
        private const string homePageURL = "https://www.bbc.co.uk/";
        private const string homeTitle = "BBC - Home";

        public BBCHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement SearchField
        {
            get { return Driver.FindElement(By.Id("orb-search-q")); }
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(homePageURL);
            HasBBCHomePageLoaded();
            HaveAllSectionsPopulated();
        }

        private void HasBBCHomePageLoaded()
        {
            bool pageHasLoaded = (Driver.Url == homePageURL) && (Driver.Title == homeTitle);

            if (!pageHasLoaded)
            {
                throw new Exception($"Failed to load BBC Homepage. Page URL = '{Driver.Url}' PageSource");
            }
        }

        private void HaveAllSectionsPopulated()
        {
            //----test for various sections/modules within the BBC Homepage
            //----NEEDS REFACTORING 

            IWebElement Section1 = Driver.FindElement(By.ClassName("hp-banner__text"));
            Assert.Equal("Welcome to the BBC", Section1.Text);

            IWebElement Section2 = Driver.FindElement(By.CssSelector("[data-template='HeroPromos']"));
            Assert.Equal("True", (Section2.Displayed).ToString());

            IWebElement Section3 = Driver.FindElement(By.CssSelector("[data-file-id='collection-coronavirus']"));
            Assert.Equal("True", (Section3.Displayed).ToString());

            IWebElement Section4 = Driver.FindElement(By.CssSelector("[data-file-id='collection-more-lifestyle-seg-test']"));
            Assert.Equal("True", (Section4.Displayed).ToString());

            IWebElement Section5 = Driver.FindElement(By.CssSelector("[data-file-id='collection-more-top-stories']"));
            Assert.Equal("True", (Section5.Displayed).ToString());

            IWebElement Section6 = Driver.FindElement(By.CssSelector("[data-file-id='collection-latest-news']"));
            Assert.Equal("True", (Section6.Displayed).ToString());

            IWebElement Section7 = Driver.FindElement(By.CssSelector("[data-file-id='collection-latest-sport']"));
            Assert.Equal("True", (Section7.Displayed).ToString());

            IWebElement Section8 = Driver.FindElement(By.CssSelector("[data-file-id='collection-around-the-uk']"));
            Assert.Equal("True", (Section8.Displayed).ToString());

            IWebElement Section9 = Driver.FindElement(By.ClassName("hp-dismissible-nations-links__nations"));
            Assert.Equal("True", (Section9.Displayed).ToString());

            IWebElement Section10 = Driver.FindElement(By.CssSelector("[data-file-id='collection-learn-at-home']"));
            Assert.Equal("True", (Section10.Displayed).ToString());

            IWebElement Section11 = Driver.FindElement(By.CssSelector("[data-file-id='collection-lifestyle']"));
            Assert.Equal("True", (Section11.Displayed).ToString());

            IWebElement Section12 = Driver.FindElement(By.CssSelector("[data-file-id='collection-more-lifestyle-seg-test']"));
            Assert.Equal("True", (Section12.Displayed).ToString());

            IWebElement Section13 = Driver.FindElement(By.CssSelector("[data-file-id='collection-3-things-we-love-today']"));
            Assert.Equal("True", (Section13.Displayed).ToString());

            IWebElement Section14 = Driver.FindElement(By.CssSelector("[data-file-id='collection-people']"));
            Assert.Equal("True", (Section14.Displayed).ToString());

            IWebElement Section15 = Driver.FindElement(By.CssSelector("[data-file-id='collection-time-well-spent']"));
            Assert.Equal("True", (Section15.Displayed).ToString());

            IWebElement Section16 = Driver.FindElement(By.CssSelector("[data-file-id='collection-time-well-spent-second-deck']"));
            Assert.Equal("True", (Section16.Displayed).ToString());

            IWebElement Section17 = Driver.FindElement(By.CssSelector("[data-file-id='collection-food']"));
            Assert.Equal("True", (Section17.Displayed).ToString());

            IWebElement Section18 = Driver.FindElement(By.CssSelector("[data-file-id='collection-entertainment-news']"));
            Assert.Equal("True", (Section18.Displayed).ToString());

            IWebElement Section19 = Driver.FindElement(By.CssSelector("[data-file-id='collection-time-well-spent']"));
            Assert.Equal("True", (Section19.Displayed).ToString());

            IWebElement Section20 = Driver.FindElement(By.CssSelector("[data-file-id='collection-stories-behind-the-news']"));
            Assert.Equal("True", (Section20.Displayed).ToString());

            IWebElement Section21 = Driver.FindElement(By.CssSelector("[data-file-id='collection-week-in-sport']"));
            Assert.Equal("True", (Section21.Displayed).ToString());

            IWebElement Section22 = Driver.FindElement(By.CssSelector("[data-file-id='collection-things-we-loved-yesterday']"));
            Assert.Equal("True", (Section22.Displayed).ToString());

            IWebElement Section23 = Driver.FindElement(By.ClassName("hp-permanent-links"));
            Assert.Equal("True", (Section23.Displayed).ToString());

            IWebElement Section24 = Driver.FindElement(By.ClassName("orb-footer-primary-links"));
            Assert.Equal("True", (Section24.Displayed).ToString());

        }
    }
}
