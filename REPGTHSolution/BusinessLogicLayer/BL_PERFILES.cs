using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BL_PERFILES
    {
        /// <summary>
        /// Devuelve los datos de todos los perfiles
        /// </summary>
        /// <returns></returns>
        public static List<BE_PERFILES> SeleccionarPERFILES()
        {
            return new DA_PERFILES().SeleccionarPerfiles();
        }
    }
}
