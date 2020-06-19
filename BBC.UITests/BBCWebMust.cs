using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using UITests.PageObjects;

namespace BBC.UITests
{
    public class BBCWebMust
    {
        [Fact]
        [Trait("Suite", "Smoke")]
        public void LoadHomePage()
        {
            using (IWebDriver driver = new ChromeDriver(Environment.CurrentDirectory))
            {                
                var homePage = new BBCHomePage(driver);
                homePage.NavigateTo();
            }
        }
        

        [Fact]
        [Trait("Suite", "Smoke")]
        public void NavigateThroughPages()
        {
            using (IWebDriver driver = new ChromeDriver(Environment.CurrentDirectory))
            {
                var homePage = new BBCHomePage(driver);
                homePage.NavigateTo();

                var newsPage = new BBCNewsPage(driver);
                newsPage.NavigateTo();

                var sportPage = new BBCSportPage(driver);
                sportPage.NavigateTo();

                var weatherPage = new BBCWeatherPage(driver);
                weatherPage.NavigateTo();

                var iPlayerPage = new BBCiPlayerPage(driver);
                iPlayerPage.NavigateTo();

                var soundsPage = new BBCSoundsPage(driver);
                soundsPage.NavigateTo();                
            }
        }


        [Fact]
        [Trait("Suite", "FunctionalTests")]
        
        /* This could be a bespoke test that could be used in a regression suite. */

        public void BeAbleToSeachIniPlayer()
        {
            using (IWebDriver driver = new ChromeDriver(Environment.CurrentDirectory))
            {
                var iPlayerPage = new BBCiPlayerPage(driver);

                iPlayerPage.NavigateTo();

                iPlayerPage.searchField.SendKeys("Planet Earth");

                iPlayerPage.planetEarth.Click();

                iPlayerPage.WaitUntilPlanetEarthPageHasLoaded();

                var expectedTitle = "BBC iPlayer - Planet Earth";

                Assert.Equal(expectedTitle, driver.Title);
                
            }
        }

    }
}
