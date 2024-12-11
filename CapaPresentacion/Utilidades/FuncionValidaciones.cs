using CapaNegocio;
using LayerPresentation.Utils;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using LayerPresentation.FormNotificaciones;
using Guna.UI.WinForms;

namespace LayerPresentation.Utils
{
    public static class FuncionesValidaciones
    {
        public static bool FuncionPropiedadesControles(GunaButton Guardar, GunaButton Actualizar, GunaButton Limpiar, bool EstadoActivarBotonRegistrar)
        {
            Guardar.OnHoverBaseColor = Color.FromArgb(34, 170, 143);
            Guardar.OnHoverBorderColor = Color.Black;
            Guardar.OnHoverForeColor = Color.White;

            Actualizar.OnHoverBaseColor = Color.FromArgb(106, 159, 187);
            Actualizar.OnHoverBorderColor = Color.Black;
            Actualizar.OnHoverForeColor = Color.White;

            Limpiar.OnHoverBaseColor = Color.FromArgb(255, 128, 128);
            Limpiar.OnHoverBorderColor = Color.Black;
            Limpiar.OnHoverForeColor = Color.White;

            if (EstadoActivarBotonRegistrar)
            {
                Limpiar.Visible = true;
                return true;
            }
            else
            {
                Limpiar.Visible = false;
                return false;
            }
        }

        public static bool FuncionPropiedadesControlesPagos(GunaButton Guardar, GunaButton Limpiar, bool EstadoActivarBotonRegistrar)
        {

            Guardar.OnHoverBaseColor = Color.FromArgb(34, 170, 143);
            Guardar.OnHoverBorderColor = Color.Black;
            Guardar.OnHoverForeColor = Color.White;

            Limpiar.OnHoverBaseColor = Color.FromArgb(255, 128, 128);
            Limpiar.OnHoverBorderColor = Color.Black;
            Limpiar.OnHoverForeColor = Color.White;

            if (EstadoActivarBotonRegistrar)
            {
                Limpiar.Visible = true;
                return true;
            }
            else
            {
                Limpiar.Visible = false;
                return false;
            }
        }

        public static void EstablecerFechasMesActual(GunaDateTimePicker DTFechaInicial, GunaDateTimePicker DTFechaFinal)
        {
            DateTime primerDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DTFechaInicial.Value = primerDiaMes;

            DateTime ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);
            DTFechaFinal.Value = ultimoDiaMes;
        }

        public static class PlaceholderHelper
        {
            private static readonly Dictionary<GunaTextBox, string> _placeholders = new Dictionary<GunaTextBox, string>();

            public static void fnPlaceholder(GunaTextBox textBox, string placeholderText)
            {
                if (_placeholders.ContainsKey(textBox))
                {
                    _placeholders[textBox] = placeholderText;
                }
                else
                {
                    _placeholders.Add(textBox, placeholderText);
                }

                textBox.Text = placeholderText;
                textBox.ForeColor = Color.Gray;
                textBox.BorderColor = Color.FromArgb(157, 31, 56);

                textBox.Enter -= TextBox_Enter;
                textBox.Leave -= TextBox_Leave;
                textBox.Enter += TextBox_Enter;
                textBox.Leave += TextBox_Leave;
            }

            private static void TextBox_Enter(object sender, EventArgs e)
            {
                var textBox = sender as GunaTextBox;
                if (textBox != null && _placeholders.TryGetValue(textBox, out var placeholderText) && textBox.Text == placeholderText)
                {
                    textBox.Text = string.Empty;
                    textBox.ForeColor = Color.Black;
                    textBox.BorderColor = Color.FromArgb(34, 170, 143);
                }
            }

            private static void TextBox_Leave(object sender, EventArgs e)
            {
                var textBox = sender as GunaTextBox;
                if (textBox != null && _placeholders.TryGetValue(textBox, out var placeholderText) && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                    textBox.BorderColor = Color.FromArgb(157, 31, 56);
                }
                else
                {
                    textBox.BorderColor = Color.FromArgb(34, 170, 143);
                }
            }

            public static bool IsPlaceholder(GunaTextBox textBox)
            {
                return _placeholders.TryGetValue(textBox, out var placeholderText) && textBox.Text == placeholderText;
            }

            public static string fnGetText(GunaTextBox textBox)
            {
                return IsPlaceholder(textBox) ? string.Empty : textBox.Text;
            }
        }

    }

}
