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
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();
        wsMaestros.BE_PERSONAL[] oListaPorEmpresa, oListaPorPresidencia, oListaPorGerencia, oListaPorArea, oListaPorCoordinacion = null;
        wsMaestros.BE_COORDINACION[] oListaCoordinaciones = null;
        wsMaestros.BE_GERENCIA[] oListaGerencias = null;
        DA_EVALUACION_COMPETENCIA_PUESTO DA_COMPETENCIA_PUESTO = new DA_EVALUACION_COMPETENCIA_PUESTO();

       /// <summary>
       /// Devuelve los datos al seleccionar las evaluaciones transversales por jerarquia
       /// </summary>
       /// <param name="jerarquia_id">id de jerarquia a consultar</param>
       /// <param name="nivel">el numero de nivel a consultar</param>
       /// <returns></returns>
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
       /// Devuelve los datos al seleccionar las evaluaciones transverales por jerarquia
       /// </summary>
       /// <param name="jerarquia_id">id de jerarquia a consultar</param>
       /// <param name="nivel">numero de nivel a consultar</param>
       /// <param name="usuario_id"> id de usuario a consultar</param>
       /// <param name="usuario_grupo_organizacional">usuario de grupo organizacional</param>
       /// <returns></returns>
        public List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> SeleccionarEvaluacionesTransversalesPorJerarquia(Guid jerarquia_id, int nivel, Guid usuario_id, String usuario_grupo_organizacional)
        {
            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
            List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oListaEvaluacionesTransversales_Filtrada = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();

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

            if (usuario_grupo_organizacional != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.GE.ToString() && usuario_grupo_organizacional != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.JD.ToString() && usuario_grupo_organizacional != BE_EVALUACION_COMPETENCIA_PUESTO.PERSONAL_CODIGO.CO.ToString())
            {
                oListaEvaluacionesTransversales_Filtrada = oListaEvaluacionesTransversales.Where(n => n.PERSONAL_ID == usuario_id).ToList();

                return oListaEvaluacionesTransversales_Filtrada;                
            }
            return oListaEvaluacionesTransversales;
        }
      
       /// <summary>
       /// Devuelve la carga de lista de evaluaciones por personal
       /// </summary>
       /// <param name="item">entidad BE_PERSONAL que representa a la tabla PERSONAL,con todos sus atributos</param>
       /// <returns></returns>
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

                    if (itemevaluaciones.PORCENTAJE * 100 >= BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ParametroSistemaporValor(BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.PARAMETRO_SISTEMA.DESARROLLADAS.ToString()))
                        oEvaluacion_Competencia_Transversales.COMPETENCIA_NO_DESARROLLADA = 0;
                    else
                        oEvaluacion_Competencia_Transversales.COMPETENCIA_NO_DESARROLLADA = 1;

                    oListaEvaluacionesTransversales.Add(oEvaluacion_Competencia_Transversales);
                }
            }
            
            return oListaEvaluacionesTransversales;
        }

       /// <summary>
       /// Devuelve la carga de lista de evaluaciones
       /// </summary>
       /// <param name="item">Entidad BE_PERSONAL que representa la tabla PERSONAL,con todos sus atributos</param>
       /// <param name="usuario_id">id de usuario a consultar</param>
       /// <returns></returns>
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

                        if (itemevaluaciones.PORCENTAJE * 100 >= BL_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ParametroSistemaporValor(BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.PARAMETRO_SISTEMA.DESARROLLADAS.ToString()))
                            oEvaluacion_Competencia_Transversales.COMPETENCIA_NO_DESARROLLADA = 0;
                        else
                            oEvaluacion_Competencia_Transversales.COMPETENCIA_NO_DESARROLLADA = 1;

                        oListaEvaluacionesTransversales.Add(oEvaluacion_Competencia_Transversales);
                    }
                }
            }

            return oListaEvaluacionesTransversales;
        }

       /// <summary>
       /// Devuelve los datos al seleccionar las evaluaciones por competencia transversal
       /// </summary>
       /// <param name="PERSONAL_ID">personal id a consultar</param>
       /// <param name="COMPETENCIA_TRANSVERSALES_CODIGO">el codigo de competencia transversal a consultar</param>
       /// <returns></returns>
        public static  decimal SeleccionarEvaluacionPorCompetenciaTransversal(Guid PERSONAL_ID, int COMPETENCIA_TRANSVERSALES_CODIGO)
        {
            return DA_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.SeleccionarEvaluacionPorCompetenciaTransversal(PERSONAL_ID, COMPETENCIA_TRANSVERSALES_CODIGO.ToString());
        }

       /// <summary>
       /// Devuelve los datos al seleecionar competencias transversales por personal
       /// </summary>
       /// <param name="PERSONAL_ID">personal id a consutar</param>
       /// <returns></returns>
        public static List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> SeleccionarCompetenciasTransversalesPorPersonal(Guid PERSONAL_ID)
        {
            return DA_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.SeleccionarCompetenciasTransversalesPorPersonal(PERSONAL_ID);
        }

       /// <summary>
       /// Devuelve el valor del parametro de sistema
       /// </summary>
       /// <param name="PARAMETRO_DESCRIPCION">la descripcion del parametro a consultar</param>
       /// <returns></returns>
        public static int ParametroSistemaporValor(String PARAMETRO_DESCRIPCION)
        {
            return DA_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ParametroSistemaporValor(PARAMETRO_DESCRIPCION);        
        }

       /// <summary>
       /// Devuelve el valor del color del parametro del sistema
       /// </summary>
       /// <param name="PARAMETRO_COLOR">parametro de color a consultar</param>
       /// <returns></returns>
        public static string ParametroSistemaporValorColor(String PARAMETRO_COLOR)
        {
            return DA_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ParametroSistemaporValorColor(PARAMETRO_COLOR);
        }

       /// <summary>
       /// Devuelve el valor del indicardor por gerencia
       /// </summary>
       /// <param name="jerarquia_id">id de jerarquia a consultar</param>
       /// <param name="nivel">numero de nivel a consultar</param>
       /// <returns></returns>
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

       /// <summary>
       /// Devuelve la data si existe o no evaluaciones transversales
       /// </summary>
       /// <param name="OBE_COMPE_TRANS">Entida BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES que representa la tabla EVALUACIONES_COMPETENCIAS_TRANSVERSALES,con todos sus atributos</param>
       /// <returns></returns>
        public static bool ExisteEvaluacionTransversal(BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES OBE_COMPE_TRANS)
        {
            return DA_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ExisteRegistrosEvaluacionTransversales(OBE_COMPE_TRANS);       
        
        }

       /// <summary>
       /// Actualiza las evaluaciones transversales
       /// </summary>
       /// <param name="OBE_COMPE_TRANS">Entidad BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES que representa la tabla EVALUACIONES_COMPETENCIAS_TRANSVERSALES,con todos sus atributos</param>
       /// <returns></returns>
        public static bool ActualizacionEvaluacionTransversal(BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES OBE_COMPE_TRANS)
        {
            return DA_EVALUACIONES_COMPETENCIAS_TRANSVERSALES.ActualizarEvaluacionTransversal(OBE_COMPE_TRANS);
                
        }

    }
}
