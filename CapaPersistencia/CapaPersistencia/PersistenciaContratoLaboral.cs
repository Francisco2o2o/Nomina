using CapaConexion;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaPersistencia
{
    public class PersistenciaContratoLaboral
    {
        #region Registrar Contrato Laboral
        public String PersistenciaRegistrarContratoLaboral(ContratoLaboral objContratoLaboral)
        {
            SqlParameter[] pa = new SqlParameter[12];
            ConexionSql objCnx = null;
            try
            {
                pa[0] = new SqlParameter("@fechaInicioContratoLaboral", SqlDbType.Date) { Value = objContratoLaboral.FechaInicioContratoLaboral };
                pa[1] = new SqlParameter("@fechaFinContratoLaboral", SqlDbType.Date) { Value = objContratoLaboral.FechaFinContratoLaboral };
                pa[2] = new SqlParameter("@horasTotalesContratoLaboral", SqlDbType.Int) { Value = objContratoLaboral.HorasTotalesContratoLaboral };
                pa[3] = new SqlParameter("@fechaRegistroContratoLaboral", SqlDbType.DateTime) { Value = objContratoLaboral.FechaRegistroContratoLaboral };
                pa[4] = new SqlParameter("@EstadoContratoLaboral", SqlDbType.Bit) { Value = objContratoLaboral.EstadoContratoLaboral };
                pa[5] = new SqlParameter("@descripcionContratoLaboral", SqlDbType.VarChar) { Value = objContratoLaboral.DescripcionContratoLaboral };
                pa[6] = new SqlParameter("@IdCargoContratoLaboral", SqlDbType.Int) { Value = objContratoLaboral.IdCargoContratoLaboral };
                pa[7] = new SqlParameter("@IdTipoContratoLaboral", SqlDbType.Int) { Value = objContratoLaboral.IdTipoContratoLaboral };
                pa[8] = new SqlParameter("@IdTrabajador", SqlDbType.Int) { Value = objContratoLaboral.IdTrabajador };
                pa[9] = new SqlParameter("@salarioContratoLaboral", SqlDbType.Decimal) { Value = objContratoLaboral.SalarioContratoLaboral };
                pa[10] = new SqlParameter("@horasDiariasContratoLaboral", SqlDbType.Int) { Value = objContratoLaboral.HorasDiariasContratoLaboral };
                pa[11] = new SqlParameter("@AsignaciónFamiliarContratoLaboral", SqlDbType.Decimal) { Value = objContratoLaboral.AsignaciónFamiliarContratoLaboral };

                objCnx = new ConexionSql("");
                objCnx.EjecutarProcedimiento("sp_RegistrarContratoLaboral", pa);

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

        #region Actualizar Contrato Laboral
        public String PersistenciaActualizarContratoLaboral(ContratoLaboral objContratoLaboral)
        {
            SqlParameter[] pa = new SqlParameter[11];
            ConexionSql objCnx = null;
            try
            {
                pa[0] = new SqlParameter("@IdContratoLaboral", SqlDbType.Int) { Value = objContratoLaboral.IdContratoLaboral };
                pa[1] = new SqlParameter("@fechaInicioContratoLaboral", SqlDbType.Date) { Value = objContratoLaboral.FechaInicioContratoLaboral };
                pa[2] = new SqlParameter("@fechaFinContratoLaboral", SqlDbType.Date) { Value = objContratoLaboral.FechaFinContratoLaboral };
                pa[3] = new SqlParameter("@horasTotalesContratoLaboral", SqlDbType.Int) { Value = objContratoLaboral.HorasTotalesContratoLaboral };
                pa[4] = new SqlParameter("@EstadoContratoLaboral", SqlDbType.Bit) { Value = objContratoLaboral.EstadoContratoLaboral };
                pa[5] = new SqlParameter("@descripcionContratoLaboral", SqlDbType.VarChar) { Value = objContratoLaboral.DescripcionContratoLaboral };
                pa[6] = new SqlParameter("@IdCargoContratoLaboral", SqlDbType.Int) { Value = objContratoLaboral.IdCargoContratoLaboral };
                pa[7] = new SqlParameter("@IdTipoContratoLaboral", SqlDbType.Int) { Value = objContratoLaboral.IdTipoContratoLaboral };
                pa[8] = new SqlParameter("@salarioContratoLaboral", SqlDbType.Decimal) { Value = objContratoLaboral.SalarioContratoLaboral };
                pa[9] = new SqlParameter("@horasDiariasContratoLaboral", SqlDbType.Int) { Value = objContratoLaboral.HorasDiariasContratoLaboral };
                pa[10] = new SqlParameter("@AsignaciónFamiliarContratoLaboral", SqlDbType.Decimal) { Value = objContratoLaboral.AsignaciónFamiliarContratoLaboral };

                objCnx = new ConexionSql("");
                objCnx.EjecutarProcedimiento("sp_ActualizarContratoLaboral", pa);

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

        #region Buscar Contrato Laboral
        public DataTable PersistenciaBuscarContratoLaboral(Boolean habilitarFechas, DateTime fechaInicial, DateTime fechaFinal, String documentoTrabajador, Int32 numPagina)
        {
            SqlParameter[] pa = new SqlParameter[5];
            ConexionSql objCnx = null;
            DataTable dtContratoLaboral;

            try
            {
                pa[0] = new SqlParameter("@peHabilitarFechas", SqlDbType.Bit) { Value = habilitarFechas };
                pa[1] = new SqlParameter("@peFechaInicial", SqlDbType.Date) { Value = fechaInicial };
                pa[2] = new SqlParameter("@peFechaFinal", SqlDbType.Date) { Value = fechaFinal };
                pa[3] = new SqlParameter("@documentoTrabajador", SqlDbType.VarChar) { Value = documentoTrabajador };
                pa[4] = new SqlParameter("@peNumPagina", SqlDbType.Int) { Value = numPagina };

                objCnx = new ConexionSql("");
                dtContratoLaboral = objCnx.EjecutarProcedimientoDT("sp_BuscarContratoLaboral", pa);
                return dtContratoLaboral;
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
                dtContratoLaboral = null;
            }
        }
        #endregion

        #region Eliminar Contrato Laboral
        public void PersistenciaEliminarContratoLaboral(Int32 IdContratoLaboral)
        {
            SqlParameter[] pa = new SqlParameter[1];
            ConexionSql objCnx = null;
            try
            {
                pa[0] = new SqlParameter("@IdContratoLaboral", SqlDbType.Int) { Value = IdContratoLaboral };
                objCnx = new ConexionSql("");
                objCnx.EjecutarProcedimiento("sp_EliminarContratoLaboral", pa);
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

        #region Listar Contrato Laboral
        public DataTable PersistenciaListarContratoLaboral(Boolean habilitarFechas, DateTime fechaInicial, DateTime fechaFinal, String documentoTrabajador, Int32 numPagina)
        {
            SqlParameter[] pa = new SqlParameter[5];
            ConexionSql objCnx = null;
            DataTable dtContratoLaboral;

            try
            {
                pa[0] = new SqlParameter("@peHabilitarFechas", SqlDbType.Bit) { Value = habilitarFechas };
                pa[1] = new SqlParameter("@peFechaInicial", SqlDbType.Date) { Value = fechaInicial };
                pa[2] = new SqlParameter("@peFechaFinal", SqlDbType.Date) { Value = fechaFinal };
                pa[3] = new SqlParameter("@documentoTrabajador", SqlDbType.VarChar) { Value = documentoTrabajador };
                pa[4] = new SqlParameter("@peNumPagina", SqlDbType.Int) { Value = numPagina };

                objCnx = new ConexionSql("");
                dtContratoLaboral = objCnx.EjecutarProcedimientoDT("sp_ListarContratoLaboral", pa);
                return dtContratoLaboral;
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
                dtContratoLaboral = null;
            }
        }
        #endregion

    }
}
