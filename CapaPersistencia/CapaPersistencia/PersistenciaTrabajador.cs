using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using CapaConexion;
using CapaEntidad;

namespace CapaPersistencia
{
    public class PersistenciaTrabajador
    {
        #region Registrar Trabajador
        public String PersistenciaRegistrarTrabajador(Trabajador objTrabajador)
        {
            SqlParameter[] pa = new SqlParameter[11];
            ConexionSql objCnx = null;
            try
            {
                pa[0] = new SqlParameter("@nombreTrabajador", SqlDbType.VarChar) { Value = objTrabajador.NombreTrabajador };
                pa[1] = new SqlParameter("@apellidoPaternoTrabajador", SqlDbType.VarChar) { Value = objTrabajador.ApellidoPaternoTrabajador };
                pa[2] = new SqlParameter("@apellidoMaternoTrabajador", SqlDbType.VarChar) { Value = objTrabajador.ApellidoMaternoTrabajador };
                pa[3] = new SqlParameter("@descripcionTrabajador", SqlDbType.VarChar) { Value = objTrabajador.DescripcionTrabajador };
                pa[4] = new SqlParameter("@documentoTrabajador", SqlDbType.VarChar) { Value = objTrabajador.DocumentoTrabajador };
                pa[5] = new SqlParameter("@direccionTrabajador", SqlDbType.VarChar) { Value = objTrabajador.DireccionTrabajador };
                pa[6] = new SqlParameter("@telefonoTrabajador", SqlDbType.VarChar) { Value = objTrabajador.TelefonoTrabajador };
                pa[7] = new SqlParameter("@correoTrabajador", SqlDbType.VarChar) { Value = objTrabajador.CorreoTrabajador };
                pa[8] = new SqlParameter("@fechaRegistroTrabajador", SqlDbType.DateTime) { Value = objTrabajador.FechaRegistroTrabajador };
                pa[9] = new SqlParameter("@EstadoTrabajador", SqlDbType.Bit) { Value = objTrabajador.EstadoTrabajador };
                pa[10] = new SqlParameter("@IdEspecializacion", SqlDbType.Int) { Value = objTrabajador.IdEspecializacion };

                objCnx = new ConexionSql("");
                objCnx.EjecutarProcedimiento("sp_RegistrarTrabajador", pa);

                return "OK";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }
        #endregion

        #region Actualizar Tabajador
        public String PersistenciaActualizarTabajador(Trabajador objTrabajador)
        {
            SqlParameter[] pa = new SqlParameter[12];
            ConexionSql objCnx = null;
            try
            {
                pa[0] = new SqlParameter("@IdTrabajador", SqlDbType.Int) { Value = objTrabajador.IdTrabajador };
                pa[1] = new SqlParameter("@nombreTrabajador", SqlDbType.VarChar) { Value = objTrabajador.NombreTrabajador };
                pa[2] = new SqlParameter("@apellidoPaternoTrabajador", SqlDbType.VarChar) { Value = objTrabajador.ApellidoPaternoTrabajador };
                pa[3] = new SqlParameter("@apellidoMaternoTrabajador", SqlDbType.VarChar) { Value = objTrabajador.ApellidoMaternoTrabajador };
                pa[4] = new SqlParameter("@descripcionTrabajador", SqlDbType.VarChar) { Value = objTrabajador.DescripcionTrabajador };
                pa[5] = new SqlParameter("@documentoTrabajador", SqlDbType.VarChar) { Value = objTrabajador.DocumentoTrabajador };
                pa[6] = new SqlParameter("@direccionTrabajador", SqlDbType.VarChar) { Value = objTrabajador.DireccionTrabajador };
                pa[7] = new SqlParameter("@telefonoTrabajador", SqlDbType.VarChar) { Value = objTrabajador.TelefonoTrabajador };
                pa[8] = new SqlParameter("@correoTrabajador", SqlDbType.VarChar) { Value = objTrabajador.CorreoTrabajador };
                pa[9] = new SqlParameter("@fechaRegistroTrabajador", SqlDbType.DateTime) { Value = objTrabajador.FechaRegistroTrabajador };
                pa[10] = new SqlParameter("@EstadoTrabajador", SqlDbType.Bit) { Value = objTrabajador.EstadoTrabajador };
                pa[11] = new SqlParameter("@IdEspecializacion", SqlDbType.Int) { Value = objTrabajador.IdEspecializacion };

                objCnx = new ConexionSql("");
                objCnx.EjecutarProcedimiento("sp_ActualizarTrabajador", pa);

                return "OK";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }
        #endregion

        #region Buscar Trabajador
        public DataTable PersistenciaBuscarTrabajador(Boolean habilitarFechas, DateTime fechaInicial, DateTime fechaFinal, String documentoTrabajador, Int32 numPagina)
        {
            SqlParameter[] pa = new SqlParameter[5];
            ConexionSql objCnx = null;
            DataTable dtTrabajador;

            try
            {
                pa[0] = new SqlParameter("@peHabilitarFechas", SqlDbType.Bit) { Value = habilitarFechas };
                pa[1] = new SqlParameter("@peFechaInicial", SqlDbType.Date) { Value = fechaInicial };
                pa[2] = new SqlParameter("@peFechaFinal", SqlDbType.Date) { Value = fechaFinal };
                pa[3] = new SqlParameter("@documentoTrabajador", SqlDbType.VarChar) { Value = documentoTrabajador };
                pa[4] = new SqlParameter("@peNumPagina", SqlDbType.Int) { Value = numPagina };

                objCnx = new ConexionSql("");
                dtTrabajador = objCnx.EjecutarProcedimientoDT("sp_BuscarTrabajador", pa);
                return dtTrabajador;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtTrabajador = null;
            }
        }
        #endregion

        #region Eliminar Trabajador
        public void PersistenciaEliminarTrabajador(Int32 IdTrabajador)
        {
            SqlParameter[] pa = new SqlParameter[1];
            ConexionSql objCnx = null;
            try
            {
                pa[0] = new SqlParameter("@IdTrabajador", SqlDbType.Int) { Value = IdTrabajador };
                objCnx = new ConexionSql("");
                objCnx.EjecutarProcedimiento("sp_EliminarTrabajador", pa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
            }
        }
        #endregion

        #region Llenar ComboBox Trabajador
        public List<Trabajador> PersistenciaLlenarComboBoxTrabajador(Int32 idTrabajador, String nombreTrabajador, Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[0];
            ConexionSql objCnx = null;
            DataTable dtTrabajador = new DataTable();

            try
            {
                objCnx = new ConexionSql("");
                dtTrabajador = objCnx.EjecutarProcedimientoDT("sp_ListarTrabajador", pa);

                List<Trabajador> lstTrabajador = new List<Trabajador>();

                lstTrabajador.Add(new Trabajador(
                     0,
                    buscar ? "Todos" : "Seleccione Trabajador",
                    "",
                    "",
                    ""
                ));


                foreach (DataRow drTrabajador in dtTrabajador.Rows)
                {
                    lstTrabajador.Add(new Trabajador(
                        Convert.ToInt32(drTrabajador["IdTrabajador"]),
                        Convert.ToString(drTrabajador["nombreTrabajador"]),
                        Convert.ToString(drTrabajador["apellidoPaternoTrabajador"]),
                        Convert.ToString(drTrabajador["apellidoMaternoTrabajador"]),
                        Convert.ToString(drTrabajador["nombreEspecializacion"])
                    ));
                }

                return lstTrabajador;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }
        #endregion

        #region  Verificar Contrato Activo
        public DataTable PersistenciaVerificarContratoLaboralActivo(Int32 IdTrabajador)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtContratoLaboralActivo = new DataTable(); // Crear un DataTable para almacenar el resultado
            ConexionSql objCnx = null;

            try
            {
                pa[0] = new SqlParameter("@IdTrabajador", SqlDbType.Int) { Value = IdTrabajador };
                objCnx = new ConexionSql("");

                // Llamar al procedimiento y llenar el DataTable
                dtContratoLaboralActivo = objCnx.EjecutarProcedimientoDT("sp_VerificarContratoLaboralActivo", pa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
            }

            return dtContratoLaboralActivo;
        }

        #endregion

    }
}
