﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForWinLottoBL
{
    [TestClass]
    public class UnitTestLotto
    {
        [TestMethod]
        public void TestGetWeek()
        {
            // Viittaus oikeaan luokkaan ja sen metodiin
            JAMK.IT.WinLotto.Lotto lotto = new JAMK.IT.WinLotto.Lotto();
            // Kutsutaan testattavaa metodia
            string vk = lotto.GetWeekUnfinished();
            Assert.AreEqual("41/2015", vk);

        }
        [TestMethod]
        public void TestGetWeek2()
        {
            // Viittaus oikeaan luokkaan ja sen metodiin
            JAMK.IT.WinLotto.Lotto lotto = new JAMK.IT.WinLotto.Lotto();
            // Kutsutaan testattavaa metodia
            string vk = lotto.GetWeekUnfinished();
            Assert.AreEqual("41/2015", vk);

        }
    }
}
