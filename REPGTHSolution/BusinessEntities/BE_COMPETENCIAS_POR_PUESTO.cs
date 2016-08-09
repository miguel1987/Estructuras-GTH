using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla COMPETENCIAS POR PUESTO de la base de datos
    /// </summary>
  public  class BE_COMPETENCIAS_POR_PUESTO:BE_GENERICO
    {
        public Guid ID { get; set; }
        public Guid COMPETENCIA_ID { get; set; }
        public string COMPETENCIA_DESCRIPCION { get; set; }
        public int COMPETENCIA_PUESTO_VALOR_REQUERIDO { get; set; }
        public Guid EMPRESA_ID;
        public Guid PUESTO_ID;
        public BE_EMPRESA oBE_EMPRESA { get; set; }
        public BE_PUESTO oBE_PUESTO { get; set; }
        public BE_COMPETENCIA oBE_COMPETENCIA { get; set; }
        public BE_PERSONAL oBE_PERSONAL { get; set; }   

        public int REAL { get; set; }
        public string COMENTARIO { get; set; }
        public int BRECHA { get; set; }
        public int ESTADO_EVALUACION { get; set; }
        public int ANIO_EVALUACION { get; set; }
        public int EVALUAR { get; set; }
    }
}
