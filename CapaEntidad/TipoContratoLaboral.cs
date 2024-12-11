using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TipoContratoLaboral
    {
        int idTipoContratoLaboral;
        string nombreTipoContratoLaboral;
        DateTime fechaRegistroTipoContratoLaboral;
        decimal salarioBaseTipoContratoLaboral;
        bool estadoTipoContratoLaboral;
        public int IdTipoContratoLaboral { get => idTipoContratoLaboral; set => idTipoContratoLaboral = value; }
        public string NombreTipoContratoLaboral { get => nombreTipoContratoLaboral; set => nombreTipoContratoLaboral = value; }
        public DateTime FechaRegistroTipoContratoLaboral { get => fechaRegistroTipoContratoLaboral; set => fechaRegistroTipoContratoLaboral = value; }
        public decimal SalarioBaseTipoContratoLaboral { get => salarioBaseTipoContratoLaboral; set => salarioBaseTipoContratoLaboral = value; }
        public bool EstadoTipoContratoLaboral { get => estadoTipoContratoLaboral; set => estadoTipoContratoLaboral = value; }

        public TipoContratoLaboral()
        {

        }

        public TipoContratoLaboral(int idTipoContratoLaboral, string nombreTipoContratoLaboral, decimal salarioBaseTipoContratoLaboral)
        {
            this.IdTipoContratoLaboral = idTipoContratoLaboral;
            this.NombreTipoContratoLaboral = nombreTipoContratoLaboral;
            this.SalarioBaseTipoContratoLaboral = salarioBaseTipoContratoLaboral;

        }


    }
}
