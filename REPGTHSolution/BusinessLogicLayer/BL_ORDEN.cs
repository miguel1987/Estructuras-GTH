using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad ORDEN
    /// </summary>
    public class BL_ORDEN
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();  

        /// <summary>
        ///  Devuelve los datos de todos los Órdenes.
        /// </summary>
        /// <returns> List de BE_ORDEN con los objetos de la entidad, que a su vez representan la tabla ORDENES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_ORDEN> SeleccionarOrdenes()
        {
            List<BE_ORDEN> oORDEN = null;

            oORDEN = new DA_ORDEN().SeleccionarOrdenes();

            if (oORDEN != null)
            {
                foreach (var oBE_ORDEN_TMP in oORDEN)
                {
                    wsMaestros.BE_AREA[] oArea = wsMantenimientoMaestros.SeleccionarAreas();
                    if (oArea != null)
                    {
                        foreach (var itemArea in oArea)
                        {
                            BE_AREA oBE_AREA = new BE_AREA();

                            if (oBE_ORDEN_TMP.AREA_ID == itemArea.ID)
                            {
                                oBE_AREA.ID = itemArea.ID;
                                oBE_AREA.DESCRIPCION = itemArea.DESCRIPCION;
                                oBE_ORDEN_TMP.AREA_ID = itemArea.ID;
                                oBE_ORDEN_TMP.GERENCIA_ID = itemArea.GERENCIA_ID; 
                                oBE_ORDEN_TMP.oBE_AREA = oBE_AREA;

                                //Asignar gerencia y empresa
                                wsMaestros.BE_GERENCIA[] oGerencia = wsMantenimientoMaestros.SeleccionarGerencia();
                                if (oGerencia != null)
                                {
                                    foreach (var itemGerencia in oGerencia)
                                    {
                                        BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();

                                        if (oBE_ORDEN_TMP.GERENCIA_ID == itemGerencia.ID)
                                        {
                                            oBE_GERENCIA.ID = itemGerencia.ID;
                                            oBE_GERENCIA.DESCRIPCION = itemGerencia.DESCRIPCION;
                                            oBE_ORDEN_TMP.oBE_GERENCIA = oBE_GERENCIA;
                                            oBE_ORDEN_TMP.EMPRESA_ID = itemGerencia.EMPRESA_ID;

                                            wsMaestros.BE_EMPRESA[] oEmpresa = wsMantenimientoMaestros.SeleccionarEmpresa();
                                            if (oEmpresa != null)
                                            {
                                                foreach (var itemEmpresa in oEmpresa)
                                                {
                                                    BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();

                                                    if (oBE_ORDEN_TMP.EMPRESA_ID == itemEmpresa.ID)
                                                    {
                                                        oBE_EMPRESA.ID = itemEmpresa.ID;
                                                        oBE_EMPRESA.DESCRIPCION = itemEmpresa.DESCRIPCION;
                                                        oBE_ORDEN_TMP.oBE_EMPRESA = oBE_EMPRESA;
                                                    }

                                                }
                                            }


                                        }

                                    }
                                }
                                // fin de asignar gerencia y empresa
                            }

                        }
                    }
                }
            }
            else
            {
                oORDEN = new List<BE_ORDEN>();
                BE_ORDEN oBE_ORDEN = new BE_ORDEN();
                oBE_ORDEN.CODIGO = String.Empty;
                oBE_ORDEN.DESCRIPCION = String.Empty;
                oBE_ORDEN.AREA_ID = Guid.Empty;
                oORDEN.Add(oBE_ORDEN);

            }

            return oORDEN;
        }

        /// <summary>
        ///  Devuelve los datos de todos los Órdenes.
        /// </summary>
        /// <param name="areaId">Id del área cuyas órdenes se desean listar </param>
        /// <returns> List de BE_ORDEN con los objetos de la entidad, que a su vez representan la tabla ORDENES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_ORDEN> SeleccionarOrdenesPorArea(Guid area_id)
        {
            return new DA_ORDEN().SeleccionarOrdenesPorArea(area_id);
        }

        /// <summary>
        /// Ingresa un nuevo Centro Gestor
        /// </summary>
        /// <param name="oBE_ORDEN">Objeto BE_ORDEN con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Guid InsertarOrden(BE_ORDEN oBE_ORDEN)
        {
            return new DA_ORDEN().InsertarOrden(oBE_ORDEN);
        }

        /// <summary>
        /// Actualiza un Centro Gestor
        /// </summary>
        /// <param name="oBE_ORDEN">Objeto BE_ORDEN con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarOrden(BE_ORDEN oBE_ORDEN)
        {
            return new DA_ORDEN().ActualizarOrden(oBE_ORDEN);
        }

        /// <summary>
        /// Elimina un Centro Gestor
        /// </summary>
        /// <param name="centroGestorId">Codigo del documento que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarOrden(Guid centroGestorId)
        {
            return new DA_ORDEN().EliminarOrden(centroGestorId);
        }
    }
}
