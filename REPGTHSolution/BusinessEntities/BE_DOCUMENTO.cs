using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla DOCUMENTOS de la base de datos
    /// </summary>
    public partial class BE_DOCUMENTO : BE_GENERICO
    {
        public Guid ID { get; set; }
        public Guid SOLICITUD_ID { get; set; }
        public String NOMBRE { get; set; }
        public String DESCRIPCION { get; set; }
        public String FECHA_REGISTRO { get; set; }
        public String URL { get; set; }
    }
}
