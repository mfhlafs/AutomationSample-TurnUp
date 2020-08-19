using OpenQA.Selenium;
using SpecflowTM.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowTM.StepDefinitions
{
    [Binding]
    public sealed class TMStepDefinition
    {
        private LoginPage loginPage;

        public TMStepDefinition(IWebDriver driver)
        {
            loginPage = new LoginPage(driver);

        }

        [Given(@"I navigate to the TurnUp portal")]
        public void GivenINavigateToTheTurnUpPortal()
        {
            var url = "http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f";
            loginPage.Navigate(url);
        }

        [When(@"I add my credentials")]
        public void WhenIAddMyCredentials()
        {
            
        }

        [Then(@"I am able to navigate to the Main Page")]
        public void ThenIAmAbleToNavigateToTheMainPage()
        {
            
        }

    }
}
