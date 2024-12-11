using CapaEntidad;
using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioCargoContratoLaboral
    {
        #region Llenar ComboBox Cargo
        public List<CargoContratoLaboral> NegocioLlenarComboBoxCargo(Int32 idCargo, String nombreCargo, Boolean buscar)
        {
            PersistenciaCargoContratoLaboral objPersistenciaCargo = new PersistenciaCargoContratoLaboral();
            try
            {
                return objPersistenciaCargo.PersistenciaLlenarComboBoxCargo(idCargo, nombreCargo, buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
