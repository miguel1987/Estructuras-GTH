using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinesEntities;
using DataAccessLayer;

namespace BussinesLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad GRUPO_ORGANIZACIONAL
    /// </summary>
    public class BL_GRUPO_ORGANIZACIONAL
    {
        /// <summary>
        ///  Devuelve los datos de todas los GRUPOS_ORGANIZACIONALES.
        /// </summary>
        /// <returns> List de BE_GRUPO_ORGANIZACIONAL con los objetos de la entidad, que a su vez representan la tabla GRUPOS_ORGANIZACIONALES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_GRUPO_ORGANIZACIONAL> SeleccionarGruposOrganizacional()
        {
            return new DA_GRUPO_ORGANIZACIONAL().SeleccionarGrupoOrganizacional();
        }
        /// <summary>
        /// Devuelve los datos de un grupo organizacional específico
        /// </summary>
        /// <param name="grupo_organizacional_id">Id del grupo organizacional que se desea consultar</param>
        /// <returns> BE_GRUPO_ORGANIZACIONAL con todos sus atributos de la entidad, que a su vez representan la tabla GRUPOS_ORGANIZACIONALES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_GRUPO_ORGANIZACIONAL> SeleccionarGrupoOrganizacionalPorId(Guid grupo_organizacional_id)
        {
            return new DA_GRUPO_ORGANIZACIONAL().SeleccionarGrupoOrganizacionalPorId(grupo_organizacional_id);
        }
        /// <summary>
        /// Inserta los datos de un Grupo Organizacional
        /// </summary>
        /// <param name="oBE_GRUPO_ORGANIZACIONAL">Entidad BE_GRUPO_ORGANIZACIONAL, que representa la tabla GRUPOS_ORGANIZACIONALES, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean InsertarGrupoOrganizacional(BE_GRUPO_ORGANIZACIONAL oBE_GRUPO_ORGANIZACIONAL)
        {
            return new DA_GRUPO_ORGANIZACIONAL().InsertarGrupoOrganizacional(oBE_GRUPO_ORGANIZACIONAL);
        }
        /// <summary>
        /// Actualiza los datos de un Grupo Organizacional
        /// </summary>
        /// <param name="oBE_GRUPO_ORGANIZACIONAL">Entidad BE_GRUPO_ORGANIZACIONAL, que representa la tabla  GRUPOS_ORGANIZACIONALES, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarGrupoOrganizacional(BE_GRUPO_ORGANIZACIONAL oBE_GRUPO_ORGANIZACIONAL)
        {
            return new DA_GRUPO_ORGANIZACIONAL().ActualizarGrupoOrganizacional(oBE_GRUPO_ORGANIZACIONAL);
        }
        /// <summary>
        /// Elimina los dato de un grupo organizacional
        /// </summary>
        /// <param name="grupo_organizacionl_id">Codigo del la Empresa al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarGrupoOrganizacional(Guid grupo_organizacionl_id)
        {
            return new DA_GRUPO_ORGANIZACIONAL().EliminarGrupoOrganizacional(grupo_organizacionl_id);
        }
    }
}
