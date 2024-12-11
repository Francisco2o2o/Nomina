using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Especializacion
    {
        int idEspecializacion;
        string nombreEspecializacion;
        DateTime fechaCreacionEspecializacion;
        Boolean EstadoEspecializacion;
        public int IdEspecializacion { get => idEspecializacion; set => idEspecializacion = value; }
        public string NombreEspecializacion { get => nombreEspecializacion; set => nombreEspecializacion = value; }
        public DateTime FechaCreacionEspecializacion { get => fechaCreacionEspecializacion; set => fechaCreacionEspecializacion = value; }
        public bool EstadoEspecializacion1 { get => EstadoEspecializacion; set => EstadoEspecializacion = value; }

        public Especializacion()
        {

        }
        public Especializacion(int idEspecializacion, string nombreEspecializacion)
        {
            this.IdEspecializacion = idEspecializacion;
            this.NombreEspecializacion = nombreEspecializacion;
        }

        
    }
}
