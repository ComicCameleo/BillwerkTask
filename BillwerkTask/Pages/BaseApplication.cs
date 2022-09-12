using OpenQA.Selenium;

namespace BillwerkTask.Pages
{
    public class BaseApplication
    {
        private readonly IWebDriver _driver;
        private readonly string _windowHandle;

        public BaseApplication(IWebDriver driver)
        {
            ArgumentNullException.ThrowIfNull(driver);
 
            _driver = driver;
            _windowHandle = _driver.CurrentWindowHandle;
            _driver.Manage().Window.Maximize();
        }

        public ProgressBarPage OpenProgressBarPage(string url)
        {
            ArgumentNullException.ThrowIfNull(url);

            _driver.Navigate().GoToUrl(url);
            return new ProgressBarPage(() => _driver.SwitchTo().Window(_windowHandle));
        }

        public void CloseApplication()
        {
            _driver.Close();
        }
    }
}
