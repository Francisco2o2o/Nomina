using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaNegocio;
using System;

namespace TestNomina
{
    [TestClass]
    public class TestCalcularDescuentosTotales
    {
        [TestMethod]
        public void CalcularDescuentosTotales_DeberiaCalcularDescuentosCorrectamenteConValoresPositivos()
        {
            var metodosPagos = new MetodosPagos();
            decimal DeduccionesSeguros = 100m;
            decimal AFP = 150m;
            decimal DeduccionImpuestos = 50m;
            decimal resultado = metodosPagos.CalcularDescuentosTotales(DeduccionesSeguros, AFP, DeduccionImpuestos);
            decimal esperado = 100m + 150m + 50m;
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void CalcularDescuentosTotales_DeberiaDevolverCeroCuandoTodosLosDescuentosSonCero()
        {
            var metodosPagos = new MetodosPagos();
            decimal DeduccionesSeguros = 0m;
            decimal AFP = 0m;
            decimal DeduccionImpuestos = 0m;
            decimal resultado = metodosPagos.CalcularDescuentosTotales(DeduccionesSeguros, AFP, DeduccionImpuestos);
            Assert.AreEqual(0m, resultado);
        }

        [TestMethod]
        public void CalcularDescuentosTotales_DeberiaDevolverValorCorrectoConValoresNegativos()
        {
            var metodosPagos = new MetodosPagos();
            decimal DeduccionesSeguros = -100m;
            decimal AFP = 150m;
            decimal DeduccionImpuestos = 50m;
            decimal resultado = metodosPagos.CalcularDescuentosTotales(DeduccionesSeguros, AFP, DeduccionImpuestos);
            decimal esperado = -100m + 150m + 50m;
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void CalcularDescuentosTotales_DeberiaCalcularCorrectamenteConMezclaDeValoresPositivosYNegativos()
        {
            var metodosPagos = new MetodosPagos();
            decimal DeduccionesSeguros = 100m;
            decimal AFP = -150m;
            decimal DeduccionImpuestos = 50m;
            decimal resultado = metodosPagos.CalcularDescuentosTotales(DeduccionesSeguros, AFP, DeduccionImpuestos);
            decimal esperado = 100m + (-150m) + 50m;
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void CalcularDescuentosTotales_DeberiaRetornarSoloElSumaCorrectaDeLosDescuentos()
        {
            var metodosPagos = new MetodosPagos();
            decimal DeduccionesSeguros = 300m;
            decimal AFP = 200m;
            decimal DeduccionImpuestos = 100m;
            decimal resultado = metodosPagos.CalcularDescuentosTotales(DeduccionesSeguros, AFP, DeduccionImpuestos);
            decimal esperado = 300m + 200m + 100m;
            Assert.AreEqual(esperado, resultado);
        }
    }
}
