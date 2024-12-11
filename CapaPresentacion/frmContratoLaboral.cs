using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;
using LayerPresentation.FormNotificaciones;
using LayerPresentation.Utils;
using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static CapaNegocio.MetodosContratoLaboral;

namespace CapaPresentacion
{
    public partial class frmContratoLaboral : Form
    {
        //Variables de busqueda
        static Boolean pasoLoad;
        static Int32 tabInicio = 0;

        public frmContratoLaboral()
        {
            InitializeComponent();

            #region Creacion de las columnas de la tabla [dgvContratoLaboral]
            dgvContratoLaboral.Columns.Add("Numero", "N°");
            dgvContratoLaboral.Columns.Add("IdContratoLaboral", "ID del Contrato Laboral");
            dgvContratoLaboral.Columns.Add("fechaInicioContratoLaboral", "Fecha de Inicio");
            dgvContratoLaboral.Columns.Add("fechaFinContratoLaboral", "Fecha de Fin");
            dgvContratoLaboral.Columns.Add("horasTotalesContratoLaboral", "Horas Totales");
            dgvContratoLaboral.Columns.Add("EstadoContratoLaboral", "Estado");
            dgvContratoLaboral.Columns.Add("descripcionContratoLaboral", "Descripción");
            dgvContratoLaboral.Columns.Add("IdCargoContratoLaboral", "ID del Cargo");
            dgvContratoLaboral.Columns.Add("nombreCargo", "Nombre del Cargo");
            dgvContratoLaboral.Columns.Add("IdTipoContratoLaboral", "ID del Tipo de Contrato");
            dgvContratoLaboral.Columns.Add("nombreTipoContrato", "Tipo de Contrato");
            dgvContratoLaboral.Columns.Add("IdTrabajador", "ID del Trabajador");
            dgvContratoLaboral.Columns.Add("nombreTrabajador", "Trabajador");
            dgvContratoLaboral.Columns.Add("salarioContratoLaboral", "Salario");
            dgvContratoLaboral.Columns.Add("horasDiariasContratoLaboral", "Horas Diarias");
            dgvContratoLaboral.Columns.Add("AsignaciónFamiliarContratoLaboral", "Asignación Familia");
            #endregion

            #region Llenar ComboBox´s
            FuncionLlenarComboBoxCargo(cboCargo, 0, "", false);
            FuncionLlenarComboBoxTipoContratoLaboral(cboTipoContrato, 0, "", false);
            FuncionLlenarComboBoxTrabajador(cboTrabajador, 0, "", false);
            #endregion

        }

        private void frmContratoLaboral_Load(object sender, EventArgs e)
        {
            FuncionesValidaciones.EstablecerFechasMesActual(dtFechaInicio, dtFechaFin);

            FuncionesValidaciones.PlaceholderHelper.fnPlaceholder(txtDescripcionContratoLaboral, "Ingrese una breve descrpcion");

            bool EstadoActivarBotonRegistrar = FuncionesValidaciones.FuncionPropiedadesControles(btnRegistrarContratoLaboral, btnActualizarContratoLaboral, btnLimpiarContratoLaboral, FuncionValidarTextBox());
            btnRegistrarContratoLaboral.Enabled = EstadoActivarBotonRegistrar;

            #region Visibilidad de Columnas de la Tabla [dgvContratoLaboral]
            dgvContratoLaboral.Columns["IdContratoLaboral"].Visible = false;
            dgvContratoLaboral.Columns["IdCargoContratoLaboral"].Visible = false;
            dgvContratoLaboral.Columns["IdTrabajador"].Visible = false;
            dgvContratoLaboral.Columns["IdTipoContratoLaboral"].Visible = false;
            dgvContratoLaboral.Columns["descripcionContratoLaboral"].Visible = false;
            dgvContratoLaboral.Columns["AsignaciónFamiliarContratoLaboral"].Visible = false;
            #endregion

            //Variable de busqueda
            pasoLoad = true;
            FuncionBuscarContratoLaboral(dgvContratoLaboral, 0);
        }

        #region  Validar Controles Vacios
        public bool FuncionValidarTextBox()
        {
            if (cboTrabajador.SelectedIndex != 0 && cboTipoContrato.SelectedIndex != 0 && cboCargo.SelectedIndex != 0 && txtHorasTotalesContratoLaboral.Text != "")
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        #endregion

        #region Funcion Validar Changed
        public void FuncionValidarChanged()
        {
            bool esValido = FuncionValidarTextBox();
            btnLimpiarContratoLaboral.Visible = esValido;
            btnRegistrarContratoLaboral.Enabled = esValido;
        }
        #endregion

        #region Funcion Llenar ComboBox Cargo
        public static List<CargoContratoLaboral> FuncionLlenarComboBoxCargo(Guna2ComboBox cbo, Int32 idCargo, String nombreCargo, Boolean buscar)
        {
            NegocioCargoContratoLaboral objeNegocioCargo = new NegocioCargoContratoLaboral();
            List<CargoContratoLaboral> lstCargo = new List<CargoContratoLaboral>();

            try
            {
                lstCargo = objeNegocioCargo.NegocioLlenarComboBoxCargo(idCargo, nombreCargo, buscar);
                cbo.ValueMember = "IdCargoContratoLaboral";
                cbo.DisplayMember = "NombreCargoContratoLaboral";
                cbo.DataSource = lstCargo;

                return lstCargo;
            }
            catch (Exception ex)
            {
                return lstCargo;
            }
            finally
            {
                lstCargo = null;
            }
        }
        #endregion

        #region Funcion Llenar ComboBox Tipo Contrato Laboral
        public static List<TipoContratoLaboral> FuncionLlenarComboBoxTipoContratoLaboral(Guna2ComboBox cbo, Int32 idTipoContratoLaboral, String nombreTipoContratoLaboral, Boolean buscar)
        {
            NegocioTipoContratoLaboral objNegocioTipoContratoLaboral = new NegocioTipoContratoLaboral();
            List<TipoContratoLaboral> lstTipoContratoLaboral = new List<TipoContratoLaboral>();

            try
            {
                lstTipoContratoLaboral = objNegocioTipoContratoLaboral.NegocioLlenarComboBoxTipoContratoLaboral(idTipoContratoLaboral, nombreTipoContratoLaboral, buscar);
                cbo.ValueMember = "IdTipoContratoLaboral";
                cbo.DisplayMember = "NombreTipoContratoLaboral";
                cbo.DataSource = lstTipoContratoLaboral;

                return lstTipoContratoLaboral;
            }
            catch (Exception ex)
            {
                return lstTipoContratoLaboral;
            }
            finally
            {
                lstTipoContratoLaboral = null;
            }
        }
        #endregion

        #region Funcion Llenar ComboBox Trabajador
        public static List<Trabajador> FuncionLlenarComboBoxTrabajador(Guna2ComboBox cbo, Int32 idTrabajador, String nombreTrabajador, Boolean buscar)
        {
            NegocioTrabajador objNegocioTrabajador = new NegocioTrabajador();
            List<Trabajador> lstTrabajador = new List<Trabajador>();

            try
            {
                lstTrabajador = objNegocioTrabajador.NegocioLlenarComboBoxTrabajador(idTrabajador, nombreTrabajador, buscar);

                cbo.ValueMember = "IdTrabajador";
                cbo.DisplayMember = "NombreCompletoTrabajador";
                cbo.DataSource = lstTrabajador;

                return lstTrabajador;
            }
            catch (Exception ex)
            {
                return lstTrabajador;
            }
            finally
            {
                lstTrabajador = null;
            }
        }

        #endregion

        #region Validacion Evento Changed de los Controles

        #region Mostrar Salario por Tipo de Contrato
        private void cboTipoContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoContratoLaboral selectedTipoContratoLaboral = (TipoContratoLaboral)cboTipoContrato.SelectedItem;

            if (selectedTipoContratoLaboral != null)
            {
                txtSalarioContratoLaboral.Text = selectedTipoContratoLaboral.SalarioBaseTipoContratoLaboral.ToString();

                if (selectedTipoContratoLaboral.IdTipoContratoLaboral == 1)
                {
                    txtIdTipoContratoLaboral.Text = selectedTipoContratoLaboral.IdTipoContratoLaboral.ToString();
                    txtHorasDiariasContratoLaboral.Enabled = false;
                    txtHorasTotalesContratoLaboral.Enabled = false;
                    txtSalarioContratoLaboral.Enabled = false;
                    txtHorasDiariasContratoLaboral.Text = "8";
                    txtHorasTotalesContratoLaboral.Text = "160";
                }
                else if (selectedTipoContratoLaboral.IdTipoContratoLaboral == 2)
                {
                    txtIdTipoContratoLaboral.Text = selectedTipoContratoLaboral.IdTipoContratoLaboral.ToString();
                    txtHorasDiariasContratoLaboral.Enabled = false;
                    txtHorasTotalesContratoLaboral.Enabled = false;
                    txtSalarioContratoLaboral.Enabled = false;
                    txtHorasDiariasContratoLaboral.Text = "4";
                    txtHorasTotalesContratoLaboral.Text = "80";
                }
                else if (selectedTipoContratoLaboral.IdTipoContratoLaboral == 3)
                {
                    txtIdTipoContratoLaboral.Text = selectedTipoContratoLaboral.IdTipoContratoLaboral.ToString();
                    txtHorasDiariasContratoLaboral.Enabled = true;
                    txtHorasTotalesContratoLaboral.Enabled = true;
                    txtSalarioContratoLaboral.Enabled = true;
                    txtHorasDiariasContratoLaboral.Text = "0";
                    txtHorasTotalesContratoLaboral.Text = "0";
                }
            }
            else
            {
                txtIdTipoContratoLaboral.Text = string.Empty;
                txtHorasDiariasContratoLaboral.Enabled = false;
                txtHorasTotalesContratoLaboral.Enabled = false;
                txtSalarioContratoLaboral.Enabled = false;
                txtSalarioContratoLaboral.Text = string.Empty;
                txtHorasDiariasContratoLaboral.Text = string.Empty;
                txtHorasTotalesContratoLaboral.Text = string.Empty;
            }

            FuncionValidarChanged();
            if (cboTipoContrato.SelectedValue != null)
            {
                cboTipoContrato.BorderColor = Color.FromArgb(192, 192, 192);
            }
            else
            {
                cboTipoContrato.BorderColor = Color.FromArgb(157, 31, 56);
            }
        }

        #endregion

        #region Funcion Verificar Contrato Laboral Activo
        public void FuncionVerificarContratoLaboralActivo(int IdTrabajador)
        {
            if (IdTrabajador == 0)
            {
                return;
            }

            NegocioTrabajador objNegocioTrabajador = new NegocioTrabajador();
            try
            {
                DataTable CapturarEstadoContratoLaboral = objNegocioTrabajador.NegocioVerificarContratoLaboralActivo(IdTrabajador);

                if (CapturarEstadoContratoLaboral.Rows.Count > 0)
                {
                    bool estadoContrato = Convert.ToInt32(CapturarEstadoContratoLaboral.Rows[0]["TieneContratoActivo"]) == 1;

                    if (estadoContrato)
                    {
                        //MessageBox.Show("El contrato está activo.", "Estado del Contrato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Mbox.Show("Ya tiene un contrato Vigente. No se puede registrar un contrato nuevo  hasta que el contrato actual finalice.", "Estado del Contrato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    btnLimpiarContratoLaboral.Visible = estadoContrato;
                    btnRegistrarContratoLaboral.Enabled = estadoContrato;
                    cboCargo.Enabled = estadoContrato;
                    cboTipoContrato.Enabled = estadoContrato;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar contrato activo: {ex.Message}", "Error de Verificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Mostrar Especialidad por Trabajador
        private void cboTrabajador_SelectedIndexChanged(object sender, EventArgs e)
        {
            Trabajador selectedTrabajador = (Trabajador)cboTrabajador.SelectedItem;

            if (selectedTrabajador != null)
            {
                txtEspecialidadtrabajador.Text = selectedTrabajador.NombreEspecializacion.ToString();
                txtIdTrabajador.Text = selectedTrabajador.IdTrabajador.ToString();

                FuncionVerificarContratoLaboralActivo(Convert.ToInt32(txtIdTrabajador.Text));
            }
            else
            {
                txtSalarioContratoLaboral.Text = string.Empty;
            }
            FuncionValidarChanged();
            if (cboTrabajador.SelectedValue != null)
            {
                cboTrabajador.BorderColor = Color.FromArgb(192, 192, 192);
            }
            else
            {
                cboTrabajador.BorderColor = Color.FromArgb(157, 31, 56);
            }
        }
        #endregion

        //Evento Changed txtEspecialidadtrabajador
        private void txtEspecialidadtrabajador_TextChanged(object sender, EventArgs e)
        {
            FuncionValidarChanged();
            if (!string.IsNullOrWhiteSpace(txtEspecialidadtrabajador.Text))
            {
                txtEspecialidadtrabajador.BorderColor = Color.FromArgb(192, 192, 192);
            }
            else
            {
                txtEspecialidadtrabajador.BorderColor = Color.FromArgb(157, 31, 56);
            }
        }

        //Evento Changed cboCargo
        private void cboCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionValidarChanged();
            CargoContratoLaboral selectedCargoContratoLaboral = (CargoContratoLaboral)cboCargo.SelectedItem;

            if (selectedCargoContratoLaboral != null)
            {

                txtIdCargo.Text = selectedCargoContratoLaboral.IdCargoContratoLaboral.ToString();
            }
            else
            {
                txtIdCargo.Text = string.Empty;
            }

            if (cboCargo.SelectedValue != null)
            {
                cboCargo.BorderColor = Color.FromArgb(192, 192, 192);
            }
            else
            {
                cboCargo.BorderColor = Color.FromArgb(157, 31, 56);
            }
        }

        //Evento Changed txtHorasTotalesContratoLaboral
        private void txtHorasTotalesContratoLaboral_TextChanged(object sender, EventArgs e)
        {
            FuncionValidarChanged();
            ActualizarSalarioPorHora();
        }

        //Evento Changed txtSalarioContratoLaboral
        private void txtSalarioContratoLaboral_TextChanged(object sender, EventArgs e)
        {
            FuncionValidarChanged();
            ActualizarSalarioPorHora();
        }

        //Evento Changed txtSalarioxHoraContratoLaboral
        private void txtSalarioxHoraContratoLaboral_TextChanged(object sender, EventArgs e)
        {
            FuncionValidarChanged();
            if (!string.IsNullOrWhiteSpace(txtSalarioxHoraContratoLaboral.Text))
            {
                txtSalarioxHoraContratoLaboral.BorderColor = Color.FromArgb(192, 192, 192);
            }
            else
            {
                txtSalarioxHoraContratoLaboral.BorderColor = Color.FromArgb(157, 31, 56);
            }
        }

        // Evento changed chkEstadoTrabajador
        private void chkEstadoTrabajador_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstadoContratoLaboral.Checked)
            {
                lblEstadoContratoLaboral.Text = "ACTIVO";
            }
            else
            {
                lblEstadoContratoLaboral.Text = "INACTIVO";
            }
        }
        #endregion

        #region Funcion para Actualizar el Salario por Horas
        private void ActualizarColorBordesSalario(bool salarioEsValido, bool horasSonValidas)
        {
            txtHorasTotalesContratoLaboral.BorderColor = horasSonValidas
                ? Color.FromArgb(192, 192, 192)
                : Color.FromArgb(157, 31, 56);

            txtSalarioContratoLaboral.BorderColor = salarioEsValido
                ? Color.FromArgb(192, 192, 192)
                : Color.FromArgb(157, 31, 56);
        }

        #endregion

        #region Método para Actualizar y Calcular Salario por Hora
        private void ActualizarSalarioPorHora()
        {
            bool salarioEsValido = decimal.TryParse(txtSalarioContratoLaboral.Text, out decimal salarioTotal);
            bool horasSonValidas = int.TryParse(txtHorasTotalesContratoLaboral.Text, out int horasTotales);

            CalcularSalarioContratoLaboral calcularSalario = new CalcularSalarioContratoLaboral();

            if (salarioEsValido && horasSonValidas && calcularSalario.CalcularSalarioPorHora(salarioTotal, horasTotales, out decimal salarioPorHora))
            {
                txtSalarioxHoraContratoLaboral.Text = salarioPorHora.ToString("F2");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un salario y horas válidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSalarioxHoraContratoLaboral.Text = "0.00";
            }

            ActualizarColorBordesSalario(salarioEsValido, horasSonValidas);
        }
        #endregion

        #region Button Registrar Trabajador
        private void btnRegistrarContratoLaboral_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIdContratoLaboral.Text) && chkEstadoContratoLaboral.Checked == true)
            {
                String pResult = funcionRegistrarTrabajador();
                if (pResult == "Contrato Registrado")
                {
                    FuncionesGenerales.ShowAlert("Contrato Registrado", frmNotificacion.enmType.Info);
                    FuncionLimpiarControles();
                    FuncionTiposBusqueda(0);
                }
                else
                {
                    Mbox.Show("Error al Registrar Contrato. Comunicar al Administrador del Sistema", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Mbox.Show("No se puede guardar un Contrato Inactivo. Comunicar al Administrador del Sistema", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Función Registrar Trabajador
        public String funcionRegistrarTrabajador()
        {
            NegocioContratoLaboral objNegocioContratoLaboral = new NegocioContratoLaboral();
            ContratoLaboral objContratoLaboral = new ContratoLaboral();
            String mensajeValidar = "";

            if (txtDescripcionContratoLaboral.Text == "Ingrese una breve descrpcion")
            {
                txtDescripcionContratoLaboral.Text = "";
            }
            try
            {
                objContratoLaboral.IdContratoLaboral = Convert.ToInt32(txtIdContratoLaboral.Text.Trim() == "" ? "0" : txtIdContratoLaboral.Text.Trim());
                objContratoLaboral.FechaInicioContratoLaboral = dtFechaInicioContrato.Value;
                objContratoLaboral.FechaFinContratoLaboral = dtFechaFinContrato.Value;
                objContratoLaboral.HorasTotalesContratoLaboral = Convert.ToInt32(txtHorasTotalesContratoLaboral.Text);
                objContratoLaboral.FechaRegistroContratoLaboral = DateTime.Now;
                objContratoLaboral.EstadoContratoLaboral = chkEstadoContratoLaboral.Checked;
                objContratoLaboral.DescripcionContratoLaboral = txtDescripcionContratoLaboral.Text;
                objContratoLaboral.IdCargoContratoLaboral = Convert.ToInt32(txtIdCargo.Text.Trim());
                objContratoLaboral.IdTipoContratoLaboral = Convert.ToInt32(txtIdTipoContratoLaboral.Text.Trim());
                objContratoLaboral.IdTrabajador = Convert.ToInt32(txtIdTrabajador.Text.Trim());
                objContratoLaboral.SalarioContratoLaboral = decimal.TryParse(txtSalarioContratoLaboral.Text, out decimal salario) ? salario : 0.00m;
                objContratoLaboral.HorasDiariasContratoLaboral = Convert.ToInt32(txtHorasDiariasContratoLaboral.Text);
                objContratoLaboral.AsignaciónFamiliarContratoLaboral = Convert.ToDecimal(txtMontoAsignacionFamiliar.Text);

                mensajeValidar = objNegocioContratoLaboral.NegocioRegistrarContratoLaboral(objContratoLaboral).Trim();
                if (mensajeValidar == "OK")
                {
                    mensajeValidar = "Contrato Registrado";
                }
                else
                {
                    mensajeValidar = "Error al registrar el Contrato.";
                }
            }
            catch (Exception ex)
            {
                mensajeValidar = $"Error: {ex.Message}";
            }

            return mensajeValidar;
        }

        #endregion

        #region Funcion Actualizar Trabajador
        public String funcionActualizarTrabajador()
        {
            NegocioContratoLaboral objNegocioContratoLaboral = new NegocioContratoLaboral();
            ContratoLaboral objContratoLaboral = new ContratoLaboral();
            String mensajeValidar = "";
            try
            {
                objContratoLaboral.IdContratoLaboral = Convert.ToInt32(txtIdContratoLaboral.Text.Trim() == "" ? "0" : txtIdContratoLaboral.Text.Trim());
                objContratoLaboral.FechaInicioContratoLaboral = dtFechaInicioContrato.Value;
                objContratoLaboral.FechaFinContratoLaboral = dtFechaFinContrato.Value;
                objContratoLaboral.HorasTotalesContratoLaboral = Convert.ToInt32(txtHorasTotalesContratoLaboral.Text);
                objContratoLaboral.FechaRegistroContratoLaboral = DateTime.Now;
                objContratoLaboral.EstadoContratoLaboral = chkEstadoContratoLaboral.Checked;
                objContratoLaboral.DescripcionContratoLaboral = txtDescripcionContratoLaboral.Text;
                objContratoLaboral.IdCargoContratoLaboral = Convert.ToInt32(txtIdCargo.Text.Trim());
                objContratoLaboral.IdTipoContratoLaboral = Convert.ToInt32(txtIdTipoContratoLaboral.Text.Trim());
                objContratoLaboral.IdTrabajador = Convert.ToInt32(txtIdTrabajador.Text.Trim());
                objContratoLaboral.SalarioContratoLaboral = decimal.TryParse(txtSalarioContratoLaboral.Text, out decimal salario) ? salario : 0.00m;
                objContratoLaboral.HorasDiariasContratoLaboral = Convert.ToInt32(txtHorasDiariasContratoLaboral.Text);

                mensajeValidar = objNegocioContratoLaboral.NegocioActuailzarContratoLaboral(objContratoLaboral).Trim();
                if (mensajeValidar == "OK")
                {
                    mensajeValidar = "Contrato Actualizado";
                }
                else
                {
                    mensajeValidar = "Error al Actualizar el Contrato.";
                }
            }
            catch (Exception ex)
            {
                mensajeValidar = $"Error: {ex.Message}";
            }

            return mensajeValidar;
        }


        #endregion

        #region Button Actualizar Trabajador
        private void btnActualizarContratoLaboral_Click(object sender, EventArgs e)
        {
            String pResult = funcionActualizarTrabajador();
            if (pResult == "Contrato Actualizado")
            {
                FuncionesGenerales.ShowAlert("Contrato Actualizado", frmNotificacion.enmType.Info);
                FuncionLimpiarControles();
                FuncionTiposBusqueda(0);
            }
            else
            {
                Mbox.Show(pResult, "Error de Actualizacion. Comunicar al Administrador del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        #endregion

        #region Funcion Limpiar Controles
        public void FuncionLimpiarControles()
        {
            bool EstadoActivarBotonRegistrar = FuncionesValidaciones.FuncionPropiedadesControles(btnRegistrarContratoLaboral, btnActualizarContratoLaboral, btnLimpiarContratoLaboral, FuncionValidarTextBox());

            if (EstadoActivarBotonRegistrar)
            {
                cboTrabajador.SelectedIndex = 0;
                txtIdTrabajador.Text = "";
                txtEspecialidadtrabajador.Text = "";
                cboCargo.SelectedIndex = 0;
                txtIdCargo.Text = "";
                cboTipoContrato.SelectedIndex = 0;
                txtIdTipoContratoLaboral.Text = "";
                txtHorasTotalesContratoLaboral.Text = "";
                txtHorasDiariasContratoLaboral.Text = "";
                txtSalarioContratoLaboral.Text = "";
                txtSalarioxHoraContratoLaboral.Text = "";
                FuncionesValidaciones.PlaceholderHelper.fnPlaceholder(txtDescripcionContratoLaboral, "Ingrese una breve descrpcion");
                chkEstadoContratoLaboral.Checked = true;
                btnLimpiarContratoLaboral.Visible = false;
                btnRegistrarContratoLaboral.Visible = true;
                btnRegistrarContratoLaboral.Enabled = false;
                btnActualizarContratoLaboral.Visible = false;
                chkEstadoContratoLaboral.Enabled = false;
            }
        }
        #endregion

        #region Button Limpiar Controles
        private void btnLimpiarContratoLaboral_Click(object sender, EventArgs e)
        {
            FuncionLimpiarControles();
        }
        #endregion

        #region Funcion Tipos de Busqueda
        public void FuncionTiposBusqueda(Int32 tipoCon)
        {
            Boolean bResult;
            if (tipoCon == 1)
            {
                if (pasoLoad)
                {
                    bResult = FuncionBuscarContratoLaboral(dgvContratoLaboral, 0);

                    if (!bResult)
                    {
                        Mbox.Show("Error al realizar busqueda. Comunicar al Administrador del Sistema", "Error de Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (tipoCon == 2)
            {
                if (pasoLoad)
                {
                    bResult = FuncionBuscarContratoLaboral(dgvContratoLaboral, 0);

                    if (!bResult)
                    {
                        Mbox.Show("Error al realizar busqueda. Comunicar al Administrador del Sistema", "Error de Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                Int32 numPagina = Convert.ToInt32(cboPaginaContratoLaboral.Text.ToString());
                if (pasoLoad)
                {
                    bResult = FuncionBuscarContratoLaboral(dgvContratoLaboral, numPagina);

                    if (!bResult)
                    {
                        Mbox.Show("Error al realizar busqueda. Comunicar al Administrador del Sistema", "Error de Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        #endregion

        #region Función Busqueda Contrato Laboral
        private bool SegundaBusqueda = false;
        public Boolean FuncionBuscarContratoLaboral(DataGridView dgv, Int32 numPagina)
        {
            NegocioContratoLaboral objNegocioContratoLaboral = new NegocioContratoLaboral();
            DataTable dtContratoLaboral = new DataTable();
            String documentoTrabajador;
            Int32 filas = 18;
            DateTime fechaInicial = dtFechaInicio.Value;
            DateTime fechaFinal = dtFechaFin.Value;
            Boolean habilitarFechas = chkHabilitarFechasBusqueda.Checked ? true : false;

            try
            {
                documentoTrabajador = txtBusquedaContratoLaboralTrabajador.Text;
                dtContratoLaboral = objNegocioContratoLaboral.NegocioBuscarContratoLaboral(habilitarFechas, fechaInicial, fechaFinal, documentoTrabajador, numPagina);
                dgvContratoLaboral.Visible = true;
                dgvContratoLaboral.Rows.Clear();
                Int32 totalResultados = dtContratoLaboral.Rows.Count;

                #region Tamaño de Columnas de la Tabla [dgvContratoLaboral]
                dgvContratoLaboral.Columns["Numero"].Width = 25;
                dgvContratoLaboral.Columns["EstadoContratoLaboral"].Width = 60;
                dgvContratoLaboral.Columns["nombreTrabajador"].Width = 170;
                #endregion

                if (dtContratoLaboral.Rows.Count > 0)
                {
                    Int32 y;
                    if (numPagina == 0)
                    {
                        y = 0;
                    }
                    else
                    {
                        tabInicio = (numPagina - 1) * filas;
                        y = tabInicio;
                    }
                    foreach (DataRow item in dtContratoLaboral.Rows)
                    {
                        y++;

                        string estado = (bool)item["EstadoContratoLaboral"] ? "ACTIVO" : "INACTIVO";
                        string nombreCompleto = $"{item["nombreTrabajador"]} {item["apellidoPaternoTrabajador"]} {item["apellidoMaternoTrabajador"]}";
                        string fechaInicio = Convert.ToDateTime(item["fechaInicioContratoLaboral"]).ToString("dd/MM/yyyy");
                        string fechaFin = Convert.ToDateTime(item["fechaFinContratoLaboral"]).ToString("dd/MM/yyyy");

                        dgvContratoLaboral.Rows.Add(
                            y,
                            item["IdContratoLaboral"],
                            fechaInicio,
                            fechaFin,
                            item["horasTotalesContratoLaboral"],
                            estado,
                            item["descripcionContratoLaboral"],
                            item["IdCargoContratoLaboral"],
                            item["nombreCargo"],
                            item["IdTipoContratoLaboral"],
                            item["nombreTipoContrato"],
                            item["IdTrabajador"],
                            nombreCompleto,
                            item["salarioContratoLaboral"],
                            item["horasDiariasContratoLaboral"],
                            item["AsignaciónFamiliarContratoLaboral"]
                        );
                    }
                }
                if (numPagina == 0 && !SegundaBusqueda)
                {
                    Int32 totalRegistros = Convert.ToInt32(dtContratoLaboral.Rows[0][0]);
                    FuncionesGenerales.CalcularPaginacion(totalRegistros, filas, totalResultados, cboPaginaContratoLaboral, btnTotalPaginasContratoLaboral, btnNumFilasContratoLaboral, btnTotalRegistrosContratoLaboral);
                    SegundaBusqueda = true;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                objNegocioContratoLaboral = null;
            }
        }
        #endregion

        #region Tipos de Busqueda 
        private void pboxBuscarTrabajador_Click(object sender, EventArgs e)
        {
            FuncionTiposBusqueda(1);
        }

        private void txtBusquedaContratoLaboralTrabajador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Key.Enter)
            {
                FuncionTiposBusqueda(2);
            }
        }

        private void cboPaginaContratoLaboral_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionTiposBusqueda(3);
        }

        #endregion

        #region Eliminar Registro Contrato Laboral
        private void eliminarRegistroContratoLaboral_Click(object sender, EventArgs e)
        {
            if (dgvContratoLaboral.SelectedRows.Count > 0)
            {
                DialogResult resultado = Mbox.Show("¿Estás seguro de que deseas eliminar el Registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    Int32 IdContratoLaboral = Convert.ToInt32(dgvContratoLaboral.SelectedRows[0].Cells["IdContratoLaboral"].Value);
                    NegocioContratoLaboral objNegocioContratoLaboral = new NegocioContratoLaboral();
                    try
                    {
                        objNegocioContratoLaboral.NegocioEliminarContratoLaboral(IdContratoLaboral);
                        FuncionesGenerales.ShowAlert("Registro Eliminado", frmNotificacion.enmType.Info);
                        FuncionBuscarContratoLaboral(dgvContratoLaboral, 0);
                    }
                    catch (Exception ex)
                    {
                        Mbox.Show($"Error al Eliminar el Registro de Contrato Laboral: {ex.Message}", "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Enviar valores de la tabla a los Controles
        private void dgvContratoLaboral_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvContratoLaboral.Rows[e.RowIndex];

                int idContratoLaboral = (int)selectedRow.Cells["IdContratoLaboral"].Value;

                if (selectedRow.Cells["fechaInicioContratoLaboral"].Value != DBNull.Value &&
                    selectedRow.Cells["fechaFinContratoLaboral"].Value != DBNull.Value)
                {
                    string fechaInicioFormateada = Convert.ToDateTime(selectedRow.Cells["fechaInicioContratoLaboral"].Value).ToString("yyyy-MM-dd HH:mm:ss");
                    string fechaFinFormateada = Convert.ToDateTime(selectedRow.Cells["fechaFinContratoLaboral"].Value).ToString("yyyy-MM-dd HH:mm:ss");

                    DateTime fechaInicioContrato = DateTime.Parse(fechaInicioFormateada);
                    DateTime fechaFinContrato = DateTime.Parse(fechaFinFormateada);

                    dtFechaInicioContrato.Value = fechaInicioContrato;
                    dtFechaFinContrato.Value = fechaFinContrato;
                    TimeSpan diferencia = fechaFinContrato - fechaInicioContrato;

                    int totalDias = diferencia.Days;
                    int totalHoras = diferencia.Hours;

                    rbContratoTresMeses.Checked = totalDias >= 365 || totalDias == 364;
                    rbContratoSeisMeses.Checked = totalDias >= 182 && totalDias < 364;
                    rbContratoDoceMeses.Checked = totalDias >= 90 && totalDias < 182;
                }
                else
                {
                    MessageBox.Show("Una o ambas fechas son inválidas.");
                }

                int horasTotalesContrato = (int)selectedRow.Cells["horasTotalesContratoLaboral"].Value;
                string estadoContrato = selectedRow.Cells["EstadoContratoLaboral"].Value.ToString();
                string descripcionContrato = selectedRow.Cells["descripcionContratoLaboral"].Value.ToString();
                int idCargoContrato = (int)selectedRow.Cells["IdCargoContratoLaboral"].Value;
                int idTipoContrato = (int)selectedRow.Cells["IdTipoContratoLaboral"].Value;
                string nombreTipoContrato = selectedRow.Cells["nombreTipoContrato"].Value.ToString();
                int idTrabajador = (int)selectedRow.Cells["IdTrabajador"].Value;
                string nombreTrabajador = selectedRow.Cells["nombreTrabajador"].Value.ToString();
                decimal salarioContrato = (decimal)selectedRow.Cells["salarioContratoLaboral"].Value;
                int horasDiariasContrato = (int)selectedRow.Cells["horasDiariasContratoLaboral"].Value;

                decimal asignacionFamiliar = (decimal)selectedRow.Cells["AsignaciónFamiliarContratoLaboral"].Value;
                chkAsignaciónFamiliarContratoLaboral.Checked = asignacionFamiliar != 0.00m;
                txtMontoAsignacionFamiliar.Text = asignacionFamiliar.ToString("F2"); 

                txtIdContratoLaboral.Text = idContratoLaboral.ToString();
                txtHorasTotalesContratoLaboral.Text = horasTotalesContrato.ToString();
                chkEstadoContratoLaboral.Checked = estadoContrato.Equals("ACTIVO", StringComparison.OrdinalIgnoreCase);
                txtDescripcionContratoLaboral.Text = descripcionContrato;
                cboCargo.SelectedIndex = idCargoContrato;
                cboTipoContrato.SelectedIndex = idTipoContrato;
                cboTrabajador.SelectedIndex = idTrabajador;
                txtSalarioContratoLaboral.Text = salarioContrato.ToString("F2");
                txtHorasDiariasContratoLaboral.Text = horasDiariasContrato.ToString();

                btnRegistrarContratoLaboral.Visible = false;
                btnActualizarContratoLaboral.Visible = true;
                chkEstadoContratoLaboral.Enabled = true;
            }

        }
        #endregion

        #region Validacion de Habilitar Fechas de Busqueda
        private void chkHabilitarFechasBusqueda_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFechasBusqueda.Checked == true)
            {
                gbRangoFechas.Enabled = true;
            }
            else
            {
                gbRangoFechas.Enabled = false;
            }
        }
        #endregion

        #region Evento checked changed de los  radio Button Rango Fechas
        private void rbContratoTresMeses_CheckedChanged(object sender, EventArgs e)
        {
            FuncionCambiarFechasContrato();
        }

        private void rbContratoSeisMeses_CheckedChanged(object sender, EventArgs e)
        {
            FuncionCambiarFechasContrato();
        }
        private void rbContratoDoceMeses_CheckedChanged(object sender, EventArgs e)
        {
            FuncionCambiarFechasContrato();
        }
        #endregion

        #region Metodo Cambiar Fechas de Contrato
        private void FuncionCambiarFechasContrato()
        {
            DateTime dtmFechaInicial = dtFechaInicioContrato.Value;
            DateTime dtmFechaFinal = dtFechaFinContrato.Value;
            Int32 intMesesDuracion = 0;

            IEnumerable<SiticoneRadioButton> grbRadioBtuttons = gbRangoFechasContrato.Controls.OfType<SiticoneRadioButton>();

            foreach (SiticoneRadioButton item in grbRadioBtuttons)
            {
                if (item.Checked)
                {
                    if (item.Name == "rbContratoTresMeses")
                    {
                        intMesesDuracion = 3;
                    }
                    if (item.Name == "rbContratoSeisMeses")
                    {
                        intMesesDuracion = 6;
                    }
                    if (item.Name == "rbContratoDoceMeses")
                    {
                        intMesesDuracion = 12;
                    }
                }
            }

            MetodosValidaciones.EstablecerFechasContrato(out DateTime fechaInicial, out DateTime fechaFinal, intMesesDuracion);

            dtFechaInicioContrato.Value = fechaInicial;
            dtFechaFinContrato.Value = fechaFinal;
        }
        #endregion

        #region Asignación Familiar ContratoLaboral
        private void chkAsignaciónFamiliarContratoLaboral_CheckedChanged(object sender, EventArgs e)
        {
            decimal salarioBase = Convert.ToDecimal(txtSalarioContratoLaboral.Text);
            CalcularMontoAsignacionFamiliar objCalcularMontoAsignacionFamiliar = new CalcularMontoAsignacionFamiliar();

            if (chkAsignaciónFamiliarContratoLaboral.Checked)
            {
                decimal asignacionFamiliar = objCalcularMontoAsignacionFamiliar.CalcularAsignacionFamiliar(salarioBase);
                txtMontoAsignacionFamiliar.Text = asignacionFamiliar.ToString("F2");
            }
            else
            {
                txtMontoAsignacionFamiliar.Text = "0.00";
            }
        }
        #endregion

    }
}
