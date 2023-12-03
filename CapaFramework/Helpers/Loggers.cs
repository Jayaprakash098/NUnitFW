using CapaFramework.Config;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CapaFramework.Helpers
{
    public static class Loggers
    {

        public static StreamWriter streamw = null;
        private static string logFileName = $"CapaNextGen_{DateTime.Now:yyyyMMdd_HHmmss}";

        public static void createLogFile()
        {
            //string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            //string logFileName = $"CapaNextGen_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            //string logFilePath = Path.Combine(dir, logFileName);
            
            //string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            //string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            //string projectPath = new Uri(actualPath).LocalPath;

            String workingDirectory = Environment.CurrentDirectory;
            String projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            string dir = projectDirectory +"\\Log\\";
            
            if (Directory.Exists(dir))
            {
                
                streamw = File.AppendText(dir + logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                streamw = File.AppendText(dir + logFileName + ".log");
            }

        }

        public static void write(string logMessage)
        {
            createLogFile();
            //streamw.Write("{0} {1}\t", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            //streamw.Write( "{0} : ", logMessage);
            streamw.Write($"{ DateTime.Now} :   " + logMessage + Environment.NewLine);
            streamw.Flush();
            streamw.Close();
        }
    }
}
