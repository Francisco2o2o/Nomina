using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ConceptoPago
    {
        int idConceptoPago, tipoConceptoPago;
        string nombreConceptoPago;
        decimal montoConceptoPago;

        public int IdConceptoPago { get => idConceptoPago; set => idConceptoPago = value; }
        public int TipoConceptoPago { get => tipoConceptoPago; set => tipoConceptoPago = value; }
        public string NombreConceptoPago { get => nombreConceptoPago; set => nombreConceptoPago = value; }
        public decimal MontoConceptoPago { get => montoConceptoPago; set => montoConceptoPago = value; }

        public ConceptoPago()
        {

        }

        public ConceptoPago(int idConceptoPago, string nombreConceptoPago, int tipoConceptoPago, decimal montoConceptoPago)
        {
            this.IdConceptoPago = idConceptoPago;
            this.NombreConceptoPago = nombreConceptoPago;
            this.TipoConceptoPago = tipoConceptoPago;
            this.MontoConceptoPago = montoConceptoPago;
        }


    }
}
