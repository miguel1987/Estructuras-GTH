using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class BL_IMPORTAR_EVALUACIONES_TRANSVERSALES
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  

        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();
        public BE_PERSONAL SeleccionarPersonalporCodigo(string Codigo_Personal)
        {
         wsMaestros.BE_PERSONAL oLista = wsMantenimientoEstructuras.SeleccionarPersonalPorCodigo(Codigo_Personal);
         BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
         if (oLista != null)
         {

             oBE_PERSONAL.ID = oLista.ID;
             oBE_PERSONAL.PUESTO_ID = oLista.PUESTO_ID;
             oBE_PERSONAL.USUARIO_CREACION = oLista.USUARIO_CREACION;
             oBE_PERSONAL.USUARIO_ACTUALIZACION = oLista.USUARIO_ACTUALIZACION;
         
         
         }
         return oBE_PERSONAL;
            
        }

        public static string seleccionarporCodigo(string codigo_competencia)
        {
            DA_IMPORTAR_EVALUACIONES_TRANSVERSALES DA_IMPORTAR_EVALUACIONES_TRANSVERSALES=new DA_IMPORTAR_EVALUACIONES_TRANSVERSALES();
            return DA_IMPORTAR_EVALUACIONES_TRANSVERSALES.EvaluacionSeleccionarporCodigo(codigo_competencia);
        
        
        }


        public static Boolean InsertarEvaluacionTransversales(BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES OBE_COMPE_TRANS)
        {
            DA_IMPORTAR_EVALUACIONES_TRANSVERSALES DA_IMPORTAR_EVALUACIONES_TRANSVERSALES = new DA_IMPORTAR_EVALUACIONES_TRANSVERSALES();
            return DA_IMPORTAR_EVALUACIONES_TRANSVERSALES.InsertarTransversales(OBE_COMPE_TRANS);
        
        
        }



    }
}
