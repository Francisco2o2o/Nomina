﻿using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Utilidades
{
    public  class FuncionesGenerales
    {
        public static void CalcularPaginacion(Int32 totalRegistros, Int32 filas, Int32 totalResultados, GunaComboBox cboPagina, GunaCircleButton btnTotalPaginas, GunaCircleButton btnNumFilas, GunaCircleButton btnTotalReg)
        {
            Int32 residuo;
            Int32 cantidadPaginas;
            residuo = totalRegistros % filas;
            if (residuo == 0)
            {
                cantidadPaginas = (totalRegistros / filas);
            }
            else
            {
                cantidadPaginas = (totalRegistros / filas) + 1;
            }
            cboPagina.Items.Clear();

            for (Int32 i = 1; i <= cantidadPaginas; i++)
            {
                cboPagina.Items.Add(i);
            }
            cboPagina.SelectedIndex = 0;
            btnTotalPaginas.Text = Convert.ToString(cantidadPaginas);
            btnNumFilas.Text = Convert.ToString(totalResultados);
            btnTotalReg.Text = Convert.ToString(totalRegistros);
        }

        public static void ShowAlert(string mensaje, frmNotificacion.enmType type)
        {
            frmNotificacion frm = new frmNotificacion();
            frm.showAlert(mensaje, type);
        }
    }
}

