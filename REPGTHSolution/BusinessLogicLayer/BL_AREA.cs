using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para la logica de negocio de AREA
    /// </summary>
    public class BL_AREA
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.          
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();        
        /// <summary>
        ///  Devuelve los datos de todas las AREAS.
        /// </summary>
        /// <returns> List de BE_AREA con los objetos de la entidad, que a su vez representan la tabla AREAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_AREA> SeleccionarArea()
        {
            wsMaestros.BE_AREA[] oLista = wsMantenimientoEstructuras.SeleccionarAreas();
           
            List<BE_AREA> oListaAreas = new List<BE_AREA>();
            if (oLista != null)
            {
                foreach (var item in oLista)
                {
                    BE_AREA oArea = new BE_AREA();
                    oArea.ID = item.ID;
                    oArea.CODIGO = item.CODIGO;
                    oArea.DESCRIPCION = item.DESCRIPCION;
                    oArea.GERENCIA_ID = item.GERENCIA_ID;
                    oArea.USUARIO_CREACION = item.USUARIO_CREACION;
                    oArea.FECHA_CREACION = item.FECHA_CREACION;
                    oArea.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oArea.ESTADO = item.ESTADO;

                    wsMaestros.BE_GERENCIA[] oGerencia = wsMantenimientoEstructuras.SeleccionarGerencia();
                   
                    if (oGerencia != null)
                    {
                        foreach (var itemGerencia in oGerencia)
                        {
                            BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();

                            if (oArea.GERENCIA_ID == itemGerencia.ID)
                            {
                                oBE_GERENCIA.ID = itemGerencia.ID;
                                oBE_GERENCIA.CODIGO = itemGerencia.CODIGO;
                                oBE_GERENCIA.DESCRIPCION = itemGerencia.DESCRIPCION;
                                oArea.oBE_GERENCIA = oBE_GERENCIA;
                                oArea.EMPRESA_ID = itemGerencia.EMPRESA_ID;

                                wsMaestros.BE_EMPRESA[] oEmpresa = wsMantenimientoEstructuras.SeleccionarEmpresa();
                                
                                if (oEmpresa != null)
                                {
                                    foreach (var itemEmpresa in oEmpresa)
                                    {
                                        BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();

                                        if (oArea.EMPRESA_ID == itemEmpresa.ID)
                                        {
                                            oBE_EMPRESA.ID = itemEmpresa.ID;
                                            oBE_EMPRESA.CODIGO = itemEmpresa.CODIGO;
                                            oBE_EMPRESA.DESCRIPCION = itemEmpresa.DESCRIPCION;
                                            oArea.oBE_EMPRESA = oBE_EMPRESA;
                                        }

                                    }
                                }


                            }

                        }
                    }

                    oListaAreas.Add(oArea);

                }
            }

            return oListaAreas;

        }

        /// <summary>
        ///  Devuelve los datos de todas las AREAS de una Gerencia.
        /// </summary>
        /// <param name="gerencia_id">Id de la gerencia cuyas áreas se desean listar </param>
        /// <returns> List de BE_AREA con los objetos de la entidad, que a su vez representan la tabla AREAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_AREA> SeleccionarArea(Guid gerencia_id)
        {

            wsMaestros.BE_AREA[] oLista = wsMantenimientoEstructuras.SeleccionarAreaPorGerencia(gerencia_id);
            List<BE_AREA> oListaAreas = new List<BE_AREA>();

            if (oLista != null)
            {
                
                foreach (var item in oLista)
                {
                    BE_AREA oArea = new BE_AREA();
                    oArea.ID = item.ID;
                    oArea.CODIGO = item.CODIGO;
                    oArea.DESCRIPCION = item.DESCRIPCION;
                    oArea.GERENCIA_ID = item.GERENCIA_ID;
                    oArea.USUARIO_CREACION = item.USUARIO_CREACION;
                    oArea.FECHA_CREACION = item.FECHA_CREACION;
                    oArea.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oArea.ESTADO = item.ESTADO;

                    oListaAreas.Add(oArea);

                }                
            }
            return oListaAreas;

        }

        /// <summary>
        ///  Devuelve los datos de todas las AREAS.
        /// </summary>
        /// <param name="gerenciaId">Id de la gerencia cuyas áreas se desean listar </param>
        /// <returns> List de BE_AREA con los objetos de la entidad, que a su vez representan la tabla AREAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_AREA> SeleccionarAreaGerencia(Guid gerenciaId)
        {

            wsMaestros.BE_AREA[] oLista = wsMantenimientoEstructuras.SeleccionarAreas();
            List<BE_AREA> oListaAreas = new List<BE_AREA>();
            if (oLista != null)
            {
                foreach (var item in oLista)
                {
                    BE_AREA oArea = new BE_AREA();
                    oArea.ID = item.ID;
                    oArea.CODIGO = item.CODIGO;
                    oArea.DESCRIPCION = item.DESCRIPCION;
                    oArea.GERENCIA_ID = item.GERENCIA_ID;
                    oArea.USUARIO_CREACION = item.USUARIO_CREACION;
                    oArea.FECHA_CREACION = item.FECHA_CREACION;
                    oArea.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oArea.ESTADO = item.ESTADO;

                    if (oArea.GERENCIA_ID == gerenciaId)
                    {
                        oListaAreas.Add(oArea);
                    }

                }
            }
            return oListaAreas;
        }


        /// <summary>
        /// Inserta los datos de una Area
        /// </summary>
        /// <param name="oBE_AREA">Entidad BE_AREA, que representa la tabla AREAS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarArea(BE_AREA oBE_AREA)
        {
            wsMaestros.BE_AREA oArea = new wsMaestros.BE_AREA();
            oArea.ID = oBE_AREA.ID;
            oArea.CODIGO = oBE_AREA.CODIGO;
            oArea.DESCRIPCION = oBE_AREA.DESCRIPCION;
            oArea.USUARIO_CREACION = oBE_AREA.USUARIO_CREACION;
            oArea.ESTADO = oBE_AREA.ESTADO;
            oArea.GERENCIA_ID = oBE_AREA.GERENCIA_ID;

            return wsMantenimientoEstructuras.InsertarArea(oArea);
        }

        /// <summary>
        /// Actualiza los datos de una Area
        /// </summary>
        /// <param name="oBE_AREA">Entidad BE_AREA, que representa la tabla AREAS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarAreas(BE_AREA oBE_AREA)
        {
            wsMaestros.BE_AREA oArea = new wsMaestros.BE_AREA();
            oArea.ID = oBE_AREA.ID;
            oArea.CODIGO = oBE_AREA.CODIGO;
            oArea.DESCRIPCION = oBE_AREA.DESCRIPCION;
            oArea.USUARIO_CREACION = oBE_AREA.USUARIO_CREACION;
            oArea.ESTADO = oBE_AREA.ESTADO;
            oArea.GERENCIA_ID = oBE_AREA.GERENCIA_ID;

            return wsMantenimientoEstructuras.ActualizarArea(oArea);
        }

        /// <summary>
        /// Elimina los dato de una Area
        /// </summary>
        /// <param name="area_id">Codigo del la Area al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarArea(Guid area_id)
        {
            return wsMantenimientoEstructuras.EliminarArea(area_id);
        }

    }
}
