using CapaConexion;
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
    public class PersistenciaEspecializacion
    {
        #region Llenar ComboBox Especializacion
        public List<Especializacion> PersistenciaLlenarComboBoxEspecializacion(Int32 idEspecializacion, String nombreEspecializacion, Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[0];
            ConexionSql objCnx = null;
            DataTable dtEspecializacion = new DataTable();

            try
            {
                objCnx = new ConexionSql("");
                dtEspecializacion = objCnx.EjecutarProcedimientoDT("sp_ListarEspecializacion", pa);

                List<Especializacion> lstTipoUsuario = new List<Especializacion>();
                lstTipoUsuario.Add(new Especializacion(
                    0,
                    Convert.ToString(buscar ? "Todos" : "Selecc. Especializacion")
                    ));

                foreach (DataRow drMenu in dtEspecializacion.Rows)
                {
                    lstTipoUsuario.Add(new Especializacion(

                        Convert.ToInt32(drMenu["IdEspecializacion"]),
                        Convert.ToString(drMenu["nombreEspecializacion"])
                                                ));
                }
                return lstTipoUsuario;
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
