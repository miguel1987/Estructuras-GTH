using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;

namespace BussinesEntities
{
    /// <summary>
    /// Entidad que representa la tabla COORDINACIONES
    /// </summary>
    public partial class BE_COORDINACION : BE_GENERICO
    {
        public Guid ID { get; set; }
        public Guid AREA_ID { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Int32 ESTADO { get; set; }
        public BE_AREA oBE_AREA { get; set; }
    }
}
