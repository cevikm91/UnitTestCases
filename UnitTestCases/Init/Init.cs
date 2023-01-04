using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;
using System.Diagnostics;

namespace UnitTestCases.Init
{
    public class Init
    {
        private readonly Delay Delay = new Delay();
        private Process Process { get; set; } = new Process();
        private string StartWADriver { get; } = ConfigurationManager.AppSettings.Get("DriverPath");
        private string NppPath { get; set; } = ConfigurationManager.AppSettings.Get("AppPathDesktop");
        //private string NppPath { get; set; } = ConfigurationManager.AppSettings.Get("AppPathLaptop");
        public RemoteWebDriver Driver { get; set; }
        
        
        public void StartDriver ()
        {
            Process.StartInfo.FileName = StartWADriver;
            Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start();
        }
        
        public void StartNpp()
        {
            StartDriver();

            AppiumOptions StartNpp = new AppiumOptions();
            StartNpp.AddAdditionalCapability("app", NppPath);
            Driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723"), StartNpp);
        }

        public void CloseNpp()
        {
            Delay.InSeconds(2);
            foreach (var nppProcess in Process.GetProcessesByName("notepad++"))
            {
                nppProcess.Kill();
            }
        }

        public void CloseWADriver()
        {
            foreach (var WAPProcess in Process.GetProcessesByName("WinAppDriver"))
            {
                WAPProcess.Kill();
            }
        }

    }
}
