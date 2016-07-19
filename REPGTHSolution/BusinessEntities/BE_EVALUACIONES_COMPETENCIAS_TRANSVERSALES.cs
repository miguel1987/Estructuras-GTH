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
        public String COMPETENCIA_TRANSVERSAL_DESCRIPCION { get; set; }
        public decimal PORCENTAJE { get; set; }
        public Guid PUESTO_ID { get; set; }
        public string PUESTO_DESCRIPCION { get; set; }
        public int ANIO { get; set; }
        public string CODIGO { get; set; }
        public int VALOR { get; set; }
        public string VALOR_COLOR { get; set; }
        
        public enum TIPO_COMPETENCIA
        {
            INSPIRAR = 1353,
            ESTRATEGICA = 1354,
            CONSTRUCCION = 738,
            DECISION = 747,
            RESULTADOS = 752

        }

        public enum ESTADO_EVALUACION
        {
            Pendiente = 0,
            En_Evaluacion = 1,
            Evaluado = 2
        }

        public enum PERSONAL_CODIGO
        {
            GE = 1,
            SE = 2,
            JD = 3,
            CO = 4
        }

        public enum PARAMETRO_SISTEMA
        {            
        DESARROLLADAS,
        VERDE,
        AMARILLO        
        }

        public decimal PORCENTAJE_INSPIRAR { get; set; }
        public decimal PORCENTAJE_ESTRATEGICA { get; set; }
        public decimal PORCENTAJE_CONSTRUCCION { get; set; }
        public decimal PORCENTAJE_DECISION { get; set; }
        public decimal PORCENTAJE_RESULTADOS { get; set; }
        public int CONTADOR_INDICADOR { get; set; }
        public int Total { get; set; }
    }
}
