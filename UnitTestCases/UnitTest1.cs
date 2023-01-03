using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Windows.Forms;

namespace UnitTestCases.Init
{
    [TestClass]
    public class UnitTest1
    {
        protected static Init UITest;
        private readonly Delay Delay = new Delay();

        [ClassInitialize]
        public static void CUPInitStart(TestContext _)
        {
            UITest = new Init();
            Delay Delay = new Delay();

            UITest.StartNpp();
            Delay.InSeconds(5);
        }

        [TestMethod]
        public void TypingTestMethod()
        {           
            Delay.InSeconds(1);
            SendKeys.SendWait("^{n}");
            UITest.Driver.FindElementByClassName("Scintilla").SendKeys("Unser erster UITest für Notepad++ !!!\n");
            Delay.InSeconds(1);
            SendKeys.SendWait("^{s}");
            Delay.InSeconds(2);
            SendKeys.SendWait("UITextDatei.txt");
            Delay.InSeconds(1);
            UITest.Driver.FindElementByName("Speichern").Click();
            Delay.InSeconds(3);
        }

         [ClassCleanup()]
        public static void CloseUiTest()
        {
            UITest.CloseNpp();
            UITest.CloseWADriver();
            UITest = null;
        }
    }
}
