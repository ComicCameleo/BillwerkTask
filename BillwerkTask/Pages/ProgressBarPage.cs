using OpenQA.Selenium;
 
namespace BillwerkTask.Pages
{
    public class ProgressBarPage : GlobalSqaBasePage
    {
        private const string DownloadButtonId = "//button[@id = 'downloadButton']";
        private const string DownloadFrame = "//iframe[contains(@class, 'demo-frame')]";
        private const string ProgressLabel = "//*[@id = 'dialog']/*[@class='progress-label']";
        private const string LoadFinishedStatusText = "Complete!";
        private const string LogoId = "logo";
        public ProgressBarPage(Func<IWebDriver> contextLocator) : base(contextLocator) { }

        public ProgressBarPage SwitchToDownloadFrame()
        {
            return GetContent<ProgressBarPage>(() => Context.WaitSwitchToFrame(By.XPath(DownloadFrame)));
        }

        public void WaitPageToLoad()
        {
            Context.WaitElementVisible(Logo);
        }

        public IWebElement Logo
        {
            get { return Context.WaitFindElement(By.Id(LogoId)); }
        }

        public IWebElement StartDownloadButton
        {
            get { return Context.WaitFindElement(By.XPath(DownloadButtonId)); }
        }

        public IWebElement ProgressStatus
        {
            get { return Context.WaitFindElement(By.XPath(ProgressLabel)); }
        }

        public void WaitProgressBarLoaded()
        {
            Context.WaitUntil((ctx) =>
            {
                try
                {
                    var el = ctx.FindElement(By.XPath(ProgressLabel));
                    return el.Displayed;
                }
                catch (NoSuchElementException)
                { return false; }
            });
        }

        public void WaitDownloadFinished(int timeToWait)
        {
            Context.WaitUntil((ctx) =>
            {
                try
                {
                    var el = ctx.FindElement(By.XPath(ProgressLabel));
                    return el.Text == LoadFinishedStatusText;
                }
                catch (NoSuchElementException)
                { return false; }
            }, timeToWait);
        }
    }
}
