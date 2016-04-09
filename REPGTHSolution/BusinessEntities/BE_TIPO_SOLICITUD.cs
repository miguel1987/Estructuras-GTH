using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa los tipos de solicitudes
    /// </summary>
    public partial class BE_TIPO_SOLICITUD : BE_GENERICO
    {
        public Nullable<Int32> CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
       
    }
}
