using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad DESTINATARIO
    /// </summary>
    public class BL_DESTINATARIO
    {
        /// <summary>
        ///  Devuelve los datos de los Destinatarios que pertenecen a un tipo de solicitud.
        /// </summary>
        /// <param name="tipo_solicitud">int Tipo de solicitud:Nacional o Internacional</param>      
        /// <returns> List de BE_DESTINATARIO con los objetos de la entidad.En caso no existan datos devuelve nothing </returns>
        public static List<BE_DESTINATARIO> SeleccionarDestinatarioPorTipo(int tipo_solicitud)
        {
            return new DA_DESTINATARIO().SeleccionarDestinatariosPorTipo(tipo_solicitud);
        }
    }
}
