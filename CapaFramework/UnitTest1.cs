using CapaFramework.Config;
using CapaFramework.Helpers;
using NUnit.Framework;

namespace CapaFramework
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            ConfigReader.SetFrameworkSettings();
            Loggers.write("log message");
            Loggers.write("test1 executes");
            Loggers.write(Settings.URL);
        }

        [Test]
        public void Test2()
        {
            Loggers.write(Settings.Browser);
            Loggers.write("log message 2");
            
        }
    }
}