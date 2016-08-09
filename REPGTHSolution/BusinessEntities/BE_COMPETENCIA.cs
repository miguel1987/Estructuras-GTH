using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla COMPETENCIAS de la base de datos
    /// </summary>
    public partial class BE_COMPETENCIA : BE_GENERICO
    {
        public Guid ID { get; set; }
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
        public Guid COMPETENCIA_TIPO_ID { get; set; }
        public Nullable<Int32> ESTADO { get; set; }
        public BE_COMPETENCIAS_TIPOS oBE_COMPETENCIA_TIPO { get; set; }        
    }
}
