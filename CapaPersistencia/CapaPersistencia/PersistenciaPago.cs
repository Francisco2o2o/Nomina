using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaConexion;

namespace CapaPersistencia
{
    public class PersistenciaPago
    {
        #region Registrar Pago
        public String PersistenciaRegistrarPago(Pago objPago, ContratoPago objContratoPago)
        {
            SqlParameter[] pa = new SqlParameter[6];
            ConexionSql objCnx = null;
            try
            {
                pa[0] = new SqlParameter("@FechaPago", SqlDbType.DateTime) { Value = objPago.FechaPago };
                pa[1] = new SqlParameter("@montoTotalPago", SqlDbType.Decimal) { Value = objPago.MontoTotalPago };
                pa[2] = new SqlParameter("@estadoPago", SqlDbType.Bit) { Value = objPago.EstadoPago };
                pa[3] = new SqlParameter("@MetodoPago", SqlDbType.VarChar) { Value = objPago.MetodoPago };

                pa[4] = new SqlParameter("@IdPeriodo", SqlDbType.Int) { Value = objContratoPago.IdPeriodo };

                pa[5] = new SqlParameter("@DetallePagoXml", SqlDbType.Xml) { Value = objPago.XmlDetalles };

                objCnx = new ConexionSql("");
                objCnx.EjecutarProcedimiento("sp_RegistrarPago", pa);

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

    }
    #endregion

}

