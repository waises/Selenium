using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.aviasales.by/");
            Assert.IsTrue(driver.Url.Contains("aviasales.by"), "Something wrong");


            IWebElement element_dest = driver.FindElement(By.XPath("//input[@id='destination']"));
            element_dest.SendKeys("ќмск"+Keys.Enter);

            IWebElement element_check_oms = driver.FindElement(By.XPath("//div[contains(@class, 'avia-form__field --destination')]//span[@class='autocomplete__iata']"));
            
            Assert.IsTrue(element_check_oms.Text=="OMS", $"problem with {element_check_oms}");
            Assert.AreEqual(element_check_oms, "OMS");


            IWebElement element_swap = driver.FindElement(By.XPath("//div[@data-test-id='swap-places']"));
            element_swap.Click();

            IWebElement element_check_omsk = driver.FindElement(By.XPath("//input[@id='origin']"));
            Assert.IsTrue(element_check_omsk.Text.Contains("ќмск"), "problem with omsk");
            //driver.Quit();
        }
    }
}