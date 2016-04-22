using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
   public class BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES:BE_GENERICO
    {
        public Guid ID { get; set; }
        public Guid PERSONAL_ID { get; set; }
        public string PERSONAL_DESCRIPCION { get; set; }
        public Guid COMPETENCIA_TRANSVERSAL_ID { get; set; }
        public decimal PORCENTAJE { get; set; }
        public Guid PUESTO_ID { get; set; }
        public string PUESTO_DESCRIPCION { get; set; }
        public int ANIO { get; set; }
        public string CODIGO { get; set; }
        
        public BE_PERSONAL oBE_PERSONAL { get; set; }

    }
}
