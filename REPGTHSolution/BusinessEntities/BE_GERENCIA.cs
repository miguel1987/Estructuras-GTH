using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla GERENCIA de la base de datos
    /// </summary>
    public partial class BE_GERENCIA : BE_GENERICO
    {
        public Guid ID { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Nullable<Int32> ESTADO { get; set; }
        public Guid EMPRESA_ID { get; set; }
        public BE_EMPRESA oBE_EMPRESA { get; set; }
    }
}
