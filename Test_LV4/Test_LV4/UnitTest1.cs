using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace RUAP_LV4
{
    [TestFixture]
    public class TestiranjeRegister
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://demo.opencart.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheIranjeRegisterTest()
        {
            var rand = new Random();
            var i = rand.Next(1, 100000);
            var j = rand.Next(1, 100000);

            driver.Navigate().GoToUrl(baseURL + "/");
            Assert.AreEqual("Your Store", driver.Title);
            driver.FindElement(By.LinkText("My Account")).Click();
            driver.FindElement(By.LinkText("Register")).Click();
            Assert.AreEqual("Register Account", driver.Title);
            driver.FindElement(By.Id("input-firstname")).Clear();
            driver.FindElement(By.Id("input-firstname")).SendKeys("jt2"+i);
            driver.FindElement(By.Id("input-lastname")).Clear();
            driver.FindElement(By.Id("input-lastname")).SendKeys("jt2"+j);
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("jtomaic"+i+"@hotmail.com");
            driver.FindElement(By.Id("input-telephone")).Clear();
            driver.FindElement(By.Id("input-telephone")).SendKeys("456321"+j);
            driver.FindElement(By.Id("input-fax")).Clear();
            driver.FindElement(By.Id("input-fax")).SendKeys("x"+i);
            driver.FindElement(By.Id("input-company")).Clear();
            driver.FindElement(By.Id("input-company")).SendKeys("xyzq");
            driver.FindElement(By.Id("input-address-1")).Clear();
            driver.FindElement(By.Id("input-address-1")).SendKeys("xyzq"+i);
            driver.FindElement(By.Id("input-address-2")).Clear();
            driver.FindElement(By.Id("input-address-2")).SendKeys("xyzq"+j);
            driver.FindElement(By.Id("input-city")).Clear();
            driver.FindElement(By.Id("input-city")).SendKeys("grad"+j);
            driver.FindElement(By.Id("input-postcode")).Clear();
            driver.FindElement(By.Id("input-postcode")).SendKeys("5000");
            new SelectElement(driver.FindElement(By.Id("input-zone"))).SelectByText("Cardiff");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("xyzq"+i);
            driver.FindElement(By.Id("input-confirm")).Clear();
            driver.FindElement(By.Id("input-confirm")).SendKeys("xyzq"+i);
            driver.FindElement(By.Name("newsletter")).Click();
            driver.FindElement(By.Name("agree")).Click();
            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            Assert.AreEqual("Your Account Has Been Created!", driver.Title);
            driver.FindElement(By.LinkText("Continue")).Click();
            Assert.AreEqual("My Account", driver.Title);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
