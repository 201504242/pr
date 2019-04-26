using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancoGT;
using System.IO;
using System.Text;

using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Data;
using System.Drawing;
using System.Diagnostics;

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
        public void PDF_Test()
        {
            Estado_Cuenta ii = new Estado_Cuenta();
            var cuenta = "2";
            var resEsperado = "ok";
            DataSet ds = new DataSet();
            ds = ii.imprimirTEST(cuenta);
            try
            {
                int i = 0;
                string sql = null;
                int yPoint = 0;
                string c1 = null;
                string c2 = null;
                string c3 = null;
                string c4 = null;
                string c5 = null;
                string c6 = null;

                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = "Database to PDF";
                PdfPage pdfPage = pdf.AddPage();
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XFont font = new XFont("Verdana", 10, XFontStyle.Regular);

                graph.DrawString("Correlativo", font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormat.TopLeft);
                graph.DrawString("Cuenta", font, XBrushes.Black, new XRect(100, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormat.TopLeft);
                graph.DrawString("Tipo", font, XBrushes.Black, new XRect(160, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormat.TopLeft);
                graph.DrawString("Monto", font, XBrushes.Black, new XRect(220, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormat.TopLeft);
                graph.DrawString("Movimiento", font, XBrushes.Black, new XRect(300, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormat.TopLeft);
                graph.DrawString("Fecha", font, XBrushes.Black, new XRect(340, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormat.TopLeft);

                yPoint = yPoint + 50;

                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    c1 = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    c2 = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    c3 = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    c4 = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    c5 = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                    c6 = ds.Tables[0].Rows[i].ItemArray[5].ToString();

                    graph.DrawString(c1, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormat.TopLeft);
                    graph.DrawString(c2, font, XBrushes.Black, new XRect(100, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormat.TopLeft);
                    graph.DrawString(c3, font, XBrushes.Black, new XRect(160, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormat.TopLeft);
                    graph.DrawString(c4, font, XBrushes.Black, new XRect(220, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormat.TopLeft);
                    graph.DrawString(c5, font, XBrushes.Black, new XRect(300, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormat.TopLeft);
                    graph.DrawString(c6, font, XBrushes.Black, new XRect(340, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormat.TopLeft);

                    yPoint = yPoint + 20;
                }
                string pdfFilename = "test.pdf";
                pdf.Save(pdfFilename);
                Process.Start(pdfFilename);
            }
            catch (Exception)
            {
                Assert.AreEqual(resEsperado, "ERROR");
            }            
            Assert.AreEqual(resEsperado, "ok");
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
