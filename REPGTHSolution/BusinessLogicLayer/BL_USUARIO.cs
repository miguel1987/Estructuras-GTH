using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BL_USUARIO
    {       

        /// <summary>
        /// Devueve los datos de todos los usuario
        /// </summary>       
        /// /// <returns> List de BE_USUARIO con los objetos de la entidad, que a su vez representan la tabla USUARIO de la base de datos.En caso no existan datos devuelve nothing.</returns>
        public static List<BE_USUARIO> SeleccionarUsuarios()
        {
            return new DA_USUARIO().SeleccionarUsuarios();
        }

        /// <summary>
        /// Devuelve los datos del usuario que ingresa a la aplicación
        /// </summary>
        /// <param name="NombreUsuario">nombre de usuario al cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public static BE_USUARIO SeleccionarPersonalPorUsuario(String NombreUsuario)
        {   
            BL_PERSONAL BL_PERSONAL = new BL_PERSONAL();
            BE_PERSONAL oBE_PERSONAL = BL_PERSONAL.SeleccionarPersonalPorUsuario(NombreUsuario);
            BE_USUARIO oBE_USUARIO = null;
            if (oBE_PERSONAL != null)
            {                
                oBE_USUARIO = new DA_USUARIO().SeleccionarUsuarioPorPersonalId(oBE_PERSONAL.ID);
                if (oBE_USUARIO != null)
                {
                    oBE_USUARIO.oBE_PERSONAL = oBE_PERSONAL;
                }

            }
            return oBE_USUARIO;
        }

        /// <summary>
        /// Devueve los datos de un usuario
        /// </summary>
        /// <param name="personal_id">Id del personal de la tabla USUARIO</param>
        /// /// <returns> objeto BE_USUARIO de los Usuarios.</returns>
        public static BE_USUARIO SeleccionarUsuarioPorPersonalId(Guid personal_id)
        {
            return new DA_USUARIO().SeleccionarUsuarioPorPersonalId(personal_id);
        }

        /// <summary>
        /// Ingresa un nuevo Usuario
        /// </summary>
        /// <param name="oBE_USUARIO">Objeto BE_USUARIO con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean InsertarUsuario(BE_USUARIO oBE_USUARIO)
        {
            return new DA_USUARIO().InsertarUsuario(oBE_USUARIO);
        }

        /// <summary>
        /// Actualiza un nuevo Usuario
        /// </summary>
        /// <param name="oBE_USUARIO">Objeto BE_USUARIO con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarUsuario(BE_USUARIO oBE_USUARIO)
        {
            return new DA_USUARIO().ActualizarUsuario(oBE_USUARIO);
        }

        /// <summary>
        /// Elimina un Usuario
        /// </summary>
        /// <param name="usuario_id">Codigo del usuario al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarUsuario(Guid usuario_id)
        {
            return new DA_USUARIO().EliminarUsuario(usuario_id);
        }

        /// <summary>
        /// Elimina un Usuario
        /// </summary>
        /// <param name="personal_id">Codigo del personal al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarUsuarioPorPersonal(Guid personal_id)
        {
            return new DA_USUARIO().EliminarUsuarioPorPersonal(personal_id);
        }
    }
}
