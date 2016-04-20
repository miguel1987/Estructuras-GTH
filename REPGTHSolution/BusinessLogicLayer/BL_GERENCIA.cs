using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad GERENCIA
    /// </summary>
    public class BL_GERENCIA
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        //wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();  
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();


        /// <summary>
        ///  Devuelve los datos de todas las GERENCIAS.
        /// </summary>
        /// <returns> List de BE_GERENCIA con los objetos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_GERENCIA> SeleccionarGerencia()
        {                     
            
            wsMaestros.BE_GERENCIA[] oLista = wsMantenimientoEstructuras.SeleccionarGerencia();
            List<BE_GERENCIA> oListaGerencia = new List<BE_GERENCIA>();
            if (oLista != null)
            {
                foreach (var item in oLista)
                {
                    BE_GERENCIA oGerencia = new BE_GERENCIA();                    
                    oGerencia.ID = item.ID;
                    oGerencia.DESCRIPCION = item.DESCRIPCION;
                    oGerencia.USUARIO_CREACION = item.USUARIO_CREACION;
                    oGerencia.FECHA_CREACION = item.FECHA_CREACION;
                    oGerencia.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oGerencia.ESTADO = item.ESTADO;
                    oGerencia.EMPRESA_ID = item.EMPRESA_ID;

                    wsMaestros.BE_EMPRESA[] oEmpresa = wsMantenimientoEstructuras.SeleccionarEmpresa();
                   // List<BE_EMPRESA> oListaEmpresa = new List<BE_EMPRESA>();
                    if (oEmpresa != null)
                    {
                        foreach (var itemEmpresa in oEmpresa)
                        {
                            BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();
                            
                            if (oGerencia.EMPRESA_ID == itemEmpresa.ID)
                            {
                                oBE_EMPRESA.ID = itemEmpresa.ID;
                                oBE_EMPRESA.DESCRIPCION = itemEmpresa.DESCRIPCION;
                                oGerencia.oBE_EMPRESA = oBE_EMPRESA;
                            }                           

                        }
                    }

                    oListaGerencia.Add(oGerencia);

               }
            }
            return oListaGerencia;
           
        }

        /// <summary>
        ///  Devuelve los datos de todas las GERENCIAS de una EMPRESA.
        /// </summary>
        /// <param name="empresa_id">Codigo del la Empresa de la cual se desea consultar sus gerencias</param>
        /// <returns> List de BE_GERENCIA con los objetos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_GERENCIA> SeleccionarGerencia(Guid empresa_id)
        {

            wsMaestros.BE_GERENCIA[] oLista = wsMantenimientoEstructuras.SeleccionarGerenciaPorEmpresa(empresa_id);
            List<BE_GERENCIA> oListaGerencia = new List<BE_GERENCIA>();
            if (oLista != null)
            {
                foreach (var item in oLista)
                {
                    BE_GERENCIA oGerencia = new BE_GERENCIA();
                    oGerencia.ID = item.ID;
                    oGerencia.DESCRIPCION = item.DESCRIPCION;
                    oGerencia.USUARIO_CREACION = item.USUARIO_CREACION;
                    oGerencia.FECHA_CREACION = item.FECHA_CREACION;
                    oGerencia.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oGerencia.ESTADO = item.ESTADO;

                    oListaGerencia.Add(oGerencia);

                }
            }
            return oListaGerencia;
        }

        /// <summary>
        ///  Devuelve los datos de todas las GERENCIAS de una EMPRESA.
        /// </summary>
        /// <param name="empresa_id">Codigo del la Empresa de la cual se desea consultar sus gerencias</param>
        /// <returns> List de BE_GERENCIA con los objetos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_GERENCIA> SeleccionarGerenciaPorEmpresa(Guid empresa_id)
        {

            wsMaestros.BE_GERENCIA[] oLista = wsMantenimientoEstructuras.SeleccionarGerenciaPorEmpresa(empresa_id);
            List<BE_GERENCIA> oListaGerencia = new List<BE_GERENCIA>();

            if (oLista != null)
            {

                foreach (var item in oLista)
                {
                    BE_GERENCIA oGerencia = new BE_GERENCIA();
                    oGerencia.ID = item.ID;
                    oGerencia.DESCRIPCION = item.DESCRIPCION;
                    oGerencia.USUARIO_CREACION = item.USUARIO_CREACION;
                    oGerencia.FECHA_CREACION = item.FECHA_CREACION;
                    oGerencia.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oGerencia.ESTADO = item.ESTADO;

                    oListaGerencia.Add(oGerencia);

                }
            }

            return oListaGerencia;

        }

        /// <summary>
        /// Inserta los datos de una Gerencia
        /// </summary>
        /// <param name="oBE_GERENCIA">Entidad BE_GERENCIA, que representa la tabla GERENCIA, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarGerencia(BE_GERENCIA oBE_GERENCIA)
        {
            wsMaestros.BE_GERENCIA oGerencia = new wsMaestros.BE_GERENCIA();
            oGerencia.ID = oBE_GERENCIA.ID;
            oGerencia.DESCRIPCION = oBE_GERENCIA.DESCRIPCION;
            oGerencia.USUARIO_CREACION = oBE_GERENCIA.USUARIO_CREACION;                  
            oGerencia.ESTADO = oBE_GERENCIA.ESTADO;
            oGerencia.EMPRESA_ID = oBE_GERENCIA.EMPRESA_ID;

            return wsMantenimientoEstructuras.InsertarGerencia(oGerencia);
             
        }

        /// <summary>
        /// Actualiza los datos de una Gerencia
        /// </summary>
        /// <param name="oBE_GERENCIA">Entidad BE_GERENCIA, que representa la tabla GERENCIA, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarGerencia(BE_GERENCIA oBE_GERENCIA)
        {
            wsMaestros.BE_GERENCIA oGerencia = new wsMaestros.BE_GERENCIA();
            oGerencia.ID = oBE_GERENCIA.ID;
            oGerencia.DESCRIPCION = oBE_GERENCIA.DESCRIPCION;
            oGerencia.USUARIO_CREACION = oBE_GERENCIA.USUARIO_CREACION;
            oGerencia.ESTADO = oBE_GERENCIA.ESTADO;
            oGerencia.EMPRESA_ID = oBE_GERENCIA.EMPRESA_ID;

            return wsMantenimientoEstructuras.ActualizarGerencia(oGerencia);
        }

        /// <summary>
        /// Elimina los dato de una gerencia
        /// </summary>
        /// <param name="gerencia_id">Codigo del la Gerencia al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarGerencia(Guid gerencia_id)
        {
            return wsMantenimientoEstructuras.EliminarGerencia(gerencia_id);
        }

    }
}
