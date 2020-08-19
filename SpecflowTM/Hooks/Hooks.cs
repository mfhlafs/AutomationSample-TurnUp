using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowTM.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private IWebDriver _driver;


        //IOC Container for specflow
        //contains BoDi
        private readonly IObjectContainer _ObjectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            _ObjectContainer = objectContainer;
        }



        [BeforeScenario]
        public void BeforeScenario()
        {
            GetDriver();

            var _driver = new ChromeDriver();
        }

        private IWebDriver GetDriver()
        {
            var browser = "Chrome";

            if (_driver == null)
            {
                switch (browser)
                {
                    case "Chrome":

                        ChromeOptions chromeOptions = new ChromeOptions();

                        // Get value for headless option from appsettings.json

                        var headless = "false";

                        if (headless == "true")
                        {
                            chromeOptions.AddArgument("--headless");
                        }

                        //
                        //_dsolves problem where you have to provide driver path (""C://)
                        //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                        _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
                        //_driver = new ChromeDriver();
                        break;

                }

                try
                {
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                    _driver.Manage().Cookies.DeleteAllCookies();
                    _driver.Manage().Window.Maximize();
                    _ObjectContainer.RegisterInstanceAs(_driver);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message + " Driver failed to initialize");
                }
            }

            return _driver;
        }


        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Close();
            _driver.Dispose();
        }
        //[AfterTestRun]
        //public static void DisposeDriver()
        //{
        //   // _driver.Dispose();
        //}

    }
}
