using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla PROVEEDORES
    /// </summary>
    public partial class BE_PROVEEDOR : BE_GENERICO
    {
        public Guid ID { get; set; }
        public String DESCRIPCION { get; set; }
        public Nullable<Int32> TIPO { get; set; }
        public Nullable<Int32> ESTADO { get; set; }
        public enum TIPO_PROVEEDOR
        {
            Nacional = 1,
            International = 2
        }
        public BE_TIPO_SOLICITUD oBE_TIPO_SOLICITUD { get; set; }
        
    }
}
