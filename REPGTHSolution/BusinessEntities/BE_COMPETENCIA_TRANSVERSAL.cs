using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla COMPETENCIAS TRANSVERSALES de la base de datos
    /// </summary>
    public partial class BE_COMPETENCIA_TRANSVERSAL : BE_GENERICO
    {
        public Guid ID { get; set; }
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<Int32> ESTADO { get; set; }
    }
}
