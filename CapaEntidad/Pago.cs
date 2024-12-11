using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pago
    {
        int idPago, idContratoPago;
        string metodoPago;
        decimal montoTotalPago;
        private DateTime fechaPago;

        bool estadoPago;
        private List<DetallePago> detallesPago = new List<DetallePago>();

        public int IdPago { get => idPago; set => idPago = value; }

        public decimal MontoTotalPago { get => montoTotalPago; set => montoTotalPago = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
        public List<DetallePago> DetallesPago { get => detallesPago; set => detallesPago = value; }
        public int IdContratoPago { get => idContratoPago; set => idContratoPago = value; }
        public bool EstadoPago { get => estadoPago; set => estadoPago = value; }
        public string XmlDetalles { get; set; }
        public string MetodoPago { get => metodoPago; set => metodoPago = value; }

        public Pago()
        {

        }

    }
}
