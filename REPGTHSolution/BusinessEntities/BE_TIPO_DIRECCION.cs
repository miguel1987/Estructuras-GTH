using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa los tipos de direcciones
    /// </summary>
    public partial class BE_TIPO_DIRECCION : BE_GENERICO
    {
        public Nullable<Int32> CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
    }
}
