using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla PERFILES de la base de datos
    /// </summary>
    public partial class BE_PERFILES : BE_GENERICO
    {
        public Int32 ID { get; set; }
        public String DESCRIPCION { get; set; }
    }
}
