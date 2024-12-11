using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ContratoPago
    {
        int idContratoPago, idPeriodo;
        decimal montoTotalContratoPago;

        public int IdContratoPago { get => idContratoPago; set => idContratoPago = value; }
        public int IdPeriodo { get => idPeriodo; set => idPeriodo = value; }
        public decimal MontoTotalContratoPago { get => montoTotalContratoPago; set => montoTotalContratoPago = value; }
    }
}
