using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla PUESTOS de la base de datos
    /// </summary>
    public partial class BE_PUESTO : BE_GENERICO
    {
        public Guid ID { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Int32 NIVEL { get; set; }
        public Int32 ESTADO { get; set; }
        public Guid EMPRESA_ID { get; set; }
        public BE_EMPRESA oBE_EMPRESA { get; set; }
        public Guid GERENCIA_ID { get; set; }
        public BE_EMPRESA oBE_GERENCIA { get; set; }
        public Guid AREA_ID { get; set; }
        public BE_EMPRESA oBE_AREA { get; set; }
        public Guid COORDINACION_ID { get; set; }
        public BE_EMPRESA oBE_COORDINACION { get; set; }

        public BE_NIVEL_PUESTO oBE_NIVEL_PUESTO { get; set; }
        
        public enum PUESTO_NIVEL
        {
            Presidencia = 1,
            Gerencia = 2,
            Area = 3,
            Coordinacion = 4
        }
    }
}
