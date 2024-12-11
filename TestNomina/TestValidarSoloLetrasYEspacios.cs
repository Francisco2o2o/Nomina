using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;// Asegúrate de tener esta línea
using CapaPresentacion.Utilidades;

namespace TestUnitariasValidarLetrasYEspacios
{
    [TestClass]
    public class TestMetodosValidacionesSoloLetrasYEspacios
    {
        [TestMethod]
        public void ValidarSoloLetrasYEspacios_EntradaValida_RetornaTrue()
        {
            string texto = "Nombre Apellido";
            char keyChar = 'A';
            bool resultado = MetodosValidaciones.ValidarSoloLetrasYEspacios(texto, keyChar, out string mensajeError);

            Assert.IsTrue(resultado);
            Assert.AreEqual(string.Empty, mensajeError);
        }

        [TestMethod]
        public void ValidarSoloLetrasYEspacios_EntradaConEspacio_RetornaTrue()
        {
            string texto = "Nombre Apellido";
            char keyChar = ' ';
            bool resultado = MetodosValidaciones.ValidarSoloLetrasYEspacios(texto, keyChar, out string mensajeError);


            Assert.IsTrue(resultado);
            Assert.AreEqual(string.Empty, mensajeError);
        }

        [TestMethod]
        public void ValidarSoloLetrasYEspacios_EntradaConCaracterNoValido_RetornaFalse()
        {
            string texto = "Nombre Apellido";
            char keyChar = '1';
            bool resultado = MetodosValidaciones.ValidarSoloLetrasYEspacios(texto, keyChar, out string mensajeError);

            Assert.IsFalse(resultado);
            Assert.AreEqual("Por favor, ingresa solo letras y espacios en este campo.", mensajeError);
        }

        [TestMethod]
        public void ValidarSoloLetrasYEspacios_EntradaConCaracteresDeControl_RetornaTrue()
        {
        
            string texto = "Nombre Apellido";
            char keyChar = '\b';

            bool resultado = MetodosValidaciones.ValidarSoloLetrasYEspacios(texto, keyChar, out string mensajeError);

            Assert.IsTrue(resultado);
            Assert.AreEqual(string.Empty, mensajeError);
        }
    }
}
