using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla CUENTAS MAYORES de la base de datos
    /// </summary>
    public partial class BE_CUENTA_MAYOR : BE_GENERICO
    {
        public Guid ID { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }       
        public Int32 ESTADO { get; set; }
        public String CODIGO_DESCRIPCION { get; set; }
    }
}
