using CapaEntidad;
using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioConceptoPago
    {
        #region Llenar ComboBox ConceptoPago
        public List<ConceptoPago> NegocioLlenarComboBoxConceptoPago(Int32 idConceptoPago, String nombreConceptoPago, Boolean buscar)
        {
            PersistenciaConceptoPago objPersistenciaConceptoPago = new PersistenciaConceptoPago();
            try
            {
                return objPersistenciaConceptoPago.PersistenciaLlenarComboBoxConceptoPago(idConceptoPago, nombreConceptoPago, buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
