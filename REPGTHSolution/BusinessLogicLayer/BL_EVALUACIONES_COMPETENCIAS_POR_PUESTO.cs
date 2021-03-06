﻿using System;
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
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();
        wsMaestros.BE_PUESTO[] oListaPorPuesto = null;

        /// <summary>
        ///  Devuelve los datos de todos los puesto y colaboradores.
        /// </summary>
        /// <param name="jerarquia_id">id de jerarquia a consultar</param>
        /// <param name="nivel">codigo de nivel a consultar</param>
        /// <returns> List de BE_PUESTO con los objetos de la entidad, que a su vez representan la tabla PUESTOS de la base de datos.En caso no existan datos devuelve nothing </returns>
        /// 
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

        /// <summary>
        ///  Devuelve los datos de todos los puesto y colaboradores.
        /// </summary>
        /// <param name="competencia_tipo_id">id tipo competencia a consultar </param>
        /// <param name="puesto_id">id puesto a consultar</param>
        /// <returns> List de BE_EVALUACION_COMPETENCIA_PUESTO con los objetos de la entidad, que a su vez representan la tabla EVALUACION COMPETENCIA PUESTO de la base de datos.En caso no existan datos devuelve nothing </returns>
        ///
        public List<BE_EVALUACION_COMPETENCIA_PUESTO> SeleccionarEvaluaciones(Guid puesto_id, Guid competencia_tipo_id)
        {
            wsMaestros.BE_PERSONAL[] oListaPersonalPorPuesto = null;
            List<BE_COMPETENCIAS_POR_PUESTO> oListaCompPorPuesto = new List<BE_COMPETENCIAS_POR_PUESTO>();
            List<BE_EVALUACION_COMPETENCIA_PUESTO> oListaEvaluacionesPorPuesto = new List<BE_EVALUACION_COMPETENCIA_PUESTO>();
            
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
