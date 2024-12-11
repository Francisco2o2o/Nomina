using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using Guna.UI2.WinForms;
using LayerPresentation.FormNotificaciones;
using LayerPresentation.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Xml.Linq;

namespace CapaPresentacion
{
    public partial class frmPagos : Form
    {
        //Variables de busqueda
        static Boolean pasoLoad;
        static Int32 tabInicio = 0;
        public frmPagos()
        {
            InitializeComponent();

            #region Creacion de columnas para la tabla [dgvContratoLaboral]
            dgvContratoLaboral.Columns.Add("NumeroContratoLaboral", "N°");
            dgvContratoLaboral.Columns.Add("IdContratoLaboral", "IdContratoLaboral");
            dgvContratoLaboral.Columns.Add("documentoTrabajador", "Documento");
            dgvContratoLaboral.Columns.Add("nombreTrabajador", "Nombre del Trabajador");
            dgvContratoLaboral.Columns.Add("fechaInicioContratoLaboral", "Fecha de Inicio");
            dgvContratoLaboral.Columns.Add("fechaFinContratoLaboral", "Fecha de Fin");
            dgvContratoLaboral.Columns.Add("nombreTipoContratoLaboral", "Tipo de Contrato");
            dgvContratoLaboral.Columns.Add("salarioBaseTipoContratoLaboral", "Salario Base");
            dgvContratoLaboral.Columns.Add("AsignaciónFamiliarContratoLaboral", "Asignación Familiar");
            #endregion

            #region Creacion de columnas para la tabla [dgvPagos]
            dgvPagos.Columns.Add("NumeroPago", "N°");
            dgvPagos.Columns.Add("IdPago", "ID Pago");
            dgvPagos.Columns.Add("IdContratoLaboral", "IdContratoLaboral");
            dgvPagos.Columns.Add("documentoTrabajador", "Documento");
            dgvPagos.Columns.Add("nombreTrabajador", "Nombre del Trabajador");
            dgvPagos.Columns.Add("fechaPago", "Fecha de Pago");
            dgvPagos.Columns.Add("SalarioContrato", "Salario");
            dgvPagos.Columns.Add("Bonificacion", "Bonificacion");
            dgvPagos.Columns.Add("DescuentosTotales", "Descuentos");
            dgvPagos.Columns.Add("IdContrato", "ID Contrato");
            dgvPagos.Columns.Add("IdContratoPago", "ID Contrato de Pago");
            dgvPagos.Columns.Add("SalarioNeto", "Salario Neto");
            #endregion

            #region Creacion de columnas para la tabla [dgvPagos]
            dgvPeriodoPagos.Columns.Add("Numero", "N°");
            dgvPeriodoPagos.Columns.Add("nombrePeriodo", "Periodo");
            dgvPeriodoPagos.Columns.Add("montoTotalPago", "Monto Total del Pago");
            dgvPeriodoPagos.Columns.Add("fechaPago", "Fecha de Pago");
            #endregion

            FuncionLlenarComboBoxPeriodo(cboPeriodo, 0, "", false);

        }

        private void frmPagos_Load(object sender, EventArgs e)
        {
            bool EstadoActivarBotonRegistrar = FuncionesValidaciones.FuncionPropiedadesControlesPagos(btnRegistrarPagos, btnLimpiarControlesPagos, FuncionValidarTextBox());
            btnRegistrarPagos.Enabled = EstadoActivarBotonRegistrar;

            cboMetodoPago.SelectedIndex = 0;
            //Variable de busqueda
            pasoLoad = true;

            FuncionBuscarContratoLaboral(dgvContratoLaboral, 0);

            #region Visibilidad de Columnas de las tablas [dgvContratoLaboral - dgvPagos]
            dgvContratoLaboral.Columns["IdContratoLaboral"].Visible = false;
            dgvPagos.Columns["IdPago"].Visible = false;
            dgvPagos.Columns["IdContrato"].Visible = false;
            dgvPagos.Columns["IdContratoPago"].Visible = false;
            dgvPagos.Columns["IdContratoLaboral"].Visible = false;
            dgvPagos.Columns["Bonificacion"].Visible = false;
            dgvPagos.Columns["DescuentosTotales"].Visible = false;
            dgvPagos.Columns["fechaPago"].Visible = false;
            dgvPagos.Columns["SalarioContrato"].Visible = false;
            #endregion
        }

        #region  Validar Controles Vacios
        public bool FuncionValidarTextBox()
        {
            if (txtDescuentosTotales.Text != "0.00" && cboMetodoPago.SelectedIndex != 0 && btnProcesarContratosLaborales.Enabled == false)
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
            btnLimpiarControlesPagos.Visible = esValido;
            btnRegistrarPagos.Enabled = esValido;
        }
        #endregion

        #region Evento Changed  cboMetodoPago
        private void cboMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdMetodoPago = cboMetodoPago.SelectedIndex;
            txtIdMetodoPago.Text = IdMetodoPago.ToString();
            FuncionValidarChanged();
        }
        #endregion

        #region Funcion para llenar el ComboBox Periodo
        public static List<Periodo> FuncionLlenarComboBoxPeriodo(Guna2ComboBox cbo, Int32 idPeriodo, String nombrePeriodo, Boolean buscar)
        {
            NegocioPeriodo objNegocioPeriodo = new NegocioPeriodo();
            List<Periodo> lstPeriodo = new List<Periodo>();

            try
            {
                lstPeriodo = objNegocioPeriodo.NegocioLlenarComboBoxPeriodo(idPeriodo, nombrePeriodo, buscar);
                cbo.ValueMember = "IdPeriodo";
                cbo.DisplayMember = "NombrePeriodo";
                cbo.DataSource = lstPeriodo;

                return lstPeriodo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return lstPeriodo;
            }
            finally
            {
                lstPeriodo = null;
            }
        }
        #endregion

        #region Asignar Datos al seleccionar el Periodo
        private void cboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPeriodo.SelectedItem is Periodo selectedPeriodo)
            {
                txtIdPeriodo.Text = selectedPeriodo.IdPeriodo.ToString();
                dtFechaInicioPeriodo.Value = selectedPeriodo.FechaInicioPeriodo;
                dtFechaFinPeriodo.Value = selectedPeriodo.FechaFinPeriodo;
            }
            FuncionValidarChanged();
        }
        #endregion

        #region Función Listar Contrato Laboral
        private bool SegundaBusqueda = false;
        public Boolean FuncionBuscarContratoLaboral(DataGridView dgv, Int32 numPagina)
        {
            NegocioContratoLaboral objNegocioContratoLaboral = new NegocioContratoLaboral();
            DataTable dtContratoLaboral = new DataTable();
            String documentoTrabajador;
            Int32 filas = 11;
            DateTime fechaInicial = dtFechaInicio.Value;
            DateTime fechaFinal = dtFechaFin.Value;
            Boolean habilitarFechas = chkHabilitarFechasBusqueda.Checked ? true : false;

            try
            {
                documentoTrabajador = txtBusquedaContratoLaboralTrabajador.Text;

                dtContratoLaboral = objNegocioContratoLaboral.NegocioListarContratoLaboral(habilitarFechas, fechaInicial, fechaFinal, documentoTrabajador, numPagina);

                dgv.Visible = true;
                chkSeleccionarTodosContrato.Visible = true;
                chkSeleccionarTodosContrato.Enabled = true;
                dgv.Rows.Clear();
                Int32 totalResultados = dtContratoLaboral.Rows.Count;

                #region Tamaño de Columnas de la Tabla [dgvContratoLaboral]
                dgv.Columns["NumeroContratoLaboral"].Width = 25;
                dgv.Columns["nombreTrabajador"].Width = 170;
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
                        int tabInicio = (numPagina - 1) * filas;
                        y = tabInicio;
                    }

                    foreach (DataRow item in dtContratoLaboral.Rows)
                    {
                        if (!dgv.Columns.Contains("Seleccionar"))
                        {
                            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
                            chkColumn.Name = "Seleccionar";
                            chkColumn.HeaderText = "Seleccionar";
                            chkColumn.Width = 50;
                            chkColumn.TrueValue = true;
                            chkColumn.FalseValue = false;
                            dgv.Columns.Add(chkColumn);
                        }
                        y++;
                        string nombreCompleto = $"{item["nombreTrabajador"]} {item["apellidoPaternoTrabajador"]} {item["apellidoMaternoTrabajador"]}";
                        string fechaInicio = Convert.ToDateTime(item["fechaInicioContratoLaboral"]).ToString("dd/MM/yyyy");
                        string fechaFin = Convert.ToDateTime(item["fechaFinContratoLaboral"]).ToString("dd/MM/yyyy");

                        dgv.Rows.Add(
                            y,
                            item["IdContratoLaboral"],
                            item["documentoTrabajador"],
                            nombreCompleto,
                            fechaInicio,
                            fechaFin,
                            item["nombreTipoContratoLaboral"],
                            item["salarioBaseTipoContratoLaboral"],
                            item["AsignaciónFamiliarContratoLaboral"],
                            true
                        );
                    }
                }

                if (numPagina == 0 && !SegundaBusqueda)
                {
                    Int32 totalRegistros = Convert.ToInt32(dtContratoLaboral.Rows[0][0]);
                    FuncionesGenerales.CalcularPaginacion(totalRegistros, filas, totalResultados, cboPaginaContratoLaboral, btnTotalPaginasPagos, btnNumFilasPagos, btnTotalRegistrosPagos);
                    SegundaBusqueda = true;
                    btnProcesarContratosLaborales.Enabled = true;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar contrato laboral: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                objNegocioContratoLaboral = null;
            }
        }
        #endregion

        #region Seleccionar Todos los Registros de la tabla [dgvContratoLaboral]
        private void chkSeleccionarTodosContrato_CheckedChanged(object sender, EventArgs e)
        {
            bool estado = chkSeleccionarTodosContrato.Checked;

            foreach (DataGridViewRow row in dgvContratoLaboral.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Seleccionar"];
                    chk.Value = estado;
                }
            }
            btnProcesarContratosLaborales.Enabled = estado;
        }

        #region Evento CellContentClick de la tabla [dgvContratoLaboral] para manejar el click en los checkboxes
        private void dgvContratoLaboral_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvContratoLaboral.Columns["Seleccionar"].Index && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvContratoLaboral.Rows[e.RowIndex].Cells["Seleccionar"];

                chk.Value = !(Convert.ToBoolean(chk.Value));

                btnProcesarContratosLaborales.Enabled = dgvContratoLaboral.Rows.Cast<DataGridViewRow>()
                    .Any(row => !row.IsNewRow && Convert.ToBoolean(row.Cells["Seleccionar"].Value));
            }
        }
        #endregion

        #endregion

        #region Funcion Tipos de Busqueda
        public void FuncionTiposBusqueda(Int32 tipoCon)
        {
            dgvPeriodoPagos.Visible = false;
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

        #region Tipos de Busqueda 
        private void pboxBuscarContratoLaboraPorTrabajador_Click(object sender, EventArgs e)
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

        #region Button Procesar Contratos Laborales
        private void btnProcesarContratosLaborales_Click(object sender, EventArgs e)
        {
            if (dgvPagos.Rows.Count > 0)
            {
                dgvPagos.Rows.Clear();
            }

            int numeroPago = 1;
            foreach (DataGridViewRow row in dgvContratoLaboral.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                {
                    #region Tamaño de Columnas de la Tabla [dgvPagos]
                    dgvPagos.Columns["NumeroPago"].Width = 25;
                    dgvPagos.Columns["documentoTrabajador"].Width = 80;
                    dgvPagos.Columns["nombreTrabajador"].Width = 180;
                    dgvPagos.Columns["fechaPago"].Width = 120;
                    #endregion

                    int index = dgvPagos.Rows.Add();

                    dgvPagos.Rows[index].Cells["NumeroPago"].Value = numeroPago;
                    dgvPagos.Rows[index].Cells["IdPago"].Value = Guid.NewGuid();
                    dgvPagos.Rows[index].Cells["IdContratoLaboral"].Value = row.Cells["IdContratoLaboral"].Value;
                    dgvPagos.Rows[index].Cells["documentoTrabajador"].Value = row.Cells["documentoTrabajador"].Value;
                    dgvPagos.Rows[index].Cells["nombreTrabajador"].Value = row.Cells["nombreTrabajador"].Value;
                    dgvPagos.Rows[index].Cells["SalarioContrato"].Value = row.Cells["salarioBaseTipoContratoLaboral"].Value;

                    decimal bonificacion = Convert.ToDecimal(row.Cells["AsignaciónFamiliarContratoLaboral"].Value);
                    decimal descuentosTotales = Convert.ToDecimal(txtDescuentosTotales.Text);

                    dgvPagos.Rows[index].Cells["Bonificacion"].Value = bonificacion;
                    dgvPagos.Rows[index].Cells["DescuentosTotales"].Value = descuentosTotales;

                    decimal salarioContrato = Convert.ToDecimal(dgvPagos.Rows[index].Cells["SalarioContrato"].Value);
                    decimal salarioNeto = (salarioContrato + bonificacion) - descuentosTotales;

                    dgvPagos.Rows[index].Cells["SalarioNeto"].Value = salarioNeto.ToString("F2");

                    dgvPagos.Rows[index].Cells["fechaPago"].Value = DateTime.Now;

                    numeroPago++;
                    dgvPagos.Visible = true;
                    FuncionCalcularMontoTotalPago();
                    btnProcesarContratosLaborales.Enabled = false;
                    lblMontoTotal.Visible = true;
                    lblMonedaMontoTotal.Visible = true;
                    txtMontoTotalPago.Visible = true;
                }
            }

            if (numeroPago == 1)
            {
                MessageBox.Show("Por favor Seleccione un registro para proceder con pago", "Error de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Funcion Culcular Total Pago
        public void FuncionCalcularMontoTotalPago()
        {
            MetodosPagos metodosPagos = new MetodosPagos();
            if (dgvPagos.Rows.Count > 0)
            {
                List<decimal> salariosSeleccionados = new List<decimal>();


                foreach (DataGridViewRow row in dgvPagos.Rows)
                {

                    if (decimal.TryParse(row.Cells["SalarioNeto"].Value?.ToString(), out decimal salarioNeto))
                    {
                        salariosSeleccionados.Add(salarioNeto);
                    }
                    else
                    {
                        MessageBox.Show("Por favor, asegúrese de que todos los salarios netos sean válidos en las filas seleccionadas.");
                        return;
                    }
                }

                decimal totalSeguro = metodosPagos.CalcularMontoTotalPago(salariosSeleccionados);

                txtMontoTotalPago.Text = totalSeguro.ToString("F2");
            }
            else
            {
                txtMontoTotalPago.Text = "0.00";

                MessageBox.Show("No hay registros en el DataGridView para procesar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Button Limpiar Controles
        private void btnLimpiarControlesPagos_Click(object sender, EventArgs e)
        {
            FuncionLimpiarControles();
        }
        #endregion

        #region Funcion Limpiar Controles
        public void FuncionLimpiarControles()
        {
            dgvContratoLaboral.Enabled = true;
            if (dgvPagos.Rows.Count > 0)
            {
                dgvPagos.Rows.Clear();
                dgvPagos.Visible = false;
            }

            chkDeduccionesSeguros.Checked = false;
            chkSeguroSalud.Checked = false;
            chkSeguroVida.Checked = false;
            chkSeguroAccidentes.Checked = false;
            chkDeducciónImpuestos.Checked = false;
            chkAFP.Checked = false;

            cboPeriodo.SelectedIndex = 0;
            txtIdPeriodo.Text = "";
            txtMontoTotalPago.Text = "";
            cboMetodoPago.SelectedIndex = 0;
            btnProcesarContratosLaborales.Enabled = true;
            lblMontoTotal.Visible = false;
            lblMonedaMontoTotal.Visible = false;
            txtMontoTotalPago.Visible = false;

        }
        #endregion

        #region Habilitar fechas de busqueda
        private void chkHabilitarFechasBusqueda_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFechasBusqueda.Checked)
            {
                gbRangoFechas.Enabled = true;
            }
            else
            {
                gbRangoFechas.Enabled = false;
            }
        }


        #endregion

        #region Función Registrar Pago
        public String funcionRegistrarPago()
        {
            NegocioPago objNegocioPago = new NegocioPago();

            Pago objPago = new Pago();
            ContratoPago objContratoPago = new ContratoPago();

            String mensajeValidar = "";

            try
            {
                objPago.MontoTotalPago = Convert.ToDecimal(txtMontoTotalPago.Text);
                objPago.FechaPago = DateTime.Now;
                objPago.EstadoPago = true;
                objPago.MetodoPago = txtIdMetodoPago.Text;

                objContratoPago.IdPeriodo = Convert.ToInt32(txtIdPeriodo.Text);

                StringBuilder xmlDetalles = new StringBuilder();
                xmlDetalles.Append("<Detalles>");

                foreach (DataGridViewRow row in dgvPagos.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        xmlDetalles.Append("<DetallePago>");

                        xmlDetalles.AppendFormat("<CantidadDetallePago>{0}</CantidadDetallePago>", 1);

                        decimal salarioContrato = Convert.ToDecimal(row.Cells["SalarioContrato"].Value);
                        xmlDetalles.AppendFormat("<MontoUnitarioDetallePago>{0}</MontoUnitarioDetallePago>", salarioContrato);

                        decimal SalarioNeto = Convert.ToDecimal(row.Cells["SalarioNeto"].Value);
                        xmlDetalles.AppendFormat("<MontoTotalDetallePago>{0}</MontoTotalDetallePago>", SalarioNeto);

                        int idContratoLaboral = Convert.ToInt32(row.Cells["IdContratoLaboral"].Value);
                        xmlDetalles.AppendFormat("<IdContratoLaboral>{0}</IdContratoLaboral>", idContratoLaboral);

                        decimal bonificaciones = Convert.ToDecimal(row.Cells["Bonificacion"].Value);
                        xmlDetalles.AppendFormat("<Bonificaciones>{0}</Bonificaciones>", bonificaciones);

                        decimal descuentos = Convert.ToDecimal(row.Cells["DescuentosTotales"].Value);
                        xmlDetalles.AppendFormat("<Descuentos>{0}</Descuentos>", descuentos);

                        xmlDetalles.Append("</DetallePago>");
                    }
                }
                xmlDetalles.Append("</Detalles>");

                objPago.XmlDetalles = xmlDetalles.ToString();

                mensajeValidar = objNegocioPago.NegocioRegistrarPago(objPago, objContratoPago).Trim();

                if (mensajeValidar == "OK")
                {
                    mensajeValidar = "Pago Registrado";
                }
                else
                {
                    mensajeValidar = "Error al registrar el Pago.";
                }
            }
            catch (Exception ex)
            {
                mensajeValidar = $"Error: {ex.Message}";
            }

            return mensajeValidar;
        }

        #endregion

        #region Button Registrar Pagos
        private void btnRegistrarPagos_Click(object sender, EventArgs e)
        {
            String pResult = funcionRegistrarPago();
            if (pResult == "Pago Registrado")
            {
                FuncionesGenerales.ShowAlert("Pago Registrado", frmNotificacion.enmType.Info);
                FuncionLimpiarControles();
                FuncionBuscarPeriodos(dgvPeriodoPagos);
            }
            else
            {
                Mbox.Show("Error al Registrar Pago. Comunicar al Administrador del Sistema", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region FuncionCalcularDeducciónSeguros
        public void FuncionCalcularDeducciónSeguros(int TipoCalculo)
        {
            MetodosPagos metodosPagos = new MetodosPagos();

            List<decimal> salariosSeleccionados = new List<decimal>();

            if (chkSeguroSalud.Checked || chkSeguroVida.Checked || chkSeguroAccidentes.Checked)
            {
                foreach (DataGridViewRow row in dgvContratoLaboral.Rows)
                {
                    if (!row.IsNewRow && Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                    {
                        if (decimal.TryParse(row.Cells["salarioBaseTipoContratoLaboral"].Value?.ToString(), out decimal salarioBase) &&
                            decimal.TryParse(row.Cells["AsignaciónFamiliarContratoLaboral"].Value?.ToString(), out decimal asignacionFamiliar))
                        {

                            decimal salarioTotal = salarioBase + asignacionFamiliar;

                            salariosSeleccionados.Add(salarioTotal);
                        }
                        else
                        {
                            MessageBox.Show("Por favor, ingresa un salario base y asignación familiar válidos en todas las filas seleccionadas.");
                            return;
                        }
                    }
                }

                decimal totalSeguro = metodosPagos.CalcularDeduccionSeguros(salariosSeleccionados, TipoCalculo);

                if (TipoCalculo == 1)
                {
                    txtSeguroSalud.Text = totalSeguro.ToString("F2");
                }
                else if (TipoCalculo == 2)
                {
                    txtSeguroVida.Text = totalSeguro.ToString("F2");
                }
                else
                {
                    txtSeguroAccidentes.Text = totalSeguro.ToString("F2");
                }
            }
            else
            {
                txtSeguroSalud.Text = "0.00";
                txtSeguroVida.Text = "0.00";
                txtSeguroAccidentes.Text = "0.00";
            }
        }


        private void chkSeguroSalud_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeguroSalud.Checked)
            {
                FuncionCalcularDeducciónSeguros(1);
                chkDeduccionesSeguros.Checked = false;
            }
            else
            {
                txtSeguroSalud.Text = "0.00";
            }
        }

        private void chkSeguroVida_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeguroVida.Checked)
            {
                FuncionCalcularDeducciónSeguros(2);
                chkDeduccionesSeguros.Checked = false;
            }
            else
            {
                txtSeguroVida.Text = "0.00";
            }
        }

        private void chkSeguroAccidentes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeguroAccidentes.Checked)
            {
                FuncionCalcularDeducciónSeguros(3);
                chkDeduccionesSeguros.Checked = false;
            }
            else
            {
                txtSeguroAccidentes.Text = "0.00";
            }
        }
        #endregion

        #region Calcular Deducciones de Seguros
        private void chkDeduccionesSeguros_CheckedChanged(object sender, EventArgs e)
        {
            MetodosPagos metodosPagos = new MetodosPagos();
            if (chkDeduccionesSeguros.Checked)
            {
                decimal SeguroVida = Convert.ToDecimal(txtSeguroVida.Text);
                decimal SeguroSalud = Convert.ToDecimal(txtSeguroSalud.Text);
                decimal SeguroAccidentes = Convert.ToDecimal(txtSeguroAccidentes.Text);

                decimal totalDeduccionesSeguro = metodosPagos.CalcularDeduccionesTotalesSeguros(SeguroSalud, SeguroVida, SeguroAccidentes);
                txtDeduccionesSeguros.Text = totalDeduccionesSeguro.ToString("F2");
            }
            else
            {
                txtDeduccionesSeguros.Text = "0.00";
            }
        }
        #endregion

        #region Calcular AFP
        private void chkAFP_CheckedChanged(object sender, EventArgs e)
        {
            MetodosPagos metodosPagos = new MetodosPagos();

            List<decimal> salariosSeleccionados = new List<decimal>();

            if (chkAFP.Checked)
            {
                foreach (DataGridViewRow row in dgvContratoLaboral.Rows)
                {
                    if (!row.IsNewRow && Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                    {
                        if (decimal.TryParse(row.Cells["salarioBaseTipoContratoLaboral"].Value?.ToString(), out decimal salarioBase) &&
                            decimal.TryParse(row.Cells["AsignaciónFamiliarContratoLaboral"].Value?.ToString(), out decimal asignacionFamiliar))
                        {

                            decimal salarioTotal = salarioBase + asignacionFamiliar;

                            salariosSeleccionados.Add(salarioTotal);
                        }
                        else
                        {
                            MessageBox.Show("Por favor, ingresa un salario base y asignación familiar válidos en todas las filas seleccionadas.");
                            return;
                        }
                    }
                }
                decimal totalSeguro = metodosPagos.CalcularAFP(salariosSeleccionados);
                txtAFP.Text = totalSeguro.ToString("F2");
            }
            else
            {
                txtAFP.Text = "0.00";
            }
        }
        #endregion

        #region Calcular Deduccion Impuestos
        private void chkDeducciónImpuestos_CheckedChanged(object sender, EventArgs e)
        {
            MetodosPagos metodosPagos = new MetodosPagos();

            List<decimal> salariosSeleccionados = new List<decimal>();

            if (chkDeducciónImpuestos.Checked)
            {
                foreach (DataGridViewRow row in dgvContratoLaboral.Rows)
                {
                    if (!row.IsNewRow && Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                    {
                        if (decimal.TryParse(row.Cells["salarioBaseTipoContratoLaboral"].Value?.ToString(), out decimal salarioBase) &&
                            decimal.TryParse(row.Cells["AsignaciónFamiliarContratoLaboral"].Value?.ToString(), out decimal asignacionFamiliar))
                        {

                            decimal salarioTotal = salarioBase + asignacionFamiliar;

                            salariosSeleccionados.Add(salarioTotal);
                        }
                        else
                        {
                            MessageBox.Show("Por favor, ingresa un salario base y asignación familiar válidos en todas las filas seleccionadas.");
                            return;
                        }
                    }
                }
                decimal totalSeguro = metodosPagos.CalcularDeduccionImpuestos(salariosSeleccionados);
                txtDeducciónImpuestos.Text = totalSeguro.ToString("F2");
            }
            else
            {
                txtDeducciónImpuestos.Text = "0.00";

            }
        }
        #endregion

        #region Calcular Descuentos Totales 
        private void chkDescuentosTotales_CheckedChanged(object sender, EventArgs e)
        {
            MetodosPagos metodosPagos = new MetodosPagos();
            if (chkDescuentosTotales.Checked)
            {
                decimal DeduccionesSeguros = Convert.ToDecimal(txtDeduccionesSeguros.Text);
                decimal AFP = Convert.ToDecimal(txtAFP.Text);
                decimal DeducciónImpuestos = Convert.ToDecimal(txtDeducciónImpuestos.Text);

                decimal totalDeduccionesSeguro = metodosPagos.CalcularDescuentosTotales(DeduccionesSeguros, AFP, DeducciónImpuestos);
                txtDescuentosTotales.Text = totalDeduccionesSeguro.ToString("F2");
            }
            else
            {
                txtDescuentosTotales.Text = "0.00";
            }
        }
        #endregion

        #region Buton Busqueda Periodo
        private void btnBusquedaPeriodo_Click(object sender, EventArgs e)
        {
            FuncionBuscarPeriodos(dgvPeriodoPagos);

        }
        #endregion

        #region Función Listar Períodos
        public Boolean FuncionBuscarPeriodos(DataGridView dgv)
        {
            dgvContratoLaboral.Visible = false;
            NegocioPeriodo objNegocioPeriodo = new NegocioPeriodo();
            DataTable dtPeriodo = new DataTable();

            try
            {
                dtPeriodo = objNegocioPeriodo.NegocioBuscarPeriodoPago();

                dgv.Visible = true;
                dgv.Rows.Clear();
                Int32 totalResultados = dtPeriodo.Rows.Count;

                if (totalResultados > 0)
                {
                    int y = 0;

                    foreach (DataRow item in dtPeriodo.Rows)
                    {
                        y++;

                        dgv.Rows.Add(
                            y,
                            item["nombrePeriodo"],
                            item["montoTotalPago"],
                            Convert.ToDateTime(item["fechaPago"]).ToString("dd/MM/yyyy")
                        );
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar períodos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                objNegocioPeriodo = null;
            }
        }
        #endregion

    }

}
