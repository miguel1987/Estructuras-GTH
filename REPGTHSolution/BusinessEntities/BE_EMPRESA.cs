using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla EMPRESAS
    /// </summary>
    public partial class BE_EMPRESA : BE_GENERICO
    {
        public Guid ID { get; set; }
        public String DESCRIPCION { get; set; }
        public Nullable<Int32> ESTADO { get; set; }
    }  
}
