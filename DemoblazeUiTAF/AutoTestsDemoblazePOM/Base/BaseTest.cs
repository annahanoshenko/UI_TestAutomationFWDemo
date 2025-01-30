using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Environment;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Base
{
    public class BaseTest
    {
        public IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(EnvironmentConfig.WebsiteUrl);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
