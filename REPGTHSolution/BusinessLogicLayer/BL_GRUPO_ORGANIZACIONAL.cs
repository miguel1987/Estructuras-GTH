using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad GRUPOS_ORGANIZACIONALES
    /// </summary>
    public class BL_GRUPO_ORGANIZACIONAL
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();
        /// <summary>
        ///  Devuelve los datos de todas las GRUPOS_ORGANIZACIONALES.
        /// </summary>
        /// <returns> List de BE_GRUPO_ORGANIZACIONAL con los objetos de la entidad, que a su vez representan la tabla GRUPOS_ORGANIZACIONALES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_GRUPO_ORGANIZACIONAL> SeleccionarGrupoOrganizacional()
        {
            wsMaestros.BE_GRUPO_ORGANIZACIONAL[] oLista = wsMantenimientoEstructuras.SeleccionarGrupoOrganizacional();
            List<BE_GRUPO_ORGANIZACIONAL> oListaGrupoOrganizacional = new List<BE_GRUPO_ORGANIZACIONAL>();
            if (oLista != null)
            {
                foreach (var item in oLista)
                {
                    BE_GRUPO_ORGANIZACIONAL oGrupoOrganizacional = new BE_GRUPO_ORGANIZACIONAL();
                    oGrupoOrganizacional.ID = item.ID;
                    oGrupoOrganizacional.CODIGO = item.CODIGO;
                    oGrupoOrganizacional.DESCRIPCION = item.DESCRIPCION;
                    oGrupoOrganizacional.USUARIO_CREACION = item.USUARIO_CREACION;
                    oGrupoOrganizacional.FECHA_CREACION = item.FECHA_CREACION;
                    oGrupoOrganizacional.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oGrupoOrganizacional.ESTADO = item.ESTADO;

                    oListaGrupoOrganizacional.Add(oGrupoOrganizacional);
                }
            }
            return oListaGrupoOrganizacional;
        }

        /// <summary>
        /// Inserta los datos de un Grupo Organizacional
        /// </summary>
        /// <param name="oBE_GRUPO_ORGANIZACIONAL">Entidad BE_GRUPO_ORGANIZACIONAL, que representa la tabla GRUPOS_ORGANIZACIONALES, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarGrupoOrganizacional(BE_GRUPO_ORGANIZACIONAL oBE_GRUPO_ORGANIZACIONAL)
        {
            wsMaestros.BE_GRUPO_ORGANIZACIONAL oGrupoOrganizacional = new wsMaestros.BE_GRUPO_ORGANIZACIONAL();
            oGrupoOrganizacional.ID = oBE_GRUPO_ORGANIZACIONAL.ID;
            oGrupoOrganizacional.CODIGO = oBE_GRUPO_ORGANIZACIONAL.CODIGO;
            oGrupoOrganizacional.DESCRIPCION = oBE_GRUPO_ORGANIZACIONAL.DESCRIPCION;
            oGrupoOrganizacional.USUARIO_CREACION = oBE_GRUPO_ORGANIZACIONAL.USUARIO_CREACION;
            oGrupoOrganizacional.ESTADO = oBE_GRUPO_ORGANIZACIONAL.ESTADO;

            return wsMantenimientoEstructuras.InsertarGrupoOrganizacional(oGrupoOrganizacional);
        }

        /// <summary>
        /// Actualiza los datos de un Grupo Organizacional
        /// </summary>
        /// <param name="oBE_GRUPO_ORGANIZACIONAL">Entidad BE_GRUPO_ORGANIZACIONAL, que representa la tabla GRUPOS_ORGANIZACIONALES, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarGrupoOrganizacional(BE_GRUPO_ORGANIZACIONAL oBE_GRUPO_ORGANIZACIONAL)
        {
            wsMaestros.BE_GRUPO_ORGANIZACIONAL oGrupoOrganizacional = new wsMaestros.BE_GRUPO_ORGANIZACIONAL();
            oGrupoOrganizacional.ID = oBE_GRUPO_ORGANIZACIONAL.ID;
            oGrupoOrganizacional.CODIGO = oBE_GRUPO_ORGANIZACIONAL.CODIGO;
            oGrupoOrganizacional.DESCRIPCION = oBE_GRUPO_ORGANIZACIONAL.DESCRIPCION;
            oGrupoOrganizacional.USUARIO_CREACION = oBE_GRUPO_ORGANIZACIONAL.USUARIO_CREACION;
            oGrupoOrganizacional.ESTADO = oBE_GRUPO_ORGANIZACIONAL.ESTADO;

            return wsMantenimientoEstructuras.ActualizarGrupoOrganizacional(oGrupoOrganizacional);
        }

        /// <summary>
        /// Elimina los dato de un grupo Organizacional
        /// </summary>
        /// <param name="grupo_organizacional_id">Id del Grupo Organizacional al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarGrupoOrganizacional(Guid grupo_organizacional_id)
        {
            return wsMantenimientoEstructuras.EliminarGrupoOrganizacional(grupo_organizacional_id);
        }
    }
}
