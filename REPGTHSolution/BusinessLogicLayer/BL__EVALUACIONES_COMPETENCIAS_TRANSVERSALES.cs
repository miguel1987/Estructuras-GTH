using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class BL__EVALUACIONES_COMPETENCIAS_TRANSVERSALES
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        //wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();
        wsMaestros.BE_PERSONAL[] oLista = null;
        
        List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();

        public List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> SeleccionarEvaluacionesTransversalesPorJerarquia(Guid jerarquia_id, int nivel)
        {

            switch (nivel)
            {
                case 0:
                    oLista = wsMantenimientoEstructuras.SeleccionarPersonalPorEmpresa(jerarquia_id);
                    break;

                case 1:
                    oLista = wsMantenimientoEstructuras.SeleccionarPersonalPorPresidencia(jerarquia_id);
                    break;

                case 2:
                    oLista = wsMantenimientoEstructuras.SeleccionarPersonalPorGerencia(jerarquia_id);

                    break;
                case 3:
                    oLista = wsMantenimientoEstructuras.SeleccionarPersonalPorArea(jerarquia_id);
                    break;
                case 4:
                    oLista = wsMantenimientoEstructuras.SeleccionarPersonalPorCoordinacion(jerarquia_id);
                    break;

            }

            //List<BE_EVALUACION_COMPETENCIA_PUESTO> oListaEvaluacionesEstado = new List<BE_EVALUACION_COMPETENCIA_PUESTO>();
            if (oLista != null)
            {               
                foreach (var item in oLista)
                {
                    BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES oEvaluacion_Competencia_Transversales = new BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES();
                    oEvaluacion_Competencia_Transversales.PERSONAL_ID = item.ID;
                    oEvaluacion_Competencia_Transversales.CODIGO = item.CODIGO_TRABAJO;
                    oEvaluacion_Competencia_Transversales.PERSONAL_DESCRIPCION = item.NOMBRES_COMPLETOS;
                    oEvaluacion_Competencia_Transversales.PUESTO_ID = item.PUESTO_ID;
                    oEvaluacion_Competencia_Transversales.PUESTO_DESCRIPCION = item.oBE_PUESTO.DESCRIPCION;
                    oEvaluacion_Competencia_Transversales.PORCENTAJE_INSPIRAR = BL__EVALUACIONES_COMPETENCIAS_TRANSVERSALES.SeleccionarEvaluacionPorCompetenciaTransversal(item.ID,(int)BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.TIPO_COMPETENCIA.INSPIRAR)*100 ;                    
                    oEvaluacion_Competencia_Transversales.PORCENTAJE_ESTRATEGICA = BL__EVALUACIONES_COMPETENCIAS_TRANSVERSALES.SeleccionarEvaluacionPorCompetenciaTransversal(item.ID,(int)BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.TIPO_COMPETENCIA.ESTRATEGICA)*100;
                    oEvaluacion_Competencia_Transversales.PORCENTAJE_CONSTRUCCION = BL__EVALUACIONES_COMPETENCIAS_TRANSVERSALES.SeleccionarEvaluacionPorCompetenciaTransversal(item.ID,(int)BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.TIPO_COMPETENCIA.CONSTRUCCION)*100;
                    oEvaluacion_Competencia_Transversales.PORCENTAJE_DECISION = BL__EVALUACIONES_COMPETENCIAS_TRANSVERSALES.SeleccionarEvaluacionPorCompetenciaTransversal(item.ID,(int)BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.TIPO_COMPETENCIA.DECISION)*100;
                    oEvaluacion_Competencia_Transversales.PORCENTAJE_RESULTADOS = BL__EVALUACIONES_COMPETENCIAS_TRANSVERSALES.SeleccionarEvaluacionPorCompetenciaTransversal(item.ID, (int)BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.TIPO_COMPETENCIA.RESULTADOS)*100;
                    oListaEvaluacionesTransversales.Add(oEvaluacion_Competencia_Transversales);

                }
            }


            return oListaEvaluacionesTransversales;

        }

        public static  decimal SeleccionarEvaluacionPorCompetenciaTransversal(Guid PERSONAL_ID, int COMPETENCIA_TRANSVERSALES_CODIGO)
        {
            return DA_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.SeleccionarEvaluacionPorCompetenciaTransversal(PERSONAL_ID, COMPETENCIA_TRANSVERSALES_CODIGO.ToString());
        }


    }

}
