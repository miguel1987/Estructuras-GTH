using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
  public  class BE_EVALUACION_COMPETENCIA_PUESTO:BE_GENERICO
    {
      public Guid ID { get; set; }
      public Guid PERSONAL_ID { get; set; }
      public string PERSONAL_DESCRIPCION { get; set; }
      public Guid PUESTO_ID { get; set; }
      public string PUESTO_DESCRIPCION { get; set; }
      public string CODIGO { get; set; }
      public Guid COMPETENCIA_ID { get; set; }
      public int VALOR_REAL { get; set; }
      public string COMENTARIO { get; set; }
      public int BRECHA { get; set; }
      public Nullable<Int32> ESTADO { get; set; }
      public string ESTADO_DESCRIPCION { get; set; }
      public int AÑO { get; set; }
      public string AREA { get; set; }
      public BE_PERSONAL oBE_PERSONAL { get; set; }

      public enum ESTADO_EVALUACION
      {
          Pendiente = 0,
          En_Evaluacion = 1,
          Evaluado = 2
      }

      public enum PERSONAL_CODIGO
      {
              GE=1,
              SE=2,
              JD=3,
              CO=4
      
      }

    }
}
