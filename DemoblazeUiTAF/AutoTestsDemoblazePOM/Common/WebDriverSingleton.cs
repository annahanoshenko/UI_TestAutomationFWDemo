using OpenQA.Selenium;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Common
{
    internal class WebDriverSingleton
    {
        private static IWebDriver _instance;

        private WebDriverSingleton() { }

        public static IWebDriver Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OpenQA.Selenium.Chrome.ChromeDriver();
                }
                return _instance;
            }
        }
        public static void QuitDriver()
        {
            if (_instance != null)
            {
                _instance.Quit();
                _instance = null;
            }
        }
    }
}
