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
    public class NegocioTrabajador
    {

        #region Registrar Trabajador
        public String NegocioRegistraTrabajador(Trabajador objTrabajador)
        {

            PersistenciaTrabajador objPersistenciaTrabajador = new PersistenciaTrabajador();
            try
            {
                return objPersistenciaTrabajador.PersistenciaRegistrarTrabajador(objTrabajador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Actualizar Trabajador
        public String NegocioActualizarTrabajador(Trabajador objTrabajador)
        {

            PersistenciaTrabajador objPersistenciaTrabajador = new PersistenciaTrabajador();
            try
            {
                return objPersistenciaTrabajador.PersistenciaActualizarTabajador(objTrabajador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Buscar Trabajador
        public DataTable NegocioBuscarTrabajador(Boolean habilitarFechas, DateTime fechaInicial, DateTime fechaFinal, String documentoTrabajador, Int32 numPagina)
        {
            PersistenciaTrabajador objPersistenciaTrabajador = new PersistenciaTrabajador();

            try
            {
                return objPersistenciaTrabajador.PersistenciaBuscarTrabajador(habilitarFechas, fechaInicial, fechaFinal, documentoTrabajador, numPagina);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Eliminar Trabajador
        public void NegocioEliminarTrabajador(Int32 IdTrabajador)
        {
            PersistenciaTrabajador objPersistenciaTrabajador = new PersistenciaTrabajador();
            try
            {
                objPersistenciaTrabajador.PersistenciaEliminarTrabajador(IdTrabajador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Llenar ComboBox Trabajador
        public List<Trabajador> NegocioLlenarComboBoxTrabajador(Int32 idTrabajador, String nombreTrabajador, Boolean buscar)
        {
            PersistenciaTrabajador objPersistenciaTrabajador = new PersistenciaTrabajador();
            try
            {
                return objPersistenciaTrabajador.PersistenciaLlenarComboBoxTrabajador(idTrabajador, nombreTrabajador, buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region  Verificar Contrato Activo
        public DataTable NegocioVerificarContratoLaboralActivo(Int32 IdTrabajador)
        {
            PersistenciaTrabajador objPersistenciaTrabajador = new PersistenciaTrabajador();
            try
            {
                return objPersistenciaTrabajador.PersistenciaVerificarContratoLaboralActivo(IdTrabajador); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
