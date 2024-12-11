using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CargoContratoLaboral
    {
        int idCargoContratoLaboral;
        string nombreCargoContratoLaboral;
        DateTime fechaRegistroCargoContratoLaboral;
        bool estadoCargoContratoLaboral;

        public int IdCargoContratoLaboral { get => idCargoContratoLaboral; set => idCargoContratoLaboral = value; }
        public string NombreCargoContratoLaboral { get => nombreCargoContratoLaboral; set => nombreCargoContratoLaboral = value; }
        public DateTime FechaRegistroCargoContratoLaboral { get => fechaRegistroCargoContratoLaboral; set => fechaRegistroCargoContratoLaboral = value; }
        public bool EstadoCargoContratoLaboral { get => estadoCargoContratoLaboral; set => estadoCargoContratoLaboral = value; }

        public CargoContratoLaboral()
        {
            
        }
        public CargoContratoLaboral(int idCargoContratoLaboral, string nombreCargoContratoLaboral)
        {
            this.IdCargoContratoLaboral = idCargoContratoLaboral;
            this.NombreCargoContratoLaboral = nombreCargoContratoLaboral;
        }

       
    }
}
