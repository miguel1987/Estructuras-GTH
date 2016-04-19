using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinesEntities;
using DataAccessLayer;

namespace BussinesLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad EMPRESA
    /// </summary>
    public class BL_EMPRESA
    {
        /// <summary>
        ///  Devuelve los datos de todas las EMPRESAS.
        /// </summary>
        /// <returns> List de BE_EMPRESA con los objetos de la entidad, que a su vez representan la tabla EMPRESAS de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_EMPRESA> SeleccionarEmpresa()
        {
            return new DA_EMPRESA().SeleccionarEmpresa();
        }
        /// <summary>
        /// Devuelve los datos de una empresa específica
        /// </summary>
        /// <param name="empresa_id">Codigo del la Gerencia al cual se desea consultar</param>
        /// <returns> BE_EMPRESA con todos sus atributos de la entidad, que a su vez representan la tabla EMPRESAS de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_EMPRESA> SeleccionarEmpresaPorId(Guid empresa_id)
        {
            return new DA_EMPRESA().SeleccionarEmpresaPorId(empresa_id);
        }
        /// <summary>
        /// Inserta los datos de una Empresa
        /// </summary>
        /// <param name="oBE_EMPRESA">Entidad BE_EMPRESA, que representa la tabla EMPRESAS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean InsertarEmpresa(BE_EMPRESA oBE_EMPRESA)
        {
            return new DA_EMPRESA().InsertarEmpresa(oBE_EMPRESA);
        }
        /// <summary>
        /// Actualiza los datos de una Empresa
        /// </summary>
        /// <param name="oBE_EMPRESA">Entidad BE_EMPRESA, que representa la tabla EMPRESAS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarEmpresa(BE_EMPRESA oBE_EMPRESA)
        {
            return new DA_EMPRESA().ActualizarEmpresa(oBE_EMPRESA);
        }
        /// <summary>
        /// Elimina los dato de una empresa
        /// </summary>
        /// <param name="empresa_id">Codigo del la Empresa al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarEmpresa(Guid empresa_id)
        {
            return new DA_EMPRESA().EliminarEmpresa(empresa_id);
        }
    }
}
