using NUnit.Framework;
using OpenQA.Selenium;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Environment;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Common;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Base
{
    public class BaseTest
    {
        public IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = WebDriverSingleton.Instance;
            Driver.Navigate().GoToUrl(EnvironmentConfig.WebsiteUrl);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverSingleton.QuitDriver();
        }
    }
}
