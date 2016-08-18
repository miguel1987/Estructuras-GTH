using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad COMPETENCIAS TRANSVERSALES
    /// </summary>
    public class BL_COMPETENCIA_TRANSVERSAL
    {
        /// <summary>
        ///  Devuelve los datos de todas las Cuentas Mayores.
        /// </summary>
        /// <returns> List de BE_COMPETENCIA_TRANSVERSAL con los objetos de la entidad, que a su vez representan la tabla COMPETENCIA TRANSVERSAL de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_COMPETENCIA_TRANSVERSAL> SeleccionarCompetenciasTranversales()
        {
            return new DA_COMPETENCIA_TRANSVERSAL().SeleccionarCompetenciasTranversales();
        }

        /// <summary>
        /// Ingresa una nueva Competencia Transversal
        /// </summary>
        /// <param name="oBE_COMPETENCIA_TRANSVERSAL">Objeto BE_COMPETENCIA_TRANSVERSAL con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean InsertarCompetenciaTransversal(BE_COMPETENCIA_TRANSVERSAL oBE_COMPETENCIA_TRASNVERSAL)
        {
            return new DA_COMPETENCIA_TRANSVERSAL().InsertarCompetenciaTransversal(oBE_COMPETENCIA_TRASNVERSAL);
        }

        /// <summary>
        /// Actualiza una Competencia Transversal
        /// </summary>
        /// <param name="oBE_COMPETENCIA_TRANSVERSAL">Objeto BE_COMPETENCIA_TRANSVERSAL con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarCompetenciaTransversal(BE_COMPETENCIA_TRANSVERSAL oBE_COMPETENCIA_TRASNVERSAL)
        {
            return new DA_COMPETENCIA_TRANSVERSAL().ActualizarCompetenciaTransversal(oBE_COMPETENCIA_TRASNVERSAL);
        }

        /// <summary>
        /// Eliminar una Competencia Transversal
        /// </summary>
        /// <param name="competencia_transversal_id">Codigo de la competencia transversal que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarCompetenciaTransversal(Guid competencia_transversal_id)
        {
            return new DA_COMPETENCIA_TRANSVERSAL().EliminarCompetenciaTransversal(competencia_transversal_id);
        }
    }
}
