using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad DIRECCION
    /// </summary>
    public class BL_DIRECCION
    {
        /// <summary>
        ///  Devuelve los datos de todas las Direcciones.
        /// </summary>
        /// <returns> List de BE_DIRECCION con los objetos de la entidad, que a su vez representan la tabla DIRECCIONES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_DIRECCION> SeleccionarDirecciones()
        {
            return new DA_DIRECCION().SeleccionarDirecciones();
        }


        /// <summary>
        ///  Devuelve los datos de todas las Direcciones Atención.
        /// </summary>
        /// <returns> List de BE_DIRECCION con los objetos de la entidad, que a su vez representan la tabla DIRECCIONES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_DIRECCION_ATENCION> SeleccionarDireccionesAtencion()
        {
            return new DA_DIRECCION().SeleccionarDireccionesAtencion();
        }

        /// <summary>
        ///  Devuelve los datos de las Direcciones Atención por Destinatario
        /// </summary>
        /// <param name="direccion_id">int dirección de destinatario a filtrar sus atenciones</param>
        /// <returns> List de BE_DIRECCION_ATENCION con los objetos de la entidad, que a su vez representan la tabla DIRECCIONES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_DIRECCION_ATENCION> SeleccionarDireccionesAtencionPorDestinatario(Guid direccion_id)
        {
            return new DA_DIRECCION().SeleccionarDireccionesAtencionPorDestinatario(direccion_id);
        }

        /// <summary>
        ///  Devuelve los datos de las Direcciones que pertenecen aun tipo de envío y de un determinado tipo.
        /// </summary>
        /// <param name="tipo_envio">int Tipo de envío:Nacional o Internacional</param>
        /// <param name="tipo_direccion">int Tipo de Dirección:Remitente o Destinatario</param>
        /// <returns> List de BE_DIRECCION con los objetos de la entidad, que a su vez representan la tabla DIRECCIONES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_DIRECCION> SeleccionarDireccionesPorTipo(int tipo_envio, int tipo_direccion)
        {
            return new DA_DIRECCION().SeleccionarDireccionesPorTipo(tipo_envio, tipo_direccion);
        }


        /// <summary>
        ///  Devuelve los datos de las Direcciones que pertenecen aun tipo de dirección determinado.
        /// </summary>                
        /// <returns> List de BE_DIRECCION con los objetos de la entidad, que a su vez representan la tabla DIRECCIONES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_DIRECCION> SeleccionarDireccionesDestinatario()
        {
            return new DA_DIRECCION().SeleccionarDireccionesDestinatario();
        }

        /// <summary>
        ///  Devuelve los tipos de direcciones.
        /// </summary>       
        /// <returns> List de BE_TIPO_DIRECCION con los objetos de la entidad, que a su vez representan los tipos de direcciones de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_TIPO_DIRECCION> SeleccionarTipoDireccion()
        {
            List<BE_TIPO_DIRECCION> oListaTipoDireccion = new List<BE_TIPO_DIRECCION>();

            BE_TIPO_DIRECCION oTipoDireccionRemitente = new BE_TIPO_DIRECCION();
            oTipoDireccionRemitente.CODIGO = 1;
            oTipoDireccionRemitente.DESCRIPCION = BE_DIRECCION.DIRECCION_TIPO.Remitente.ToString();
            oListaTipoDireccion.Add(oTipoDireccionRemitente);

            BE_TIPO_DIRECCION oTipoDireccionDestinatario = new BE_TIPO_DIRECCION();
            oTipoDireccionDestinatario.CODIGO = 2;
            oTipoDireccionDestinatario.DESCRIPCION = BE_DIRECCION.DIRECCION_TIPO.Destinatario.ToString();

            oListaTipoDireccion.Add(oTipoDireccionDestinatario);

            return oListaTipoDireccion;

        }

        /// <summary>
        /// Devuelve los datos de una dirección
        /// </summary>
        /// <param name="direccionId">Id de la Dirección a Consultar</param>
        /// <returns>List de BE_DIRECCION con los objetos de la entidad, que a su vez representan la tabla DIRECCIONES de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public static BE_DIRECCION SeleccionarDireccionPorId(Guid direccionId)
        {
            return new DA_DIRECCION().SeleccionarDireccionPorId(direccionId);
        }

        /// <summary>
        /// Ingresa una Dirección
        /// </summary>
        /// <param name="oBE_DIRECCION">Objeto BE_DIRECCION con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Guid InsertarDireccion(BE_DIRECCION oBE_DIRECCION)
        {
            return new DA_DIRECCION().InsertarDireccion(oBE_DIRECCION);
        }

        /// <summary>
        /// Actualiza una Dirección
        /// </summary>
        /// <param name="oBE_DIRECCION">Objeto BE_DIRECCION con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarDireccion(BE_DIRECCION oBE_DIRECCION)
        {
            return new DA_DIRECCION().ActualizarDireccion(oBE_DIRECCION);
        }

        /// <summary>
        /// Eliminar una Direccion
        /// </summary>
        /// <param name="direccionId">Codigo de la dirección que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarDireccion(Guid direccionId)
        {
            return new DA_DIRECCION().EliminarDireccion(direccionId);
        }

        /// <summary>
        /// Ingresa una Dirección
        /// </summary>
        /// <param name="oBE_DIRECCION_ATENCION">Objeto BE_DIRECCION_ATENCION con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Guid InsertarDireccionAtencion(BE_DIRECCION_ATENCION oBE_DIRECCION_ATENCION)
        {
            return new DA_DIRECCION().InsertarDireccionAtencion(oBE_DIRECCION_ATENCION);
        }

        /// <summary>
        /// Actualiza una Dirección
        /// </summary>
        /// <param name="oBE_DIRECCION_ATENCION">Objeto BE_DIRECCION_ATENCION con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarDireccionAtencion(BE_DIRECCION_ATENCION oBE_DIRECCION_ATENCION)
        {
            return new DA_DIRECCION().ActualizarDireccionAtencion(oBE_DIRECCION_ATENCION);
        }

        /// <summary>
        /// Eliminar una Direccion Atención
        /// </summary>
        /// <param name="direccionatencionId">Codigo de la dirección atención que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarDireccionAtencion(Guid direccion_atencion_Id)
        {
            return new DA_DIRECCION().EliminarDireccionAtencion(direccion_atencion_Id);
        }

        /// <summary>
        /// Eliminar una Direccion Atención Por Destinatario 
        /// </summary>
        /// <param name="direccionId">Codigo de la dirección atención que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarDireccionAtencionPorDestinatario(Guid direccionn_Id)
        {
            return new DA_DIRECCION().EliminarDireccionAtencionPorDestinatario(direccionn_Id);
        }


    }
}
