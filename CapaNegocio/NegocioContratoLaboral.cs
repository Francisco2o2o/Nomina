using CapaEntidad;
using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioContratoLaboral
    {

        #region Registrar  ContratoLaboral
        public String NegocioRegistrarContratoLaboral(ContratoLaboral objContratoLaboral)
        {

            PersistenciaContratoLaboral objPersistenciaContratoLaboral = new PersistenciaContratoLaboral();
            try
            {
                return objPersistenciaContratoLaboral.PersistenciaRegistrarContratoLaboral(objContratoLaboral);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Actualizar ContratoLaboral
        public String NegocioActuailzarContratoLaboral(ContratoLaboral objContratoLaboral)
        {

            PersistenciaContratoLaboral objPersistenciaContratoLaboral = new PersistenciaContratoLaboral();
            try
            {
                return objPersistenciaContratoLaboral.PersistenciaActualizarContratoLaboral(objContratoLaboral);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Buscar Contrato Laboral
        public DataTable NegocioBuscarContratoLaboral(Boolean habilitarFechas, DateTime fechaInicial, DateTime fechaFinal, String documentoTrabajador, Int32 numPagina)
        {
            PersistenciaContratoLaboral objPersistenciaContratoLaboral = new PersistenciaContratoLaboral();

            try
            {
                return objPersistenciaContratoLaboral.PersistenciaBuscarContratoLaboral(habilitarFechas, fechaInicial, fechaFinal, documentoTrabajador, numPagina);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Eliminar Contrato Laboral
        public void NegocioEliminarContratoLaboral(Int32 IdContratoLaboral)
        {
            PersistenciaContratoLaboral objPersistenciaContratoLaboral = new PersistenciaContratoLaboral();
            try
            {
                objPersistenciaContratoLaboral.PersistenciaEliminarContratoLaboral(IdContratoLaboral);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Listar Contrato Laboral
        public DataTable NegocioListarContratoLaboral(Boolean habilitarFechas, DateTime fechaInicial, DateTime fechaFinal, String documentoTrabajador, Int32 numPagina)
        {
            PersistenciaContratoLaboral objPersistenciaContratoLaboral = new PersistenciaContratoLaboral();

            try
            {
                return objPersistenciaContratoLaboral.PersistenciaListarContratoLaboral(habilitarFechas, fechaInicial, fechaFinal, documentoTrabajador, numPagina);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion



    }
}
