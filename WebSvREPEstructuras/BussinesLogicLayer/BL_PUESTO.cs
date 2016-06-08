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
            return new DA_PUESTO().SeleccionarPuestos();            
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
            return new DA_PUESTO().SeleccionarPuestoPorEmpresa(empresa_id);
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

        /// <summary>
        /// Inserta los datos de un Puesto
        /// </summary>
        /// <param name="oBE_PUESTO">Entidad BE_PUESTO, que representa la tabla PUESTOS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean InsertarPuesto(BE_PUESTO oBE_PUESTO)
        {
            return new DA_PUESTO().InsertarPuesto(oBE_PUESTO);
        }
        /// <summary>
        /// Actualiza los datos de un Puesto
        /// </summary>
        /// <param name="oBE_PUESTO">Entidad BE_PUESTO, que representa la tabla EMPRESAS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarPuesto(BE_PUESTO oBE_PUESTO)
        {
            return new DA_PUESTO().ActualizarPuesto(oBE_PUESTO);
        }
        /// <summary>
        /// Eliminar los dato de un puesto
        /// </summary>
        /// <param name="puesto_id">Id del puesto que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarPuesto(Guid puesto_id)
        {
            return new DA_PUESTO().EliminarPuesto(puesto_id);
        }
    }
}
