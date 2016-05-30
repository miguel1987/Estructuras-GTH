using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class BL_COMPETENCIAS_POR_PUESTO
    {
        /// <summary>
        ///  Devuelve los datos de todos las Competencias de un Puesto
        /// </summary>
        /// <param name="puestoId">puesto id de la cual se desea consultar sus competencias</param>
        /// <param name="tipoCompetenciaId">tipo de competencia que se desea consultar</param>
        /// <returns> List de BE_COMPETENCIAS_POR_PUESTO con los objetos de la entidad, que a su vez representan la tabla CENTROS_COSTOS de la base de datos.En caso no existan datos devuelve nothing </returns>
       public static List<BE_COMPETENCIAS_POR_PUESTO> SeleccionarCompetenciasPorPuestoyTipo(Guid idPuesto, Guid idTipoCompetencia,Guid idPersonal)
        {
            return new DA_COMPETENCIAS_POR_PUESTO().SeleccionarCompetenciasPorPuestoyTipo(idPuesto, idTipoCompetencia,idPersonal);
        }


       public static int EvaluacionFinalGrabar(Guid idPuesto)
       {
           return new DA_COMPETENCIAS_POR_PUESTO().EvaluacionFinalGrabar(idPuesto);
       }
    }
}
