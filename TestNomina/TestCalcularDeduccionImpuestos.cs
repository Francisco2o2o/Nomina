using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaNegocio;
using System;
using System.Collections.Generic;

namespace TestNomina
{
    [TestClass]
    public class TestCalcularDeduccionImpuestos
    {
        [TestMethod]
        public void CalcularDeduccionImpuestos_DeberiaCalcularDeduccionCorrectamenteConVariosSalarios()
        {
            var metodosPagos = new MetodosPagos();
            List<decimal> salarios = new List<decimal> { 1000m, 1500m, 2000m };
            decimal resultado = metodosPagos.CalcularDeduccionImpuestos(salarios);
            decimal esperado = (1000m * 0.08m) + (1500m * 0.08m) + (2000m * 0.08m);
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void CalcularDeduccionImpuestos_DeberiaDevolverCeroCuandoNoHaySalarios()
        {
            var metodosPagos = new MetodosPagos();
            List<decimal> salarios = new List<decimal>();
            decimal resultado = metodosPagos.CalcularDeduccionImpuestos(salarios);
            Assert.AreEqual(0m, resultado);
        }

        [TestMethod]
        public void CalcularDeduccionImpuestos_DeberiaDevolverCeroCuandoTodosLosSalariosSonCero()
        {
            var metodosPagos = new MetodosPagos();
            List<decimal> salarios = new List<decimal> { 0m, 0m, 0m };
            decimal resultado = metodosPagos.CalcularDeduccionImpuestos(salarios);
            Assert.AreEqual(0m, resultado);
        }

        [TestMethod]
        public void CalcularDeduccionImpuestos_DeberiaSumarDeduccionesConValoresNegativos()
        {
            var metodosPagos = new MetodosPagos();
            List<decimal> salarios = new List<decimal> { -1000m, -1500m, -2000m };
            decimal resultado = metodosPagos.CalcularDeduccionImpuestos(salarios);
            decimal esperado = (-1000m * 0.08m) + (-1500m * 0.08m) + (-2000m * 0.08m);
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void CalcularDeduccionImpuestos_DeberiaCalcularDeduccionConCombinacionDeValoresPositivosYNegativos()
        {
            var metodosPagos = new MetodosPagos();
            List<decimal> salarios = new List<decimal> { 1000m, -1500m, 2000m };
            decimal resultado = metodosPagos.CalcularDeduccionImpuestos(salarios);
            decimal esperado = (1000m * 0.08m) + (-1500m * 0.08m) + (2000m * 0.08m);
            Assert.AreEqual(esperado, resultado);
        }
    }
}
