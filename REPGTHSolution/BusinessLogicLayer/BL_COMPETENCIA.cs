using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad COMPETENCIAS
    /// </summary>
    public class BL_COMPETENCIA
    {
        /// <summary>
        ///  Devuelve los datos de todas las Competencias
        /// </summary>
        /// <returns> List de BE_CUENTA_MAYOR con los objetos de la entidad, que a su vez representan la tabla CUENTAS MAYORES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_COMPETENCIA> SeleccionarCompetencias()
        {
            return new DA_COMPETENCIA().SeleccionarCompetencias();
        }

        /// <summary>
        /// Ingresa una nueva Competencia
        /// </summary>
        /// <param name="oBE_COMPETENCIA">Objeto BE_CUENTA_MAYOR con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean InsertarCompetencia(BE_COMPETENCIA oBE_COMPETENCIA)
        {
            return new DA_COMPETENCIA().InsertarCompetencia(oBE_COMPETENCIA);
        }

        /// <summary>
        /// Actualiza una Cuenta Mayor
        /// </summary>
        /// <param name="oBE_CUENTA_MAYOR">Objeto BE_CUENTA_MAYOR con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarCompetencia(BE_COMPETENCIA oBE_COMPETENCIA)
        {
            return new DA_COMPETENCIA().ActualizarCompetencia(oBE_COMPETENCIA);
        }

        /// <summary>
        /// Eliminar una Competencia 
        /// </summary>
        /// <param name="competencia_id">Codigo de la cuenta mayor que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarCompetencia(Guid competencia_id)
        {
            return new DA_COMPETENCIA().EliminarCompetencia(competencia_id);
        }
    }
}
