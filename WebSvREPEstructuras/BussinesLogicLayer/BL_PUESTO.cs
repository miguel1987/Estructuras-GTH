using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BussinesEntities;
using DataAccessLayer;

namespace BussinesLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para la logica de negocio de PUESTO
    /// </summary>
    public class BL_PUESTO
    {
        /// <summary>
        ///  Devuelve los datos de todas las áreas.
        /// </summary>
        /// <returns> List de BE_PUESTO con los objetos de la entidad, que a su vez representan la tabla PUESTOS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public static List<BE_PUESTO> SeleccionarPuestos()
        {
            List<BE_PUESTO> oPUESTO = null;
            List<BE_GERENCIA> oGERENCIA = null;
            BE_AREA oAREA = null;
            BE_COORDINACION oCOORDINACION = null;
            List<BE_COORDINACION_PUESTO> oCOORDINACION_PUESTO = null;

            oPUESTO = new DA_PUESTO().SeleccionarPuestos();

            if (oPUESTO != null)
            {
                foreach (var oBE_PUESTO_TMP in oPUESTO)
                {
                    //Por cada puesto se recuperan las gerencias, áreas o coordinaciones a las que está asociado el puesto
                    oCOORDINACION_PUESTO = new DA_COORDINACION_PUESTO().SeleccionarCoordinacionPuestoPorPuesto(oBE_PUESTO_TMP.ID);

                    if (oCOORDINACION_PUESTO != null)
                    {
                        oBE_PUESTO_TMP.lstBE_COORDINACION_PUESTO = oCOORDINACION_PUESTO;

                        foreach (var oBE_COORDINACION_PUESTO_TMP in oCOORDINACION_PUESTO)
                        {
                            //Si el puesto está a nivel de gerencia se llena la lista de gerencias a las que está asociado el puesto
                            if (oBE_PUESTO_TMP.NIVEL == (Int32)BE_PUESTO.PUESTO_NIVEL.Gerencia)
                            {
                                oGERENCIA = new DA_GERENCIA().SeleccionarGerenciaPorId(oBE_COORDINACION_PUESTO_TMP.GERENCIA_ID);
                                if (oGERENCIA != null)
                                    oBE_PUESTO_TMP.lstBE_GERENCIA.Add(oGERENCIA[0]);
                            }
                                
                            //Si el puesto está a nivel de área se llena la lista de áreas a las que está asociado el puesto
                            if (oBE_PUESTO_TMP.NIVEL == (Int32)BE_PUESTO.PUESTO_NIVEL.Area)
                            {
                                oGERENCIA = new DA_GERENCIA().SeleccionarGerenciaPorId(oBE_COORDINACION_PUESTO_TMP.GERENCIA_ID);
                                if (oGERENCIA != null)
                                    oBE_PUESTO_TMP.lstBE_GERENCIA.Add(oGERENCIA[0]);

                                oAREA = new DA_AREA().SeleccionarAreaPorId(oBE_COORDINACION_PUESTO_TMP.AREA_ID);
                                if (oAREA != null)
                                {
                                    oBE_PUESTO_TMP.lstBE_AREA.Add(oAREA);
                                }
                            }

                            //Si el puesto está a nivel de coordinación se llena la lista de coordinaciones a las que está asociado el puesto
                            if (oBE_PUESTO_TMP.NIVEL == (Int32)BE_PUESTO.PUESTO_NIVEL.Coordinacion)
                            {
                                oGERENCIA = new DA_GERENCIA().SeleccionarGerenciaPorId(oBE_COORDINACION_PUESTO_TMP.GERENCIA_ID);
                                if (oGERENCIA != null)
                                    oBE_PUESTO_TMP.lstBE_GERENCIA.Add(oGERENCIA[0]);

                                oAREA = new DA_AREA().SeleccionarAreaPorId(oBE_COORDINACION_PUESTO_TMP.AREA_ID);
                                if (oAREA != null)
                                {
                                    oBE_PUESTO_TMP.lstBE_AREA.Add(oAREA);
                                }
                                oCOORDINACION = new DA_COORDINACION().SeleccionarCoordinacionPorId(oBE_COORDINACION_PUESTO_TMP.COORDINACION_ID);
                                if (oCOORDINACION != null)
                                {
                                    oBE_PUESTO_TMP.lstBE_COORDINACION.Add(oCOORDINACION);
                                }
                            }
                            
                        }
                        
                    }
                   
                }
            }
            return oPUESTO;

        }

        /// <summary>
        /// Devuelve los datos de un puestos por su Id
        /// </summary>
        /// <param name="puesto_id">Codigo del puesto al cual se desea consultar</param>
        /// <returns>BE_PUESTO, entidad que representa la tabla PUESTOS, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public static BE_PUESTO SeleccionarPuestoPorId(Guid puesto_id)
        {
            return new DA_PUESTO().SeleccionarPuestoPorId(puesto_id);
        }

        /// <summary>
        /// Devuelve los datos de puestos por empresa específica.
        /// </summary>
        /// <param name="empresa_id">Id de la empresa  al cual se desea consultar</param>
        /// <returns>BE_PUESTO, entidad que representa la tabla PUESTOS, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public static List<BE_PUESTO> SeleccionarPuestoPorEmpresa(Guid empresa_id)
        {
            return new DA_PUESTO().SeleccionarPuestoPorPresidencia(empresa_id);
        }    
        
        /// <summary>
        /// Devuelve los datos de puestos por gerencia específica.
        /// </summary>
        /// <param name="presidencia_id">Codigo de la gerencia  al cual se desea consultar</param>
        /// <returns>BE_PUESTO, entidad que representa la tabla PUESTOS, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public static List<BE_PUESTO> SeleccionarPuestoPorPresidencia(Guid presidencia_id)
        {
            return new DA_PUESTO().SeleccionarPuestoPorPresidencia(presidencia_id);
        }       
      
        /// <summary>
        /// Devuelve los datos de puestos por una gerencia específica
        /// </summary>
        /// <param name="gerencia_id">Codigo de la gerencia  al cual se desea consultar</param>
        /// <returns>BE_PUESTO, entidad que representa la tabla PUESTOS, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public static List<BE_PUESTO> SeleccionarPuestoPorGerencia(Guid gerencia_id)
        {
            return new DA_PUESTO().SeleccionarPuestoPorGerencia(gerencia_id);
        }

        /// <summary>
        /// Devuelve los datos de puestos por un área específica
        /// </summary>
        /// <param name="area_id">Codigo del área  que se desea consultar</param>
        /// <returns>BE_PUESTO, entidad que representa la tabla PUESTOS, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public static List<BE_PUESTO> SeleccionarPuestoPorArea(Guid area_id)
        {
            return new DA_PUESTO().SeleccionarPuestoPorArea(area_id);
        }

        /// <summary>
        /// Devuelve los datos de puestos por una coordinación específica
        /// </summary>
        /// <param name="coordinacion_id">Codigo de la coordinación  que se desea consultar</param>
        /// <returns>BE_PUESTO, entidad que representa la tabla PUESTOS, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public static List<BE_PUESTO> SeleccionarPuestoPorCoordinacion(Guid coordinacion_id)
        {
            return new DA_PUESTO().SeleccionarPuestoPorCoordinacion(coordinacion_id);
        }
    }
}
