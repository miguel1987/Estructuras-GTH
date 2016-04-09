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
        public static List<BE_PERFILES> SeleccionarPERFILES()
        {
            return new DA_PERFILES().SeleccionarPerfiles();
        }

    }
}
