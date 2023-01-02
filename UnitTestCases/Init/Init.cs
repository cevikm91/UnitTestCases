﻿using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;

namespace UnitTestCases.Init
{
    public class Init
    {
        //private WindowsDriver<WindowsElement> _driver;
        private Process Process { get; set; } = new Process();
        private string StartWADriver { get; } = $@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";
        //private string SteamPath { get; set; } = $@"C:\Program Files (x86)\Steam\Steam.exe";
        private string NotepadPlusPlusPath { get; set; } = $@"C:\Program Files\Notepad++\notepad++.exe";
        public RemoteWebDriver Driver { get; set; }

        private readonly Delay Delay = new Delay();
        

        public void StartDriver ()
        {
            Process.StartInfo.FileName = StartWADriver;
            Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start();
        }

       /* public void StartSteam()
        {

            StartDriver();

            AppiumOptions startSteam = new AppiumOptions();
            startStream.AddAdditionalCapability("app", SteamPath);
            Driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723"), startSteam);

        }*/
        
        public void StartNotepadPlusPlus()
        {
            StartDriver();

            AppiumOptions StartNotepadPlusPlus = new AppiumOptions();
            StartNotepadPlusPlus.AddAdditionalCapability("app", NotepadPlusPlusPath);
            Driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723"), StartNotepadPlusPlus);
        }

        /*private IWebElement _login;
        public IWebElement Login
        {
            get
            {
                _login = Driver.FindElementByName("Login");
                return _login;
            }
        }*/


        public void CloseNotepadPlusPlus()
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
