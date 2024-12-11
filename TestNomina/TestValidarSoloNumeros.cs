using CapaPresentacion.Utilidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitariasValidarSoloNumeros
{
    [TestClass]
    public class TestMetodosValidacionesValidarSoloNumeros
    {
        [TestMethod]
        public void ValidarSoloNumeros_EntradaValidaTipoCon1_DeberiaRetornarTrue()
        {
            string texto = "1235674";
            int tipoCon = 1;
            char keyChar = '1';
            string mensajeError;

            bool resultado = MetodosValidaciones.ValidarSoloNumeros(texto, tipoCon, keyChar, out mensajeError);

            Assert.IsTrue(resultado);
            Assert.AreEqual(string.Empty, mensajeError);
        }

        [TestMethod]
        public void ValidarSoloNumeros_EntradaInvalidaCaracterNoNumerico_DeberiaRetornarFalse()
        {
            // Arrange
            string texto = "1234567";
            int tipoCon = 1;
            char keyChar = 'A';
            string mensajeError;

            bool resultado = MetodosValidaciones.ValidarSoloNumeros(texto, tipoCon, keyChar, out mensajeError);

            Assert.IsFalse(resultado);
            Assert.AreEqual("Por favor, ingresa solo números en el campo.", mensajeError);
        }

        [TestMethod]
        public void ValidarSoloNumeros_ExcedeLongitudTipoCon1_DeberiaRetornarFalse()
        {
            string texto = "12345678";
            int tipoCon = 1;
            char keyChar = '1';
            string mensajeError;

            bool resultado = MetodosValidaciones.ValidarSoloNumeros(texto, tipoCon, keyChar, out mensajeError);

            Assert.IsFalse(resultado);
            Assert.AreEqual("El documento debe tener exactamente 8 caracteres.", mensajeError);
        }

        [TestMethod]
        public void ValidarSoloNumeros_ExcedeLongitudTipoCon2_DeberiaRetornarFalse()
        {
            string texto = "123456789";
            int tipoCon = 2;
            char keyChar = '1';
            string mensajeError;


            bool resultado = MetodosValidaciones.ValidarSoloNumeros(texto, tipoCon, keyChar, out mensajeError);

            Assert.IsFalse(resultado);
            Assert.AreEqual("El documento debe tener exactamente 9 caracteres.", mensajeError);
        }
    }
}
