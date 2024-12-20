﻿using CapaPresentacion.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Utilidades
{
    public partial class frmNotificacion : Form
    {
        public frmNotificacion()
        {
            InitializeComponent();
        }
        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }
        private frmNotificacion.enmAction action;

        private int x, y;
        private void ShowNotificacion_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    ShowNotificacion.Interval = 5000;
                    action = enmAction.close;
                    break;
                case frmNotificacion.enmAction.start:
                    this.ShowNotificacion.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = frmNotificacion.enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    ShowNotificacion.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            ShowNotificacion.Interval = 1;
            action = enmAction.close;
        }
        public void showAlert(string mensaje, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                frmNotificacion frm = (frmNotificacion)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;

                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Success:
                    this.picIcono.Image = Resources.NotifyInfo;
                    this.BackColor = Color.RoyalBlue;
                    break;
                case enmType.Error:
                    this.picIcono.Image = Resources.NotifyError;
                    this.BackColor = Color.DarkRed;
                    break;
                case enmType.Info:
                    this.picIcono.Image = Resources.NotifySuccess;
                    this.BackColor = Color.SeaGreen;
                    break;
                case enmType.Warning:
                    this.picIcono.Image = Resources.NotifyWarning;
                    this.BackColor = Color.DarkOrange;
                    break;
            }


            this.lblMensaje.Text = mensaje;

            this.Show();
            this.action = enmAction.start;
            this.ShowNotificacion.Interval = 1;
            this.ShowNotificacion.Start();
        }
    }
}

