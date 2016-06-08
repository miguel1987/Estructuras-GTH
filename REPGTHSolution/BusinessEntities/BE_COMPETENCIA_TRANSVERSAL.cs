using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public partial class BE_COMPETENCIA_TRANSVERSAL : BE_GENERICO
    {
        public Guid ID { get; set; }
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<Int32> ESTADO { get; set; }
    }
}
