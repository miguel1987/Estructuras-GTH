using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla COMPETENCIAS TIPOS de la base de datos
    /// </summary>
   public  class BE_COMPETENCIAS_TIPOS:BE_GENERICO
    {
       
      public Guid ID { get; set; }
      public string COMPETENCIA_TIPO_CODIGO { get; set; }
      public string COMPETENCIA_TIPO_DESCRIPCION { get; set; }
      public int COMPETENCIA_TIPO_ESTADO { get; set; }
    }
}
