using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BL_EVALUACIONES_COMPETENCIAS_POR_PUESTO
    {

        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        //wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();
        wsMaestros.BE_PUESTO[] oListaPorPuesto = null;

        public List<BE_PUESTO> SeleccionarPuestosPorJerarquia(Guid jerarquia_id, int nivel)
        {
            List<BE_PUESTO> oListaPuesto = new List<BE_PUESTO>();


            switch (nivel)
            {
                case 0:
                    oListaPorPuesto = wsMantenimientoEstructuras.SeleccionarPuestos();
                    

                    break;

                case 1:
                    oListaPorPuesto = wsMantenimientoEstructuras.SeleccionarPuestoPorPresidencia(jerarquia_id);
                    break;

                case 2:
                    oListaPorPuesto = wsMantenimientoEstructuras.SeleccionarPuestoPorGerencia(jerarquia_id);

                    break;
                case 3:
                    oListaPorPuesto = wsMantenimientoEstructuras.SeleccionarPuestoPorArea(jerarquia_id);
                   
                    break;
                case 4:
                    oListaPorPuesto = wsMantenimientoEstructuras.SeleccionarPuestoPorCoordinacion(jerarquia_id);
                    break;

            }

            if (oListaPorPuesto != null)
            {
                foreach (var itemPuesto in oListaPorPuesto)
                {
                    BE_PUESTO oBE_PUESTO = new BE_PUESTO();
                    oBE_PUESTO.CODIGO = itemPuesto.CODIGO;
                    oBE_PUESTO.DESCRIPCION = itemPuesto.DESCRIPCION;
                    oBE_PUESTO.ESTADO = itemPuesto.ESTADO;
                    oBE_PUESTO.ID = itemPuesto.ID;
                    oListaPuesto.Add(oBE_PUESTO);
                }
            }
            return oListaPuesto;


        }


        public List<BE_EVALUACION_COMPETENCIA_PUESTO> SeleccionarEvaluaciones(Guid puesto_id, Guid competencia_tipo_id)
        {
            wsMaestros.BE_PERSONAL[] oListaPersonalPorPuesto = null;
            List<BE_COMPETENCIAS_POR_PUESTO> oListaCompPorPuesto = new List<BE_COMPETENCIAS_POR_PUESTO>();
            List<BE_EVALUACION_COMPETENCIA_PUESTO> oListaEvaluacionesPorPuesto = new List<BE_EVALUACION_COMPETENCIA_PUESTO>();
            //puesto_id=Guid.Parse("06762B1D-4C71-4A85-8461-1AFDF176A31F");
            oListaPersonalPorPuesto = wsMantenimientoEstructuras.SeleccionarPersonalPorPuesto(puesto_id);

            if (oListaPersonalPorPuesto != null)
            {
                foreach (var item in oListaPersonalPorPuesto)
                {

                    BE_EVALUACION_COMPETENCIA_PUESTO BE_EVALUACION_COMPETENCIA_PUESTO = new BE_EVALUACION_COMPETENCIA_PUESTO();
                    BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_DESCRIPCION = item.NOMBRES_COMPLETOS;
                    BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_ID = item.ID;



                    oListaCompPorPuesto = BL_COMPETENCIAS_POR_PUESTO.SeleccionarCompetenciasPorPuestoyTipo(puesto_id, competencia_tipo_id, item.ID);
                    if (oListaCompPorPuesto != null)
                    {
                        foreach (var competencia in oListaCompPorPuesto)
                        {
                            BE_EVALUACION_COMPETENCIA_PUESTO oBE_EVALUACION_COMPETENCIA_POR_PUESTO = new BE_EVALUACION_COMPETENCIA_PUESTO();
                            oBE_EVALUACION_COMPETENCIA_POR_PUESTO.COMPETENCIA_DESCRIPCION = competencia.COMPETENCIA_DESCRIPCION;
                            oBE_EVALUACION_COMPETENCIA_POR_PUESTO.VALOR_REAL = competencia.REAL;
                            oBE_EVALUACION_COMPETENCIA_POR_PUESTO.BRECHA = competencia.BRECHA;
                            oBE_EVALUACION_COMPETENCIA_POR_PUESTO.PERSONAL_DESCRIPCION = item.NOMBRES_COMPLETOS;
                            oBE_EVALUACION_COMPETENCIA_POR_PUESTO.VALOR_REQUERIDO = competencia.COMPETENCIA_PUESTO_VALOR_REQUERIDO;

                            oListaEvaluacionesPorPuesto.Add(oBE_EVALUACION_COMPETENCIA_POR_PUESTO);

                        }



                    }


                }
            
            }

            return oListaEvaluacionesPorPuesto;


            










        }









    }
}
