using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla CENTROS DE COSTOS de la base de datos
    /// </summary>
    public partial class BE_CENTRO_COSTO : BE_GENERICO
    {
        public Guid ID { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Guid AREA_ID { get; set; }
        public Guid EMPRESA_ID { get; set; }
        public Guid GERENCIA_ID { get; set; }
        public Int32 ESTADO { get; set; }
        public String CODIGO_DESCRIPCION { get; set; }        
        public BE_AREA oBE_AREA{ get; set; }
        public BE_GERENCIA oBE_GERENCIA { get; set; }
        public BE_EMPRESA oBE_EMPRESA { get; set; }
    }
}
