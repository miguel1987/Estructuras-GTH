using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad PROVEEDOR
    /// </summary>
    public class BL_PROVEEDOR
    {

        /// <summary>
        ///  Devuelve los datos de todos los Proveedores.
        /// </summary>
        /// <returns> List de BE_PROVEEDOR con los objetos de la entidad, que a su vez representan la tabla PROVEEDORES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_PROVEEDOR> SeleccionarProveedores()
        {
            return new DA_PROVEEDOR().SeleccionarProveedores();
        }

        /// <summary>
        ///  Devuelve los datos de todos los Proveedores Por Tipo.
        /// </summary>
        /// <param name="tipo">int Tipo de Proveedor:Nacional o Internacional</param>
        /// <returns> List de BE_PROVEEDOR con los objetos de la entidad, que a su vez representan la tabla PROVEEDORES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_PROVEEDOR> SeleccionarProveedoresPorTipo(int tipo)
        {
            return new DA_PROVEEDOR().SeleccionarProveedoresPorTipo(tipo);
        }

        /// <summary>
        ///  Devuelve los tipos de solicitud.
        /// </summary>
        /// <param name="tipo">int Tipo de Proveedor:Nacional o Internacional</param>
        /// <returns> List de BE_PROVEEDOR con los objetos de la entidad, que a su vez representan la tabla PROVEEDORES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_TIPO_SOLICITUD> SeleccionarTipoSolicitud()
        {
            List<BE_TIPO_SOLICITUD> oListaTipoSolicitud = new List<BE_TIPO_SOLICITUD>();

            BE_TIPO_SOLICITUD oTipoSolicitud_Nacional = new BE_TIPO_SOLICITUD();
            oTipoSolicitud_Nacional.CODIGO = 1;
            oTipoSolicitud_Nacional.DESCRIPCION = BE_PROVEEDOR.TIPO_PROVEEDOR.Nacional.ToString();
            oListaTipoSolicitud.Add(oTipoSolicitud_Nacional);

            BE_TIPO_SOLICITUD oTipoSolicitud_Internacional = new BE_TIPO_SOLICITUD();
            oTipoSolicitud_Internacional.CODIGO = 2;
            oTipoSolicitud_Internacional.DESCRIPCION = BE_PROVEEDOR.TIPO_PROVEEDOR.International.ToString();

            oListaTipoSolicitud.Add(oTipoSolicitud_Internacional);

            return oListaTipoSolicitud;

        }

        /// <summary>
        /// Ingresa un Proveedor
        /// </summary>
        /// <param name="oBE_PROVEEDOR">Objeto BE_PROVEEDOR con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean InsertarProveedor(BE_PROVEEDOR oBE_PROVEEDOR)
        {
            return new DA_PROVEEDOR().InsertarProveedor(oBE_PROVEEDOR);
        }

        /// <summary>
        /// Actualiza un Proveedor
        /// </summary>
        /// <param name="oBE_PROVEEDOR">Objeto BE_PROVEEDOR con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarProveedor(BE_PROVEEDOR oBE_PROVEEDOR)
        {
            return new DA_PROVEEDOR().ActualizarProveedor(oBE_PROVEEDOR);
        }

        /// <summary>
        /// Eliminar un Proveedor
        /// </summary>
        /// <param name="proveedorId">Codigo de la cuenta mayor que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarProveedor(Guid proveedorId)
        {
            return new DA_PROVEEDOR().EliminarProveedor(proveedorId);
        }



    }
}
