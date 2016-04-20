using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad CENTRO_GESTOR
    /// </summary>
    public class BL_CENTRO_GESTOR
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        //wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();

        /// <summary>
        ///  Devuelve los datos de todos los Proveedores.
        /// </summary>
        /// <returns> List de BE_CENTRO_GESTOR con los objetos de la entidad, que a su vez representan la tabla CENTROS_GESTORES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_CENTRO_GESTOR> SeleccionarCentrosGestores()
        {
            List<BE_CENTRO_GESTOR> oCENTRO_GESTOR = null;

            oCENTRO_GESTOR = new DA_CENTRO_GESTOR().SeleccionarCentrosGestores();
            if (oCENTRO_GESTOR != null)
            {
                foreach (var oBE_CENTRO_GESTOR_TMP in oCENTRO_GESTOR)
                {
                    wsMaestros.BE_AREA[] oArea = wsMantenimientoEstructuras.SeleccionarAreas();
                    if (oArea != null)
                    {
                        foreach (var itemArea in oArea)
                        {
                            BE_AREA oBE_AREA = new BE_AREA();

                            if (oBE_CENTRO_GESTOR_TMP.AREA_ID == itemArea.ID)
                            {
                                oBE_AREA.ID = itemArea.ID;
                                oBE_AREA.DESCRIPCION = itemArea.DESCRIPCION;
                                oBE_CENTRO_GESTOR_TMP.AREA_ID = itemArea.ID;
                                oBE_CENTRO_GESTOR_TMP.GERENCIA_ID = itemArea.GERENCIA_ID; 
                                oBE_CENTRO_GESTOR_TMP.oBE_AREA = oBE_AREA;

                                //Asignar gerencia y empresa
                                wsMaestros.BE_GERENCIA[] oGerencia = wsMantenimientoEstructuras.SeleccionarGerencia();
                                if (oGerencia != null)
                                {
                                    foreach (var itemGerencia in oGerencia)
                                    {
                                        BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();

                                        if (oBE_CENTRO_GESTOR_TMP.GERENCIA_ID == itemGerencia.ID)
                                        {
                                            oBE_GERENCIA.ID = itemGerencia.ID;
                                            oBE_GERENCIA.DESCRIPCION = itemGerencia.DESCRIPCION;
                                            oBE_CENTRO_GESTOR_TMP.oBE_GERENCIA = oBE_GERENCIA;
                                            oBE_CENTRO_GESTOR_TMP.EMPRESA_ID = itemGerencia.EMPRESA_ID;

                                            wsMaestros.BE_EMPRESA[] oEmpresa = wsMantenimientoEstructuras.SeleccionarEmpresa();
                                            if (oEmpresa != null)
                                            {
                                                foreach (var itemEmpresa in oEmpresa)
                                                {
                                                    BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();

                                                    if (oBE_CENTRO_GESTOR_TMP.EMPRESA_ID == itemEmpresa.ID)
                                                    {
                                                        oBE_EMPRESA.ID = itemEmpresa.ID;
                                                        oBE_EMPRESA.DESCRIPCION = itemEmpresa.DESCRIPCION;
                                                        oBE_CENTRO_GESTOR_TMP.oBE_EMPRESA = oBE_EMPRESA;
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
                oCENTRO_GESTOR = new List<BE_CENTRO_GESTOR>();
                BE_CENTRO_GESTOR oBE_CENTRO_GESTOR = new BE_CENTRO_GESTOR();
                oBE_CENTRO_GESTOR.CODIGO = String.Empty;
                oBE_CENTRO_GESTOR.DESCRIPCION = String.Empty;
                oBE_CENTRO_GESTOR.AREA_ID = Guid.Empty;
                oCENTRO_GESTOR.Add(oBE_CENTRO_GESTOR);

            }

            return oCENTRO_GESTOR;
        }

        /// <summary>
        ///  Devuelve los datos de todos los Proveedores.
        /// </summary>
        /// <param name="areaId">area id de la cual se desea consultar sus centros de costo</param>
        /// <returns> List de BE_CENTRO_GESTOR con los objetos de la entidad, que a su vez representan la tabla CENTROS_GESTORES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_CENTRO_GESTOR> SeleccionarCentrosGestoresPorArea(Guid areaId)
        {
            return new DA_CENTRO_GESTOR().SeleccionarCentrosGestoresPorArea(areaId);
        }

        /// <summary>
        /// Ingresa un nuevo Centro Gestor
        /// </summary>
        /// <param name="oBE_CENTRO_GESTOR">Objeto BE_CENTRO_GESTOR con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Guid InsertarCentroGestor(BE_CENTRO_GESTOR oBE_CENTRO_GESTOR)
        {
            return new DA_CENTRO_GESTOR().InsertarCentroGestor(oBE_CENTRO_GESTOR);
        }

        /// <summary>
        /// Actualiza un Centro Gestor
        /// </summary>
        /// <param name="oBE_CENTRO_GESTOR">Objeto BE_CENTRO_GESTOR con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarCentroGestor(BE_CENTRO_GESTOR oBE_CENTRO_GESTOR)
        {
            return new DA_CENTRO_GESTOR().ActualizarCentroGestor(oBE_CENTRO_GESTOR);
        }

        /// <summary>
        /// Elimina un Centro Gestor
        /// </summary>
        /// <param name="centroGestorId">Codigo del documento que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarCentroGestor(Guid centroGestorId)
        {
            return new DA_CENTRO_GESTOR().EliminarCentroGestor(centroGestorId);
        }
    }
}
