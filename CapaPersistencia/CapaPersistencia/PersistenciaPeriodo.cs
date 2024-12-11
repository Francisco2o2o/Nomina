using CapaConexion;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia
{
    public class PersistenciaPeriodo
    {
        #region Llenar ComboBox Periodo
        public List<Periodo> PersistenciaLlenarComboBoxPeriodo(Int32 idPeriodo, String nombrePeriodo, Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[0];
            ConexionSql objCnx = null;
            DataTable dtPeriodo = new DataTable();

            try
            {
                objCnx = new ConexionSql("");
                dtPeriodo = objCnx.EjecutarProcedimientoDT("sp_ListarPeriodo", pa);

                List<Periodo> lstPeriodo = new List<Periodo>();

                lstPeriodo.Add(new Periodo(
                    0,
                    Convert.ToString(buscar ? "Todos" : "Selecc. Periodo"),
                    DateTime.Now,
                    DateTime.Now.AddMonths(1)

                ));
                foreach (DataRow drMenu in dtPeriodo.Rows)
                {
                    lstPeriodo.Add(new Periodo(
                        Convert.ToInt32(drMenu["IdPeriodo"]),
                        Convert.ToString(drMenu["nombrePeriodo"]),
                        Convert.ToDateTime(drMenu["fechaInicioPeriodo"]),
                        Convert.ToDateTime(drMenu["fechaFinPeriodo"])
                    ));
                }

                return lstPeriodo;
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

        #region Buscar Periodo Pago
        public DataTable PersistenciaBuscarPeriodoPägo()
        {
            SqlParameter[] pa = new SqlParameter[0];
            ConexionSql objCnx = null;
            DataTable dtPeriodoPago;

            try
            {
                objCnx = new ConexionSql("");
                dtPeriodoPago = objCnx.EjecutarProcedimientoDT("sp_BuscarPagosPeriodo", pa);
                return dtPeriodoPago;
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
                dtPeriodoPago = null;
            }
        }
        #endregion
    }
}
