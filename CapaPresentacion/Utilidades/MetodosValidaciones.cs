using System;
using System.Windows.Forms;

namespace CapaPresentacion.Utilidades
{
    public class MetodosValidaciones
    {
        public static bool ValidarSoloNumeros(string texto, int tipoCon, char keyChar, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (!char.IsControl(keyChar) && !char.IsDigit(keyChar))
            {
                mensajeError = "Por favor, ingresa solo números en el campo.";
                return false;
            }
            if (tipoCon == 1 && texto.Length >= 8 && keyChar != (char)Keys.Back)
            {
                mensajeError = "El documento debe tener exactamente 8 caracteres.";
                return false;
            }
            if (tipoCon == 2 && texto.Length >= 9 && keyChar != (char)Keys.Back)
            {
                mensajeError = "El documento debe tener exactamente 9 caracteres.";
                return false;
            }

            return true;
        }


        public static bool ValidarSoloLetrasYEspacios(string texto, char keyChar, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (!char.IsLetter(keyChar) && !char.IsWhiteSpace(keyChar) && !char.IsControl(keyChar))
            {
                mensajeError = "Por favor, ingresa solo letras y espacios en este campo.";
                return false;
            }

            return true;

        }

        public static void EstablecerFechasContrato(out DateTime fechaInicial, out DateTime fechaFinal, int mesesDuracion)
        {
            fechaInicial = DateTime.Now;
            fechaFinal = fechaInicial.AddMonths(mesesDuracion);
        }
    }
}
