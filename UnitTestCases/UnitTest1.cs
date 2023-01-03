using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCases.Init
{
    [TestClass]
    public class UnitTest1
    {

        protected static Init UITest;
        //private readonly Artikel Artikel = new Artikel(NotepadPlusPlus.Driver);
        //private readonly Keyboard Keyboard = new Keyboard();
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
            UITest.Driver.FindElementByClassName("Scintilla").SendKeys("Das ist ein Text!\n");
            Delay.InSeconds(5);
            UITest.Driver.FindElementByClassName("Scintilla").SendKeys("Ciao!");
            Delay.InSeconds(2);
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
