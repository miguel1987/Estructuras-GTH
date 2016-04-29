using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class BL_COMPETENCIAS_TIPOS
    {
        /// <summary>
        ///  Devuelve los datos de todas las competencias por tipos.
        /// </summary>
        /// <returns> List de BE_COMPETENCIAS_TIPOS con los objetos de la entidad, que a su vez representan la tabla COMPETENCIAS_TIPOS de la base de datos.En caso no haiga datos devuelve nothing </returns>
       public static List<BE_COMPETENCIAS_TIPOS> SeleccionarCompetenciasTipos()
        {
            return new DA_COMPETENCIAS_TIPOS().SeleccionarCompetenciasTipos();
        }
    }
}
