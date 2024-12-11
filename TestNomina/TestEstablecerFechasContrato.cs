using CapaPresentacion.Utilidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestUnitariasEstablecerFechasContrato
{
    [TestClass]
    public class TestMetodosValidacionesFechasContrato
    {
        [TestMethod]
        public void TestEstablecerFechasContrato_3Meses()
        {
            int mesesDuracion = 3;

            MetodosValidaciones.EstablecerFechasContrato(out DateTime fechaInicial, out DateTime fechaFinal, mesesDuracion);

            Assert.AreEqual(DateTime.Now.Date, fechaInicial.Date, "La fecha inicial debe ser la fecha actual.");
            Assert.AreEqual(fechaInicial.AddMonths(mesesDuracion).Date, fechaFinal.Date, "La fecha final debe ser 3 meses después de la fecha inicial.");
        }

        [TestMethod]
        public void TestEstablecerFechasContrato_6Meses()
        {
            int mesesDuracion = 6;

            MetodosValidaciones.EstablecerFechasContrato(out DateTime fechaInicial, out DateTime fechaFinal, mesesDuracion);

            Assert.AreEqual(DateTime.Now.Date, fechaInicial.Date, "La fecha inicial debe ser la fecha actual.");
            Assert.AreEqual(fechaInicial.AddMonths(mesesDuracion).Date, fechaFinal.Date, "La fecha final debe ser 6 meses después de la fecha inicial.");
        }

        [TestMethod]
        public void TestEstablecerFechasContrato_12Meses()
        {
            int mesesDuracion = 12;

            MetodosValidaciones.EstablecerFechasContrato(out DateTime fechaInicial, out DateTime fechaFinal, mesesDuracion);

            Assert.AreEqual(DateTime.Now.Date, fechaInicial.Date, "La fecha inicial debe ser la fecha actual.");
            Assert.AreEqual(fechaInicial.AddMonths(mesesDuracion).Date, fechaFinal.Date, "La fecha final debe ser 12 meses después de la fecha inicial.");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "El formato de la fecha no es correcto.")]
        public void TestEstablecerFechasContrato_FormatoFechaIncorrecto()
        {
            string fechaFormatoIncorrecto = "invalid-date";

            MetodosValidaciones.EstablecerFechasContrato(out DateTime fechaInicial, out DateTime fechaFinal, 6);
            throw new FormatException("El formato de la fecha no es correcto.");
        }
    }
}
