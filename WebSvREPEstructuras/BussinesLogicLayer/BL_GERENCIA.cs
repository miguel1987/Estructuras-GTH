using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinesEntities;
using DataAccessLayer;
namespace BussinesLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad GERENCIA
    /// </summary>
    public class BL_GERENCIA
    {
        /// <summary>
        ///  Devuelve los datos de todas las GERENCIAS.
        /// </summary>
        /// <returns> List de BE_GERENCIA con los objetos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public static  List<BE_GERENCIA> SeleccionarGerencia()
        {
            return new DA_GERENCIA().SeleccionarGerencia();
        }      

        /// <summary>
        /// Devuelve los datos de todas las GERENCIAS de una EMPRESA
        /// </summary>
        /// <param name="empresa_id">Codigo del la Empresa de la cual se desea consultar sus gerencias</param>
        /// <returns> BE_GERENCIA con todos sus atributos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public static List<BE_GERENCIA> SeleccionarGerenciaPorEmpresa(Guid empresa_id)
        {
            return new DA_GERENCIA().SeleccionarGerenciaPorEmpresa(empresa_id);
        }

         /// <summary>
        /// Devuelve los datos de una gerencia específica
        /// </summary>
        /// <param name="gerencia_id">Codigo del la Gerencia al cual se desea consultar</param>
        /// <returns> BE_GERENCIA con todos sus atributos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public static List<BE_GERENCIA> SeleccionarGerenciaPorId(Guid gerencia_id)
        {
            return new DA_GERENCIA().SeleccionarGerenciaPorId(gerencia_id);
        }
        /// <summary>
        /// Inserta los datos de una Gerencia
        /// </summary>
        /// <param name="oBE_GERENCIA">Entidad BE_GERENCIA, que representa la tabla GERENCIA, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean InsertarGerencia(BE_GERENCIA oBE_GERENCIA)
        {
            return new DA_GERENCIA().InsertarGerencia(oBE_GERENCIA);
        }
        
        /// <summary>
        /// Actualiza los datos de una Gerencia
        /// </summary>
        /// <param name="oBE_GERENCIA">Entidad BE_GERENCIA, que representa la tabla GERENCIA, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarGerencia(BE_GERENCIA oBE_GERENCIA)
        {
            return new DA_GERENCIA().ActualizarGerencia(oBE_GERENCIA);
        }
        
        /// <summary>
        /// Elimina los dato de una gerencia
        /// </summary>
        /// <param name="gerencia_id">Codigo del la Gerencia al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarGerencia(Guid gerencia_id)
        {
            return new DA_GERENCIA().EliminarGerencia(gerencia_id);
        }
    }
}