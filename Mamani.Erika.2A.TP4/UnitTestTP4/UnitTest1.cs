using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestTP4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PaqueteListaInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]

        public void PaquetesRepetidos()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Falsa 123", "123456");
            Paquete p2 = new Paquete("Calle 456", "123456");

            correo += p1;

            try
            {
                correo += p2;
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
