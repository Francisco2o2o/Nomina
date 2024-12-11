using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaNegocio;
using static CapaNegocio.MetodosContratoLaboral;

namespace TestUnitariasCalcularSalarioPorHora
{
    [TestClass]
    public class TestMetodosValidacionesCalcularSalarioPorHora
    {
        [TestMethod]
        public void CalcularSalarioPorHora_ValoresValidos_RetornaTrueYSalarioPorHoraCorrecto()
        {
            decimal salarioTotal = 2000m;
            int horasTotales = 160;
            decimal salarioPorHora;

               var calcularSalario = new CalcularSalarioContratoLaboral();

            bool resultado = calcularSalario.CalcularSalarioPorHora(salarioTotal, horasTotales, out salarioPorHora);

            Assert.IsTrue(resultado);
            Assert.AreEqual(12.5m, salarioPorHora);
        }

        [TestMethod]
        public void CalcularSalarioPorHora_SalarioTotalNegativo_RetornaFalseYSalarioPorHoraCero()
        {
            decimal salarioTotal = -1000m;
            int horasTotales = 160;
            decimal salarioPorHora;

            var calcularSalario = new CalcularSalarioContratoLaboral();
            bool resultado = calcularSalario.CalcularSalarioPorHora(salarioTotal, horasTotales, out salarioPorHora);

            Assert.IsFalse(resultado);
            Assert.AreEqual(0.00m, salarioPorHora);
        }

        [TestMethod]
        public void CalcularSalarioPorHora_HorasTotalesNegativas_RetornaFalseYSalarioPorHoraCero()
        {
            decimal salarioTotal = 2000m;
            int horasTotales = -160;
            decimal salarioPorHora;

            var calcularSalario = new CalcularSalarioContratoLaboral();
            bool resultado = calcularSalario.CalcularSalarioPorHora(salarioTotal, horasTotales, out salarioPorHora);

            Assert.IsFalse(resultado);
            Assert.AreEqual(0.00m, salarioPorHora);
        }

        [TestMethod]
        public void CalcularSalarioPorHora_SalarioTotalCero_RetornaFalseYSalarioPorHoraCero()
        {
            decimal salarioTotal = 0m;
            int horasTotales = 160;
            decimal salarioPorHora;

            var calcularSalario = new CalcularSalarioContratoLaboral();
            bool resultado = calcularSalario.CalcularSalarioPorHora(salarioTotal, horasTotales, out salarioPorHora);

            Assert.IsFalse(resultado);
            Assert.AreEqual(0.00m, salarioPorHora);
        }
    }
}
