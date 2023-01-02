using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCases.Init
{
    [TestClass]
    public class UnitTest1
    {

        protected static Init UITest;
        //private readonly Artikel Artikel = new Artikel(NotepadPlusPlus.Driver);
        //private readonly Keyboard Keyboard = new Keyboard();
        //private readonly Delay Delay = new Delay();

        [ClassInitialize]
        public static void CUPInitStart(TestContext _)
        {
            UITest = new Init();
            //Delay Delay = new Delay();
            //Thread ThreadDelay = new Thread(() => Delay.InSeconds(5));

            UITest.StartNotepadPlusPlus();
            //NotepadPlusPlus.BringCUPtoFront();

            //ThreadDelay.Start();
            //Delay.InSeconds(5);
            //NotepadPlusPlus.BringCUPtoFront();
            //CUP.Password.SendKeys(CUP.CUPPassword);

           // UITest.Login.Click();
            //Delay.InSeconds(3);

            //NotepadPlusPlus.BringCUPtoFront();
        }



        [TestMethod]
        public void TypingTestMethod()
        {
            UITest.Driver.FindElementByClassName("Scintilla").SendKeys("Das ist ein Text!");
        }
    }
}
