using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowTM.PageObjects
{
    public abstract class BasePage
    {
        private IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url); 
        }
    }
}
