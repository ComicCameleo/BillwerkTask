using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BillwerkTask.Pages
{
    public static class WebDriverExtensions
    {
        private const int DefaultWaitingInSeconds = 15;

        public static IWebElement WaitFindElement(this IWebDriver webDriver, By by)
        {
            return webDriver.WaitFindElement(by, DefaultWaitingInSeconds);
        }

        public static IWebElement WaitFindElement(this IWebDriver webDriver, By by, int numberOfSeconds)
        {
            return webDriver.Wait(numberOfSeconds).Until(d => d.FindElement(by));
        }

        public static IWebDriver WaitSwitchToFrame(this IWebDriver webDriver, By by)
        {
            return webDriver.WaitSwitchToFrame(by, DefaultWaitingInSeconds);
        }

        public static IWebDriver WaitSwitchToFrame(this IWebDriver webDriver, By by, int numberOfSeconds)
        {
            return webDriver.Wait(numberOfSeconds).Until(d => d.SwitchTo().Frame(webDriver.FindElement(by)));
        }

        public static WebDriverWait Wait(this IWebDriver webdriver, int numberOfSeconds)
        {
            return new WebDriverWait(webdriver, TimeSpan.FromSeconds(numberOfSeconds));
        }

        public static TResult WaitUntil<TResult>(this IWebDriver webDriver, Func<IWebDriver, TResult> action, int numberOfSeconds = DefaultWaitingInSeconds)
        {
            return webDriver.Wait(numberOfSeconds).Until(action);
        }

        public static bool WaitElementVisible(this IWebDriver driver, IWebElement element)
        {
            try
            {
                driver.WaitUntil(dr => (element != null && element.Displayed) ? element : null);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
