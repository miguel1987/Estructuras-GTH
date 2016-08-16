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

       /// <summary>
       ///  Devuelve los datos de las Competencias de un Puesto por Puesto, Tipo de Competencia y Personal
       /// </summary>
       /// <param name="puestoId">puesto id de la cual se desea consultar sus competencias</param>
       /// <param name="tipoCompetenciaId">tipo de competencia que se desea consultar</param>
       /// <returns> List de BE_COMPETENCIAS_POR_PUESTO con los objetos de la entidad, que a su vez representan la tabla COMPETENCIAS_PUESTOS de la base de datos.En caso no existan datos devuelve nothing </returns>
       public static List<BE_COMPETENCIAS_POR_PUESTO> SeleccionarCompetenciasPorPuestoyTipo(Guid idPuesto, Guid idTipoCompetencia)
       {
           return new DA_COMPETENCIAS_POR_PUESTO().SeleccionarCompetenciasPorPuestoyTipo(idPuesto, idTipoCompetencia);
       }

       /// <summary>
       /// devuelve el tipo de evaluacion 
       /// </summary>
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
           return new DA_COMPETENCIAS_POR_PUESTO().SeleccionarCompetenciasPorPuesto();           
       }

       /// <summary>
       ///  Devuelve los datos de todos las Competencias de un Puesto por empresa
       /// </summary>      
       /// <param name="empresa_id">Id de la empresa cuyas competencias por puesto se desea consultar</param>
       /// <returns> List de BE_COMPETENCIAS_POR_PUESTO con los objetos de la entidad, que a su vez representan la tabla COMPETENCIAS_PUESTOS de la base de datos.En caso no existan datos devuelve nothing </returns>
       public List<BE_COMPETENCIAS_POR_PUESTO> SeleccionarCompetenciasPorPuesto(Guid empresa_id)
       {
           List<BE_COMPETENCIAS_POR_PUESTO> oListaCompetenciasPorPuesto = new List<BE_COMPETENCIAS_POR_PUESTO>();

           List<BE_COMPETENCIAS_POR_PUESTO> oListaCompetenciasPorPuestoConEmpresa = new List<BE_COMPETENCIAS_POR_PUESTO>();

           oListaCompetenciasPorPuesto = new DA_COMPETENCIAS_POR_PUESTO().SeleccionarCompetenciasPorPuesto();

           if (oListaCompetenciasPorPuesto != null)
           {
               foreach (var item in oListaCompetenciasPorPuesto)
               {
                   if (item.EMPRESA_ID == empresa_id)
                   { 
                       oListaCompetenciasPorPuestoConEmpresa.Add(item);
                   }

               }
           }

           return oListaCompetenciasPorPuestoConEmpresa;
       }

       /// <summary>
       ///  Devuelve los datos de todos las Competencias de un Puesto por empresa y gerencia
       /// </summary>      
       /// <param name="empresa_id">Id de la empresa cuyas competencias por puesto se desea consultar</param>
       /// <param name="gerencia_id">Id de la gerencia cuyas competencias por puesto se desea consultar</param>
       /// <returns> List de BE_COMPETENCIAS_POR_PUESTO con los objetos de la entidad, que a su vez representan la tabla COMPETENCIAS_PUESTOS de la base de datos.En caso no existan datos devuelve nothing </returns>
       public List<BE_COMPETENCIAS_POR_PUESTO> SeleccionarCompetenciasPorPuesto(Guid empresa_id, Guid gerencia_id)
       {
           List<BE_COMPETENCIAS_POR_PUESTO> oListaCompetenciasPorPuesto = new List<BE_COMPETENCIAS_POR_PUESTO>();

           List<BE_COMPETENCIAS_POR_PUESTO> oListaCompetenciasPorPuestoConEmpresa = new List<BE_COMPETENCIAS_POR_PUESTO>();

           oListaCompetenciasPorPuesto = new DA_COMPETENCIAS_POR_PUESTO().SeleccionarCompetenciasPorPuesto();

           if (oListaCompetenciasPorPuesto != null)
           {
               foreach (var item in oListaCompetenciasPorPuesto)
               {
                   if (item.EMPRESA_ID == empresa_id && item.oBE_GERENCIA.ID == gerencia_id)
                   {
                       oListaCompetenciasPorPuestoConEmpresa.Add(item);
                   }

               }
           }

           return oListaCompetenciasPorPuestoConEmpresa;
       }

       /// <summary>
       ///  Devuelve los datos de todos las Competencias de un Puesto por empresa y gerencia
       /// </summary>      
       /// <param name="empresa_id">Id de la empresa cuyas competencias por puesto se desea consultar</param>
       /// <param name="gerencia_id">Id de la gerencia cuyas competencias por puesto se desea consultar</param>
       /// <param name="area_id">Id del area cuyas competencias por puesto se desea consultar</param>
       /// <returns> List de BE_COMPETENCIAS_POR_PUESTO con los objetos de la entidad, que a su vez representan la tabla COMPETENCIAS_PUESTOS de la base de datos.En caso no existan datos devuelve nothing </returns>
       public List<BE_COMPETENCIAS_POR_PUESTO> SeleccionarCompetenciasPorPuesto(Guid empresa_id, Guid gerencia_id, Guid area_id)
       {
           List<BE_COMPETENCIAS_POR_PUESTO> oListaCompetenciasPorPuesto = new List<BE_COMPETENCIAS_POR_PUESTO>();

           List<BE_COMPETENCIAS_POR_PUESTO> oListaCompetenciasPorPuestoConEmpresa = new List<BE_COMPETENCIAS_POR_PUESTO>();

           oListaCompetenciasPorPuesto = new DA_COMPETENCIAS_POR_PUESTO().SeleccionarCompetenciasPorPuesto();

           if (oListaCompetenciasPorPuesto != null)
           {
               foreach (var item in oListaCompetenciasPorPuesto)
               {
                   if (item.EMPRESA_ID == empresa_id && item.oBE_GERENCIA.ID == gerencia_id && item.oBE_AREA.ID == area_id)
                   {
                       oListaCompetenciasPorPuestoConEmpresa.Add(item);
                   }

               }
           }

           return oListaCompetenciasPorPuestoConEmpresa;
       }

       /// <summary>
       ///  Devuelve los datos de todos las Competencias de un Puesto por empresa y gerencia
       /// </summary>      
       /// <param name="empresa_id">Id de la empresa cuyas competencias por puesto se desea consultar</param>
       /// <param name="gerencia_id">Id de la gerencia cuyas competencias por puesto se desea consultar</param>
       /// <param name="area_id">Id del area cuyas competencias por puesto se desea consultar</param>
       /// <param name="coordinacion_id">Id de la coordinación cuyas competencias por puesto se desea consultar</param>
       /// <returns> List de BE_COMPETENCIAS_POR_PUESTO con los objetos de la entidad, que a su vez representan la tabla COMPETENCIAS_PUESTOS de la base de datos.En caso no existan datos devuelve nothing </returns>
       public List<BE_COMPETENCIAS_POR_PUESTO> SeleccionarCompetenciasPorPuesto(Guid empresa_id, Guid gerencia_id, Guid area_id, Guid coordinacion_id)
       {
           List<BE_COMPETENCIAS_POR_PUESTO> oListaCompetenciasPorPuesto = new List<BE_COMPETENCIAS_POR_PUESTO>();

           List<BE_COMPETENCIAS_POR_PUESTO> oListaCompetenciasPorPuestoConEmpresa = new List<BE_COMPETENCIAS_POR_PUESTO>();

           oListaCompetenciasPorPuesto = new DA_COMPETENCIAS_POR_PUESTO().SeleccionarCompetenciasPorPuesto();

           if (oListaCompetenciasPorPuesto != null)
           {
               foreach (var item in oListaCompetenciasPorPuesto)
               {
                   if (item.EMPRESA_ID == empresa_id && item.oBE_GERENCIA.ID == gerencia_id && item.oBE_AREA.ID == area_id && item.oBE_COORDINACION.ID == coordinacion_id)
                   {
                       oListaCompetenciasPorPuestoConEmpresa.Add(item);
                   }

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

       /// <summary>
       /// devuelve el codigo del valor requerido
       /// </summary>
       public int SeleccionarValorRequerido(BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL oBE_COMPE_PUESTO_PERSONAL)
       {
           DA_COMPETENCIAS_POR_PUESTO DA_COMPETENCIAS_POR_PUESTO = new DA_COMPETENCIAS_POR_PUESTO();
           return DA_COMPETENCIAS_POR_PUESTO.SeleccionarValorRequerido(oBE_COMPE_PUESTO_PERSONAL);       
       }
      
    }
}
