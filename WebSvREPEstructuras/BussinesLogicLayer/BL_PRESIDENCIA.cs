using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinesEntities;
using DataAccessLayer;

namespace BussinesLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad PRESIDENCIA
    /// </summary>
    public class BL_PRESIDENCIA
    {
        /// <summary>
        ///  Devuelve los datos de todas las PRESIDENCIAS.
        /// </summary>
        /// <returns> List de BE_PRESIDENCIA con los objetos de la entidad, que a su vez representan la tabla PRESIDENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public static List<BE_PRESIDENCIA> SeleccionarPresidencia()
        {
            return new DA_PRESIDENCIA().SeleccionarPresidencia();
        }

        /// <summary>
        /// Devuelve los datos de una PRESIDENCIA por Id
        /// </summary>
        /// <param name="empresa_id">Codigo del la Presidencia que se desea consultar</param>
        /// <returns> BE_PRESIDENCIA con todos sus atributos de la entidad, que a su vez representan la tabla PRESIDENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public static List<BE_PRESIDENCIA> SeleccionarPresidenciaPorEmpresa(Guid empresa_id)
        {
            return new DA_PRESIDENCIA().SeleccionarPresidenciaPorEmpresa(empresa_id);
        }

        /// <summary>
        /// Devuelve los datos de una PRESIDENCIA por Id
        /// </summary>
        /// <param name="presidencia_id">Codigo del la Presidencia que se desea consultar</param>
        /// <returns> BE_GERENCIA con todos sus atributos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public static List<BE_PRESIDENCIA> SeleccionarPresidenciaPorId(Guid presidencia_id)
        {
            return new DA_PRESIDENCIA().SeleccionarPresidenciaPorId(presidencia_id);
        }
        /// <summary>
        /// Inserta los datos de una Presidencia
        /// </summary>
        /// <param name="oBE_PRESIDENCIA">Entidad BE_PRESIDENCIA, que representa la tabla PRESIDENCIA, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean InsertarPresidencia(BE_PRESIDENCIA oBE_PRESIDENCIA)
        {
            return new DA_PRESIDENCIA().InsertarPresidencia(oBE_PRESIDENCIA);
        }

        /// <summary>
        /// Actualiza los datos de una Gerencia
        /// </summary>
        /// <param name="oBE_GEoBE_PRESIDENCIARENCIA">Entidad BE_PRESIDENCIA, que representa la tabla PRESIDENCIAS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarPresidencia(BE_PRESIDENCIA oBE_PRESIDENCIA)
        {
            return new DA_PRESIDENCIA().ActualizarPresidencia(oBE_PRESIDENCIA);
        }

        /// <summary>
        /// Elimina los dato de una gerencia
        /// </summary>
        /// <param name="gerencia_id">Codigo del la Gerencia al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarPresidencia(Guid presidencia_id)
        {
            return new DA_PRESIDENCIA().EliminarPresidencia(presidencia_id);
        }
    }
}
