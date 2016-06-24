using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad PARAMETROS_SISTEMA
    /// </summary>
    public class BL_PARAMETRO
    {
        /// <summary>
        ///  Devuelve los datos de todos las Parámetros del Sistema
        /// </summary>
        /// <returns> List de BE_PARAMETRO con los objetos de la entidad, que a su vez representan la tabla PARAMETROS_SISTEMA de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_PARAMETRO> SeleccionarParametros()
        {
            return new DA_PARAMETRO().SeleccionarParametros();
        }    

        /// <summary>
        /// Actualiza un Parámetro del Sistema
        /// </summary>
        /// <param name="oBE_PARAMETRO">Objeto BE_PARAMETRO con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarParametro(BE_PARAMETRO oBE_PARAMETRO)
        {
            return new DA_PARAMETRO().ActualizarParametro(oBE_PARAMETRO);
        }

        /// <summary>
        /// Eliminar un Parámetro del Sistema
        /// </summary>
        /// <param name="parametro_id">Codigo del parámetro que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarParametro(Guid parametro_id)
        {
            return new DA_PARAMETRO().EliminarParametro(parametro_id);
        }
    }
}
