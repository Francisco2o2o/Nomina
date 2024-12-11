using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaNegocio;
using System;
using System.Collections.Generic;

namespace TestNomina
{
    [TestClass]
    public class TestCalcularMontoTotalPago
    {
        [TestMethod]
        public void CalcularMontoTotalPago_DeberiaSumarCorrectamenteLosSalarios()
        {
            var metodosPagos = new MetodosPagos();
            var salarios = new List<decimal> { 1000m, 2000m, 3000m };
            decimal resultado = metodosPagos.CalcularMontoTotalPago(salarios);
            decimal esperado = 1000m + 2000m + 3000m;
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void CalcularMontoTotalPago_DeberiaRetornarCeroCuandoLaListaEstaVacia()
        {
            var metodosPagos = new MetodosPagos();
            var salarios = new List<decimal>();
            decimal resultado = metodosPagos.CalcularMontoTotalPago(salarios);
            Assert.AreEqual(0m, resultado);
        }

        [TestMethod]
        public void CalcularMontoTotalPago_DeberiaSumarCorrectamenteCuandoHayUnSoloSalario()
        {
            var metodosPagos = new MetodosPagos();
            var salarios = new List<decimal> { 1500m };
            decimal resultado = metodosPagos.CalcularMontoTotalPago(salarios);
            Assert.AreEqual(1500m, resultado);
        }

        [TestMethod]
        public void CalcularMontoTotalPago_DeberiaSumarCorrectamenteConSalariosNegativos()
        {
            var metodosPagos = new MetodosPagos();
            var salarios = new List<decimal> { -1000m, 2000m, 1500m };
            decimal resultado = metodosPagos.CalcularMontoTotalPago(salarios);
            decimal esperado = -1000m + 2000m + 1500m;
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void CalcularMontoTotalPago_DeberiaSumarCorrectamenteConDecimales()
        {
            var metodosPagos = new MetodosPagos();
            var salarios = new List<decimal> { 1500.75m, 2500.50m, 1200.25m };
            decimal resultado = metodosPagos.CalcularMontoTotalPago(salarios);
            decimal esperado = 1500.75m + 2500.50m + 1200.25m;
            Assert.AreEqual(esperado, resultado);
        }
    }
}
