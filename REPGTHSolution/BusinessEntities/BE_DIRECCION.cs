using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla DIRECCIONES de la base de datos
    /// </summary>
    public partial class BE_DIRECCION : BE_GENERICO
    {
        public Guid ID { get; set; }
        public Int32 TIPO_ENVIO { get; set; }
        public Int32 TIPO { get; set; }
        public String DESCRIPCION { get; set; }
        public Int32 ESTADO { get; set; }
        public String DESTINATARIO { get; set; }
        public String ATENCION { get; set; }
        
        public enum DIRECCION_TIPO_ENVIO
        {
            Nacional = 1,
            International = 2
        }

        public enum DIRECCION_TIPO
        {
            Remitente = 1,
            Destinatario = 2
        }

        public BE_TIPO_SOLICITUD oBE_TIPO_SOLICITUD { get; set; }
        public BE_TIPO_DIRECCION oBE_TIPO_DIRECCION { get; set; }

        
    }
}
