using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad SEDE
    /// </summary>
    public class BL_SEDE
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();
        /// <summary>
        ///  Devuelve los datos de todas las SEDES.
        /// </summary>
        /// <returns> List de BE_SEDE con los objetos de la entidad, que a su vez representan la tabla SEDES de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_SEDE> SeleccionarSede()
        {

            wsMaestros.BE_SEDE[] oLista = wsMantenimientoEstructuras.SeleccionarSede();
            List<BE_SEDE> oListaSede = new List<BE_SEDE>();
            if (oLista != null)
            {
                foreach (var item in oLista)
                {
                    BE_SEDE oSede = new BE_SEDE();
                    oSede.ID = item.ID;
                    oSede.CODIGO = item.CODIGO;
                    oSede.DESCRIPCION = item.DESCRIPCION;
                    oSede.USUARIO_CREACION = item.USUARIO_CREACION;
                    oSede.FECHA_CREACION = item.FECHA_CREACION;
                    oSede.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oSede.ESTADO = item.ESTADO;
                    oSede.EMPRESA_ID = item.EMPRESA_ID;

                    wsMaestros.BE_EMPRESA[] oEmpresa = wsMantenimientoEstructuras.SeleccionarEmpresa();
                   
                    if (oEmpresa != null)
                    {
                        foreach (var itemEmpresa in oEmpresa)
                        {
                            BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();

                            if (oSede.EMPRESA_ID == itemEmpresa.ID)
                            {
                                oBE_EMPRESA.ID = itemEmpresa.ID;
                                oBE_EMPRESA.CODIGO = itemEmpresa.CODIGO;
                                oBE_EMPRESA.DESCRIPCION = itemEmpresa.DESCRIPCION;
                                oSede.oBE_EMPRESA = oBE_EMPRESA;
                            }                           

                        }
                    }

                    oListaSede.Add(oSede);

               }
            }
            return oListaSede;           
        }

        /// <summary>
        ///  Devuelve los datos de todas las SEDES de una EMPRESA.
        /// </summary>
        /// <param name="empresa_id">Codigo del la Empresa de la cual se desea consultar sus gerencias</param>
        /// <returns> List de BE_SEDE con los objetos de la entidad, que a su vez representan la tabla SEDES de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_SEDE> SeleccionarSede(Guid empresa_id)
        {

            wsMaestros.BE_SEDE[] oLista = wsMantenimientoEstructuras.SeleccionarSedePorEmpresa(empresa_id);
            List<BE_SEDE> oListaSede = new List<BE_SEDE>();
            if (oLista != null)
            {
                foreach (var item in oLista)
                {
                    BE_SEDE oSede = new BE_SEDE();
                    oSede.ID = item.ID;
                    oSede.CODIGO = item.CODIGO;
                    oSede.DESCRIPCION = item.DESCRIPCION;
                    oSede.USUARIO_CREACION = item.USUARIO_CREACION;
                    oSede.FECHA_CREACION = item.FECHA_CREACION;
                    oSede.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oSede.ESTADO = item.ESTADO;

                    oListaSede.Add(oSede);

                }
            }
            return oListaSede;
        }       

        /// <summary>
        /// Inserta los datos de una Sede
        /// </summary>
        /// <param name="oBE_SEDE">Entidad BE_SEDE, que representa la tabla SEDES, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarSede(BE_SEDE oBE_SEDE)
        {
            wsMaestros.BE_SEDE oSede = new wsMaestros.BE_SEDE();
            oSede.ID = oBE_SEDE.ID;
            oSede.CODIGO = oBE_SEDE.CODIGO;
            oSede.DESCRIPCION = oBE_SEDE.DESCRIPCION;
            oSede.USUARIO_CREACION = oBE_SEDE.USUARIO_CREACION;
            oSede.ESTADO = oBE_SEDE.ESTADO;
            oSede.EMPRESA_ID = oBE_SEDE.EMPRESA_ID;

            return wsMantenimientoEstructuras.InsertarSede(oSede);
             
        }

        /// <summary>
        /// Actualiza los datos de una Sede
        /// </summary>
        /// <param name="oBE_SEDE">Entidad BE_SEDE, que representa la tabla SEDES, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarSede(BE_SEDE oBE_SEDE)
        {
            wsMaestros.BE_SEDE oSede = new wsMaestros.BE_SEDE();
            oSede.ID = oBE_SEDE.ID;
            oSede.CODIGO = oBE_SEDE.CODIGO;
            oSede.DESCRIPCION = oBE_SEDE.DESCRIPCION;
            oSede.USUARIO_CREACION = oBE_SEDE.USUARIO_CREACION;
            oSede.ESTADO = oBE_SEDE.ESTADO;
            oSede.EMPRESA_ID = oBE_SEDE.EMPRESA_ID;

            return wsMantenimientoEstructuras.ActualizarSede(oSede);
        }

        /// <summary>
        /// Elimina los dato de una sede
        /// </summary>
        /// <param name="sede_id">Codigo del la Sede al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarSede(Guid sede_id)
        {
            return wsMantenimientoEstructuras.EliminarSede(sede_id);
        }
    }
}
