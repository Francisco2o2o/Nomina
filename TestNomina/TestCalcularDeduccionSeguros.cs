using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaNegocio;  // Asegúrate de usar el espacio de nombres correcto
using System;
using System.Collections.Generic;

namespace TestNomina
{
    [TestClass]
    public class TestCalcularDeduccionSeguros
    {
        [TestMethod]
        public void CalcularDeduccionSeguros_ConCondicionTipo1_DeberiaCalcularCorrectamente()
        {
            // Arrange
            var metodosPagos = new MetodosPagos();
            var salarios = new List<decimal> { 1000m, 2000m, 3000m };  
            int tipoCondicion = 1; 

            decimal resultado = metodosPagos.CalcularDeduccionSeguros(salarios, tipoCondicion);

            decimal esperado = (1000m * 0.09m) + (2000m * 0.09m) + (3000m * 0.09m); 
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void CalcularDeduccionSeguros_ConCondicionTipo2_DeberiaCalcularCorrectamente()
        {
            var metodosPagos = new MetodosPagos();
            var salarios = new List<decimal> { 1000m, 2000m, 3000m };  
            int tipoCondicion = 2; 

            decimal resultado = metodosPagos.CalcularDeduccionSeguros(salarios, tipoCondicion);

            decimal esperado = (1000m * 0.01m) + (2000m * 0.01m) + (3000m * 0.01m);
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void CalcularDeduccionSeguros_ConCondicionDefault_DeberiaCalcularCorrectamente()
        {
            var metodosPagos = new MetodosPagos();
            var salarios = new List<decimal> { 1000m, 2000m, 3000m };  
            int tipoCondicion = 3; 

            decimal resultado = metodosPagos.CalcularDeduccionSeguros(salarios, tipoCondicion);

            decimal esperado = (1000m * 0.015m) + (2000m * 0.015m) + (3000m * 0.015m); 
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void CalcularDeduccionSeguros_ConListaVacia_DeberiaRetornarCero()
        {
            var metodosPagos = new MetodosPagos();
            var salarios = new List<decimal>(); 
            int tipoCondicion = 1;

            decimal resultado = metodosPagos.CalcularDeduccionSeguros(salarios, tipoCondicion);

            Assert.AreEqual(0m, resultado);  
        }
    }
}
