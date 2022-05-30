using OpenQA.Selenium;
using System;

namespace TestOmada.PageObjectModels
{
    internal class BasePage
    {
        protected IWebDriver Driver;

        protected virtual string PageUrl { get; }
        protected virtual string PageTitle { get; }
        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(PageUrl);
            Driver.Manage().Window.Maximize();
            EnsurePageLoaded();
        }
        public void EnsurePageLoaded()
        {
            bool pageLoaded = (Driver.Url == PageUrl) && (Driver.Title == PageTitle);

            if (!pageLoaded)
            {
                throw new Exception($"Failed to load page. Page URL: '{Driver.Url}' Page Source: \r\n {Driver.PageSource}");
            }
        }
        public IWebElement ScrollToElementByXpath(IWebDriver driver, string elementXPath)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement link = driver.FindElement(By.XPath(elementXPath));
            js.ExecuteScript("arguments[0].scrollIntoView();", link);
            return link;
        }
    }
}
