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
    public class PersistenciaConceptoPago
    {
        #region Llenar ComboBox ConceptoPago
        public List<ConceptoPago> PersistenciaLlenarComboBoxConceptoPago(Int32 idConceptoPago, String nombreConceptoPago, Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[0];
            ConexionSql objCnx = null;
            DataTable dtConceptoPago = new DataTable();

            try
            {
                objCnx = new ConexionSql("");
                dtConceptoPago = objCnx.EjecutarProcedimientoDT("sp_ListarConceptoPago", pa);

                List<ConceptoPago> lstConceptoPago = new List<ConceptoPago>();

                lstConceptoPago.Add(new ConceptoPago(
                     0,
                    buscar ? "Todos" : "Seleccione Trabajador",
                    0,
                    0
                ));


                foreach (DataRow drConceptoPago in dtConceptoPago.Rows)
                {
                    lstConceptoPago.Add(new ConceptoPago(
                        Convert.ToInt32(drConceptoPago["IdConceptoPago"]),
                        Convert.ToString(drConceptoPago["nombreConceptoPago"]),
                        Convert.ToInt32(drConceptoPago["tipoConceptoPago"]),
                        Convert.ToDecimal(drConceptoPago["montoConceptoPago"])
                    ));
                }

                return lstConceptoPago;
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
