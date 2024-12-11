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
    public class PersistenciaTipoContratoLaboral
    {
        #region Llenar ComboBox Tipo Contrato Laboral
        public List<TipoContratoLaboral> PersistenciaLlenarComboBoxTipoContratoLaboral(Int32 idTipoContratoLaboral, String nombreTipoContratoLaboral, Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[0];
            ConexionSql objCnx = null;
            DataTable dtTipoContratoLaboral = new DataTable();

            try
            {
                objCnx = new ConexionSql("");
                dtTipoContratoLaboral = objCnx.EjecutarProcedimientoDT("sp_ListarTipoContratoLaboral", pa);

                List<TipoContratoLaboral> lstCargo = new List<TipoContratoLaboral>();
                lstCargo.Add(new TipoContratoLaboral(
                    0,
                    Convert.ToString(buscar ? "Todos" : "Selecc. Tipo Contrato"),
                    0
                    ));

                foreach (DataRow drMenu in dtTipoContratoLaboral.Rows)
                {
                    lstCargo.Add(new TipoContratoLaboral(

                        Convert.ToInt32(drMenu["IdTipoContratoLaboral"]),
                        Convert.ToString(drMenu["nombreTipoContratoLaboral"]),
                        Convert.ToDecimal(drMenu["salarioBaseTipoContratoLaboral"])
                                                ));
                }
                return lstCargo;
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
    }
}
