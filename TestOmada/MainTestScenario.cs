using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestOmada.PageObjectModels;

namespace TestOmada
{
    [TestClass]
    public class MainTestScenario
    {        

        [TestMethod]
        public void NavigateToProductsByHeaderMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                HomePage homePage = new(driver);
                homePage.NavigateTo();
                
                homePage.ClickProductHeaderLink();
                OmadaIdentityCloudPage omadaIdentityCloud = homePage.ClickOmadaIdentityCloudLink();

                omadaIdentityCloud.EnsurePageLoaded();

            }

        }
        [TestMethod]
        public void NavigateToProductsByFooterMenu()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                HomePage homePage = new(driver);
                homePage.NavigateTo();

                OmadaIdentityCloudPage omadaIdentityCloud = homePage.ClickOmadaIdentityCloudFooterLink();
                omadaIdentityCloud.EnsurePageLoaded();
            }
        }

        [TestMethod]
        public void NavigateToCareers()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                HomePage homePage = new(driver);
                homePage.NavigateTo();

                homePage.ClickCompanyLink();
                CareersPage careersPage = homePage.ClickCareersLink();

                careersPage.EnsurePageLoaded();
            }
        }
        [TestMethod]
        public void NavigateToMeetOurOmadiansAndSeeDetails()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                CareersPage careersPage = new CareersPage(driver);

                careersPage.NavigateTo();
                
                careersPage.MoveToOurOmadians();

                careersPage.OpenOmadianDetails("Gry");

                careersPage.CloseOmadianDetails();

                careersPage.OpenOmadianDetails("Daria");

                careersPage.CloseOmadianDetails();

            }
            
        }
    }
}