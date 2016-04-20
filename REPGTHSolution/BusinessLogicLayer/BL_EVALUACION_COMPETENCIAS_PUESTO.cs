using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BL_EVALUACION_COMPETENCIAS_PUESTO
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        //wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();
        wsMaestros.BE_PERSONAL[] oLista=null;
        DA_EVALUACION_COMPETENCIA_PUESTO DA_COMPETENCIA_PUESTO = new DA_EVALUACION_COMPETENCIA_PUESTO();
        List<BE_EVALUACION_COMPETENCIA_PUESTO> oListaEvaluacionesEstado = new List<BE_EVALUACION_COMPETENCIA_PUESTO>();
        

        /// <summary>
        ///  Devuelve los datos de todos los puesto y colaboradores.
        /// </summary>
        /// <returns> List de BE_EMPRESA con los objetos de la entidad, que a su vez representan la tabla EMPRESAS de la base de datos.En caso no existan datos devuelve nothing </returns>
        /// 
        public List<BE_EVALUACION_COMPETENCIA_PUESTO> SeleccionarEvaluacionesPorJerarquia(Guid jerarquia_id, int nivel)
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

                    BE_EVALUACION_COMPETENCIA_PUESTO oEvaluacion_Competencia = new BE_EVALUACION_COMPETENCIA_PUESTO();
                    oEvaluacion_Competencia.PUESTO_ID = item.PUESTO_ID;
                    oEvaluacion_Competencia.PUESTO_DESCRIPCION = item.oBE_PUESTO.DESCRIPCION;
                    oEvaluacion_Competencia.PERSONAL_ID = item.ID;
                    oEvaluacion_Competencia.PERSONAL_DESCRIPCION = item.NOMBRES_COMPLETOS;
                    if (DA_COMPETENCIA_PUESTO.SeleccionarEvaluacionEstadoPorPersonal(oEvaluacion_Competencia.PERSONAL_ID) == (Int32)BE_EVALUACION_COMPETENCIA_PUESTO.ESTADO_EVALUACION.Pendiente)
                        oEvaluacion_Competencia.ESTADO_DESCRIPCION = BE_EVALUACION_COMPETENCIA_PUESTO.ESTADO_EVALUACION.Pendiente.ToString();
                    if (DA_COMPETENCIA_PUESTO.SeleccionarEvaluacionEstadoPorPersonal(oEvaluacion_Competencia.PERSONAL_ID) == (Int32)BE_EVALUACION_COMPETENCIA_PUESTO.ESTADO_EVALUACION.En_Evaluacion)
                        oEvaluacion_Competencia.ESTADO_DESCRIPCION = BE_EVALUACION_COMPETENCIA_PUESTO.ESTADO_EVALUACION.En_Evaluacion.ToString();
                    if (DA_COMPETENCIA_PUESTO.SeleccionarEvaluacionEstadoPorPersonal(oEvaluacion_Competencia.PERSONAL_ID) == (Int32)BE_EVALUACION_COMPETENCIA_PUESTO.ESTADO_EVALUACION.Evaluado)
                        oEvaluacion_Competencia.ESTADO_DESCRIPCION = BE_EVALUACION_COMPETENCIA_PUESTO.ESTADO_EVALUACION.Evaluado.ToString();

                    oListaEvaluacionesEstado.Add(oEvaluacion_Competencia);

                }
            }
                   
            
            return oListaEvaluacionesEstado;

        }



    }
}
