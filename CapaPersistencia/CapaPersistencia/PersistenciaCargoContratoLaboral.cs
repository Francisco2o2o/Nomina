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
    public class PersistenciaCargoContratoLaboral
    {
        #region Llenar ComboBox Cargo
        public List<CargoContratoLaboral> PersistenciaLlenarComboBoxCargo(Int32 idCargo, String nombreCargo, Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[0];
            ConexionSql objCnx = null;
            DataTable dtCargo = new DataTable();

            try
            {
                objCnx = new ConexionSql("");
                dtCargo = objCnx.EjecutarProcedimientoDT("sp_ListarCargoContratoLaboral", pa);

                List<CargoContratoLaboral> lstCargo = new List<CargoContratoLaboral>();
                lstCargo.Add(new CargoContratoLaboral(
                    0,
                    Convert.ToString(buscar ? "Todos" : "Selecc. Cargo")
                    ));

                foreach (DataRow drMenu in dtCargo.Rows)
                {
                    lstCargo.Add(new CargoContratoLaboral(

                        Convert.ToInt32(drMenu["IdCargoContratoLaboral"]),
                        Convert.ToString(drMenu["nombreCargoContratoLaboral"])
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
