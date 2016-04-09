using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla PERSONAL de la base de datos
    /// </summary>
    public partial class BE_PERSONAL : BE_GENERICO
    {

        public Guid ID { get; set; }
        public String CODIGO_TRABAJO { get; set; }
        public String APELLIDO_PATERNO { get; set; }
        public String APELLIDO_MATERNO { get; set; }
        public String NOMBRES { get; set; }
        public String NOMBRES_COMPLETOS { get; set; }
        public Nullable<Guid> GERENCIA { get; set; }
        public Nullable<Guid> AREA { get; set; }
        public String DEPARTAMENTO { get; set; }
        public String PUESTO { get; set; }
        public String CORREO { get; set; }
        public Nullable<Int32> ESTADO { get; set; }
        public Guid GERENCIA_ID { get; set; }
        public Guid AREA_ID { get; set; }
        public BE_GERENCIA oBE_GERENCIA { get; set; }
        public BE_AREA oBE_AREA { get; set; }
        public BE_PERFILES oBE_PERFILES { get; set; }
        public Int32 PERFIL_ID { get; set; }
        public Int32 ES_JEFE { get; set; }
        public Nullable<Guid> EMPRESA { get; set; }
        public Guid EMPRESA_ID { get; set; }
        public BE_EMPRESA oBE_EMPRESA { get; set; }
        public String NOMBRES_COMPLETOS_EMAIL { get; set; }


        //Campos que no pertenece a la tabla
        public String APELLIDOSYNOMBRESCOMPLETOS
        {
            get
            {
                return String.Concat(APELLIDO_PATERNO, " ", APELLIDO_MATERNO, ", ", NOMBRES);
            }
        }
        public String NOMBRE_USUARIO { get; set; }

        public BE_TIPO_JEFE oBE_TIPO_JEFE { get; set; }
      
    }
}
