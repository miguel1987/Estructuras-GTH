using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL
    /// </summary>
    public class BL_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL
    {
        /// <summary>
        /// Inserta los datos de una solicitud
        /// </summary>
        /// <param name="oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL">Entidad BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL, que representa la tabla EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL, con todos sus atributos </param>
        /// <returns>Guid. Guid, si se ingreso con exito. Null, si hubo un error al ingresar</returns>
        public static Guid InsertarEvaluacionCompetenciasPuestosPersonal(BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL)
        {
            return new DA_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL().InsertarEvaluacionCompetenciaPuestoPersonal(oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL);
        }


        public bool  ActualizarEvaluacionCompetenciasPuestosPersonal(BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL)
        {
            return new DA_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL().ActualizarEvaluacionCompetenciaPuestoPersonal(oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL);
        }


        public bool ActualizarEvaluacionFinal(BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL)
        {
            return new DA_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL().ActualizarEvaluacionFinal(oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL);
        }
    }
}
