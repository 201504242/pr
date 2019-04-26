using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancoGT;
using System.IO;
using System.Text;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        string fileName = @"C:\Users\p_ab1\Desktop\Analisis\pr\PruebasUnitarias\result.txt";
        public void concat(String textp)
        {
            using (StreamWriter fs = File.AppendText(fileName))
            {   
                fs.WriteLine(textp);
                fs.Close();
            }
            
        }


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
            String resEsperado = "si";
            var resObtenido = i.CrearUsuarioTest(n1,n2);
            if (!resEsperado.Equals(resObtenido))
            {
                concat("");
                concat("***************************************************");
                concat("TEST REGISTRO FALLO");
                concat("Motivo: "+resObtenido);
                concat("***************************************************");
                concat("");
            }
            Assert.AreEqual(resEsperado, resObtenido);
            
        }

        [TestMethod]
        public void Login_Test()
        {
            Inicio i = new Inicio();
            var usuario = "Cliente1";
            var pass = "12345678";
            var codigo = "2";
            string resEsperado = "si";

            var resObtenido = i.iniciar_sesion_Test(usuario,pass,codigo);

            if (!resEsperado.Equals(resObtenido))
            {
                concat("");
                concat("***************************************************");
                concat("TEST LOGIN FALLO");
                concat("Motivo: " + resObtenido);
                concat("***************************************************");
                concat("");
            }
            Assert.AreEqual(resEsperado, resObtenido);            
        }

        [TestMethod]
        public void consultarSaldo_Test()
        {
            Inicio i = new Inicio();
            var usuario = "Cliente1";
            String resEsperado = "Saldo:";

            String resObtenido = i.consultarSaldoTest(usuario);

            if (resEsperado.Equals(resObtenido))
            {
                concat("");
                concat("***************************************************");
                concat("TEST CONSULTAR SALDO FALLO");
                concat("Motivo: No existe usuario o no tiene un saldo de 0");
                concat("***************************************************");
                concat("");
            }            
            Assert.AreNotEqual(resEsperado, resObtenido);
        }
    }
}
