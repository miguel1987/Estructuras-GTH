using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinesEntities;
using DataAccessLayer;

namespace BussinesLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad SEDE
    /// </summary>
    public class BL_SEDE
    {
        /// <summary>
        ///  Devuelve los datos de todas las SEDES.
        /// </summary>
        /// <returns> List de BE_SEDE con los objetos de la entidad, que a su vez representan la tabla SEDES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_SEDE> SeleccionarSede()
        {
            return new DA_SEDE().SeleccionarSede();
        }
        /// <summary>
        /// Devuelve los datos de una sede específica
        /// </summary>
        /// <param name="sede_id">Id del la Sede al cual se desea consultar</param>
        /// <returns> BE_SEDE con todos sus atributos de la entidad, que a su vez representan la tabla EMPRESAS de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_SEDE> SeleccionarSedePorId(Guid sede_id)
        {
            return new DA_SEDE().SeleccionarSedePorId(sede_id);
        }
        /// <summary>
        /// Inserta los datos de una Sede
        /// </summary>
        /// <param name="oBE_SEDE">Entidad BE_SEDE, que representa la tabla SEDES, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean InsertarSede(BE_SEDE oBE_SEDE)
        {
            return new DA_SEDE().InsertarSede(oBE_SEDE);
        }
        /// <summary>
        /// Actualiza los datos de una Sede
        /// </summary>
        /// <param name="oBE_SEDE">Entidad BE_EMPRESA, que representa la tabla EMPRESAS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarSede(BE_SEDE oBE_SEDE)
        {
            return new DA_SEDE().ActualizarSede(oBE_SEDE);
        }
        /// <summary>
        /// Elimina los dato de una sede
        /// </summary>
        /// <param name="sede_id">Id del la sede que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarSede(Guid sede_id)
        {
            return new DA_SEDE().EliminarSede(sede_id);
        }
    }
}
