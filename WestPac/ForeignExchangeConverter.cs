using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WestPacForeignExchange
{
    class CurrencyConverter
    {
        IWebDriver driver;
        [SetUp]
        public void SetupDriver() {
            TestContext.WriteLine("set up the driver");
            driver = new ChromeDriver("C:\\Users\\jimmy\\source\\repos\\WestPac\\WestPac\\bin\\Debug\\");
            driver.Navigate().GoToUrl("https://www.westpac.co.nz");
            driver.Manage().Window.Maximize();
        }

        //validates the message "Please enter the amount you want to convert" is displayed 
        //when the Convert button is clicked without entering a value in the amount input box
        [Test]
        public void Story1NoAmountEntered()
        {
            IWebElement westpacFrame;
            TestContext.WriteLine("No amount entered, convert button is clicked");
            NavigateToCurrencyConverter(); 
            westpacFrame = driver.FindElement(By.Id("westpac-iframe"));
            //switch to the westpac-iframe
            driver.SwitchTo().Frame(westpacFrame);
            if (IsElementFound(By.Id("convert"), out IWebElement ConvertButton))
            {
                ConvertButton.Click();
                String ExpectedText = "Please enter the amount you want to convert.";
                String ActualText = driver.FindElement(By.Id("errordiv")).Text;
                TestContext.WriteLine("ActualText is " + ActualText);
                Assert.AreEqual(ExpectedText, ActualText, "failed to find " + ExpectedText);
            }
        }
            
        [Test]
        // User is able to convert 1 NZD to USD successfully
        public void Story2ConvertNZD2USD()
        {
            IWebElement westpacFrame;
            TestContext.WriteLine("Convert NZD to USD");
            NavigateToCurrencyConverter();
            westpacFrame = driver.FindElement(By.Id("westpac-iframe"));
            //switch to the westpac-iframe
            driver.SwitchTo().Frame(westpacFrame);
            driver.FindElement(By.Id("ConvertFrom"))
                  .FindElement(By.XPath("//select[1]/option[1]")).Click();
            driver.FindElement(By.Id("ConvertTo"))
                              .FindElement(By.XPath("//select[2]/option[2]")).Click();
            driver.FindElement(By.Name("Amount")).SendKeys("1");
            if (IsElementFound(By.Id("convert"), out IWebElement ConvertButton))
            {
                ConvertButton.Click();
                String ActualText = driver.FindElement(By.Id("resultsdiv")).Text;
                TestContext.WriteLine("ActualText is " + ActualText);
                String FailedMessage = "failed to convert NZD to USD";
                Assert.IsTrue(ActualText.Contains("1 New Zealand Dollar"), FailedMessage);
                Assert.IsTrue(ActualText.Contains("United States Dollar"), FailedMessage);
                Assert.IsTrue(ActualText.Contains("Would you like to make another calculation"), FailedMessage);
            }
        }

        [Test]
        // User is able to convert 1 USD to NZD successfully 
        public void Story2ConvertUSDtoNZD()
        {
            IWebElement westpacFrame;
            TestContext.WriteLine("Convert USD to NZD");
            NavigateToCurrencyConverter();
            westpacFrame = driver.FindElement(By.Id("westpac-iframe"));
            //switch to the westpac-iframe
            driver.SwitchTo().Frame(westpacFrame);
            driver.FindElement(By.Id("ConvertFrom"))
                  .FindElement(By.XPath("//select[1]/option[2]")).Click();
            driver.FindElement(By.Id("ConvertTo"))
                              .FindElement(By.XPath("//select[2]/option[1]")).Click();
            driver.FindElement(By.Name("Amount")).SendKeys("1");
            if (IsElementFound(By.Id("convert"), out IWebElement ConvertButton))
            {
                ConvertButton.Click();
                String ActualText = driver.FindElement(By.Id("resultsdiv")).Text;
                TestContext.WriteLine("ActualText is " + ActualText);
                String FailedMessage = "failed to convert USD to NZD";
                Assert.IsTrue(ActualText.Contains("1 United States Dollar"), FailedMessage);
                Assert.IsTrue(ActualText.Contains("New Zealand Dollar"), FailedMessage);
                Assert.IsTrue(ActualText.Contains("Would you like to make another calculation"), FailedMessage);
                Assert.IsTrue(ActualText.Contains("notes you wish to exchange"), FailedMessage);
            }
        }

        [Test]
        // User is able to convert 1 Pound Sterling to NZD successfully 
        public void Story2ConvertPoundToNZD()
        {
            IWebElement westpacFrame;
            TestContext.WriteLine("Convert Pound Sterling to NZD");
            NavigateToCurrencyConverter();
            westpacFrame = driver.FindElement(By.Id("westpac-iframe"));
            //switch to the westpac-iframe
            driver.SwitchTo().Frame(westpacFrame);
            driver.FindElement(By.Id("ConvertFrom"))
                  .FindElement(By.XPath("//select[1]/option[3]")).Click();
            driver.FindElement(By.Id("ConvertTo"))
                              .FindElement(By.XPath("//select[2]/option[1]")).Click();
            driver.FindElement(By.Name("Amount")).SendKeys("1");
            if (IsElementFound(By.Id("convert"), out IWebElement ConvertButton))
            {
                ConvertButton.Click();
                String ActualText = driver.FindElement(By.Id("resultsdiv")).Text;
                TestContext.WriteLine("ActualText is " + ActualText);
                String FailedMessage = "failed to convert Pound Sterling to NZD";
                Assert.IsTrue(ActualText.Contains("1 Pound Sterling"), FailedMessage);
                Assert.IsTrue(ActualText.Contains("New Zealand Dollar"), FailedMessage);
                Assert.IsTrue(ActualText.Contains("Would you like to make another calculation"), FailedMessage);
                Assert.IsTrue(ActualText.Contains("if you are purchasing Pound Sterling"), FailedMessage);
            }
        }

        [Test]
        // User is able to convert 1 Swiss Franc to EURO successfully 
        public void Story2ConvertSwissFrancToEuro()
        {
            IWebElement westpacFrame;
            TestContext.WriteLine("Convert Swiss Franc to EURO");
            NavigateToCurrencyConverter();
            westpacFrame = driver.FindElement(By.Id("westpac-iframe"));
            //switch to the westpac-iframe
            driver.SwitchTo().Frame(westpacFrame);
            driver.FindElement(By.Id("ConvertFrom"))
                  .FindElement(By.XPath("//select[1]/option[9]")).Click();
            driver.FindElement(By.Id("ConvertTo"))
                              .FindElement(By.XPath("//select[2]/option[5]")).Click();
            driver.FindElement(By.Name("Amount")).SendKeys("1");
            if (IsElementFound(By.Id("convert"), out IWebElement ConvertButton))
            {
                ConvertButton.Click();
                String ActualText = driver.FindElement(By.Id("resultsdiv")).Text;
                TestContext.WriteLine("ActualText is " + ActualText);
                String FailedMessage = "failed to convert Swiss Franc to Euro";
                Assert.IsTrue(ActualText.Contains("1 Swiss Franc"), FailedMessage);
                Assert.IsTrue(ActualText.Contains("Euro"), FailedMessage);
                Assert.IsTrue(ActualText.Contains("Would you like to make another calculation"), FailedMessage);
            
            }
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
        }

        // navigates to the currency converter page
        public void NavigateToCurrencyConverter()
        {
            IWebElement element;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            element = wait.Until(SeleniumExtras.WaitHelpers
                      .ExpectedConditions.ElementIsVisible
                      (By.Id("ubermenu-section-link-fx-travel-and-migrant-ps")));
            Actions action = new Actions(driver);
            //Move to the Fx, travel & migrant menu
            action.MoveToElement(element).Perform();
            element = wait.Until(SeleniumExtras.WaitHelpers
                      .ExpectedConditions.ElementIsVisible
                      (By.Id("ubermenu-item-cta-currency-converter-ps")));
            //Find and click the Curency converter button
            if (IsElementFound(By.Id("ubermenu-item-cta-currency-converter-ps"), out element))
                element.Click();
            // wait for the westpac-iframe is available
            element = wait.Until(SeleniumExtras.WaitHelpers
                      .ExpectedConditions.ElementIsVisible
                      (By.Id("westpac-iframe")));
        }


        // search for element in the page, return true if found or false for not found
        public bool IsElementFound (By by, out IWebElement outElement){
            try
            {
                outElement = driver.FindElement(by); 
            }
            catch (NoSuchElementException) {
                TestContext.WriteLine("The Element not found");
                outElement = null;
                return false;
            }
            return true;
        } 

    }
}