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
           List<BE_COMPETENCIAS_POR_PUESTO> oListaCompetenciasPorPuesto = new List<BE_COMPETENCIAS_POR_PUESTO>();

           List<BE_COMPETENCIAS_POR_PUESTO> oListaCompetenciasPorPuestoConEmpresa = new List<BE_COMPETENCIAS_POR_PUESTO>();

           wsMaestros.BE_PUESTO wBE_PUESTO = null;

           wsMaestros.BE_EMPRESA wBE_EMPRESA = null;

           wsMaestros.BE_GERENCIA wBE_GERENCIA = null;

           wsMaestros.BE_AREA wBE_AREA = null;

           wsMaestros.BE_COORDINACION wBE_COORDINACION = null;


           oListaCompetenciasPorPuesto = new DA_COMPETENCIAS_POR_PUESTO().SeleccionarCompetenciasPorPuesto();

           if (oListaCompetenciasPorPuesto != null)
           {
               foreach (var item in oListaCompetenciasPorPuesto)
               {
                   BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();
                   BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();
                   BE_AREA oBE_AREA = new BE_AREA();
                   BE_COORDINACION oBE_COORDINACION = new BE_COORDINACION();
                   BE_PUESTO oBE_PUESTO = new BE_PUESTO();
                   BE_COMPETENCIA oBE_COMPETENCIA = new BE_COMPETENCIA();
                   BE_COMPETENCIAS_POR_PUESTO oBE_COMPETENCIA_PUESTO = new BE_COMPETENCIAS_POR_PUESTO();

                   oBE_COMPETENCIA_PUESTO.ID = item.ID;
                   oBE_COMPETENCIA_PUESTO.COMPETENCIA_PUESTO_VALOR_REQUERIDO = item.COMPETENCIA_PUESTO_VALOR_REQUERIDO;

                   oBE_COMPETENCIA_PUESTO.COMPETENCIA_ID = item.COMPETENCIA_ID;                  

                   oBE_COMPETENCIA.ID = item.COMPETENCIA_ID;
                   oBE_COMPETENCIA.DESCRIPCION = item.COMPETENCIA_DESCRIPCION;
                   oBE_COMPETENCIA_PUESTO.oBE_COMPETENCIA = oBE_COMPETENCIA;

                   oBE_COMPETENCIA_PUESTO.oBE_COMPETENCIA_TIPO = item.oBE_COMPETENCIA_TIPO;

                   wBE_PUESTO  = wsMantenimientoEstructuras.SeleccionarPuestoPorId(item.PUESTO_ID);
                   oBE_PUESTO.ID = wBE_PUESTO.ID;
                   oBE_PUESTO.CODIGO = wBE_PUESTO.CODIGO;
                   oBE_PUESTO.DESCRIPCION = wBE_PUESTO.DESCRIPCION;
                   oBE_PUESTO.EMPRESA_ID = wBE_PUESTO.EMPRESA_ID;
                   oBE_PUESTO.GERENCIA_ID = wBE_PUESTO.GERENCIA_ID;
                   oBE_PUESTO.AREA_ID = wBE_PUESTO.AREA_ID;
                   oBE_PUESTO.COORDINACION_ID = wBE_PUESTO.COORDINACION_ID;

                   oBE_COMPETENCIA_PUESTO.PUESTO_ID = oBE_PUESTO.ID;
                   oBE_COMPETENCIA_PUESTO.oBE_PUESTO = oBE_PUESTO;

                   wBE_EMPRESA = wsMantenimientoEstructuras.SeleccionarEmpresaPorId(oBE_PUESTO.EMPRESA_ID)[0];

                   if (wBE_EMPRESA != null)
                   {

                       oBE_EMPRESA.ID = wBE_EMPRESA.ID;
                       oBE_EMPRESA.CODIGO = wBE_EMPRESA.CODIGO;
                       oBE_EMPRESA.DESCRIPCION = wBE_EMPRESA.DESCRIPCION;

                       oBE_COMPETENCIA_PUESTO.EMPRESA_ID = oBE_EMPRESA.ID;
                       oBE_COMPETENCIA_PUESTO.oBE_EMPRESA = oBE_EMPRESA;
                   }

                   wBE_GERENCIA = wsMantenimientoEstructuras.SeleccionarGerenciaPorId(oBE_PUESTO.GERENCIA_ID)[0];

                   if (wBE_GERENCIA != null)
                   {

                       oBE_GERENCIA.ID = wBE_GERENCIA.ID;
                       oBE_GERENCIA.CODIGO = wBE_GERENCIA.CODIGO;
                       oBE_GERENCIA.DESCRIPCION = wBE_GERENCIA.DESCRIPCION;

                       oBE_COMPETENCIA_PUESTO.oBE_GERENCIA = oBE_GERENCIA;
                   }

                   wBE_AREA = wsMantenimientoEstructuras.SeleccionarAreaPorId(oBE_PUESTO.AREA_ID);

                   if (wBE_AREA != null)
                   {

                       oBE_AREA.ID = wBE_AREA.ID;
                       oBE_AREA.CODIGO = wBE_AREA.CODIGO;
                       oBE_AREA.DESCRIPCION = wBE_AREA.DESCRIPCION;

                       oBE_COMPETENCIA_PUESTO.oBE_AREA = oBE_AREA;
                   }

                   wBE_COORDINACION = wsMantenimientoEstructuras.SeleccionarCoordinacionPorId(oBE_PUESTO.COORDINACION_ID);

                   if (wBE_COORDINACION != null)
                   {
                       oBE_COORDINACION.ID = wBE_COORDINACION.ID;
                       oBE_COORDINACION.CODIGO = wBE_COORDINACION.CODIGO;
                       oBE_COORDINACION.DESCRIPCION = wBE_COORDINACION.DESCRIPCION;

                       oBE_COMPETENCIA_PUESTO.oBE_COORDINACION = oBE_COORDINACION;
                   }

                   oListaCompetenciasPorPuestoConEmpresa.Add(oBE_COMPETENCIA_PUESTO);

               }
           }

           return oListaCompetenciasPorPuestoConEmpresa;
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

           wsMaestros.BE_PUESTO wBE_PUESTO = null;

           wsMaestros.BE_EMPRESA wBE_EMPRESA = null;

           wsMaestros.BE_GERENCIA wBE_GERENCIA = null;

           wsMaestros.BE_AREA wBE_AREA = null;

           wsMaestros.BE_COORDINACION wBE_COORDINACION = null;


           oListaCompetenciasPorPuesto = new DA_COMPETENCIAS_POR_PUESTO().SeleccionarCompetenciasPorPuesto();

           if (oListaCompetenciasPorPuesto != null)
           {
               foreach (var item in oListaCompetenciasPorPuesto)
               {
                   if (item.EMPRESA_ID == empresa_id)
                   {
                       BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();
                       BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();
                       BE_AREA oBE_AREA = new BE_AREA();
                       BE_COORDINACION oBE_COORDINACION = new BE_COORDINACION();
                       BE_PUESTO oBE_PUESTO = new BE_PUESTO();
                       BE_COMPETENCIA oBE_COMPETENCIA = new BE_COMPETENCIA();
                       BE_COMPETENCIAS_POR_PUESTO oBE_COMPETENCIA_PUESTO = new BE_COMPETENCIAS_POR_PUESTO();

                       oBE_COMPETENCIA_PUESTO.ID = item.ID;
                       oBE_COMPETENCIA_PUESTO.COMPETENCIA_PUESTO_VALOR_REQUERIDO = item.COMPETENCIA_PUESTO_VALOR_REQUERIDO;

                       oBE_COMPETENCIA_PUESTO.COMPETENCIA_ID = item.COMPETENCIA_ID;

                       oBE_COMPETENCIA.ID = item.COMPETENCIA_ID;
                       oBE_COMPETENCIA.DESCRIPCION = item.COMPETENCIA_DESCRIPCION;
                       oBE_COMPETENCIA_PUESTO.oBE_COMPETENCIA = oBE_COMPETENCIA;

                       oBE_COMPETENCIA_PUESTO.oBE_COMPETENCIA_TIPO = item.oBE_COMPETENCIA_TIPO;

                       wBE_PUESTO = wsMantenimientoEstructuras.SeleccionarPuestoPorId(item.PUESTO_ID);
                       oBE_PUESTO.ID = wBE_PUESTO.ID;
                       oBE_PUESTO.CODIGO = wBE_PUESTO.CODIGO;
                       oBE_PUESTO.DESCRIPCION = wBE_PUESTO.DESCRIPCION;
                       oBE_PUESTO.EMPRESA_ID = wBE_PUESTO.EMPRESA_ID;
                       oBE_PUESTO.GERENCIA_ID = wBE_PUESTO.GERENCIA_ID;
                       oBE_PUESTO.AREA_ID = wBE_PUESTO.AREA_ID;
                       oBE_PUESTO.COORDINACION_ID = wBE_PUESTO.COORDINACION_ID;

                       oBE_COMPETENCIA_PUESTO.PUESTO_ID = oBE_PUESTO.ID;
                       oBE_COMPETENCIA_PUESTO.oBE_PUESTO = oBE_PUESTO;

                       wBE_EMPRESA = wsMantenimientoEstructuras.SeleccionarEmpresaPorId(oBE_PUESTO.EMPRESA_ID)[0];

                       if (wBE_EMPRESA != null)
                       {

                           oBE_EMPRESA.ID = wBE_EMPRESA.ID;
                           oBE_EMPRESA.CODIGO = wBE_EMPRESA.CODIGO;
                           oBE_EMPRESA.DESCRIPCION = wBE_EMPRESA.DESCRIPCION;

                           oBE_COMPETENCIA_PUESTO.EMPRESA_ID = oBE_EMPRESA.ID;
                           oBE_COMPETENCIA_PUESTO.oBE_EMPRESA = oBE_EMPRESA;
                       }

                       wBE_GERENCIA = wsMantenimientoEstructuras.SeleccionarGerenciaPorId(oBE_PUESTO.GERENCIA_ID)[0];

                       if (wBE_GERENCIA != null)
                       {

                           oBE_GERENCIA.ID = wBE_GERENCIA.ID;
                           oBE_GERENCIA.CODIGO = wBE_GERENCIA.CODIGO;
                           oBE_GERENCIA.DESCRIPCION = wBE_GERENCIA.DESCRIPCION;

                           oBE_COMPETENCIA_PUESTO.oBE_GERENCIA = oBE_GERENCIA;
                       }

                       wBE_AREA = wsMantenimientoEstructuras.SeleccionarAreaPorId(oBE_PUESTO.AREA_ID);

                       if (wBE_AREA != null)
                       {

                           oBE_AREA.ID = wBE_AREA.ID;
                           oBE_AREA.CODIGO = wBE_AREA.CODIGO;
                           oBE_AREA.DESCRIPCION = wBE_AREA.DESCRIPCION;

                           oBE_COMPETENCIA_PUESTO.oBE_AREA = oBE_AREA;
                       }

                       wBE_COORDINACION = wsMantenimientoEstructuras.SeleccionarCoordinacionPorId(oBE_PUESTO.COORDINACION_ID);

                       if (wBE_COORDINACION != null)
                       {
                           oBE_COORDINACION.ID = wBE_COORDINACION.ID;
                           oBE_COORDINACION.CODIGO = wBE_COORDINACION.CODIGO;
                           oBE_COORDINACION.DESCRIPCION = wBE_COORDINACION.DESCRIPCION;

                           oBE_COMPETENCIA_PUESTO.oBE_COORDINACION = oBE_COORDINACION;
                       }

                       oListaCompetenciasPorPuestoConEmpresa.Add(oBE_COMPETENCIA_PUESTO);
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

           wsMaestros.BE_PUESTO wBE_PUESTO = null;

           wsMaestros.BE_EMPRESA wBE_EMPRESA = null;

           wsMaestros.BE_GERENCIA wBE_GERENCIA = null;

           wsMaestros.BE_AREA wBE_AREA = null;

           wsMaestros.BE_COORDINACION wBE_COORDINACION = null;


           oListaCompetenciasPorPuesto = new DA_COMPETENCIAS_POR_PUESTO().SeleccionarCompetenciasPorPuesto();

           if (oListaCompetenciasPorPuesto != null)
           {
               foreach (var item in oListaCompetenciasPorPuesto)
               {                  
                    BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();
                    BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();
                    BE_AREA oBE_AREA = new BE_AREA();
                    BE_COORDINACION oBE_COORDINACION = new BE_COORDINACION();
                    BE_PUESTO oBE_PUESTO = new BE_PUESTO();
                    BE_COMPETENCIA oBE_COMPETENCIA = new BE_COMPETENCIA();
                    BE_COMPETENCIAS_POR_PUESTO oBE_COMPETENCIA_PUESTO = new BE_COMPETENCIAS_POR_PUESTO();

                    oBE_COMPETENCIA_PUESTO.ID = item.ID;
                    oBE_COMPETENCIA_PUESTO.COMPETENCIA_PUESTO_VALOR_REQUERIDO = item.COMPETENCIA_PUESTO_VALOR_REQUERIDO;

                    oBE_COMPETENCIA_PUESTO.COMPETENCIA_ID = item.COMPETENCIA_ID;

                    oBE_COMPETENCIA.ID = item.COMPETENCIA_ID;
                    oBE_COMPETENCIA.DESCRIPCION = item.COMPETENCIA_DESCRIPCION;
                    oBE_COMPETENCIA_PUESTO.oBE_COMPETENCIA = oBE_COMPETENCIA;

                    oBE_COMPETENCIA_PUESTO.oBE_COMPETENCIA_TIPO = item.oBE_COMPETENCIA_TIPO;

                    wBE_PUESTO = wsMantenimientoEstructuras.SeleccionarPuestoPorId(item.PUESTO_ID);
                    oBE_PUESTO.ID = wBE_PUESTO.ID;
                    oBE_PUESTO.CODIGO = wBE_PUESTO.CODIGO;
                    oBE_PUESTO.DESCRIPCION = wBE_PUESTO.DESCRIPCION;
                    oBE_PUESTO.EMPRESA_ID = wBE_PUESTO.EMPRESA_ID;
                    oBE_PUESTO.GERENCIA_ID = wBE_PUESTO.GERENCIA_ID;
                    oBE_PUESTO.AREA_ID = wBE_PUESTO.AREA_ID;
                    oBE_PUESTO.COORDINACION_ID = wBE_PUESTO.COORDINACION_ID;

                    oBE_COMPETENCIA_PUESTO.PUESTO_ID = oBE_PUESTO.ID;
                    oBE_COMPETENCIA_PUESTO.oBE_PUESTO = oBE_PUESTO;

                    wBE_EMPRESA = wsMantenimientoEstructuras.SeleccionarEmpresaPorId(oBE_PUESTO.EMPRESA_ID)[0];

                    if (wBE_EMPRESA != null)
                    {

                        oBE_EMPRESA.ID = wBE_EMPRESA.ID;
                        oBE_EMPRESA.CODIGO = wBE_EMPRESA.CODIGO;
                        oBE_EMPRESA.DESCRIPCION = wBE_EMPRESA.DESCRIPCION;

                        oBE_COMPETENCIA_PUESTO.EMPRESA_ID = oBE_EMPRESA.ID;
                        oBE_COMPETENCIA_PUESTO.oBE_EMPRESA = oBE_EMPRESA;
                    }

                    wBE_GERENCIA = wsMantenimientoEstructuras.SeleccionarGerenciaPorId(oBE_PUESTO.GERENCIA_ID)[0];

                    if (wBE_GERENCIA != null)
                    {

                        oBE_GERENCIA.ID = wBE_GERENCIA.ID;
                        oBE_GERENCIA.CODIGO = wBE_GERENCIA.CODIGO;
                        oBE_GERENCIA.DESCRIPCION = wBE_GERENCIA.DESCRIPCION;

                        oBE_COMPETENCIA_PUESTO.oBE_GERENCIA = oBE_GERENCIA;
                    }

                    wBE_AREA = wsMantenimientoEstructuras.SeleccionarAreaPorId(oBE_PUESTO.AREA_ID);

                    if (wBE_AREA != null)
                    {

                        oBE_AREA.ID = wBE_AREA.ID;
                        oBE_AREA.CODIGO = wBE_AREA.CODIGO;
                        oBE_AREA.DESCRIPCION = wBE_AREA.DESCRIPCION;

                        oBE_COMPETENCIA_PUESTO.oBE_AREA = oBE_AREA;
                    }

                    wBE_COORDINACION = wsMantenimientoEstructuras.SeleccionarCoordinacionPorId(oBE_PUESTO.COORDINACION_ID);

                    if (wBE_COORDINACION != null)
                    {
                        oBE_COORDINACION.ID = wBE_COORDINACION.ID;
                        oBE_COORDINACION.CODIGO = wBE_COORDINACION.CODIGO;
                        oBE_COORDINACION.DESCRIPCION = wBE_COORDINACION.DESCRIPCION;

                        oBE_COMPETENCIA_PUESTO.oBE_COORDINACION = oBE_COORDINACION;
                    }

                    if (oBE_COMPETENCIA_PUESTO.EMPRESA_ID == empresa_id && oBE_COMPETENCIA_PUESTO.oBE_GERENCIA.ID == gerencia_id)
                    {

                        oListaCompetenciasPorPuestoConEmpresa.Add(oBE_COMPETENCIA_PUESTO);
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

           wsMaestros.BE_PUESTO wBE_PUESTO = null;

           wsMaestros.BE_EMPRESA wBE_EMPRESA = null;

           wsMaestros.BE_GERENCIA wBE_GERENCIA = null;

           wsMaestros.BE_AREA wBE_AREA = null;

           wsMaestros.BE_COORDINACION wBE_COORDINACION = null;


           oListaCompetenciasPorPuesto = new DA_COMPETENCIAS_POR_PUESTO().SeleccionarCompetenciasPorPuesto();

           if (oListaCompetenciasPorPuesto != null)
           {
               foreach (var item in oListaCompetenciasPorPuesto)
               {                   
                    BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();
                    BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();
                    BE_AREA oBE_AREA = new BE_AREA();
                    BE_COORDINACION oBE_COORDINACION = new BE_COORDINACION();
                    BE_PUESTO oBE_PUESTO = new BE_PUESTO();
                    BE_COMPETENCIA oBE_COMPETENCIA = new BE_COMPETENCIA();
                    BE_COMPETENCIAS_POR_PUESTO oBE_COMPETENCIA_PUESTO = new BE_COMPETENCIAS_POR_PUESTO();

                    oBE_COMPETENCIA_PUESTO.ID = item.ID;
                    oBE_COMPETENCIA_PUESTO.COMPETENCIA_PUESTO_VALOR_REQUERIDO = item.COMPETENCIA_PUESTO_VALOR_REQUERIDO;

                    oBE_COMPETENCIA_PUESTO.COMPETENCIA_ID = item.COMPETENCIA_ID;

                    oBE_COMPETENCIA.ID = item.COMPETENCIA_ID;
                    oBE_COMPETENCIA.DESCRIPCION = item.COMPETENCIA_DESCRIPCION;
                    oBE_COMPETENCIA_PUESTO.oBE_COMPETENCIA = oBE_COMPETENCIA;

                    oBE_COMPETENCIA_PUESTO.oBE_COMPETENCIA_TIPO = item.oBE_COMPETENCIA_TIPO;

                    wBE_PUESTO = wsMantenimientoEstructuras.SeleccionarPuestoPorId(item.PUESTO_ID);
                    oBE_PUESTO.ID = wBE_PUESTO.ID;
                    oBE_PUESTO.CODIGO = wBE_PUESTO.CODIGO;
                    oBE_PUESTO.DESCRIPCION = wBE_PUESTO.DESCRIPCION;
                    oBE_PUESTO.EMPRESA_ID = wBE_PUESTO.EMPRESA_ID;
                    oBE_PUESTO.GERENCIA_ID = wBE_PUESTO.GERENCIA_ID;
                    oBE_PUESTO.AREA_ID = wBE_PUESTO.AREA_ID;
                    oBE_PUESTO.COORDINACION_ID = wBE_PUESTO.COORDINACION_ID;

                    oBE_COMPETENCIA_PUESTO.PUESTO_ID = oBE_PUESTO.ID;
                    oBE_COMPETENCIA_PUESTO.oBE_PUESTO = oBE_PUESTO;

                    wBE_EMPRESA = wsMantenimientoEstructuras.SeleccionarEmpresaPorId(oBE_PUESTO.EMPRESA_ID)[0];

                    if (wBE_EMPRESA != null)
                    {

                        oBE_EMPRESA.ID = wBE_EMPRESA.ID;
                        oBE_EMPRESA.CODIGO = wBE_EMPRESA.CODIGO;
                        oBE_EMPRESA.DESCRIPCION = wBE_EMPRESA.DESCRIPCION;

                        oBE_COMPETENCIA_PUESTO.EMPRESA_ID = oBE_EMPRESA.ID;
                        oBE_COMPETENCIA_PUESTO.oBE_EMPRESA = oBE_EMPRESA;
                    }

                    wBE_GERENCIA = wsMantenimientoEstructuras.SeleccionarGerenciaPorId(oBE_PUESTO.GERENCIA_ID)[0];

                    if (wBE_GERENCIA != null)
                    {

                        oBE_GERENCIA.ID = wBE_GERENCIA.ID;
                        oBE_GERENCIA.CODIGO = wBE_GERENCIA.CODIGO;
                        oBE_GERENCIA.DESCRIPCION = wBE_GERENCIA.DESCRIPCION;

                        oBE_COMPETENCIA_PUESTO.oBE_GERENCIA = oBE_GERENCIA;
                    }

                    wBE_AREA = wsMantenimientoEstructuras.SeleccionarAreaPorId(oBE_PUESTO.AREA_ID);

                    if (wBE_AREA != null)
                    {

                        oBE_AREA.ID = wBE_AREA.ID;
                        oBE_AREA.CODIGO = wBE_AREA.CODIGO;
                        oBE_AREA.DESCRIPCION = wBE_AREA.DESCRIPCION;

                        oBE_COMPETENCIA_PUESTO.oBE_AREA = oBE_AREA;
                    }

                    wBE_COORDINACION = wsMantenimientoEstructuras.SeleccionarCoordinacionPorId(oBE_PUESTO.COORDINACION_ID);

                    if (wBE_COORDINACION != null)
                    {
                        oBE_COORDINACION.ID = wBE_COORDINACION.ID;
                        oBE_COORDINACION.CODIGO = wBE_COORDINACION.CODIGO;
                        oBE_COORDINACION.DESCRIPCION = wBE_COORDINACION.DESCRIPCION;

                        oBE_COMPETENCIA_PUESTO.oBE_COORDINACION = oBE_COORDINACION;
                    }
                    if (oBE_COMPETENCIA_PUESTO.oBE_AREA != null)
                    {
                        if (oBE_COMPETENCIA_PUESTO.EMPRESA_ID == empresa_id && oBE_COMPETENCIA_PUESTO.oBE_GERENCIA.ID == gerencia_id && oBE_COMPETENCIA_PUESTO.oBE_AREA.ID == area_id)
                        {
                            oListaCompetenciasPorPuestoConEmpresa.Add(oBE_COMPETENCIA_PUESTO);
                        }
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

           wsMaestros.BE_PUESTO wBE_PUESTO = null;

           wsMaestros.BE_EMPRESA wBE_EMPRESA = null;

           wsMaestros.BE_GERENCIA wBE_GERENCIA = null;

           wsMaestros.BE_AREA wBE_AREA = null;

           wsMaestros.BE_COORDINACION wBE_COORDINACION = null;


           oListaCompetenciasPorPuesto = new DA_COMPETENCIAS_POR_PUESTO().SeleccionarCompetenciasPorPuesto();

           if (oListaCompetenciasPorPuesto != null)
           {
               foreach (var item in oListaCompetenciasPorPuesto)
               {                   
                    BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();
                    BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();
                    BE_AREA oBE_AREA = new BE_AREA();
                    BE_COORDINACION oBE_COORDINACION = new BE_COORDINACION();
                    BE_PUESTO oBE_PUESTO = new BE_PUESTO();
                    BE_COMPETENCIA oBE_COMPETENCIA = new BE_COMPETENCIA();
                    BE_COMPETENCIAS_POR_PUESTO oBE_COMPETENCIA_PUESTO = new BE_COMPETENCIAS_POR_PUESTO();

                    oBE_COMPETENCIA_PUESTO.ID = item.ID;
                    oBE_COMPETENCIA_PUESTO.COMPETENCIA_PUESTO_VALOR_REQUERIDO = item.COMPETENCIA_PUESTO_VALOR_REQUERIDO;

                    oBE_COMPETENCIA_PUESTO.COMPETENCIA_ID = item.COMPETENCIA_ID;

                    oBE_COMPETENCIA.ID = item.COMPETENCIA_ID;
                    oBE_COMPETENCIA.DESCRIPCION = item.COMPETENCIA_DESCRIPCION;
                    oBE_COMPETENCIA_PUESTO.oBE_COMPETENCIA = oBE_COMPETENCIA;

                    oBE_COMPETENCIA_PUESTO.oBE_COMPETENCIA_TIPO = item.oBE_COMPETENCIA_TIPO;

                    wBE_PUESTO = wsMantenimientoEstructuras.SeleccionarPuestoPorId(item.PUESTO_ID);
                    oBE_PUESTO.ID = wBE_PUESTO.ID;
                    oBE_PUESTO.CODIGO = wBE_PUESTO.CODIGO;
                    oBE_PUESTO.DESCRIPCION = wBE_PUESTO.DESCRIPCION;
                    oBE_PUESTO.EMPRESA_ID = wBE_PUESTO.EMPRESA_ID;
                    oBE_PUESTO.GERENCIA_ID = wBE_PUESTO.GERENCIA_ID;
                    oBE_PUESTO.AREA_ID = wBE_PUESTO.AREA_ID;
                    oBE_PUESTO.COORDINACION_ID = wBE_PUESTO.COORDINACION_ID;

                    oBE_COMPETENCIA_PUESTO.PUESTO_ID = oBE_PUESTO.ID;
                    oBE_COMPETENCIA_PUESTO.oBE_PUESTO = oBE_PUESTO;

                    wBE_EMPRESA = wsMantenimientoEstructuras.SeleccionarEmpresaPorId(oBE_PUESTO.EMPRESA_ID)[0];

                    if (wBE_EMPRESA != null)
                    {

                        oBE_EMPRESA.ID = wBE_EMPRESA.ID;
                        oBE_EMPRESA.CODIGO = wBE_EMPRESA.CODIGO;
                        oBE_EMPRESA.DESCRIPCION = wBE_EMPRESA.DESCRIPCION;

                        oBE_COMPETENCIA_PUESTO.EMPRESA_ID = oBE_EMPRESA.ID;
                        oBE_COMPETENCIA_PUESTO.oBE_EMPRESA = oBE_EMPRESA;
                    }

                    wBE_GERENCIA = wsMantenimientoEstructuras.SeleccionarGerenciaPorId(oBE_PUESTO.GERENCIA_ID)[0];

                    if (wBE_GERENCIA != null)
                    {

                        oBE_GERENCIA.ID = wBE_GERENCIA.ID;
                        oBE_GERENCIA.CODIGO = wBE_GERENCIA.CODIGO;
                        oBE_GERENCIA.DESCRIPCION = wBE_GERENCIA.DESCRIPCION;

                        oBE_COMPETENCIA_PUESTO.oBE_GERENCIA = oBE_GERENCIA;
                    }

                    wBE_AREA = wsMantenimientoEstructuras.SeleccionarAreaPorId(oBE_PUESTO.AREA_ID);

                    if (wBE_AREA != null)
                    {

                        oBE_AREA.ID = wBE_AREA.ID;
                        oBE_AREA.CODIGO = wBE_AREA.CODIGO;
                        oBE_AREA.DESCRIPCION = wBE_AREA.DESCRIPCION;

                        oBE_COMPETENCIA_PUESTO.oBE_AREA = oBE_AREA;
                    }

                    wBE_COORDINACION = wsMantenimientoEstructuras.SeleccionarCoordinacionPorId(oBE_PUESTO.COORDINACION_ID);

                    if (wBE_COORDINACION != null)
                    {
                        oBE_COORDINACION.ID = wBE_COORDINACION.ID;
                        oBE_COORDINACION.CODIGO = wBE_COORDINACION.CODIGO;
                        oBE_COORDINACION.DESCRIPCION = wBE_COORDINACION.DESCRIPCION;

                        oBE_COMPETENCIA_PUESTO.oBE_COORDINACION = oBE_COORDINACION;
                    }

                    if (oBE_COMPETENCIA_PUESTO.oBE_COORDINACION != null)
                    {
                        if (oBE_COMPETENCIA_PUESTO.EMPRESA_ID == empresa_id && oBE_COMPETENCIA_PUESTO.oBE_GERENCIA.ID == gerencia_id && oBE_COMPETENCIA_PUESTO.oBE_AREA.ID == area_id && oBE_COMPETENCIA_PUESTO.oBE_COORDINACION.ID == coordinacion_id)
                        {
                            oListaCompetenciasPorPuestoConEmpresa.Add(oBE_COMPETENCIA_PUESTO);
                        }
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
