using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa si el personal es o no jefe
    /// </summary>
    public partial class BE_TIPO_JEFE : BE_GENERICO
    {
        public Nullable<Int32> CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
    }
}
