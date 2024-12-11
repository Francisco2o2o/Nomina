using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Periodo
    {
        int idPeriodo;
        string nombrePeriodo;
        DateTime fechaInicioPeriodo, fechaFinPeriodo, fechaRegistroPeriodo;
        bool estadoPeriodo;

        public int IdPeriodo { get => idPeriodo; set => idPeriodo = value; }
        public string NombrePeriodo { get => nombrePeriodo; set => nombrePeriodo = value; }
        public DateTime FechaInicioPeriodo { get => fechaInicioPeriodo; set => fechaInicioPeriodo = value; }
        public DateTime FechaFinPeriodo { get => fechaFinPeriodo; set => fechaFinPeriodo = value; }
        public DateTime FechaRegistroPeriodo { get => fechaRegistroPeriodo; set => fechaRegistroPeriodo = value; }
        public bool EstadoPeriodo { get => estadoPeriodo; set => estadoPeriodo = value; }
        public Periodo()
        {

        }
        public Periodo(int idPeriodo, string nombrePeriodo, DateTime fechaInicioPeriodo, DateTime fechaFinPeriodo)
        {
            IdPeriodo = idPeriodo;
            this.NombrePeriodo = nombrePeriodo;
            this.FechaInicioPeriodo = fechaInicioPeriodo;
            this.FechaFinPeriodo = fechaFinPeriodo;
        }

    }
}
