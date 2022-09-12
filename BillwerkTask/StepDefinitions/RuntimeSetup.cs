using BillwerkTask.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Unity;

namespace BillwerkTask.StepDefinitions
{
    [Binding]
    public static class RuntimeSetup
    {
        [BeforeFeature]
        public static void SetupRuntime()
        {
            IUnityContainer container = new UnityContainer();
            ChromeDriver driver = new ChromeDriver();
            container.RegisterInstance<IWebDriver>(driver);
            container.RegisterType<BaseApplication>();

            FeatureContext.Current.Set(container);
        }

        [AfterFeature]
        public static void CleanupRuntime()
        {
            var app = FeatureContext.Current.Get<BaseApplication>();
            app.CloseApplication();
        }
    }
}
