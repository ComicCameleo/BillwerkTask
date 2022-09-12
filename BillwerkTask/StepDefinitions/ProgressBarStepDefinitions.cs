using BillwerkTask.Pages;
using System;
using TechTalk.SpecFlow;

namespace BillwerkTask.StepDefinitions
{
    [Binding]
    public class ProgressBarStepDefinitions
    {
        private ProgressBarPage ProgressBarPage
        {
            get { return ScenarioContext.Current.Get<ProgressBarPage>(); }
        }

        [When(@"I click on Start download button")]
        public void WhenIClickOnStartDownloadButton()
        {
            ProgressBarPage.WaitPageToLoad();
            var downloadFrame = ProgressBarPage.SwitchToDownloadFrame();
            downloadFrame.StartDownloadButton.Click();
        }

        [Then(@"I should see download finished")]
        public void ThenIShouldSeeDownloadFinished()
        {
            var downloadFrame = ProgressBarPage.SwitchToDownloadFrame();
            downloadFrame.WaitProgressBarLoaded();
            downloadFrame.WaitDownloadFinished(60);
        }
    }
}
