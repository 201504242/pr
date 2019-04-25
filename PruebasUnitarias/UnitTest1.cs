using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancoGT;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Operaciones s = new Operaciones();
            var n1 = 10;
            var n2 = 5;
            int resEsperado = 1;

            var resObtenido = s.metodoTest(n1, n2);
            Assert.AreEqual(resEsperado, resObtenido);
        }
    }
}
