using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla PARAMETROS SISTEMA de la base de datos
    /// </summary>
    public partial class BE_PARAMETRO : BE_GENERICO
    {
        public Guid ID { get; set; }
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
        public string VALOR { get; set; }        
    }
}
