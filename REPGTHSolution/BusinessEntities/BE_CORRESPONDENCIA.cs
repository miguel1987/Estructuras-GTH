using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla CORRESPONDENCIA de la base de datos
    /// </summary>
    public partial class BE_CORRESPONDENCIA : BE_GENERICO
    {
        public Guid ID { get; set; }
        public Guid SOLICITUD_ID { get; set; }
        public Int32 TIPO_ENVIO { get; set; }
        public Int32 TIPO { get; set; }
        public Int32 CARACTERISTICA { get; set; }
        public Nullable<Guid> PROVEEDOR_ID { get; set; }
        public String ORDEN_PROVEEDOR { get; set; }
        public String FECHA_ENVIO { get; set; }
        public String REMITENTE { get; set; }
        public Guid DIRECCION_REMITENTE_ID { get; set; }
        public Nullable<Decimal> CANTIDAD { get; set; }
        public Nullable<Decimal> PESO { get; set; }
        public Nullable<Decimal> COSTO { get; set; }
        public String CONTENIDO { get; set; }
        public String GUIA { get; set; }
        public String DESTINATARIO { get; set; }
        public Guid DIRECCION_DESTINATARIO_ID { get; set; }        
        public String ATENCION { get; set; }
        public String MEDIDAS { get; set; }
        public String COSTO_DECLARAR { get; set; }
        public String TELEFONO { get; set; }
        public String PAIS { get; set; }
        public String ESTADO_PROVINCIA { get; set; }
        public String CIUDAD { get; set; }
        public String CODIGO_POSTAL { get; set; }       
        public Nullable<Int32> ESTADO { get; set; }
        public Guid ATENCION_ID { get; set; }



    }
}
