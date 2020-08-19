using TurnUp.Helpers;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace TurnUp.Pages
{
    class TMPage
    {
        // function to create new TM
        public void CreateTM(IWebDriver driver)
        {

            // Click new button
            WaitHelper.WaitClickable(driver, "XPath", "//*[@id='container']/p/a", 2);
            driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();

            try
            {
                // Select a type code from the drop down list
                driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")).Click();
                WaitHelper.WaitClickable(driver, "XPath", "//*[@id='TypeCode_listbox']/li[2]", 2);
                driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Create new TM page did not launch", ex.Message);
            }


            // Input a code value
            driver.FindElement(By.Id("Code")).SendKeys("0316");
            WaitHelper.WaitClickable(driver, "Id", "Description", 2);

            // Input Description
            driver.FindElement(By.Id("Description")).SendKeys("AugustDescription");

            // Input price per unit
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
            driver.FindElement(By.Id("Price")).SendKeys("40");

            // Click save button
            driver.FindElement(By.Id("SaveButton")).Click();

            // Go to last page
            //WaitHelper.WaitClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 5);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();

            // Check if the created time/ material is present
            // WaitHelper.WaitClickable(driver, "XPath", ".//*[@id='tmsGrid']//td[contains(text(),'0316')]", 2);
            Thread.Sleep(3000);
            IWebElement actualCode = driver.FindElement(By.XPath(".//*[@id='tmsGrid']//td[contains(text(),'0316')]"));

            if (actualCode.Text == "0316")
            {
                Console.WriteLine("Time record created successfully, test passed!");
            }
            else
            {
                Console.WriteLine("Time record not created successfully, test failed!");
            }
        }

        // function to edit existing TM
        public void EditTM(IWebDriver driver)
        {

            // Go to last page
            Thread.Sleep(3000);
            //WaitHelper.WaitClickable(driver, attribute: "XPath", value: "//*[@id='tmsGrid']/div[4]/a[4]", seconds: 3);
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();

            // Check if the created time/ material is present 
            //WaitHelper.WaitClickable(driver, attribute: "XPath", value: "//div[@id='tmsGrid']//td[contains(text(),'August2020')]/../td/a[contains(text(),'Edit')]", seconds: 3);
            Thread.Sleep(3000);
            IWebElement actualCode = driver.FindElement(By.XPath("//div[@id='tmsGrid']//td[contains(text(),'0316')]/../td/a[contains(text(),'Edit')]")); actualCode.Click();
        }

        // function to delete TM
        public void DeleteTM(IWebDriver driver)
        {
            // Delete time and material test
            Thread.Sleep(3000);
            //WaitHelper.WaitClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 3);
            // Go to last page
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();
            Thread.Sleep(3000);
            //WaitHelper.WaitClickable(driver, "XPath", "//div[@id='tmsGrid']//td[contains(text(),'August2020')]/../td/a[contains(text(),'Delete')]", 3);
            // Check if the created time/ material is present 
            IWebElement actualCode = driver.FindElement(By.XPath("//div[@id='tmsGrid']//td[contains(text(),'0316')]/../td/a[contains(text(),'Delete')]")); actualCode.Click();
        }
    }
}