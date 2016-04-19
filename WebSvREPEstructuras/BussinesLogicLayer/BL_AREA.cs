using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using BussinesEntities;
using DataAccessLayer;

namespace BussinesLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para la logica de negocio de AREA
    /// </summary>
    public class BL_AREA
    {
        /// <summary>
        ///  Devuelve los datos de todas las áreas.
        /// </summary>
        /// <returns> List de BE_AREA con los objetos de la entidad, que a su vez representan la tabla AREAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public static List<BE_AREA> SeleccionarAreas()
        {
            List<BE_AREA> oAREA = null;
            List<BE_GERENCIA> oGERENCIA = null;

            oAREA = new DA_AREA().SeleccionarAreas();

            if (oAREA != null)
            {
                foreach (var oBE_AREA_TMP in oAREA)
                {
                    oGERENCIA = new DA_GERENCIA().SeleccionarGerenciaPorId(oBE_AREA_TMP.GERENCIA_ID);
                    if (oGERENCIA != null)
                    {
                        oBE_AREA_TMP.oBE_GERENCIA = oGERENCIA[0];
                    }
                }
            }
            return oAREA;

        }
        /// <summary>
        /// Devuelve los datos de un área específica.
        /// </summary>
        /// <param name="area_id">Codigo del area al cual se desea consultar</param>
        /// <returns>BE_AREA, entidad que representa la tabla AREAS, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public static BE_AREA SeleccionarAreaPorId(Guid area_id)
        {
            return new DA_AREA().SeleccionarAreaPorId(area_id);
        }
        /// <summary>
        /// Devuelve los datos de la gerencia de un área específica
        /// </summary>
        /// <param name="gerencia_id">Codigo de la gerencia  al cual se desea consultar</param>
        /// <returns>BE_AREA, entidad que representa la tabla GERENCIAS, con todas sus atributos.Ademas, esa entidad trae tambien un atributo que se llama oBE_GERENCIA, donde se obtiene todos los datos de la entidad GERENCIA En caso no haiga datos devuelve nothing</returns>
        public static List<BE_AREA> SeleccionarAreaPorGerencia(Guid gerencia_id)
        {
            return new DA_AREA().SeleccionarAreaPorGerencia(gerencia_id);
        }
        /// <summary>
        /// Inserta los datos de un área
        /// </summary>
        /// <param name="oBE_AREA">Entidad BE_AREA, que representa la tabla AREA, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean InsertarArea(BE_AREA oBE_AREA)
        {
            return new DA_AREA().InsertarArea(oBE_AREA);
        }
        /// <summary>
        /// Actualiza los datos de una Area
        /// </summary>
        /// <param name="oBE_AREA">Entidad BE_AREA, que representa la tabla AREA, con todos sus atributos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarArea(BE_AREA oBE_AREA)
        {
            return new DA_AREA().ActualizarArea(oBE_AREA);
        }

        /// <summary>
        /// Elimina un Area es especifica
        /// </summary>
        /// <param name="area_id">Codigo del area al cual se desea Eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarArea(Guid area_id)
        {
            return new DA_AREA().EliminarArea(area_id);
        }
    }
}
