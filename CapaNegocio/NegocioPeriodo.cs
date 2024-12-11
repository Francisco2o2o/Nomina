using CapaEntidad;
using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioPeriodo
    {
        #region Llenar ComboBox Periodo
        public List<Periodo> NegocioLlenarComboBoxPeriodo(Int32 idPeriodo, String nombrePeriodo, Boolean buscar)
        {
            PersistenciaPeriodo objPersistenciaPeriodo = new PersistenciaPeriodo();
            try
            {
                return objPersistenciaPeriodo.PersistenciaLlenarComboBoxPeriodo(idPeriodo, nombrePeriodo, buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Buscar Periodo Pago
        public DataTable NegocioBuscarPeriodoPago()
        {
            PersistenciaPeriodo objPersistenciaPeriodo = new PersistenciaPeriodo();
            try
            {
                return objPersistenciaPeriodo.PersistenciaBuscarPeriodoPägo();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
