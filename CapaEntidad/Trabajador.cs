using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Trabajador
    {
        int idTrabajador, idEspecializacion;
        string nombreTrabajador, apellidoPaternoTrabajador, apellidoMaternoTrabajador, documentoTrabajador, direccionTrabajador, telefonoTrabajador, correoTrabajador, descripcionTrabajador;
        DateTime fechaRegistroTrabajador;
        Boolean estadoTrabajador;

       
        public int IdTrabajador { get => idTrabajador; set => idTrabajador = value; }
        public string NombreTrabajador { get => nombreTrabajador; set => nombreTrabajador = value; }
        public string ApellidoPaternoTrabajador { get => apellidoPaternoTrabajador; set => apellidoPaternoTrabajador = value; }
        public string ApellidoMaternoTrabajador { get => apellidoMaternoTrabajador; set => apellidoMaternoTrabajador = value; }
        public string DocumentoTrabajador { get => documentoTrabajador; set => documentoTrabajador = value; }
        public string DireccionTrabajador { get => direccionTrabajador; set => direccionTrabajador = value; }
        public string TelefonoTrabajador { get => telefonoTrabajador; set => telefonoTrabajador = value; }
        public string CorreoTrabajador { get => correoTrabajador; set => correoTrabajador = value; }
        public string DescripcionTrabajador { get => descripcionTrabajador; set => descripcionTrabajador = value; }
        public DateTime FechaRegistroTrabajador { get => fechaRegistroTrabajador; set => fechaRegistroTrabajador = value; }
        public bool EstadoTrabajador { get => estadoTrabajador; set => estadoTrabajador = value; }
        public int IdEspecializacion { get => idEspecializacion; set => idEspecializacion = value; }


        public string NombreCompletoTrabajador
        {
            get
            {
                return $"{NombreTrabajador} {ApellidoPaternoTrabajador} {ApellidoMaternoTrabajador}";
            }
        }

        public Trabajador(int idTrabajador, string nombreTrabajador, string apellidoPaternoTrabajador, string apellidoMaternoTrabajador,string nombreEspecializacion)
        {
            this.IdTrabajador = idTrabajador;
            this.NombreTrabajador = nombreTrabajador;
            this.ApellidoPaternoTrabajador = apellidoPaternoTrabajador;
            this.ApellidoMaternoTrabajador = apellidoMaternoTrabajador;
            this.NombreEspecializacion = nombreEspecializacion;
        }

        public Especializacion Especializacion { get; set; }
        public string NombreEspecializacion { get; set; }
        public override string ToString()
        {
            return $"{Especializacion?.NombreEspecializacion}";
        }
        public Trabajador()
        {
            Especializacion = new Especializacion();
        }

    }
}