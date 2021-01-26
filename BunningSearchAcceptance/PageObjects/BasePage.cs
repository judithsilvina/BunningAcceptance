using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BunningSearchAcceptance.Helpers
{
    public class BasePage
    {
        public static IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            //options.AddArgument("--headless");
            options.AddArgument("test-type");
            options.AddArgument("disable-web-security");
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            //driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public static void OpenURL()
        {
            driver.Navigate().GoToUrl("https://www.bunnings.com.au/");
        }

        public static void CloseTheBrowser()
        {
            driver.Quit();
        }
    }
}