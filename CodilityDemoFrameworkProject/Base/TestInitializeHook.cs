using DemoFramework.Config;
using DemoFramework.Helpers;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Remote;
using System;
using OpenQA.Selenium;

namespace DemoFramework.Base
{
    public class TestInitializeHook : Steps
    {

        private readonly ParallelConfig _parallelConfig;

        public TestInitializeHook(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }


        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Set Log
            LogHelpers.CreateLogFile();

            //Open Browser
            OpenBrowser(GetBrowserOption(Settings.BrowserType));

            LogHelpers.Write("Initialized framework");

        }

        private void OpenBrowser(DriverOptions driverOptions)
        {
            switch (driverOptions)
            {
                case InternetExplorerOptions internetExplorerOptions:
                    //ToDo
                    break;
                case FirefoxOptions firefoxOptions:
                    //To Do
                    break;
                case ChromeOptions chromeOptions:
                    chromeOptions.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);
                    break;
            }

            _parallelConfig.Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"),driverOptions.ToCapabilities());
        }

        public DriverOptions GetBrowserOption(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    return new InternetExplorerOptions();
                case BrowserType.FireFox:
                    return new FirefoxOptions();
                case BrowserType.Chrome:
                    return new ChromeOptions();
                default:
                    return new ChromeOptions();
            }
        }
    }
}
