using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad DOCUMENTOS
    /// </summary>
    public class BL_DOCUMENTO
    {
        /// <summary>
        ///  Devuelve los datos de los Docuemntos que pertenecen a una solicitud.
        /// </summary>
        /// <param name="solicitudId">Guid: Id de la solicitud</param>      
        /// <returns> List de BE_DOCUMENTOS con los objetos de la entidad.En caso no existan datos devuelve nothing </returns>
        public static List<BE_DOCUMENTO> SeleccionarDocumentosPorSolicitud(Guid solicitudId)
        {
            return new DA_DOCUMENTO().SeleccionarDocumentosPorSolicitud(solicitudId);
        }

        /// <summary>
        /// Ingresa un nuevo Documento
        /// </summary>
        /// <param name="oBE_DOCUMENTO">Objeto BE_DOCUMENTO con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean InsertarDocumento(BE_DOCUMENTO oBE_DOCUMENTO)
        {
            return new DA_DOCUMENTO().InsertarDocumento(oBE_DOCUMENTO);
        }

        /// <summary>
        /// Actualiza un Documento
        /// </summary>
        /// <param name="oBE_USUARIO">Objeto BE_DOCUMENTO con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarDocumento(BE_DOCUMENTO oBE_DOCUMENTO)
        {
            return new DA_DOCUMENTO().ActualizarDocumento(oBE_DOCUMENTO);
        }

        /// <summary>
        /// Elimina un Documento
        /// </summary>
        /// <param name="documentoId">Codigo del documento que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarDocumento(Guid documentoId)
        {
            return new DA_DOCUMENTO().EliminarDocumento(documentoId);
        }
    }
}
