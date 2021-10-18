﻿using System;
using System.IO;
using DemoFramework.Base;
using Microsoft.Extensions.Configuration;

namespace DemoFramework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");


            IConfigurationRoot configurationRoot = builder.Build();


            Settings.AUT = configurationRoot.GetSection("testSettings").Get<TestSettings>().AUT;
            Settings.TestType = configurationRoot.GetSection("testSettings").Get<TestSettings>().TestType;
            Settings.IsLog = configurationRoot.GetSection("testSettings").Get<TestSettings>().IsLog;
            Settings.LogPath = configurationRoot.GetSection("testSettings").Get<TestSettings>().LogPath;
            Settings.AppConnectionString = configurationRoot.GetSection("testSettings").Get<TestSettings>().AUTConnectionString;
            Settings.BrowserType = configurationRoot.GetSection("testSettings").Get<TestSettings>().Browser;

        }

    }
}
