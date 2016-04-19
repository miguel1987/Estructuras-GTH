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
    }
}
