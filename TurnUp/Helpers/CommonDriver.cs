using TurnUp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Reflection;
using System.IO;
using System.Runtime.CompilerServices;

namespace TurnUp.Helpers
{
    class CommonDriver
    {
        // Init driver
        public  IWebDriver driver;
      


        [OneTimeSetUp]
        public void LoginActions()
        {
            // define webdriver
            //driver = new ChromeDriver();
            
            driver = new ChromeDriver("C://");



            // Login page object init and definition
            LoginPage loginObj = new LoginPage();
            loginObj.LoginSteps(driver);

        }

        [OneTimeTearDown]
        public void ClosingSteps()
        {
            // kills driver instance
            //driver.Quit();
        }
    }
}