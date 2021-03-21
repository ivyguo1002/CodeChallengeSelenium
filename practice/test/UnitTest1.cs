using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace test
{
    public class Tests
    {
        public IWebDriver Driver { get; set; }
        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
        }

        [Test]
        public void TestVideoSkip()
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            Driver.Navigate().GoToUrl("https://www.youtube.com/watch?v=1z9cX_lpkFg");
            // slider - drag and drop
            var actions = new Actions(Driver);
            Thread.Sleep(5000);
            var slider = Driver.FindElement(By.CssSelector(".ytp-progress-bar"));
            float ratio = 0.5F;
            var pixelsToMove = Convert.ToInt32(slider.Size.Width * ratio);
            var indicator = Driver.FindElement(By.CssSelector("div.ytp-scrubber-container"));
            actions.ClickAndHold(indicator).MoveByOffset(pixelsToMove, 0).Release().Build().Perform();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}