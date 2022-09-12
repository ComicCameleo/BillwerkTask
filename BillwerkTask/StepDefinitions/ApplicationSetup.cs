using BillwerkTask.Pages;
using Unity;

namespace BillwerkTask.StepDefinitions
{
    [Binding]
    public class ApplicationSetup
    {
        [Given(@"I am at the Progress bar page '(.*)'")]
        public void WhenINavigateToTheProgressBarPage(string url)
        {
            var app = CreateApplication();
            var page = app.OpenProgressBarPage(url);
            ScenarioContext.Current.Set(page);
        }

        private BaseApplication CreateApplication()
        {
            var context = FeatureContext.Current;

            if (context == null)
            {
                throw new InvalidOperationException("Feature conext does not exist");
            }

            var container = context.Get<IUnityContainer>();
            var application = container.Resolve<BaseApplication>();
            context.Set(application);
            return application;
        }
    }
}
