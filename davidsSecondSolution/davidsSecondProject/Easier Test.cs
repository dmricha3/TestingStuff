using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace QuickAutomationRepo
{
    [TestFixture]
    public class EasierTests
    {
        private IWebDriver driver;

        //public IWebElement WaitUntilElementClickable(By elementLocator, int timeout = 10)
        //{
        //    try
        //    {
        //        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
        //        return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
        //        throw;
        //    }
        //}
        // this is a test
        /*
         *Establish a timeout
         * Make a way to track time
         * Make a way to break out of the while loop if it goes over time.
         */
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body


        public void WaitUntilElementPresent(By elementLocator, int timeout = 10)
        {   
            var remainingTime = timeout;
            System.Diagnostics.Stopwatch sp = new Stopwatch();
            sp.Restart();
            var counter = 0;
            while (remainingTime > 0)
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("We hit the try!");
                    driver.FindElement(elementLocator);
                    break;
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("We hit the catch!");                    
                }
                counter++;
                remainingTime = remainingTime--;
                Thread.Sleep(1000);
            }

            throw new Exception($"Element not found: {elementLocator.ToString()} waited for {sp.ElapsedMilliseconds} ms checked {counter} times");
            //This will throw the error as well as the element it happened on.
        }

#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body


        [SetUp]
        public void Setup()
        {
            //var options = new ChromeOptions();
            //options.AddArgument("no-sandbox");
            driver = new ChromeDriver("/Users/david.richards/projects/QuickAutomationRepo/QuickAutomationRepo/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
        }

        [Test]
        public void Test1()
        {
            driver.Url = "http://automationpractice.com/index.php";
            string username = "scubachicken88@gmail.com";
            string pass = "JavaPura1!";
            //sup bro

            driver.FindElement(By.XPath("//*[@class='login']")).Click();
           
            WaitUntilElementPresent(By.XPath("//*[@id='email']"), 20);

           
            driver.FindElement(By.XPath("//*[@id='email']")).Click();
            driver.FindElement(By.XPath("//*[@id='email']")).SendKeys(username);
                   

            driver.FindElement(By.XPath("//*[@id='passwd']")).Click();
            driver.FindElement(By.XPath("//*[@id='passwd']")).SendKeys(pass);

            driver.FindElement(By.XPath("//*[@class='icon-lock left']")).Click();
            WaitUntilElementPresent(By.XPath("(//*[@title='Dresses'][2])"));

            driver.FindElement(By.XPath("(//*[@title='Dresses'][2])")).Click();
            WaitUntilElementPresent(By.XPath("(//*[@title='Printed Summer Dress'])"));

            driver.FindElement(By.XPath("(//*[@title='Printed Summer Dress'])")).Click();
            WaitUntilElementPresent(By.XPath("//*[@id='thumb_13']"));

            driver.FindElement(By.XPath("//*[@id='thumb_13']")).Click();
            WaitUntilElementPresent(By.XPath("(//*[@title='Close'])"));

            driver.FindElement(By.XPath("(//*[@title='Close'])")).Click();
            WaitUntilElementPresent(By.XPath("//*[@id='group_1']"));

            driver.FindElement(By.XPath("//*[@id='group_1']")).Click();
            driver.FindElement(By.XPath("(//*[@title='L'])")).Click();
            WaitUntilElementPresent(By.XPath("//*[@class='exclusive']"));

            driver.FindElement(By.XPath("//*[@class='exclusive']")).Click();
                    
        }
        [OneTimeTearDown]
        public void End()
        {
            driver.Close();
            driver.Dispose();
        }

    }
}