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
        public void verificarEstado_Test()
        {
            Estado_Cuenta i = new Estado_Cuenta();
            var cuenta = "2";
            var resEsperado = "ok";
            
            var resObtenido = i.verficarEstadoTest(cuenta);
            
            Assert.AreEqual(resEsperado, resObtenido);
        }

        [TestMethod]
        public void Debito_Test()
        {
            Debito i = new Debito();
            var cuenta = 1;
            var monto = 1;
            int correlativo = 8;
            var resEsperado = 1;
            var resObtenido = i.testDebito(correlativo, cuenta, monto);
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
        public void Transferencia_Test()
        {
            About i = new About();
            var cuentaOrigen = "1";
            var cuentaDestino = "2";
            var monto = "33";
            string resEsperado = "Exito!";

            var resObtenido = i.transTest(cuentaOrigen, monto, cuentaDestino);

            if (!resEsperado.Equals(resObtenido))
            {
                concat("");
                concat("***************************************************");
                concat("TEST TRANSFERENCIA FALLO");
                concat("Motivo: " + resObtenido);
                concat("***************************************************");
                concat("");
            }
            Assert.AreEqual(resEsperado, resObtenido);
        }

        [TestMethod]
        public void credito_Test()
        {
            Adminstrador i = new Adminstrador();
            string usuario = "cliente1";
            string monto = "2000";
            string descripcion = "varios";
            int correlativo = 3;//cambaiar este numero
            int cuenta = 1;
            double montoSumar = 2000;

            string resEsperado = "ok";

            var resObtenido = i.creditoTest(usuario,monto,descripcion,correlativo,cuenta,montoSumar);

            if (!resEsperado.Equals(resObtenido))
            {
                concat("");
                concat("***************************************************");
                concat("TEST Solicitud de Credito FALLO");
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
                concat("Motivo: No existe usuario o no tiene ningun saldo");
                concat("***************************************************");
                concat("");
            }            
            Assert.AreNotEqual(resEsperado, resObtenido);
        }
    }
}
