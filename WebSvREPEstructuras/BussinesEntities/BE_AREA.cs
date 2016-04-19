using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesEntities
{
    /// <summary>
    /// Entidad que representa la tabla Areas
    /// </summary>
    public partial class BE_AREA:BE_GENERICO
    {
        public Guid ID { get; set; }
        public Guid GERENCIA_ID{get; set;}
        public String CODIGO { get; set; }
        public String DESCRIPCION {get; set;}
        public Int32 ESTADO {get; set;}
        public BE_GERENCIA oBE_GERENCIA { get; set;}
    }
}
