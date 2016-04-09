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
        wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();   

        /// <summary>
        ///  Devuelve los datos de todas las EMPRESAS.
        /// </summary>
        /// <returns> List de BE_EMPRESA con los objetos de la entidad, que a su vez representan la tabla EMPRESAS de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_EMPRESA> SeleccionarEmpresa()
        {
            wsMaestros.BE_EMPRESA[] oLista = wsMantenimientoMaestros.SeleccionarEmpresa();
            List<BE_EMPRESA> oListaEmpresa = new List<BE_EMPRESA>();
            if (oLista != null)
            {
                foreach (var item in oLista)
                {
                    BE_EMPRESA oEmpresa = new BE_EMPRESA();
                    oEmpresa.ID = item.ID;
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
        /// Inserta los datos de una Empresa
        /// </summary>
        /// <param name="oBE_EMPRESA">Entidad BE_EMPRESA, que representa la tabla EMPRESAS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarEmpresa(BE_EMPRESA oBE_EMPRESA)
        {
            wsMaestros.BE_EMPRESA oEmpresa = new wsMaestros.BE_EMPRESA();
            oEmpresa.ID = oBE_EMPRESA.ID;
            oEmpresa.DESCRIPCION = oBE_EMPRESA.DESCRIPCION;
            oEmpresa.USUARIO_CREACION = oBE_EMPRESA.USUARIO_CREACION;
            oEmpresa.ESTADO = oBE_EMPRESA.ESTADO;

            return wsMantenimientoMaestros.InsertarEmpresa(oEmpresa);

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
            oEmpresa.DESCRIPCION = oBE_EMPRESA.DESCRIPCION;
            oEmpresa.USUARIO_CREACION = oBE_EMPRESA.USUARIO_CREACION;
            oEmpresa.ESTADO = oBE_EMPRESA.ESTADO;

            return wsMantenimientoMaestros.ActualizarEmpresa(oEmpresa);
        }

        /// <summary>
        /// Elimina los dato de una empresa
        /// </summary>
        /// <param name="gerencia_id">Codigo del la Empresa al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarEmpresa(Guid empresa_id)
        {
            return wsMantenimientoMaestros.EliminarEmpresa(empresa_id);
        }
    }
}
