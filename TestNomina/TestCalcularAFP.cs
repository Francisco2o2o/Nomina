using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaNegocio;
using System;
using System.Collections.Generic;

namespace TestNomina
{
    [TestClass]
    public class TestCalcularAFP
    {
        [TestMethod]
        public void CalcularAFP_DeberiaCalcularAFPCorrectamenteConVariosSalarios()
        {
            var metodosPagos = new MetodosPagos();
            List<decimal> salarios = new List<decimal> { 1000m, 1500m, 2000m };
            decimal resultado = metodosPagos.CalcularAFP(salarios);
            decimal esperado = (1000m * 0.1m) + (1500m * 0.1m) + (2000m * 0.1m);
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void CalcularAFP_DeberiaDevolverCeroCuandoNoHaySalarios()
        {
            var metodosPagos = new MetodosPagos();
            List<decimal> salarios = new List<decimal>();
            decimal resultado = metodosPagos.CalcularAFP(salarios);
            Assert.AreEqual(0m, resultado);
        }

        [TestMethod]
        public void CalcularAFP_DeberiaDevolverCeroCuandoTodosLosSalariosSonCero()
        {
            var metodosPagos = new MetodosPagos();
            List<decimal> salarios = new List<decimal> { 0m, 0m, 0m };
            decimal resultado = metodosPagos.CalcularAFP(salarios);
            Assert.AreEqual(0m, resultado);
        }

        [TestMethod]
        public void CalcularAFP_DeberiaSumarAFPConValoresNegativos()
        {
            var metodosPagos = new MetodosPagos();
            List<decimal> salarios = new List<decimal> { -1000m, -1500m, -2000m };
            decimal resultado = metodosPagos.CalcularAFP(salarios);
            decimal esperado = (-1000m * 0.1m) + (-1500m * 0.1m) + (-2000m * 0.1m);
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void CalcularAFP_DeberiaCalcularAFPConCombinacionDeValoresPositivosYNegativos()
        {
            var metodosPagos = new MetodosPagos();
            List<decimal> salarios = new List<decimal> { 1000m, -1500m, 2000m };
            decimal resultado = metodosPagos.CalcularAFP(salarios);
            decimal esperado = (1000m * 0.1m) + (-1500m * 0.1m) + (2000m * 0.1m);
            Assert.AreEqual(esperado, resultado);
        }
    }
}
