using CapaEntidad;
using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioEspecializacion
    {
        #region Llenar ComboBox Especializacion
        public List<Especializacion> NegocioLlenarComboBoxEspecializacion(Int32 idEspecializacion, String nombreEspecializacion, Boolean buscar)
        {
            PersistenciaEspecializacion objPersistenciaEspecializacion = new PersistenciaEspecializacion();
            try
            {
                return objPersistenciaEspecializacion.PersistenciaLlenarComboBoxEspecializacion(idEspecializacion, nombreEspecializacion, buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
