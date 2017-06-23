using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using prjDAL;
using prjDil;
using prjBLL;
using prjControlCar;
using System.Windows.Forms;
using System.Configuration;

namespace LoginTeste
{
    [TestClass]
    public class UnitTest1
    {
      

        [TestMethod]
        public void TestMethod1()
        {
            FormCliente cliente = new FormCliente();

            Assert.AreEqual(true, cliente.validarCPF("67742476010"));
        }
    }
}
