using OpenQA.Selenium;
using System;
using System.Reflection;
using System.Security.Policy;

namespace BillwerkTask.Pages
{
    public abstract class GlobalSqaBasePage
    {
        private readonly Func<IWebDriver> _contextLocator;
        private const BindingFlags FlagsForBinding = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        protected GlobalSqaBasePage(Func<IWebDriver> conextLocator)
        {
            ArgumentNullException.ThrowIfNull(conextLocator);

            _contextLocator = conextLocator;
        }

        protected IWebDriver Context
        {
            get { return _contextLocator(); }
        }

        protected Func<IWebDriver> ConextLocator
        {
            get { return _contextLocator; }
        }

        protected T GetContent<T>(Func<IWebDriver> contextLocator) where T : GlobalSqaBasePage
        {
            var control = (T)Activator.CreateInstance(typeof(T),
                   FlagsForBinding,
                   null,
                   new object[] { contextLocator }, null);
            return control;
        }
    }
}
