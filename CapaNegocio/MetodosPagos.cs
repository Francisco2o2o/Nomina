using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class MetodosPagos
    {
        public decimal CalcularDeduccionSeguros(List<decimal> salarios, int tipoCondicion)
        {
            decimal totalSeguroSalud = 0m;

            foreach (var salarioBase in salarios)
            {
                if (tipoCondicion == 1)
                {
                    totalSeguroSalud += salarioBase * 0.09m;
                }
                else if (tipoCondicion == 2)
                {
                    totalSeguroSalud += salarioBase * 0.01m;
                }
                else
                {
                    totalSeguroSalud += salarioBase * 0.015m;
                }
            }
            return totalSeguroSalud;
        }

        public decimal CalcularDeduccionesTotalesSeguros(decimal SeguroSalud, decimal SeguroVida, decimal SeguroAccidentes)
        {
            decimal totalDeduccionesSeguroSalud = 0m;

            totalDeduccionesSeguroSalud = SeguroSalud + SeguroVida + SeguroAccidentes;

            return totalDeduccionesSeguroSalud;
        }

        public decimal CalcularAFP(List<decimal> salarios)
        {
            decimal TotalAFP = 0m;

            foreach (var salarioBase in salarios)
            {

                TotalAFP += salarioBase * 0.1m;
            }
            return TotalAFP;
        }

        public decimal CalcularDeduccionImpuestos(List<decimal> salarios)
        {
            decimal TotalDeduccionImpuestos = 0m;

            foreach (var salarioBase in salarios)
            {

                TotalDeduccionImpuestos += salarioBase * 0.08m;
            }
            return TotalDeduccionImpuestos;
        }

        public decimal CalcularDescuentosTotales(decimal DeduccionesSeguros, decimal AFP, decimal DeducciónImpuestos)
        {
            decimal totalDescuentosTotales = 0m;

            totalDescuentosTotales = DeduccionesSeguros + AFP + DeducciónImpuestos;

            return totalDescuentosTotales;
        }

        public decimal CalcularMontoTotalPago(List<decimal> salarios)
        {
            decimal TotalDeduccionImpuestos = 0m;

            foreach (var salarioBase in salarios)
            {

                TotalDeduccionImpuestos += salarioBase ;
            }
            return TotalDeduccionImpuestos;
        }
    }
}
