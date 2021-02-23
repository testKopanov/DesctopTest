using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace DesctopTest
{
    public class Tests
    {
        
        private WindowsDriver<WindowsElement> driver;

        [SetUp]
        public void Setup()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App,
                @"D:\Exam\ContactBook-DesktopClient.exe");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName,
                "Windows");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName,
                "WindowsPC");
            driver = new WindowsDriver<WindowsElement>(new Uri("http://[::1]:4723/wd/hub"), appiumOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        }

        [Test]
        public void Test1()
        {
            var buton = driver.FindElementByName("Connect");
            buton.Click();
            /* ???????? ?? ??? ???????, ????? ?? ???????, ??? ???? ?? ??????? ?????????, 
             * ?? ??????? ???????? ? ???????? ? ?????? ??-????? ?????.
            ??? ? ??????????? ?? ?? ?????? ???? ?????? - ?? ?? ?????? :) 
            */
            driver.FindElementByAccessibilityId("textBoxSearch").SendKeys("Steven");
            driver.FindElementByName("Search").Click();
            string name = driver.FindElementByName("FirstName Row 0, Not sorted").Text;
            Assert.AreEqual(name, "Steven");
        }
    }
}