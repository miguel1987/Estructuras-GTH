using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad CUENTA_MAYOR
    /// </summary>
    public class BL_CUENTA_MAYOR
    {
        /// <summary>
        ///  Devuelve los datos de todas las Cuentas Mayores.
        /// </summary>
        /// <returns> List de BE_CUENTA_MAYOR con los objetos de la entidad, que a su vez representan la tabla CUENTAS MAYORES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_CUENTA_MAYOR> SeleccionarCuentasMayores()
        {
            return new DA_CUENTA_MAYOR().SeleccionarCuentasMayores();
        }

        /// <summary>
        /// Ingresa una nueva Cuenta Mayor
        /// </summary>
        /// <param name="oBE_CUENTA_MAYOR">Objeto BE_CUENTA_MAYOR con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean InsertarCuentaMayor(BE_CUENTA_MAYOR oBE_CUENTA_MAYOR)
        {
            return new DA_CUENTA_MAYOR().InsertarCuentaMayor(oBE_CUENTA_MAYOR);
        }

        /// <summary>
        /// Actualiza una Cuenta Mayor
        /// </summary>
        /// <param name="oBE_CUENTA_MAYOR">Objeto BE_CUENTA_MAYOR con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarCuentaMayor(BE_CUENTA_MAYOR oBE_CUENTA_MAYOR)
        {
            return new DA_CUENTA_MAYOR().ActualizarCuentaMayor(oBE_CUENTA_MAYOR);
        }

        /// <summary>
        /// Eliminar una Cuenta Mayor
        /// </summary>
        /// <param name="cuentaMayorId">Codigo de la cuenta mayor que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarCuentaMayor(Guid cuentaMayorId)
        {
            return new DA_CUENTA_MAYOR().EliminarCuentaMayor(cuentaMayorId);
        }
    }
}
