using CapaEntidad;
using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioTipoContratoLaboral
    {
        #region Llenar ComboBox Tipo Contrato Laboral
        public List<TipoContratoLaboral> NegocioLlenarComboBoxTipoContratoLaboral(Int32 idTipoContratoLaboral, String nombreTipoContratoLaboral, Boolean buscar)
        {
            PersistenciaTipoContratoLaboral objPersistenciaTipoContratoLaboral = new PersistenciaTipoContratoLaboral();
            try
            {
                return objPersistenciaTipoContratoLaboral.PersistenciaLlenarComboBoxTipoContratoLaboral(idTipoContratoLaboral, nombreTipoContratoLaboral, buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
