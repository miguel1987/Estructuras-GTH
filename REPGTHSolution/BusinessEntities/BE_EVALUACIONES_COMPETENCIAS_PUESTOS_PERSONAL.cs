using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
   public class BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL:BE_GENERICO
    {
       public Guid ID { get; set; }
       public Guid PERSONAL_ID { get; set; }
       public Guid PUESTO_ID { get; set; }
       public Guid COMPETENCIA_ID { get; set; }
       public int REAL { get; set; }
       public string COMENTARIO { get; set; }
       public int BRECHA { get; set; }
       public int ESTADO_EVALUACION { get; set; }
       public int ANIO_EVALUACION { get; set; }
    }
}
