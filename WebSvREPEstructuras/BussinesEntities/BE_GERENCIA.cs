using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BussinesEntities
{
    /// <summary>
    /// Entidad que representa la tabla GERENCIAS
    /// </summary>
    public partial class BE_GERENCIA:BE_GENERICO
    {
        public Guid ID { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Nullable<Int32> ESTADO { get; set; }
        public Guid EMPRESA_ID { get; set; }
        
    }
}