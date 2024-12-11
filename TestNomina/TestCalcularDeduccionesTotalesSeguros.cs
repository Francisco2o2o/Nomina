using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaNegocio;
using System;

namespace TestNomina
{
    [TestClass]
    public class TestCalcularDeduccionesTotalesSeguros
    {
        [TestMethod]
        public void CalcularDeduccionesTotalesSeguros_DeberiaSumarCorrectamenteLosValoresPositivos()
        {
            var metodosPagos = new MetodosPagos();
            decimal seguroSalud = 100m;
            decimal seguroVida = 50m;
            decimal seguroAccidentes = 25m;
            decimal resultado = metodosPagos.CalcularDeduccionesTotalesSeguros(seguroSalud, seguroVida, seguroAccidentes);
            decimal esperado = 100m + 50m + 25m;
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void CalcularDeduccionesTotalesSeguros_DeberiaDevolverCeroCuandoTodosLosValoresSonCero()
        {
            var metodosPagos = new MetodosPagos();
            decimal seguroSalud = 0m;
            decimal seguroVida = 0m;
            decimal seguroAccidentes = 0m;
            decimal resultado = metodosPagos.CalcularDeduccionesTotalesSeguros(seguroSalud, seguroVida, seguroAccidentes);
            Assert.AreEqual(0m, resultado);
        }

        [TestMethod]
        public void CalcularDeduccionesTotalesSeguros_DeberiaSumarCorrectamenteConValoresNegativos()
        {
            var metodosPagos = new MetodosPagos();
            decimal seguroSalud = -100m;
            decimal seguroVida = -50m;
            decimal seguroAccidentes = -25m;
            decimal resultado = metodosPagos.CalcularDeduccionesTotalesSeguros(seguroSalud, seguroVida, seguroAccidentes);
            decimal esperado = -100m + (-50m) + (-25m);
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void CalcularDeduccionesTotalesSeguros_DeberiaSumarCorrectamenteConCombinacionDeValoresPositivosYNegativos()
        {
            var metodosPagos = new MetodosPagos();
            decimal seguroSalud = 100m;
            decimal seguroVida = -50m;
            decimal seguroAccidentes = 25m;
            decimal resultado = metodosPagos.CalcularDeduccionesTotalesSeguros(seguroSalud, seguroVida, seguroAccidentes);
            decimal esperado = 100m + (-50m) + 25m;
            Assert.AreEqual(esperado, resultado);
        }
    }
}
