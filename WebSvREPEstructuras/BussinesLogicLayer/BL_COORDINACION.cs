using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BussinesEntities;
using DataAccessLayer;

namespace BussinesLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para la logica de negocio de COORDINACIONES
    /// </summary>
    public class BL_COORDINACION
    {
        /// <summary>
        ///  Devuelve los datos de todas las coordinaciones.
        /// </summary>
        /// <returns> List de BE_COORDINACION con los objetos de la entidad, que a su vez representan la tabla COORDINACIONES de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public static List<BE_COORDINACION> SeleccionarCoordinaciones()
        {
            List<BE_COORDINACION> oCOORDINACION = null;
            BE_AREA oAREA = null;

            oCOORDINACION = new DA_COORDINACION().SeleccionarCoordinaciones();

            if (oCOORDINACION != null)
            {
                foreach (var oBE_COORDINACION_TMP in oCOORDINACION)
                {
                    oAREA = new DA_AREA().SeleccionarAreaPorId(oBE_COORDINACION_TMP.AREA_ID);
                    if (oAREA != null)
                    {
                        oBE_COORDINACION_TMP.oBE_AREA = oAREA;
                    }
                }
            }
            return oCOORDINACION;

        }

        /// <summary>
        ///  Devuelve los datos de todas las coordinaciones de un área.
        /// </summary>
        /// <returns> List de BE_COORDINACION con los objetos de la entidad, que a su vez representan la tabla COORDINACIONES de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public static List<BE_COORDINACION> SeleccionarCoordinacionesPorArea(Guid area_id)
        {
            List<BE_COORDINACION> oCOORDINACION = null;
            BE_AREA oAREA = null;

            oCOORDINACION = new DA_COORDINACION().SeleccionarCoordinacionPorArea(area_id);

            if (oCOORDINACION != null)
            {
                foreach (var oBE_COORDINACION_TMP in oCOORDINACION)
                {
                    oAREA = new DA_AREA().SeleccionarAreaPorId(oBE_COORDINACION_TMP.AREA_ID);
                    if (oAREA != null)
                    {
                        oBE_COORDINACION_TMP.oBE_AREA = oAREA;
                    }
                }
            }
            return oCOORDINACION;

        }

        /// <summary>
        ///  Devuelve los datos de todas las coordinaciones de un área.
        /// </summary>
        /// <returns> Objeto BE_COORDINACION, que a su vez representan un registro de la tabla COORDINACIONES de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public static BE_COORDINACION SeleccionarCoordinacionPorId(Guid coordinacion_id)
        {
            BE_COORDINACION oCOORDINACION = null;

            oCOORDINACION = new DA_COORDINACION().SeleccionarCoordinacionPorId(coordinacion_id);
           
            return oCOORDINACION;

        }

        /// <summary>
        /// Inserta los datos de una coordinación
        /// </summary>
        /// <param name="oBE_COORDINACION">Entidad BE_COORDINACION, que representa la tabla COORDINACION, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean InsertarCoordinacion(BE_COORDINACION oBE_COORDINACION)
        {
            return new DA_COORDINACION().InsertarCoordinacion(oBE_COORDINACION);
        }
        /// <summary>
        /// Actualiza los datos de una Coordinación
        /// </summary>
        /// <param name="oBE_COORDINACION">Entidad BE_COORDINACION, que representa la tabla COORDINACION, con todos sus atributos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarCoordinacion(BE_COORDINACION oBE_COORDINACION)
        {
            return new DA_COORDINACION().ActualizarCoordinacion(oBE_COORDINACION);
        }

        /// <summary>
        /// Elimina un Coordinacion es especifica
        /// </summary>
        /// <param name="coordinacion_id">Codigo de la coordinacion al cual se desea Eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarCoordinacion(Guid coordinacion_id)
        {
            return new DA_COORDINACION().EliminarCoordinacion(coordinacion_id);
        }
    }
}
