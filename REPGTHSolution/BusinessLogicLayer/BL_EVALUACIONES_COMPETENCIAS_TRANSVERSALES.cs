using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES
    {
       
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        //wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();
        wsMaestros.BE_PERSONAL[] oListaPorEmpresa, oListaPorPresidencia, oListaPorGerencia, oListaPorArea, oListaPorCoordinacion = null;
        wsMaestros.BE_COORDINACION[] oListaCoordinaciones = null;
        wsMaestros.BE_GERENCIA[] oListaGerencias = null;
        DA_EVALUACION_COMPETENCIA_PUESTO DA_COMPETENCIA_PUESTO = new DA_EVALUACION_COMPETENCIA_PUESTO();

       

        public List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> SeleccionarEvaluacionesTransversalesPorJerarquia(Guid jerarquia_id, int nivel)
        {
            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
            

            switch (nivel)
            {
                case 0:
                    oListaPorEmpresa = wsMantenimientoEstructuras.SeleccionarPersonalPorEmpresa(jerarquia_id);
                    break;

                case 1:
                    oListaPorPresidencia = wsMantenimientoEstructuras.SeleccionarPersonalPorPresidencia(jerarquia_id);
                    break;

                case 2:
                    oListaPorGerencia = wsMantenimientoEstructuras.SeleccionarPersonalPorGerencia(jerarquia_id);
                    oListaGerencias = wsMantenimientoEstructuras.SeleccionarGerenciaPorId(jerarquia_id);
                    break;
                case 3:
                    oListaPorArea = wsMantenimientoEstructuras.SeleccionarPersonalPorArea(jerarquia_id);
                    oListaCoordinaciones = wsMantenimientoEstructuras.SeleccionarCoordinacionesPorArea(jerarquia_id);
                    break;
                case 4:
                    oListaPorCoordinacion = wsMantenimientoEstructuras.SeleccionarPersonalPorCoordinacion(jerarquia_id);
                    break;

            }

            
            if (oListaPorEmpresa != null)
            {
                foreach (var item in oListaPorEmpresa)
                {
                    List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                    oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                    oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);                
                              
                }
            }
             


             if (oListaPorPresidencia != null)
             {
                 foreach (var item in oListaPorPresidencia)
                 {
                     List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                     oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                     oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);                   

                 }
             }


             if (oListaPorGerencia != null)
             {
                 foreach (var item in oListaPorGerencia)
                 {
                     if (item.oBE_GRUPO_ORGANIZACIONAL != null)
                     {
                         if (oListaGerencias[0].CODIGO == BE_GERENCIA.CODIGO_GERENCIA.GN.ToString())
                         {
                             if (item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.GE.ToString() || item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.JD.ToString() || item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.SE.ToString() || item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.CO.ToString())
                             {
                                 List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                                 oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                                 oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);

                             }
                             
                         }
                         else if (oListaGerencias[0].CODIGO == BE_GERENCIA.CODIGO_GERENCIA.AI.ToString() || oListaGerencias[0].CODIGO == BE_GERENCIA.CODIGO_GERENCIA.AJ.ToString() || oListaGerencias[0].CODIGO == BE_GERENCIA.CODIGO_GERENCIA.CC.ToString())
                         {

                             List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                             oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                             oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);
                         }
                         else
                         {                             

                             if (item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.GE.ToString() || item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.JD.ToString() || item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.SE.ToString())
                             {
                                 List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                                 oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                                 oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);

                             }

                         }

                     }
                 }
             }
            
            if (oListaPorArea != null)
            {
                foreach (var item in oListaPorArea)
                {
                    if (oListaCoordinaciones != null)
                    {
                        if (item.oBE_GRUPO_ORGANIZACIONAL != null)
                        {
                            if (item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.JD.ToString() || item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.CO.ToString() || item.oBE_COORDINACION == null)
                            {
                                List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                                oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                                oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);
                            }
                        }
                    }
                    else
                    {
                        List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                        oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                        oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);
                    }
                }
            }


            if (oListaPorCoordinacion != null)
            {
                foreach (var item in oListaPorCoordinacion)
                {
                    if (item.oBE_GRUPO_ORGANIZACIONAL != null)
                    {
                        if (item.oBE_GRUPO_ORGANIZACIONAL.CODIGO != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.CO.ToString())
                        {
                            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                            oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                            oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);
                        }


                        else
                        {
                            if (item.oBE_GRUPO_ORGANIZACIONAL.CODIGO != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.JD.ToString())
                            {
                                List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                                oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                                oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);
                            }
                        }
                    }


                }
            }


             return oListaEvaluacionesTransversales;

        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="item"></param>
       /// <returns></returns>
       /// 

        public List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> SeleccionarEvaluacionesTransversalesPorJerarquia(Guid jerarquia_id, int nivel,Guid usuario_id)
        {
            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();


            switch (nivel)
            {
                case 0:
                    oListaPorEmpresa = wsMantenimientoEstructuras.SeleccionarPersonalPorEmpresa(jerarquia_id);
                    break;

                case 1:
                    oListaPorPresidencia = wsMantenimientoEstructuras.SeleccionarPersonalPorPresidencia(jerarquia_id);
                    break;

                case 2:
                    oListaPorGerencia = wsMantenimientoEstructuras.SeleccionarPersonalPorGerencia(jerarquia_id);
                    oListaGerencias = wsMantenimientoEstructuras.SeleccionarGerenciaPorId(jerarquia_id);
                    break;
                case 3:
                    oListaPorArea = wsMantenimientoEstructuras.SeleccionarPersonalPorArea(jerarquia_id);
                    oListaCoordinaciones = wsMantenimientoEstructuras.SeleccionarCoordinacionesPorArea(jerarquia_id);
                    break;
                case 4:
                    oListaPorCoordinacion = wsMantenimientoEstructuras.SeleccionarPersonalPorCoordinacion(jerarquia_id);
                    break;

            }


            if (oListaPorEmpresa != null)
            {
                foreach (var item in oListaPorEmpresa)
                {
                    List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                    oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                    oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);

                }
            }



            if (oListaPorPresidencia != null)
            {
                foreach (var item in oListaPorPresidencia)
                {
                    List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                    oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                    oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);

                }
            }


            if (oListaPorGerencia != null)
            {
                foreach (var item in oListaPorGerencia)
                {
                    if (item.oBE_GRUPO_ORGANIZACIONAL != null)
                    {
                        if (oListaGerencias[0].CODIGO == BE_GERENCIA.CODIGO_GERENCIA.GN.ToString())
                        {
                            if (item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.GE.ToString() || item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.JD.ToString() || item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.SE.ToString() || item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.CO.ToString())
                            {
                                List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                                oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                                oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);

                            }

                        }
                        else if (oListaGerencias[0].CODIGO == BE_GERENCIA.CODIGO_GERENCIA.AI.ToString() || oListaGerencias[0].CODIGO == BE_GERENCIA.CODIGO_GERENCIA.AJ.ToString() || oListaGerencias[0].CODIGO == BE_GERENCIA.CODIGO_GERENCIA.CC.ToString())
                        {

                            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                            oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                            oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);
                        }
                        else
                        {

                            if (item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.GE.ToString() || item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.JD.ToString() || item.oBE_GRUPO_ORGANIZACIONAL.CODIGO == BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.SE.ToString())
                            {
                                List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                                oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                                oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);

                            }

                        }

                    }
                }
            }

            if (oListaPorArea != null)
            {
                foreach (var item in oListaPorArea)
                {
                    if (oListaCoordinaciones != null)
                    {
                        if (item.oBE_GRUPO_ORGANIZACIONAL != null)
                        {
                            if (item.oBE_GRUPO_ORGANIZACIONAL.CODIGO!= BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.GE.ToString() && item.oBE_GRUPO_ORGANIZACIONAL.CODIGO!= BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.JD.ToString() && item.oBE_GRUPO_ORGANIZACIONAL.CODIGO != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.CO.ToString())
                            {
                                List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                                oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item,usuario_id);
                                oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);
                            }
                        }
                    }
                    else
                    {
                        if (item.oBE_GRUPO_ORGANIZACIONAL.CODIGO != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.GE.ToString() && item.oBE_GRUPO_ORGANIZACIONAL.CODIGO != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.JD.ToString() && item.oBE_GRUPO_ORGANIZACIONAL.CODIGO != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.CO.ToString())
                        {
                            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                            oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item,usuario_id);
                            oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);
                        }
                    }
                }
            }


            if (oListaPorCoordinacion != null)
            {
                foreach (var item in oListaPorCoordinacion)
                {
                    if (item.oBE_GRUPO_ORGANIZACIONAL != null)
                    {
                        if (item.oBE_GRUPO_ORGANIZACIONAL.CODIGO != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.GE.ToString() && item.oBE_GRUPO_ORGANIZACIONAL.CODIGO != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.JD.ToString() && item.oBE_GRUPO_ORGANIZACIONAL.CODIGO != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.CO.ToString())
                        {
                            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                            oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item,usuario_id);
                            oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);
                        }


                        else
                        {
                            if (item.oBE_GRUPO_ORGANIZACIONAL.CODIGO != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.GE.ToString() && item.oBE_GRUPO_ORGANIZACIONAL.CODIGO != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.JD.ToString() && item.oBE_GRUPO_ORGANIZACIONAL.CODIGO != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.CO.ToString())
                            {
                                List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                                oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item,usuario_id);
                                oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);
                            }
                        }
                    }


                }
            }


            return oListaEvaluacionesTransversales;

        }





       ///////////////

        protected List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> CargarListaEvaluaciones(wsMaestros.BE_PERSONAL item)
        {
            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaCompetenciaEvaluaciones = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();

            oListaCompetenciaEvaluaciones = BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.SeleccionarCompetenciasTransversalesPorPersonal(item.ID);
            if (oListaCompetenciaEvaluaciones != null)
            {
                foreach (var itemevaluaciones in oListaCompetenciaEvaluaciones)
                {
                    BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES oEvaluacion_Competencia_Transversales = new BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES();
                    oEvaluacion_Competencia_Transversales.PERSONAL_ID = item.ID;
                    oEvaluacion_Competencia_Transversales.CODIGO = item.CODIGO_TRABAJO;
                    oEvaluacion_Competencia_Transversales.PERSONAL_DESCRIPCION = item.NOMBRES_COMPLETOS;
                    oEvaluacion_Competencia_Transversales.PUESTO_ID = item.PUESTO_ID;
                    oEvaluacion_Competencia_Transversales.PUESTO_DESCRIPCION = item.oBE_PUESTO.DESCRIPCION;
                    oEvaluacion_Competencia_Transversales.COMPETENCIA_TRANSVERSAL_DESCRIPCION = itemevaluaciones.COMPETENCIA_TRANSVERSAL_DESCRIPCION;
                    oEvaluacion_Competencia_Transversales.PORCENTAJE = itemevaluaciones.PORCENTAJE;
                    oListaEvaluacionesTransversales.Add(oEvaluacion_Competencia_Transversales);
                }
            }
            
            return oListaEvaluacionesTransversales;

        }

        protected List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> CargarListaEvaluaciones(wsMaestros.BE_PERSONAL item, Guid usuario_id)
        {
            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaCompetenciaEvaluaciones = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();

            oListaCompetenciaEvaluaciones = BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.SeleccionarCompetenciasTransversalesPorPersonal(item.ID);
            if (oListaCompetenciaEvaluaciones != null)
            {
                foreach (var itemevaluaciones in oListaCompetenciaEvaluaciones)
                {
                    if (item.ID == usuario_id)
                    {
                        BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES oEvaluacion_Competencia_Transversales = new BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES();
                        oEvaluacion_Competencia_Transversales.PERSONAL_ID = item.ID;
                        oEvaluacion_Competencia_Transversales.CODIGO = item.CODIGO_TRABAJO;
                        oEvaluacion_Competencia_Transversales.PERSONAL_DESCRIPCION = item.NOMBRES_COMPLETOS;
                        oEvaluacion_Competencia_Transversales.PUESTO_ID = item.PUESTO_ID;
                        oEvaluacion_Competencia_Transversales.PUESTO_DESCRIPCION = item.oBE_PUESTO.DESCRIPCION;
                        oEvaluacion_Competencia_Transversales.COMPETENCIA_TRANSVERSAL_DESCRIPCION = itemevaluaciones.COMPETENCIA_TRANSVERSAL_DESCRIPCION;
                        oEvaluacion_Competencia_Transversales.PORCENTAJE = itemevaluaciones.PORCENTAJE;
                        oListaEvaluacionesTransversales.Add(oEvaluacion_Competencia_Transversales);
                    }
                }
            }

            return oListaEvaluacionesTransversales;

        }


        public static  decimal SeleccionarEvaluacionPorCompetenciaTransversal(Guid PERSONAL_ID, int COMPETENCIA_TRANSVERSALES_CODIGO)
        {
            return DA_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.SeleccionarEvaluacionPorCompetenciaTransversal(PERSONAL_ID, COMPETENCIA_TRANSVERSALES_CODIGO.ToString());
        }


        public static List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> SeleccionarCompetenciasTransversalesPorPersonal(Guid PERSONAL_ID)
        {
            return DA_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.SeleccionarCompetenciasTransversalesPorPersonal(PERSONAL_ID);
        }

        public static int ParametroSistemaporValor(String PARAMETRO_DESCRIPCION)
        {
            return DA_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ParametroSistemaporValor(PARAMETRO_DESCRIPCION);
        
        
        }

       

        public static string ParametroSistemaporValorColor(String PARAMETRO_COLOR)
        {
            return DA_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ParametroSistemaporValorColor(PARAMETRO_COLOR);


        }




        public List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> CalcularIndicadorporGerencia(Guid jerarquia_id, int nivel)
        {
            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();


            switch (nivel)
            {
                case 0:
                    oListaPorEmpresa = wsMantenimientoEstructuras.SeleccionarPersonalPorEmpresa(jerarquia_id);
                    break;

                case 1:
                    oListaPorPresidencia = wsMantenimientoEstructuras.SeleccionarPersonalPorPresidencia(jerarquia_id);
                    break;

                case 2:
                    oListaPorGerencia = wsMantenimientoEstructuras.SeleccionarPersonalPorGerencia(jerarquia_id);

                    break;
                case 3:
                    oListaPorArea = wsMantenimientoEstructuras.SeleccionarPersonalPorArea(jerarquia_id);
                    
                    break;
                case 4:
                    oListaPorCoordinacion = wsMantenimientoEstructuras.SeleccionarPersonalPorCoordinacion(jerarquia_id);
                    break;

            }
                  


            if (oListaPorGerencia != null)
            {
                foreach (var item in oListaPorGerencia)
                {
                   
                            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                            oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                            oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);

                       
                    


                }
            }

            if (oListaPorArea != null)
            {
                foreach (var item in oListaPorArea)
                {

                    List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Temp = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                    oListaEvaluacionesTransversales_Temp = CargarListaEvaluaciones(item);
                    oListaEvaluacionesTransversales.AddRange(oListaEvaluacionesTransversales_Temp);

                }
            }


            


            return oListaEvaluacionesTransversales;

        }


    }

}
