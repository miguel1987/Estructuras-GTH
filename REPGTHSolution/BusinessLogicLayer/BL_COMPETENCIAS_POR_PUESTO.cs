using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class BL_COMPETENCIAS_POR_PUESTO
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.          
       wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();

        /// <summary>
        ///  Devuelve los datos de las Competencias de un Puesto por Puesto, Tipo de Competencia y Personal
        /// </summary>
        /// <param name="puestoId">puesto id de la cual se desea consultar sus competencias</param>
        /// <param name="tipoCompetenciaId">tipo de competencia que se desea consultar</param>
        /// <returns> List de BE_COMPETENCIAS_POR_PUESTO con los objetos de la entidad, que a su vez representan la tabla COMPETENCIAS_PUESTOS de la base de datos.En caso no existan datos devuelve nothing </returns>
       public static List<BE_COMPETENCIAS_POR_PUESTO> SeleccionarCompetenciasPorPuestoyTipo(Guid idPuesto, Guid idTipoCompetencia,Guid idPersonal)
        {
            return new DA_COMPETENCIAS_POR_PUESTO().SeleccionarCompetenciasPorPuestoyTipo(idPuesto, idTipoCompetencia,idPersonal);
        }


       public static int EvaluacionFinalGrabar(Guid idPuesto)
       {
           return new DA_COMPETENCIAS_POR_PUESTO().EvaluacionFinalGrabar(idPuesto);
       }

       /// <summary>
       ///  Devuelve los datos de todos las Competencias de un Puesto
       /// </summary>      
       /// <returns> List de BE_COMPETENCIAS_POR_PUESTO con los objetos de la entidad, que a su vez representan la tabla COMPETENCIAS_PUESTOS de la base de datos.En caso no existan datos devuelve nothing </returns>
       public List<BE_COMPETENCIAS_POR_PUESTO> SeleccionarCompetenciasPorPuesto()
       {
           List<BE_COMPETENCIAS_POR_PUESTO> oListaCompetenciasPorPuesto = new List<BE_COMPETENCIAS_POR_PUESTO>();

           List<BE_COMPETENCIAS_POR_PUESTO> oListaCompetenciasPorPuestoConEmpresa = new List<BE_COMPETENCIAS_POR_PUESTO>();

           wsMaestros.BE_PUESTO wBE_PUESTO = null;

           wsMaestros.BE_EMPRESA wBE_EMPRESA = null;


           oListaCompetenciasPorPuesto = new DA_COMPETENCIAS_POR_PUESTO().SeleccionarCompetenciasPorPuesto();

           if (oListaCompetenciasPorPuesto != null)
           {
               foreach (var item in oListaCompetenciasPorPuesto)
               {
                   BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();
                   BE_PUESTO oBE_PUESTO = new BE_PUESTO();
                   BE_COMPETENCIA oBE_COMPETENCIA = new BE_COMPETENCIA();
                   BE_COMPETENCIAS_POR_PUESTO oBE_COMPETENCIA_PUESTO = new BE_COMPETENCIAS_POR_PUESTO();

                   oBE_COMPETENCIA_PUESTO.ID = item.ID;
                   oBE_COMPETENCIA_PUESTO.COMPETENCIA_PUESTO_VALOR_REQUERIDO = item.COMPETENCIA_PUESTO_VALOR_REQUERIDO;

                   oBE_COMPETENCIA_PUESTO.COMPETENCIA_ID = item.COMPETENCIA_ID;

                   oBE_COMPETENCIA.ID = item.COMPETENCIA_ID;
                   oBE_COMPETENCIA.DESCRIPCION = item.COMPETENCIA_DESCRIPCION;
                   oBE_COMPETENCIA_PUESTO.oBE_COMPETENCIA = oBE_COMPETENCIA;                   

                   wBE_PUESTO  = wsMantenimientoEstructuras.SeleccionarPuestoPorId(item.PUESTO_ID);
                   oBE_PUESTO.ID = wBE_PUESTO.ID;
                   oBE_PUESTO.CODIGO = wBE_PUESTO.CODIGO;
                   oBE_PUESTO.DESCRIPCION = wBE_PUESTO.DESCRIPCION;
                   oBE_PUESTO.EMPRESA_ID = wBE_PUESTO.EMPRESA_ID;

                   oBE_COMPETENCIA_PUESTO.PUESTO_ID = oBE_PUESTO.ID;
                   oBE_COMPETENCIA_PUESTO.oBE_PUESTO = oBE_PUESTO;

                   wBE_EMPRESA = wsMantenimientoEstructuras.SeleccionarEmpresaPorId(oBE_PUESTO.EMPRESA_ID)[0];

                   oBE_EMPRESA.ID = wBE_EMPRESA.ID;
                   oBE_EMPRESA.CODIGO = wBE_EMPRESA.CODIGO;
                   oBE_EMPRESA.DESCRIPCION = wBE_EMPRESA.DESCRIPCION;

                   oBE_COMPETENCIA_PUESTO.EMPRESA_ID = oBE_EMPRESA.ID;
                   oBE_COMPETENCIA_PUESTO.oBE_EMPRESA = oBE_EMPRESA;

                   oListaCompetenciasPorPuestoConEmpresa.Add(oBE_COMPETENCIA_PUESTO);

               }
           }

           return oListaCompetenciasPorPuestoConEmpresa;
       }

       /// <summary>
       /// Ingresa una nueva Competencia por Puesto
       /// </summary>
       /// <param name="oBE_COMPETENCIA_PUESTO">Objeto BE_COMPETENCIAS_POR_PUESTO con todos sus campos llenos</param>
       /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
       public static Boolean InsertarCompetenciaPuesto(BE_COMPETENCIAS_POR_PUESTO oBE_COMPETENCIA_PUESTO)
       {
           return new DA_COMPETENCIAS_POR_PUESTO().InsertarCompetenciaPuesto(oBE_COMPETENCIA_PUESTO);
       }

       /// <summary>
       /// Actualiza una Competencia por Puesto
       /// </summary>
       /// <param name="oBE_COMPETENCIA_PUESTO">Objeto BE_COMPETENCIAS_POR_PUESTO con todos sus campos llenos</param>
       /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
       public static Boolean ActualizarCompetenciaPuesto(BE_COMPETENCIAS_POR_PUESTO oBE_COMPETENCIA_PUESTO)
       {
           return new DA_COMPETENCIAS_POR_PUESTO().ActualizarCompetenciaPuesto(oBE_COMPETENCIA_PUESTO);
       }

       /// <summary>
       /// Eliminar una Competencia por Puesto
       /// </summary>
       /// <param name="competencia_puesto_id">Codigo de la competencia por puesto que se desea eliminar</param>
       /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
       public static Boolean EliminarCompetenciaPuesto(Guid competencia_puesto_id)
       {
           return new DA_COMPETENCIAS_POR_PUESTO().EliminarCompetenciaPuesto(competencia_puesto_id);
       }
    }
}
