using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;

namespace BussinesEntities
{
    public partial class BE_COORDINACION_PUESTO : BE_GENERICO
    {
        public Guid ID { get; set; } 
        public Guid PUESTO_ID { get; set; }
        public Guid EMPRESA_ID { get; set; }
        public Guid PRESIDENCIA_ID { get; set; }
        public Guid GERENCIA_ID { get; set; }
        public Guid AREA_ID { get; set; }
        public Guid COORDINACION_ID { get; set; }
        

    }
}
