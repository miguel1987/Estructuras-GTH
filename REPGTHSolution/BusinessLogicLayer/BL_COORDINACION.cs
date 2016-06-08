using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
  public  class BL_COORDINACION
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        //wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();

        /// <summary>
        ///  Devuelve los datos de todas las COORDINACIONES de un AREA.
        /// </summary>
        /// <param name="area_id">Codigo del la Empresa de la cual se desea consultar sus gerencias</param>
        /// <returns> List de BE_GERENCIA con los objetos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_COORDINACION> SeleccionarCoordinacionPorArea(Guid area_id)
        {

            wsMaestros.BE_COORDINACION[] oLista = wsMantenimientoEstructuras.SeleccionarCoordinacionesPorArea(area_id);
            List<BE_COORDINACION> oListaCoordinacion = new List<BE_COORDINACION>();

            if (oLista != null)
            {

                foreach (var item in oLista)
                {
                    BE_COORDINACION oCoordinacion = new BE_COORDINACION();
                    oCoordinacion.ID = item.ID;
                    oCoordinacion.DESCRIPCION = item.DESCRIPCION;
                    oCoordinacion.USUARIO_CREACION = item.USUARIO_CREACION;
                    oCoordinacion.FECHA_CREACION = item.FECHA_CREACION;
                    oCoordinacion.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oCoordinacion.ESTADO = item.ESTADO;

                    oListaCoordinacion.Add(oCoordinacion);

                }
            }

            return oListaCoordinacion;

        }

        /// <summary>
        ///  Devuelve los datos de todas las COORDINACIONES.
        /// </summary>
        /// <returns> List de BE_COORDINACION con los objetos de la entidad, que a su vez representan la tabla COORDINACIONES de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_COORDINACION> SeleccionarCoordinacion()
        {
            wsMaestros.BE_COORDINACION[] oLista = wsMantenimientoEstructuras.SeleccionarCoordinaciones();

            List<BE_COORDINACION> oListaCoordinaciones = new List<BE_COORDINACION>();
            if (oLista != null)
            {
                foreach (var item in oLista)
                {
                    BE_COORDINACION oCoordinacion = new BE_COORDINACION();
                    oCoordinacion.ID = item.ID;
                    oCoordinacion.CODIGO = item.CODIGO;
                    oCoordinacion.DESCRIPCION = item.DESCRIPCION;
                    oCoordinacion.AREA_ID = item.AREA_ID;
                    oCoordinacion.USUARIO_CREACION = item.USUARIO_CREACION;
                    oCoordinacion.FECHA_CREACION = item.FECHA_CREACION;
                    oCoordinacion.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oCoordinacion.ESTADO = item.ESTADO;

                    wsMaestros.BE_AREA oArea = wsMantenimientoEstructuras.SeleccionarAreaPorId(item.AREA_ID);

                    BE_AREA oBE_AREA = new BE_AREA();

                    oBE_AREA.ID = oArea.ID;
                    oBE_AREA.CODIGO = oArea.CODIGO;
                    oBE_AREA.DESCRIPCION = oArea.DESCRIPCION;
                    oBE_AREA.GERENCIA_ID = oArea.GERENCIA_ID;
                    oCoordinacion.oBE_AREA = oBE_AREA;
                    oCoordinacion.GERENCIA_ID = oArea.GERENCIA_ID;

                    wsMaestros.BE_GERENCIA[] oGerencia = wsMantenimientoEstructuras.SeleccionarGerenciaPorId(oCoordinacion.GERENCIA_ID);

                    if (oGerencia != null)
                    {
                        foreach (var itemGerencia in oGerencia)
                        {
                            BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();
                           
                            oBE_GERENCIA.ID = itemGerencia.ID;
                            oBE_GERENCIA.CODIGO = itemGerencia.CODIGO;
                            oBE_GERENCIA.DESCRIPCION = itemGerencia.DESCRIPCION;
                            oCoordinacion.oBE_GERENCIA = oBE_GERENCIA;
                            oCoordinacion.EMPRESA_ID = itemGerencia.EMPRESA_ID;

                            wsMaestros.BE_EMPRESA[] oEmpresa = wsMantenimientoEstructuras.SeleccionarEmpresaPorId(oCoordinacion.EMPRESA_ID);

                            if (oEmpresa != null)
                            {
                                foreach (var itemEmpresa in oEmpresa)
                                {
                                    BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();

                                    oBE_EMPRESA.ID = itemEmpresa.ID;
                                    oBE_EMPRESA.CODIGO = itemEmpresa.CODIGO;
                                    oBE_EMPRESA.DESCRIPCION = itemEmpresa.DESCRIPCION;
                                    oCoordinacion.oBE_EMPRESA = oBE_EMPRESA;                                    

                                }
                            }                          

                        }
                    }

                    oListaCoordinaciones.Add(oCoordinacion);

                }
            }

            return oListaCoordinaciones;

        }


        /// <summary>
        ///  Devuelve los datos de todas las COORDINACIONES de un AREA.
        /// </summary>
        /// <param name="area_id">Codigo del la Empresa de la cual se desea consultar sus gerencias</param>
        /// <returns> List de BE_GERENCIA con los objetos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_COORDINACION> SeleccionarCoordinacion(Guid area_id)
        {

            wsMaestros.BE_COORDINACION[] oLista = wsMantenimientoEstructuras.SeleccionarCoordinacionesPorArea(area_id);
            List<BE_COORDINACION> oListaCoordinacion = new List<BE_COORDINACION>();

            if (oLista != null)
            {

                foreach (var item in oLista)
                {
                    BE_COORDINACION oCoordinacion = new BE_COORDINACION();
                    oCoordinacion.ID = item.ID;
                    oCoordinacion.DESCRIPCION = item.DESCRIPCION;
                    oCoordinacion.USUARIO_CREACION = item.USUARIO_CREACION;
                    oCoordinacion.FECHA_CREACION = item.FECHA_CREACION;
                    oCoordinacion.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oCoordinacion.ESTADO = item.ESTADO;

                    oListaCoordinacion.Add(oCoordinacion);

                }
            }

            return oListaCoordinacion;

        }

        /// <summary>
        /// Inserta los datos de una Coordinación
        /// </summary>
        /// <param name="oBE_COORDINACION">Entidad BE_COORDINACION, que representa la tabla COORDINACIONES, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarCoordinacion(BE_COORDINACION oBE_COORDINACION)
        {
            wsMaestros.BE_COORDINACION oCoordinacion = new wsMaestros.BE_COORDINACION();
            oCoordinacion.ID = oBE_COORDINACION.ID;
            oCoordinacion.CODIGO = oBE_COORDINACION.CODIGO;
            oCoordinacion.DESCRIPCION = oBE_COORDINACION.DESCRIPCION;
            oCoordinacion.USUARIO_CREACION = oBE_COORDINACION.USUARIO_CREACION;
            oCoordinacion.ESTADO = oBE_COORDINACION.ESTADO;
            oCoordinacion.AREA_ID = oBE_COORDINACION.AREA_ID;

            return wsMantenimientoEstructuras.InsertarCoordinacion(oCoordinacion);

        }

        /// <summary>
        /// Actualiza los datos de una Coordinación
        /// </summary>
        /// <param name="oBE_COORDINACION">Entidad BE_AREA, que representa la tabla AREAS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarCoordinacion(BE_COORDINACION oBE_COORDINACION)
        {
            wsMaestros.BE_COORDINACION oCoordinacion = new wsMaestros.BE_COORDINACION();
            oCoordinacion.ID = oBE_COORDINACION.ID;
            oCoordinacion.CODIGO = oBE_COORDINACION.CODIGO;
            oCoordinacion.DESCRIPCION = oBE_COORDINACION.DESCRIPCION;
            oCoordinacion.USUARIO_CREACION = oBE_COORDINACION.USUARIO_CREACION;
            oCoordinacion.ESTADO = oBE_COORDINACION.ESTADO;
            oCoordinacion.AREA_ID = oBE_COORDINACION.AREA_ID;

            return wsMantenimientoEstructuras.ActualizarCoordinacion(oCoordinacion);
        }

        /// <summary>
        /// Elimina los dato de una Coordinación
        /// </summary>
        /// <param name="coordinacion_id">Codigo del la Coordinación que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarCoordinacion(Guid coordinacion_id)
        {
            return wsMantenimientoEstructuras.EliminarCoordinacion(coordinacion_id);
        }


    }
}
