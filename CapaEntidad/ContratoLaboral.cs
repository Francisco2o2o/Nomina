using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ContratoLaboral
    {
        int idContratoLaboral, horasTotalesContratoLaboral, idCargoContratoLaboral, idTipoContratoLaboral, idTrabajador, horasDiariasContratoLaboral;
        DateTime fechaInicioContratoLaboral, fechaFinContratoLaboral, fechaRegistroContratoLaboral;
        decimal salarioContratoLaboral, asignaciónFamiliarContratoLaboral;
        string descripcionContratoLaboral;
        bool estadoContratoLaboral;

        public int IdContratoLaboral { get => idContratoLaboral; set => idContratoLaboral = value; }
        public int HorasTotalesContratoLaboral { get => horasTotalesContratoLaboral; set => horasTotalesContratoLaboral = value; }
        public int IdCargoContratoLaboral { get => idCargoContratoLaboral; set => idCargoContratoLaboral = value; }
        public int IdTipoContratoLaboral { get => idTipoContratoLaboral; set => idTipoContratoLaboral = value; }
        public int IdTrabajador { get => idTrabajador; set => idTrabajador = value; }
        public int HorasDiariasContratoLaboral { get => horasDiariasContratoLaboral; set => horasDiariasContratoLaboral = value; }
        public DateTime FechaInicioContratoLaboral { get => fechaInicioContratoLaboral; set => fechaInicioContratoLaboral = value; }
        public DateTime FechaFinContratoLaboral { get => fechaFinContratoLaboral; set => fechaFinContratoLaboral = value; }
        public decimal SalarioContratoLaboral { get => salarioContratoLaboral; set => salarioContratoLaboral = value; }
        public string DescripcionContratoLaboral { get => descripcionContratoLaboral; set => descripcionContratoLaboral = value; }
        public bool EstadoContratoLaboral { get => estadoContratoLaboral; set => estadoContratoLaboral = value; }
        public DateTime FechaRegistroContratoLaboral { get => fechaRegistroContratoLaboral; set => fechaRegistroContratoLaboral = value; }
        public decimal AsignaciónFamiliarContratoLaboral { get => asignaciónFamiliarContratoLaboral; set => asignaciónFamiliarContratoLaboral = value; }

        public ContratoLaboral()
        {

        }

      
    }


}
