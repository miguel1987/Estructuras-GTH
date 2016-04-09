using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa los destinatarios de las solicitudes
    /// </summary>
    public partial class BE_DESTINATARIO : BE_GENERICO
    {
        public String NOMBRE { get; set; }
        public String DIRECCION { get; set; }
        public Guid DIRECCION_ID { get; set; }

    }
}
