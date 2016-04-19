using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesEntities
{
    /// <summary>
    /// Entidad que representa la tabla GRUPO_ORGANIZACIONAL
    /// </summary>
    public partial class BE_GRUPO_ORGANIZACIONAL : BE_GENERICO
    {
        public Guid ID { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Nullable<Int32> ESTADO { get; set; }
       
    }
}
