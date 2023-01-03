using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.IO;

namespace UnitTestCases.Init
{
    public class Init
    {
        private readonly Delay Delay = new Delay();
        private Process Process { get; set; } = new Process();
        //private string StartWADriver { get; } = $@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";
        //private string StartWADriver { get; } = File.ReadAllText($@"C:\Users\{Environment.UserName}\source\repos\UnitTestCases\UnitTestCases\Helper\DriverPath.txt");
        private string StartWADriver { get; } = File.ReadAllText($@"C:\Users\M\source\repos\UnitTestCases\UnitTestCases\Helper\DriverPath.txt");
        //private string NppPath { get; set; } = $@"C:\Program Files\Notepad++\notepad++.exe";
       // private string NppPath { get; set; } = File.ReadAllText($@"C:\Users\{Environment.UserName}\source\repos\UnitTestCases\UnitTestCases\Helper\AppPath2.txt");
        private string NppPath { get; set; } = File.ReadAllText($@"C:\Users\M\source\repos\UnitTestCases\UnitTestCases\Helper\AppPath2.txt");
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
