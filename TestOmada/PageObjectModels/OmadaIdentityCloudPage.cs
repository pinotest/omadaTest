using OpenQA.Selenium;



namespace TestOmada.PageObjectModels
{
    internal class OmadaIdentityCloudPage : BasePage
    {
        protected override string PageUrl => "https://omadaidentity.com/products/omada-identity-cloud/";
        protected override string PageTitle => "Identity Governance and Administration (IGA) Cloud Solution";

        public OmadaIdentityCloudPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }


}
