using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmMenu : Form
    {
        private bool menuOculto = false;
        private const int ANCHURA_MENU_VISIBLE = 200;
        private const int ANCHURA_MENU_OCULTO = 50;
        private const int MARGEN_DERECHO = 5;

        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public frmMenu()
        {
            InitializeComponent();
            this.Load += frmMenu_Load;
            this.Resize += frmMenu_Resize;


            hideSubMenu();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 49);
            // pMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void hideSubMenu()
        {
            pContratos.Visible = false;
            pPagos.Visible = false;
            pTrabajador.Visible = false;
            //pSubMenuSuscriptores.Visible = false;
            //pSubMenuUsuarios.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(229, 111, 81);
            public static Color color2 = Color.FromArgb(60, 64, 90);
            public static Color color3 = Color.FromArgb(243, 240, 221);
            public static Color color4 = Color.FromArgb(50, 199, 142);
            public static Color color5 = Color.FromArgb(34, 170, 143);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(159, 172, 252);
            public static Color color8 = Color.FromArgb(41, 95, 152);
            public static Color color9 = Color.FromArgb(84, 208, 224);
            public static Color color10 = Color.FromArgb(51, 183, 244);
            public static Color color11 = Color.FromArgb(125, 127, 145);
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.IconColor = Color.FromArgb(42, 157, 142);
                currentBtn.ForeColor = color;
                //currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                //currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                // leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.IconColor = Color.FromArgb(40, 114, 113);
                currentBtn.ForeColor = Color.Black;
                // currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Black;
                //currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                //currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private Form formAbierto = null;


        private void AbrirFormularioSecundario(Form formSecundario)
        {
            if (formAbierto != null)
            {
                formAbierto.Close();
            }
            formSecundario.TopLevel = false;
            formSecundario.FormBorderStyle = FormBorderStyle.None;
            formSecundario.Dock = DockStyle.Fill;

            pCentral.Controls.Clear();
            pCentral.Controls.Add(formSecundario);
            formSecundario.Show();
            formAbierto = formSecundario;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pMenu.Width = ANCHURA_MENU_VISIBLE;
            pCentral.Width = this.ClientSize.Width - pMenu.Width - MARGEN_DERECHO;
            pCentral.Left = pMenu.Right + MARGEN_DERECHO;
            CentrarLogoEnCentral();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

            int anchoMenuAnterior = pMenu.Width;

            if (menuOculto)
            {
                pMenu.BorderRadius = 4;
                btnInicio.Text = "Gestinar Trabajador";
                btnContratos.Text = "Gestinar Contratos";
                btnPagos.Text = "Gestinar Pagos";
                btnSubRegistrarTrabajador.Text = "Registrar Trabajador";
                btnSubRegistrarContratro.Text = "Registrar Contrato";
                btnSubRegistrarPagos.Text = "Registrar Pagos";
                pMenu.Width = ANCHURA_MENU_VISIBLE;
            }
            else
            {
                pMenu.BorderRadius = 20;
                btnInicio.Text = "";
                btnContratos.Text = "";
                btnPagos.Text = "";
                btnSubRegistrarTrabajador.Text = "";
                btnSubRegistrarContratro.Text = "";
                btnSubRegistrarPagos.Text = "";
                pMenu.Width = ANCHURA_MENU_OCULTO;
            }

            int diferencia = pMenu.Width - anchoMenuAnterior;
            pCentral.Width -= diferencia;

            pCentral.Left = pMenu.Right + MARGEN_DERECHO;

            btnOcultarMenu.Text = menuOculto ? "Ocultar Menu" : "Mostrar Menu";

            menuOculto = !menuOculto;

            pCentral.Invalidate();
            this.Invalidate();
        }
        private void CentrarLogoEnCentral()
        {
            int nuevoX = (pCentral.ClientSize.Width - pLogo.Width) / 2;
            int nuevoY = (pCentral.ClientSize.Height - pLogo.Height) / 2;


            pLogo.Location = new Point(nuevoX, nuevoY);
        }

        private void frmMenu_Resize(object sender, EventArgs e)
        {
            pCentral.Width = this.ClientSize.Width - pMenu.Width - MARGEN_DERECHO;
            pCentral.Left = pMenu.Right + MARGEN_DERECHO;
            CentrarLogoEnCentral();

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            showSubMenu(pTrabajador);
            ActivateButton(sender, RGBColors.color5);
        }

        private void btnSubRegistrarTrabajador_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            AbrirFormularioSecundario(new frmTrabajador());
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            showSubMenu(pContratos);
            ActivateButton(sender, RGBColors.color8);
        }

        private void btnSubRegistrarContratro_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            AbrirFormularioSecundario(new frmContratoLaboral());
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            showSubMenu(pPagos);
            ActivateButton(sender, RGBColors.color1);
        }

        private void btnSubRegistrarPagos_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            AbrirFormularioSecundario(new frmPagos());
        }
    }
}
