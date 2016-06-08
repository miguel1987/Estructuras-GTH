using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad EMPRESA
    /// </summary>
    public class BL_EMPRESA
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        //wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();
 

        /// <summary>
        ///  Devuelve los datos de todas las EMPRESAS.
        /// </summary>
        /// <returns> List de BE_EMPRESA con los objetos de la entidad, que a su vez representan la tabla EMPRESAS de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_EMPRESA> SeleccionarEmpresa()
        {
            wsMaestros.BE_EMPRESA[] oLista = wsMantenimientoEstructuras.SeleccionarEmpresa();
            List<BE_EMPRESA> oListaEmpresa = new List<BE_EMPRESA>();
            if (oLista != null)
            {
                foreach (var item in oLista)
                {
                    BE_EMPRESA oEmpresa = new BE_EMPRESA();
                    oEmpresa.ID = item.ID;
                    oEmpresa.CODIGO = item.CODIGO;
                    oEmpresa.DESCRIPCION = item.DESCRIPCION;
                    oEmpresa.USUARIO_CREACION = item.USUARIO_CREACION;
                    oEmpresa.FECHA_CREACION = item.FECHA_CREACION;
                    oEmpresa.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oEmpresa.ESTADO = item.ESTADO;

                    oListaEmpresa.Add(oEmpresa);

                }
            }
            return oListaEmpresa;
        }

        /// <summary>
        ///  Devuelve los datos de una EMPRESA.
        /// </summary>
        /// <param name="empresa_id">Codigo del la Empresa que se desea consultar</param>
        /// <returns> List de BE_EMPRESA con los objetos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public BE_EMPRESA SeleccionarEmpresaPorId(Guid empresa_id)
        {

            wsMaestros.BE_EMPRESA[] oLista = wsMantenimientoEstructuras.SeleccionarEmpresaPorId(empresa_id);
            BE_EMPRESA oEmpresa = new BE_EMPRESA();
            if (oLista != null)
            {
                oEmpresa.ID = oLista[0].ID;
                oEmpresa.CODIGO = oLista[0].CODIGO;
                oEmpresa.DESCRIPCION = oLista[0].DESCRIPCION;
                oEmpresa.USUARIO_CREACION = oLista[0].USUARIO_CREACION;
                oEmpresa.FECHA_CREACION = oLista[0].FECHA_CREACION;
                oEmpresa.USUARIO_ACTUALIZACION = oLista[0].USUARIO_ACTUALIZACION;
                oEmpresa.ESTADO = oLista[0].ESTADO;            

               
            }
            return oEmpresa;
        }

        /// <summary>
        /// Inserta los datos de una Empresa
        /// </summary>
        /// <param name="oBE_EMPRESA">Entidad BE_EMPRESA, que representa la tabla EMPRESAS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarEmpresa(BE_EMPRESA oBE_EMPRESA)
        {
            wsMaestros.BE_EMPRESA oEmpresa = new wsMaestros.BE_EMPRESA();
            oEmpresa.ID = oBE_EMPRESA.ID;
            oEmpresa.CODIGO = oBE_EMPRESA.CODIGO;
            oEmpresa.DESCRIPCION = oBE_EMPRESA.DESCRIPCION;
            oEmpresa.USUARIO_CREACION = oBE_EMPRESA.USUARIO_CREACION;
            oEmpresa.ESTADO = oBE_EMPRESA.ESTADO;

            return wsMantenimientoEstructuras.InsertarEmpresa(oEmpresa);

        }

        /// <summary>
        /// Actualiza los datos de una Empresa
        /// </summary>
        /// <param name="oBE_EMPRESA">Entidad BE_EMPRESA, que representa la tabla EMPRESAS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarEmpresa(BE_EMPRESA oBE_EMPRESA)
        {
            wsMaestros.BE_EMPRESA oEmpresa = new wsMaestros.BE_EMPRESA();
            oEmpresa.ID = oBE_EMPRESA.ID;
            oEmpresa.CODIGO = oBE_EMPRESA.CODIGO;
            oEmpresa.DESCRIPCION = oBE_EMPRESA.DESCRIPCION;
            oEmpresa.USUARIO_CREACION = oBE_EMPRESA.USUARIO_CREACION;
            oEmpresa.ESTADO = oBE_EMPRESA.ESTADO;

            return wsMantenimientoEstructuras.ActualizarEmpresa(oEmpresa);
        }

        /// <summary>
        /// Elimina los dato de una empresa
        /// </summary>
        /// <param name="gerencia_id">Codigo del la Empresa al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarEmpresa(Guid empresa_id)
        {
            return wsMantenimientoEstructuras.EliminarEmpresa(empresa_id);
        }
    }
}
