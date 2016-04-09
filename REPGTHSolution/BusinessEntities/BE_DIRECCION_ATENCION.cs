using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla DIRECCIONES de la base de datos
    /// </summary>
    public partial class BE_DIRECCION_ATENCION : BE_GENERICO
    {
        public Guid ID { get; set; }
        public Guid DIRECCION_ID { get; set; }  
        public Int32 ESTADO { get; set; }        
        public String ATENCION { get; set; }
        public String DESTINATARIO { get; set; }

        public BE_DIRECCION oBE_DIRECCION { get; set; }
        
    }
}
