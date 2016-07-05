using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla GERENCIA de la base de datos
    /// </summary>
    public partial class BE_GERENCIA : BE_GENERICO
    {
        public Guid ID { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Nullable<Int32> ESTADO { get; set; }
        public Guid EMPRESA_ID { get; set; }
        public BE_EMPRESA oBE_EMPRESA { get; set; }

        public enum CODIGO_GERENCIA
        {
            GN = 1,
            GOM = 2,
            GF = 3,
            GA = 4,
            C = 5,
            GG = 6,
            GP = 7,
            AJ = 8,
            AI = 9,
            CC = 10
        }
    }
}
