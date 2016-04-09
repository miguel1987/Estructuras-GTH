using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad CENTRO_COSTO
    /// </summary>
    public class BL_CENTRO_COSTO
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();     

        /// <summary>
        ///  Devuelve los datos de todos los Centros de Costo.
        /// </summary>
        /// <returns> List de BE_CENTRO_COSTO con los objetos de la entidad, que a su vez representan la tabla CENTROS_COSTOS de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_CENTRO_COSTO> SeleccionarCentrosCostos()
        {
            try
            {
                List<BE_CENTRO_COSTO> oCENTRO_COSTO = null;                      

                oCENTRO_COSTO = new DA_CENTRO_COSTO().SeleccionarCentrosCostos();
                if (oCENTRO_COSTO != null)
                {
                    foreach (var oBE_CENTRO_COSTO_TMP in oCENTRO_COSTO)
                    {
                        wsMaestros.BE_AREA[] oArea = wsMantenimientoMaestros.SeleccionarAreas();
                        if (oArea != null)
                        {
                            foreach (var itemArea in oArea)
                            {
                                BE_AREA oBE_AREA = new BE_AREA();

                                if (oBE_CENTRO_COSTO_TMP.AREA_ID == itemArea.ID)
                                {
                                    oBE_AREA.ID = itemArea.ID;
                                    oBE_AREA.DESCRIPCION = itemArea.DESCRIPCION;                                
                                    oBE_CENTRO_COSTO_TMP.AREA_ID = itemArea.ID;
                                    oBE_CENTRO_COSTO_TMP.GERENCIA_ID = itemArea.GERENCIA_ID;                                
                                    oBE_CENTRO_COSTO_TMP.oBE_AREA = oBE_AREA;


                                    //Asignar gerencia y empresa
                                    wsMaestros.BE_GERENCIA[] oGerencia = wsMantenimientoMaestros.SeleccionarGerencia();
                                    if (oGerencia != null)
                                    {
                                        foreach (var itemGerencia in oGerencia)
                                        {
                                            BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();

                                            if (oBE_CENTRO_COSTO_TMP.GERENCIA_ID == itemGerencia.ID)
                                            {
                                                oBE_GERENCIA.ID = itemGerencia.ID;
                                                oBE_GERENCIA.DESCRIPCION = itemGerencia.DESCRIPCION;
                                                oBE_CENTRO_COSTO_TMP.oBE_GERENCIA = oBE_GERENCIA;
                                                oBE_CENTRO_COSTO_TMP.EMPRESA_ID = itemGerencia.EMPRESA_ID;

                                                wsMaestros.BE_EMPRESA[] oEmpresa = wsMantenimientoMaestros.SeleccionarEmpresa();
                                                if (oEmpresa != null)
                                                {
                                                    foreach (var itemEmpresa in oEmpresa)
                                                    {
                                                        BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();

                                                        if (oBE_CENTRO_COSTO_TMP.EMPRESA_ID == itemEmpresa.ID)
                                                        {
                                                            oBE_EMPRESA.ID = itemEmpresa.ID;
                                                            oBE_EMPRESA.DESCRIPCION = itemEmpresa.DESCRIPCION;
                                                            oBE_CENTRO_COSTO_TMP.oBE_EMPRESA = oBE_EMPRESA;
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
                    oCENTRO_COSTO = new List<BE_CENTRO_COSTO>();
                    BE_CENTRO_COSTO oBE_CENTRO_COSTO = new BE_CENTRO_COSTO();
                    oBE_CENTRO_COSTO.CODIGO = String.Empty;
                    oBE_CENTRO_COSTO.DESCRIPCION = String.Empty;
                    oBE_CENTRO_COSTO.AREA_ID = Guid.Empty;
                    oCENTRO_COSTO.Add(oBE_CENTRO_COSTO);

                }

                return oCENTRO_COSTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Devuelve los datos de todos los Centros de Costo de un área.
        /// </summary>
        /// <param name="areaId">area id de la cual se desea consultar sus centros de costo</param>
        /// <returns> List de BE_CENTRO_COSTO con los objetos de la entidad, que a su vez representan la tabla CENTROS_COSTOS de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_CENTRO_COSTO> SeleccionarCentroCostoArea(Guid areaId)
        {
            return new DA_CENTRO_COSTO().SeleccionarCentroCostoArea(areaId);
        }

        /// <summary>
        /// Ingresa un nuevo Centro de Costo
        /// </summary>
        /// <param name="oBE_CENTRO_COSTO">Objeto BE_CENTRO_COSTO con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Guid InsertarCentroCosto(BE_CENTRO_COSTO oBE_CENTRO_COSTO)
        {
            return new DA_CENTRO_COSTO().InsertarCentroCosto(oBE_CENTRO_COSTO);
        }

        /// <summary>
        /// Actualiza un Centro de Costo
        /// </summary>
        /// <param name="oBE_CENTRO_COSTO">Objeto BE_CENTRO_COSTO con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarCentroCosto(BE_CENTRO_COSTO oBE_CENTRO_COSTO)
        {
            return new DA_CENTRO_COSTO().ActualizarCentroCosto(oBE_CENTRO_COSTO);
        }

        /// <summary>
        /// Elimina un Centro de Costo
        /// </summary>
        /// <param name="centroCostoId">Codigo del documento que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarCentroCosto(Guid centroCostoId)
        {
            return new DA_CENTRO_COSTO().EliminarCentroCosto(centroCostoId);
        }

    }
}
