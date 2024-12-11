using CapaEntidad;
using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public  class NegocioPago
    {
        #region Registrar Pago
        public String NegocioRegistrarPago(Pago objPago, ContratoPago objContratoPago)
        {
            PersistenciaPago objPersistenciaPago = new PersistenciaPago();
            try
            {
                return objPersistenciaPago.PersistenciaRegistrarPago(objPago, objContratoPago);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
