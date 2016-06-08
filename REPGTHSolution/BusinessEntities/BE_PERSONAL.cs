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
        public Guid PUESTO_ID { get; set; }
        public BE_PUESTO oBE_PUESTO { get; set; }
        public String PUESTO { get; set; }
        public String CORREO { get; set; }
        public Nullable<Int32> ESTADO { get; set; }
        public Guid GERENCIA_ID { get; set; }
        public Guid AREA_ID { get; set; }
        public BE_GERENCIA oBE_GERENCIA { get; set; }
        public BE_AREA oBE_AREA { get; set; }
        public BE_PERFILES oBE_PERFILES { get; set; }
        public Int32 PERFIL_ID { get; set; }        
        public Nullable<Guid> EMPRESA { get; set; }
        public Guid EMPRESA_ID { get; set; }        
        public BE_EMPRESA oBE_EMPRESA { get; set; }
        public Guid COORDINACION_ID { get; set; }
        public BE_COORDINACION oBE_COORDINACION { get; set; }
        public Guid SEDE_ID { get; set; }
        public BE_SEDE oBE_SEDE { get; set; }
        public Guid GRUPO_ORGANIZACIONAL_ID { get; set; }
        public BE_GRUPO_ORGANIZACIONAL oBE_GRUPO_ORGANIZACIONAL { get; set; }
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
      
    }
}
