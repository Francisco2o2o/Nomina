using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaNegocio;  // Asegúrate de usar el espacio de nombres correcto
using System;
using static CapaNegocio.MetodosContratoLaboral;

namespace TestNomina
{
    [TestClass]
    public class TestCalcularMontoAsignacionFamiliar
    {
        [TestMethod]
        public void CalcularAsignacionFamiliar_ConSalarioValido_DeberiaRetornarAsignacionCorrecta()
        {
            var calcularMontoAsignacionFamiliar = new CalcularMontoAsignacionFamiliar();
            decimal salarioBase = 1000m;
            decimal esperado = 100m;

            decimal resultado = calcularMontoAsignacionFamiliar.CalcularAsignacionFamiliar(salarioBase);

            Assert.AreEqual(esperado, resultado);
        }
    }
}
