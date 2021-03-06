﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    /// <summary>
    /// Entidad que representa la tabla EVALUACIONES COMPETENCIAS PERSONAL de la base de datos
    /// </summary>
    public class BE_EVALUACIONES_COMPETENCIAS_PERSONAL
    {
        public Guid ID { get; set; }
        public Guid PERSONAL_ID { get; set; }
        public Guid COMPETENCIA_ID { get; set; }
        public int EVALUACION_COMPETENCIA_BRECHA { get; set; }
    }
}
