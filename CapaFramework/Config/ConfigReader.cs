using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace CapaFramework.Config
{
    class ConfigReader
    {

        public static void SetFrameworkSettings()
        {
            String workingDirectory = Environment.CurrentDirectory;
            String projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            var builder = new ConfigurationBuilder().SetBasePath(projectDirectory)
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configRoot = builder.Build();

            Settings.Browser = configRoot.GetSection("testSettings").Get<TestSettings>().Browser;
            Settings.URL = configRoot.GetSection("testSettings").Get<TestSettings>().URL;
            Settings.Username = configRoot.GetSection("testSettings").Get<TestSettings>().Username;
            Settings.Password = configRoot.GetSection("testSettings").Get<TestSettings>().Password;
            Settings.HeadlessBrowser = configRoot.GetSection("testSettings").Get<TestSettings>().HeadlessBrowser;

        }
    }
}
