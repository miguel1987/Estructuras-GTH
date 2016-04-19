using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesEntities
{
    /// <summary>
    /// Entidad que tiene los artributos mas comunes entre todas las tablas
    /// </summary>
    public class BE_GENERICO
    {
        public Guid  USUARIO_CREACION {get; set;}
        public DateTime FECHA_CREACION{get; set;}
        public  Nullable<Guid> USUARIO_ACTUALIZACION{get; set;}
        public DateTime FECHA_ACTUALIZACION{get ; set;}
    }
}
