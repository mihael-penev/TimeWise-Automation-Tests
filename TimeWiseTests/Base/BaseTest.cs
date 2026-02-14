using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TimeWiseTests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TimeWiseTests.Base
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected readonly string baseUrl = "https://d1dzr3dh7g0qgk.cloudfront.net";

        [SetUp]
        public void SetUp()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-save-password-bubble");

            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(baseUrl);

            // Infrastructure check
            if (driver.PageSource.Contains("502"))
            {
                Assert.Fail("Application is currently unavailable (HTTP 502).");
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}

