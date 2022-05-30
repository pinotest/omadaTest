using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace TestOmada.PageObjectModels
{
    internal class CareersPage : BasePage
    {
        protected override string PageTitle => "Careers | Omada Identity and Access Management";
        protected override string PageUrl => "https://omadaidentity.com/company/careers/";

        private const string OmadianGryDetails = "“The great thing I’ve found with a career in finance is that it doesn’t matter what business you are in, " +
                "you can’t argue with logic, numbers, and hard work. You just have to stick to your beliefs, trust yourself and most important " +
                "of all: have fun with what you are doing and enjoy the ride.”";
        private const string OmadianDariaDetails = "";

        public CareersPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void MoveToOurOmadians()
        {
            IWebElement omadiansLink = ScrollToElementByXpath(Driver, "/html/body/section[6]/div[2]");


        }
        public void OpenOmadianDetails(string name="Gry")
        {
            ReadOnlyCollection<IWebElement> omadiansCollection = Driver.FindElements(By.ClassName("js-modal-open"));
            //to be fixed - should not be sleep but another actions doesn't work
            System.Threading.Thread.Sleep(1000);
            if (name =="Gry") omadiansCollection[0].Click();
            if (name=="Daria") omadiansCollection[2].Click();
            EnsureThatOmadianDetailsLoaded(name);

        }
        public void EnsureThatOmadianDetailsLoaded(string name= "Gry")
        {
            IWebElement a = Driver.FindElement(By.XPath("/html/body/section[6]/div[2]/div[3]/div[2]/div/div/div/div/p[1]"));

            bool detailsLoaded = false;
            if (name == "Gry") detailsLoaded = (a.Text == OmadianGryDetails);
            if (name == "Daria") detailsLoaded = (a.Text == OmadianDariaDetails);

            if (!detailsLoaded)
            {
                throw new Exception($"Failed to load detail Page. Omadian Name: '{name}' founded details: \r\n {a.Text}");
            }


        }
        public void CloseOmadianDetails()
        {
            Driver.FindElement(By.ClassName("js-modal-close")).Click();
        }
    }
}
