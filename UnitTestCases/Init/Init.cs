﻿using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCases.Init
{
    class Init
    {
        private Process Process { get; set; } = new Process();
        private string StartWADriver { get; } = $@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";

        private string SteamPath { get; set; } = $@"C:\Program Files (x86)\Steam\Steam.exe";

        public RemoteWebDriver Driver { get; set; }


        public void StartDriver ()
        {
            Process.StartInfo.FileName = StartWADriver;
            Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start();
        }

        public void StartSteam()
        {

            StartDriver();

            AppiumOptions startStream = new AppiumOptions();
            startStream.AddAdditionalCapability("app", SteamPath);
            Driver = new RemoteWebDriver(new Uri("http://http://127.0.0.1:4723"), startStream);

        }

        private IWebElement _password;
        public IWebElement Password
        {
            get
            {
                _password = Driver.FindElementByName("PasswordTextEdit");
                 return _password;
            }
        }
        private IWebElement _login;
        public IWebElement Login
        {
            get
            {
                _login = Driver.FindElementByName("Login");
                return _login;
            }
        }

    }
}
