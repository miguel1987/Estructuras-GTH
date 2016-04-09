using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla SOLICITUD de la base de datos
    /// </summary>
    public partial class BE_SOLICITUD : BE_GENERICO
    {
        public Guid ID { get; set; }
        public Int32 CODIGO { get; set; }
        public String FECHA_REGISTRO { get; set; }
        public Guid EMPRESA_ID { get; set; }
        public Guid GERENCIA_ID { get; set; }
        public Guid AREA_ID { get; set; }
        public Int32 PRIORIDAD { get; set; }
        public Int32 TIPO { get; set; }
        public Nullable<Guid> CENTRO_COSTO_ID { get; set; }
        public Nullable<Guid> ORDEN_ID { get; set; }
        public Guid CENTRO_GESTOR_ID { get; set; }
        public Guid CUENTA_MAYOR_ID { get; set; }
        public Guid AUTORIZADOR { get; set; }
        public Int32 REQUIERE_APROBACION { get; set; }
        public String SOLICITANTE { get; set; }
        public Nullable<Int32> ESTADO { get; set; }
        public BE_CORRESPONDENCIA oBE_CORRESPONDENCIA { get; set; }
        public String DESTINATARIO { get; set; }
        public String ORDEN_PROVEEDOR { get; set; }
        public String ESTADO_DESCRIPCION { get; set; }
        public List<BE_DOCUMENTO> DOCUMENTOS { get; set; }
        public String SOLICITANTE_CORREO { get; set; }

        public enum SOLICITUD_TIPO
        {
            Nacional = 1,
            International = 2
        }

        public enum SOLICITUD_PRIORIDAD
        {
            Normal = 1,
            Media = 2,
            Urgente = 3
        }

        public enum SOLICITUD_REQUIERE_APROBACION
        {
            No = 0,
            Si = 1
        }

        public enum SOLICITUD_ESTADO
        {
            Eliminada = 0,
            PendienteAprobacion = 1,
            Aprobada = 2,
            Rechazada = 3,
            Cerrada = 4            
        }

        public enum SOLICITUD_TIPO_CORRESPONDENCIA
        {
            Sobre = 1,
            Paquete = 2
        }

        public enum SOLICITUD_ENVIO_CARACTERISTICA
        {
            Ninguna = 0,
            Confidencial = 1,
            Fragil = 2
        }

    }
}
