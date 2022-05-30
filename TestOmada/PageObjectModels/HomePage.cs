using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestOmada.PageObjectModels
{
    internal class HomePage : BasePage
    {
        protected override string PageUrl => "https://omadaidentity.com/";
        protected override string PageTitle => "Identity Governance Solutions Simplified | Omada Identity";
  
        private const string footerOmadaIdentifyCloudLinkXPath = "//*[@id='menu-item-2263']/a";
        private const string headerOmadaIdentifyCloudLinkXpath = "//a[text()[contains(.,'Omada Identity Cloud')]]";

        public HomePage (IWebDriver driver)
        {
            Driver = driver;
        }

        public void ClickProductHeaderLink()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            IWebElement productHeaderLink = wait.Until(e => e.FindElement(By.XPath("//*[@id='menu-item-727']/a")));
            Console.WriteLine($"Is product link displayed: {productHeaderLink.Displayed}");
            Console.WriteLine(productHeaderLink.Enabled);

            productHeaderLink.Click();
        }
        public OmadaIdentityCloudPage ClickOmadaIdentityCloudLink()
        {
            IWebElement headerOmadaIdentifyCloudLink = ScrollToElementByXpath(Driver, headerOmadaIdentifyCloudLinkXpath);      
            headerOmadaIdentifyCloudLink.Click();
            return new OmadaIdentityCloudPage(Driver);
        }
        public OmadaIdentityCloudPage ClickOmadaIdentityCloudFooterLink()
        {
            IWebElement footerOmadaIdentifyCloudLink = ScrollToElementByXpath(Driver, footerOmadaIdentifyCloudLinkXPath);
            footerOmadaIdentifyCloudLink.Click();
            return new OmadaIdentityCloudPage(Driver);
        }

        public void ClickCompanyLink()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            IWebElement companyLink = wait.Until(e => e.FindElement(By.XPath("//*[@id='menu-item-731']/a")));
            companyLink.Click();
        }
        public CareersPage ClickCareersLink()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            IWebElement careersLink =   wait.Until(e => e.FindElement(By.XPath("//*[@id='menu-item-731']/div/div/div[1]/ul/li[2]/a")));
            Console.WriteLine($"Is careers link displayed: {careersLink.Displayed}");
            Console.WriteLine(careersLink.Enabled);
            careersLink.Click();
            return new CareersPage(Driver);
        }
    }
}
