using System;
using System.Threading;


namespace UnitTestCases.Helper
{
    public class Delay
    {
        public void InSeconds(int seconds) => Thread.Sleep(TimeSpan.FromSeconds(seconds));

        public void InMilliSeconds(double miliSeconds) => Thread.Sleep(TimeSpan.FromMilliseconds(miliSeconds));

    }
}
