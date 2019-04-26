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
            var n1 = 10000;
            var n2 = 5;
            int resEsperado = 1;

            var resObtenido = s.metodoTest(n1, n2);
            Assert.AreEqual(resEsperado, resObtenido);
        }

        [TestMethod]
        public void Registro_Test()
        {
            Inicio i = new Inicio();
            var n1 = "Cliente1";
            var n2 = "12345678";
            int resEsperado = 1;

            var resObtenido = i.CrearUsuarioTest(n1,n2);
            Assert.AreEqual(resEsperado, resObtenido);
        }
    }
}
