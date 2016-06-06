using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
  public class BE_PUESTO
    {
        public Guid ID { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Int32 NIVEL { get; set; }
        public Int32 ESTADO { get; set; }
        //public List<BE_COORDINACION_PUESTO> lstBE_COORDINACION_PUESTO { get; set; }
        public List<BE_GERENCIA> lstBE_GERENCIA { get; set; }
        public List<BE_AREA> lstBE_AREA { get; set; }
        public List<BE_COORDINACION> lstBE_COORDINACION { get; set; }

        public enum PUESTO_NIVEL
        {
            Presidencia = 1,
            Gerencia = 2,
            Area = 3,
            Coordinacion = 4
        }
    }
}
