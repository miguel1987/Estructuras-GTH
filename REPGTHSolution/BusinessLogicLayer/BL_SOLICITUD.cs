using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad SOLICITUDES
    /// </summary>
    public class BL_SOLICITUD
    {

        /// <summary>
        /// Devuelve un listado ded solicitudes
        /// </summary>       
        /// <returns>Listado de BE_SOLICITUD con los datos de una solicitud, que a su vez representan la tabla SOLICITUDES de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public static List<BE_SOLICITUD> SeleccionarSolicitudes()
        {
            return new DA_SOLICITUD().SeleccionarSolicitudes();
        }


        /// <summary>
        /// Devuelve un listado ded solicitudes
        /// </summary>
        /// <param name="empresaId">Id de la Empresa cuyas solicitudes se desea consultar</param>
        /// <param name="gerenciaId">Id de la Gerencia cuyas solicitudes se desea consultar</param>
        /// <param name="areaId">Id del área cuyas solicitudes se desea consultar</param>
        /// <param name="tipo">Tipo de solicitudes que se desea consultar</param>
        /// <param name="destinatario">Destinatario que se desea consultar</param>
        /// <param name="fechaDesde">Rango de fecha inicial desde el que se desea consultar</param>
        /// <param name="fechaHasta">Rango de fecha final hasta la que se desea consultar</param>
        /// <returns>Listado de BE_SOLICITUD con los datos de una solicitud, que a su vez representan la tabla SOLICITUDES de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public static List<BE_SOLICITUD> SeleccionarSolicitudes(Guid empresaId, Guid gerenciaId, Guid areaId, int tipo, string destinatario, string fechaDesde, string fechaHasta)
        {
            return new DA_SOLICITUD().SeleccionarSolicitudesPorFechas(empresaId, gerenciaId, areaId, tipo, destinatario, fechaDesde, fechaHasta);
        }

        /// <summary>
        /// Devuelve un listado ded solicitudes
        /// </summary>
        /// <param name="empresaId">Id de la Empresa cuyas solicitudes se desea consultar</param>
        /// <param name="gerenciaId">Id de la Gerencia cuyas solicitudes se desea consultar</param>
        /// <param name="areaId">Id del área cuyas solicitudes se desea consultar</param>
        /// <param name="tipo">Tipo de solicitudes que se desea consultar</param>
        /// <param name="destinatario">Destinatario que se desea consultar</param>
        /// <param name="fechaDesde">Rango de fecha inicial desde el que se desea consultar</param>
        /// <param name="fechaHasta">Rango de fecha final hasta la que se desea consultar</param>
        /// <param name="estado">Estado de la solicitudes a consultar</param>
        /// <returns>Listado de BE_SOLICITUD con los datos de una solicitud, que a su vez representan la tabla SOLICITUDES de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public static List<BE_SOLICITUD> SeleccionarSolicitudes(Guid empresaId, Guid gerenciaId, Guid areaId, int tipo, string destinatario, string fechaDesde, string fechaHasta, int estado)
        {
            return new DA_SOLICITUD().SeleccionarSolicitudesPorFechas(empresaId, gerenciaId, areaId, tipo, destinatario, fechaDesde, fechaHasta, estado);
        }

        /// <summary>
        /// Devuelve un listado de solicitudes
        /// </summary>
        /// <param name="empresaId">Id de la Empresa cuyas solicitudes se desea consultar</param>
        /// <param name="gerenciaId">Id de la Gerencia cuyas solicitudes se desea consultar</param>
        /// <param name="areaId">Id del área cuyas solicitudes se desea consultar</param>
        /// <param name="tipo">Tipo de solicitudes que se desea consultar</param>
        /// <param name="destinatario">Destinatario que se desea consultar</param>
        /// <param name="fechaDesde">Rango de fecha inicial desde el que se desea consultar</param>
        /// <param name="fechaHasta">Rango de fecha final hasta la que se desea consultar</param>
        /// <param name="usuarioId">Id del usuario cuyas solicitudes se desea consultar</param>
        /// <returns>Listado de BE_SOLICITUD con los datos de una solicitud, que a su vez representan la tabla SOLICITUDES de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public static List<BE_SOLICITUD> SeleccionarSolicitudes(Guid empresaId, Guid gerenciaId, Guid areaId, int tipo, string destinatario, string fechaDesde, string fechaHasta, Guid usuarioId)
        {
            return new DA_SOLICITUD().SeleccionarSolicitudesPorFechas(empresaId, gerenciaId, areaId, tipo, destinatario, fechaDesde, fechaHasta, usuarioId);
        }

        /// <summary>
        /// Devuelve un listado de solicitudes
        /// </summary>
        /// <param name="empresaId">Id de la Empresa cuyas solicitudes se desea consultar</param>
        /// <param name="gerenciaId">Id de la Gerencia cuyas solicitudes se desea consultar</param>
        /// <param name="areaId">Id del área cuyas solicitudes se desea consultar</param>
        /// <param name="tipo">Tipo de solicitudes que se desea consultar</param>
        /// <param name="destinatario">Destinatario que se desea consultar</param>
        /// <param name="fechaDesde">Rango de fecha inicial desde el que se desea consultar</param>
        /// <param name="fechaHasta">Rango de fecha final hasta la que se desea consultar</param>
        /// <param name="estado">Estado de las solicitudes que se desea consultar</param>
        /// <param name="usuarioId">Id del usuario cuyas solicitudes se desea consultar</param>
        /// <returns>Listado de BE_SOLICITUD con los datos de una solicitud, que a su vez representan la tabla SOLICITUDES de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public static List<BE_SOLICITUD> SeleccionarSolicitudes(Guid empresaId, Guid gerenciaId, Guid areaId, int tipo, string destinatario, string fechaDesde, string fechaHasta, int estado, Guid usuarioId)
        {
            return new DA_SOLICITUD().SeleccionarSolicitudesPorFechas(empresaId, gerenciaId, areaId, tipo, destinatario, fechaDesde, fechaHasta, estado, usuarioId);
        }

        /// <summary>
        /// Devuelve los datos de una solicitud
        /// </summary>
        /// <param name="solicitudId">Id de la Solicitud a Consultar</param>
        /// <returns>List de BE_SOLICITUD con los objetos de la entidad, que a su vez representan la tabla SOLICITUDES de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public static BE_SOLICITUD SeleccionarSolicitudPorId(Guid solicitudId)
        {
            return new DA_SOLICITUD().SeleccionarSolicitudPorId(solicitudId);
        }

        /// <summary>
        /// Inserta los datos de una solicitud
        /// </summary>
        /// <param name="oBE_SOLICITUD">Entidad BE_SOLICITUD, que representa la tabla SOLICITUDES, con todos sus atributos </param>
        /// <returns>Guid. Guid, si se ingreso con exito. Null, si hubo un error al ingresar</returns>
        public static Guid InsertarSolicitud(BE_SOLICITUD oBE_SOLICITUD)
        {
            return new DA_SOLICITUD().InsertarSolicitud(oBE_SOLICITUD);
        }

        /// <summary>
        /// Actualiza los datos de una solicitud
        /// </summary>
        /// <param name="oBE_SOLICITUD">Entidad BE_SOLICITUD, que representa la tabla SOLICITUDES, con todos sus atributos </param>
        /// <returns>Bool. True, si se actualizó con exito. False, si hubo un error al actualizar</returns>
        public static bool ActualizarSolicitud(BE_SOLICITUD oBE_SOLICITUD)
        {
            return new DA_SOLICITUD().ActualizarSolicitud(oBE_SOLICITUD);
        }

        /// <summary>
        /// Actualiza el estado de una solicitud
        /// </summary>
        /// <param name="solicitudId">Identificador de la solicitud a actualizar</param>
        /// <param name="estado">Estado a actualizar</param>
        /// <param name="usuario">Usuario Id que desea actualizar la solicitud</param>
        /// <param name="solicitanteCorreo">Correo del usuario que solicitó la aprobación</param>
        /// <returns>Bool. True, si se actualizó con exito. False, si hubo un error al actualizar</returns>
        public static bool ActualizarEstadoSolicitud(Guid solicitudId, int estado, Guid usuario, String solicitanteCorreo)
        {
            return new DA_SOLICITUD().ActualizarEstadoSolicitud(solicitudId, estado, usuario, solicitanteCorreo);
        }

        /// <summary>
        /// Solicitar Aprobación de Solicitud por Correo
        /// </summary>
        /// <param name="solicitudId">Identificador de la solicitud a actualizar</param>
        /// <param name="correo">Correo de la persona que debe autorizar la solicitud</param>       
        /// <returns>Bool. True, si se actualizó con exito. False, si hubo un error al actualizar</returns>
        public static bool SolicitarAprobacionSolicitud(Guid solicitudId, String correo)
        {
            return new DA_SOLICITUD().SolicitarAprobacionSolicitud(solicitudId, correo);
        }
    }
}
