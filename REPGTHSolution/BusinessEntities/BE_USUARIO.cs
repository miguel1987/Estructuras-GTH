using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla USUARIOS
    /// </summary>
    public partial class BE_USUARIO : BE_GENERICO
    {
        public Guid USUARIO_ID { get; set; }
        public Nullable<Guid> PERSONAL_ID { get; set; }
        public BE_PERFILES oBE_PERFILES { get; set; }
        public Int32 PERFIL_ID { get; set; }

       public BE_PERSONAL oBE_PERSONAL { get; set; }
    }
}
