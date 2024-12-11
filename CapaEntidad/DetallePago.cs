using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetallePago
    {

        int idDetallePago, idConcepto, cantidadDetallePago, idContratoLaboral;

        decimal montoUnitarioDetallePago, montoTotalDetallePago;

        public int IdDetallePago { get => idDetallePago; set => idDetallePago = value; }
        public int IdConcepto { get => idConcepto; set => idConcepto = value; }
        public int CantidadDetallePago { get => cantidadDetallePago; set => cantidadDetallePago = value; }
        public decimal MontoUnitarioDetallePago { get => montoUnitarioDetallePago; set => montoUnitarioDetallePago = value; }
        public decimal MontoTotalDetallePago { get => montoTotalDetallePago; set => montoTotalDetallePago = value; }
        public int IdContratoLaboral { get => idContratoLaboral; set => idContratoLaboral = value; }

        public DetallePago()
        {

        }
    }
}
