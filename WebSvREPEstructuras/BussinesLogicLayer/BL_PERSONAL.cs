using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BussinesEntities;
using DataAccessLayer;

namespace BussinesLogicLayer
{
    /// <summary>
    /// /// En esta clase se encuentran toda los metodos para la logica de negocio de la tabla PERSONAL
    /// </summary>
    public class BL_PERSONAL
    {

        /// <summary>
        /// Devuelve los datos de todo el personal
        /// </summary>        
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public static List<BE_PERSONAL> SeleccionarPersonal()
        {
            List<BE_PERSONAL> oPERSONAL = null;
            BE_AREA oAREA = null;
            BE_COORDINACION oCOORDINACION = null;
            List<BE_GERENCIA> oGERENCIA = null;
            List<BE_EMPRESA> oEMPRESA = null;
            BE_PUESTO oPUESTO = null;
            List<BE_SEDE> oSEDE = null;
            List<BE_GRUPO_ORGANIZACIONAL> oGRUPO_ORGANIZACIONAL = null;

            oPERSONAL = new DA_PERSONAL().SeleccionarPersonal();

            if (oPERSONAL != null)
            {
                foreach (var oBE_PERSONAL_TMP in oPERSONAL)
                {
                    oEMPRESA = new DA_EMPRESA().SeleccionarEmpresaPorId(oBE_PERSONAL_TMP.EMPRESA_ID);

                    if (oEMPRESA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_EMPRESA = oEMPRESA[0];
                    }

                    oGERENCIA = new DA_GERENCIA().SeleccionarGerenciaPorId(oBE_PERSONAL_TMP.GERENCIA_ID);

                    if (oGERENCIA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_GERENCIA = oGERENCIA[0];
                    }
                    oAREA = new DA_AREA().SeleccionarAreaPorId(oBE_PERSONAL_TMP.AREA_ID);

                    if (oAREA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_AREA = oAREA;
                    }

                    oCOORDINACION = new DA_COORDINACION().SeleccionarCoordinacionPorId(oBE_PERSONAL_TMP.COORDINACION_ID);
                    if (oCOORDINACION != null)
                    {
                        oBE_PERSONAL_TMP.oBE_COORDINACION = oCOORDINACION;
                    }

                    oPUESTO = new DA_PUESTO().SeleccionarPuestoPorId(oBE_PERSONAL_TMP.PUESTO_ID);
                    if (oPUESTO != null)
                    {
                        oBE_PERSONAL_TMP.oBE_PUESTO = oPUESTO;
                    }
                    
                    oGRUPO_ORGANIZACIONAL = new DA_GRUPO_ORGANIZACIONAL().SeleccionarGrupoOrganizacionalPorId(oBE_PERSONAL_TMP.GRUPO_ORGANIZACIONAL_ID);
                    if (oGRUPO_ORGANIZACIONAL != null)
                    {
                        oBE_PERSONAL_TMP.oBE_GRUPO_ORGANIZACIONAL = oGRUPO_ORGANIZACIONAL[0];
                    }

                    oSEDE = new DA_SEDE().SeleccionarSedePorId(oBE_PERSONAL_TMP.SEDE_ID);
                    if (oSEDE != null)
                    {
                        oBE_PERSONAL_TMP.oBE_SEDE = oSEDE[0];
                    }

                }

            }
            return oPERSONAL;
        }

        /// <summary>
        /// Devuelve los datos de todas las personas de una empresa
        /// </summary>        
        /// <param name="empresa_id">Empresa Id a la cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public static List<BE_PERSONAL> SeleccionarPersonalPorEmpresa(Guid empresa_id)
        {
            List<BE_PERSONAL> oPERSONAL = null;
            BE_AREA oAREA = null;
            BE_COORDINACION oCOORDINACION = null;
            List<BE_GERENCIA> oGERENCIA = null;
            List<BE_EMPRESA> oEMPRESA = null;
            BE_PUESTO oPUESTO = null;
            List<BE_SEDE> oSEDE = null;
            List<BE_GRUPO_ORGANIZACIONAL> oGRUPO_ORGANIZACIONAL = null;            

            oPERSONAL = new DA_PERSONAL().SeleccionarPersonalPorEmpresa(empresa_id);

            if (oPERSONAL != null)
            {
                foreach (var oBE_PERSONAL_TMP in oPERSONAL)
                {
                    oEMPRESA = new DA_EMPRESA().SeleccionarEmpresaPorId(oBE_PERSONAL_TMP.EMPRESA_ID);

                    if (oEMPRESA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_EMPRESA = oEMPRESA[0];
                    }

                    oGERENCIA = new DA_GERENCIA().SeleccionarGerenciaPorId(oBE_PERSONAL_TMP.GERENCIA_ID);

                    if (oGERENCIA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_GERENCIA = oGERENCIA[0];
                    }
                    oAREA = new DA_AREA().SeleccionarAreaPorId(oBE_PERSONAL_TMP.AREA_ID);

                    if (oAREA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_AREA = oAREA;
                    }

                    oCOORDINACION = new DA_COORDINACION().SeleccionarCoordinacionPorId(oBE_PERSONAL_TMP.COORDINACION_ID);
                    if (oCOORDINACION != null)
                    {
                        oBE_PERSONAL_TMP.oBE_COORDINACION = oCOORDINACION;
                    }

                    oPUESTO = new DA_PUESTO().SeleccionarPuestoPorId(oBE_PERSONAL_TMP.PUESTO_ID);
                    if (oPUESTO != null)
                    {
                        oBE_PERSONAL_TMP.oBE_PUESTO = oPUESTO;
                    }

                    oGRUPO_ORGANIZACIONAL = new DA_GRUPO_ORGANIZACIONAL().SeleccionarGrupoOrganizacionalPorId(oBE_PERSONAL_TMP.GRUPO_ORGANIZACIONAL_ID);
                    if (oGRUPO_ORGANIZACIONAL != null)
                    {
                        oBE_PERSONAL_TMP.oBE_GRUPO_ORGANIZACIONAL = oGRUPO_ORGANIZACIONAL[0];
                    }

                    oSEDE = new DA_SEDE().SeleccionarSedePorId(oBE_PERSONAL_TMP.SEDE_ID);
                    if (oSEDE != null)
                    {
                        oBE_PERSONAL_TMP.oBE_SEDE = oSEDE[0];
                    }
                }

            }
            return oPERSONAL;
        }

        /// <summary>
        /// Devuelve los datos de todos los gerentes de una empresa
        /// </summary>       
        /// <param name="presidencia_id">Empresa Id a la cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public static List<BE_PERSONAL> SeleccionarPersonalPorPresidencia(Guid presidencia_id)
        {
            List<BE_PERSONAL> oPERSONAL = null;

            BE_AREA oAREA = null;
            BE_COORDINACION oCOORDINACION = null;
            List<BE_GERENCIA> oGERENCIA = null;
            List<BE_EMPRESA> oEMPRESA = null;
            BE_PUESTO oPUESTO = null;
            List<BE_SEDE> oSEDE = null;
            List<BE_GRUPO_ORGANIZACIONAL> oGRUPO_ORGANIZACIONAL = null;

            oPERSONAL = new DA_PERSONAL().SeleccionarPersonalPorPresidencia(presidencia_id);

            if (oPERSONAL != null)
            {
                foreach (var oBE_PERSONAL_TMP in oPERSONAL)
                {
                    oEMPRESA = new DA_EMPRESA().SeleccionarEmpresaPorId(oBE_PERSONAL_TMP.EMPRESA_ID);

                    if (oEMPRESA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_EMPRESA = oEMPRESA[0];
                    }

                    oGERENCIA = new DA_GERENCIA().SeleccionarGerenciaPorId(oBE_PERSONAL_TMP.GERENCIA_ID);

                    if (oGERENCIA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_GERENCIA = oGERENCIA[0];
                    }
                    oAREA = new DA_AREA().SeleccionarAreaPorId(oBE_PERSONAL_TMP.AREA_ID);

                    if (oAREA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_AREA = oAREA;
                    }

                    oCOORDINACION = new DA_COORDINACION().SeleccionarCoordinacionPorId(oBE_PERSONAL_TMP.COORDINACION_ID);
                    if (oCOORDINACION != null)
                    {
                        oBE_PERSONAL_TMP.oBE_COORDINACION = oCOORDINACION;
                    }

                    oPUESTO = new DA_PUESTO().SeleccionarPuestoPorId(oBE_PERSONAL_TMP.PUESTO_ID);
                    if (oPUESTO != null)
                    {
                        oBE_PERSONAL_TMP.oBE_PUESTO = oPUESTO;
                    }

                    oGRUPO_ORGANIZACIONAL = new DA_GRUPO_ORGANIZACIONAL().SeleccionarGrupoOrganizacionalPorId(oBE_PERSONAL_TMP.GRUPO_ORGANIZACIONAL_ID);
                    if (oGRUPO_ORGANIZACIONAL != null)
                    {
                        oBE_PERSONAL_TMP.oBE_GRUPO_ORGANIZACIONAL = oGRUPO_ORGANIZACIONAL[0];
                    }

                    oSEDE = new DA_SEDE().SeleccionarSedePorId(oBE_PERSONAL_TMP.SEDE_ID);
                    if (oSEDE != null)
                    {
                        oBE_PERSONAL_TMP.oBE_SEDE = oSEDE[0];
                    }
                }

            }
            return oPERSONAL;
        }

        /// <summary>
        /// Devuelve los datos de todos las personas de una gerencia
        /// </summary>       
        /// <param name="gerencia_id">Empresa Id a la cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public static List<BE_PERSONAL> SeleccionarPersonalPorGerencia(Guid gerencia_id)
        {
            List<BE_PERSONAL> oPERSONAL = null;

            BE_AREA oAREA = null;
            BE_COORDINACION oCOORDINACION = null;
            List<BE_GERENCIA> oGERENCIA = null;
            List<BE_EMPRESA> oEMPRESA = null;
            BE_PUESTO oPUESTO = null;
            List<BE_SEDE> oSEDE = null;
            List<BE_GRUPO_ORGANIZACIONAL> oGRUPO_ORGANIZACIONAL = null;    

            oPERSONAL = new DA_PERSONAL().SeleccionarPersonalPorGerencia(gerencia_id);

            if (oPERSONAL != null)
            {
                foreach (var oBE_PERSONAL_TMP in oPERSONAL)
                {
                    oEMPRESA = new DA_EMPRESA().SeleccionarEmpresaPorId(oBE_PERSONAL_TMP.EMPRESA_ID);

                    if (oEMPRESA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_EMPRESA = oEMPRESA[0];
                    }

                    oGERENCIA = new DA_GERENCIA().SeleccionarGerenciaPorId(oBE_PERSONAL_TMP.GERENCIA_ID);

                    if (oGERENCIA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_GERENCIA = oGERENCIA[0];
                    }
                    oAREA = new DA_AREA().SeleccionarAreaPorId(oBE_PERSONAL_TMP.AREA_ID);

                    if (oAREA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_AREA = oAREA;
                    }

                    oCOORDINACION = new DA_COORDINACION().SeleccionarCoordinacionPorId(oBE_PERSONAL_TMP.COORDINACION_ID);
                    if (oCOORDINACION != null)
                    {
                        oBE_PERSONAL_TMP.oBE_COORDINACION = oCOORDINACION;
                    }

                    oPUESTO = new DA_PUESTO().SeleccionarPuestoPorId(oBE_PERSONAL_TMP.PUESTO_ID);
                    if (oPUESTO != null)
                    {
                        oBE_PERSONAL_TMP.oBE_PUESTO = oPUESTO;
                    }

                    oGRUPO_ORGANIZACIONAL = new DA_GRUPO_ORGANIZACIONAL().SeleccionarGrupoOrganizacionalPorId(oBE_PERSONAL_TMP.GRUPO_ORGANIZACIONAL_ID);
                    if (oGRUPO_ORGANIZACIONAL != null)
                    {
                        oBE_PERSONAL_TMP.oBE_GRUPO_ORGANIZACIONAL = oGRUPO_ORGANIZACIONAL[0];
                    }

                    oSEDE = new DA_SEDE().SeleccionarSedePorId(oBE_PERSONAL_TMP.SEDE_ID);
                    if (oSEDE != null)
                    {
                        oBE_PERSONAL_TMP.oBE_SEDE = oSEDE[0];
                    }
                }

            }
            return oPERSONAL;
        }

        /// <summary>
        /// Devuelve los datos de todos las personas de una área
        /// </summary>       
        /// <param name="area_id">Empresa Id a la cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public static List<BE_PERSONAL> SeleccionarPersonalPorArea(Guid area_id)
        {
            List<BE_PERSONAL> oPERSONAL = null;

            BE_AREA oAREA = null;
            BE_COORDINACION oCOORDINACION = null;
            List<BE_GERENCIA> oGERENCIA = null;
            List<BE_EMPRESA> oEMPRESA = null;
            BE_PUESTO oPUESTO = null;
            List<BE_SEDE> oSEDE = null;
            List<BE_GRUPO_ORGANIZACIONAL> oGRUPO_ORGANIZACIONAL = null;    

            oPERSONAL = new DA_PERSONAL().SeleccionarPersonalPorArea(area_id);

            if (oPERSONAL != null)
            {
                foreach (var oBE_PERSONAL_TMP in oPERSONAL)
                {
                    oEMPRESA = new DA_EMPRESA().SeleccionarEmpresaPorId(oBE_PERSONAL_TMP.EMPRESA_ID);

                    if (oEMPRESA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_EMPRESA = oEMPRESA[0];
                    }

                    oGERENCIA = new DA_GERENCIA().SeleccionarGerenciaPorId(oBE_PERSONAL_TMP.GERENCIA_ID);

                    if (oGERENCIA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_GERENCIA = oGERENCIA[0];
                    }
                    oAREA = new DA_AREA().SeleccionarAreaPorId(oBE_PERSONAL_TMP.AREA_ID);

                    if (oAREA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_AREA = oAREA;
                    }

                    oCOORDINACION = new DA_COORDINACION().SeleccionarCoordinacionPorId(oBE_PERSONAL_TMP.COORDINACION_ID);
                    if (oCOORDINACION != null)
                    {
                        oBE_PERSONAL_TMP.oBE_COORDINACION = oCOORDINACION;
                    }

                    oPUESTO = new DA_PUESTO().SeleccionarPuestoPorId(oBE_PERSONAL_TMP.PUESTO_ID);
                    if (oPUESTO != null)
                    {
                        oBE_PERSONAL_TMP.oBE_PUESTO = oPUESTO;
                    }

                    oGRUPO_ORGANIZACIONAL = new DA_GRUPO_ORGANIZACIONAL().SeleccionarGrupoOrganizacionalPorId(oBE_PERSONAL_TMP.GRUPO_ORGANIZACIONAL_ID);
                    if (oGRUPO_ORGANIZACIONAL != null)
                    {
                        oBE_PERSONAL_TMP.oBE_GRUPO_ORGANIZACIONAL = oGRUPO_ORGANIZACIONAL[0];
                    }

                    oSEDE = new DA_SEDE().SeleccionarSedePorId(oBE_PERSONAL_TMP.SEDE_ID);
                    if (oSEDE != null)
                    {
                        oBE_PERSONAL_TMP.oBE_SEDE = oSEDE[0];
                    }
                }

            }
            return oPERSONAL;
        }

        /// <summary>
        /// Devuelve los datos de todos las personas de una coordinación
        /// </summary>       
        /// <param name="coordinacion_id">Empresa Id a la cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public static List<BE_PERSONAL> SeleccionarPersonalPorCoordinacion(Guid coordinacion_id)
        {
            List<BE_PERSONAL> oPERSONAL = null;

            BE_AREA oAREA = null;
            BE_COORDINACION oCOORDINACION = null;
            List<BE_GERENCIA> oGERENCIA = null;
            List<BE_EMPRESA> oEMPRESA = null;
            BE_PUESTO oPUESTO = null;
            List<BE_SEDE> oSEDE = null;
            List<BE_GRUPO_ORGANIZACIONAL> oGRUPO_ORGANIZACIONAL = null;    

            oPERSONAL = new DA_PERSONAL().SeleccionarPersonalPorCoordinacion(coordinacion_id);

            if (oPERSONAL != null)
            {
                foreach (var oBE_PERSONAL_TMP in oPERSONAL)
                {
                    oEMPRESA = new DA_EMPRESA().SeleccionarEmpresaPorId(oBE_PERSONAL_TMP.EMPRESA_ID);

                    if (oEMPRESA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_EMPRESA = oEMPRESA[0];
                    }

                    oGERENCIA = new DA_GERENCIA().SeleccionarGerenciaPorId(oBE_PERSONAL_TMP.GERENCIA_ID);

                    if (oGERENCIA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_GERENCIA = oGERENCIA[0];
                    }
                    oAREA = new DA_AREA().SeleccionarAreaPorId(oBE_PERSONAL_TMP.AREA_ID);

                    if (oAREA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_AREA = oAREA;
                    }

                    oCOORDINACION = new DA_COORDINACION().SeleccionarCoordinacionPorId(oBE_PERSONAL_TMP.COORDINACION_ID);
                    if (oCOORDINACION != null)
                    {
                        oBE_PERSONAL_TMP.oBE_COORDINACION = oCOORDINACION;
                    }

                    oPUESTO = new DA_PUESTO().SeleccionarPuestoPorId(oBE_PERSONAL_TMP.PUESTO_ID);
                    if (oPUESTO != null)
                    {
                        oBE_PERSONAL_TMP.oBE_PUESTO = oPUESTO;
                    }

                    oGRUPO_ORGANIZACIONAL = new DA_GRUPO_ORGANIZACIONAL().SeleccionarGrupoOrganizacionalPorId(oBE_PERSONAL_TMP.GRUPO_ORGANIZACIONAL_ID);
                    if (oGRUPO_ORGANIZACIONAL != null)
                    {
                        oBE_PERSONAL_TMP.oBE_GRUPO_ORGANIZACIONAL = oGRUPO_ORGANIZACIONAL[0];
                    }

                    oSEDE = new DA_SEDE().SeleccionarSedePorId(oBE_PERSONAL_TMP.SEDE_ID);
                    if (oSEDE != null)
                    {
                        oBE_PERSONAL_TMP.oBE_SEDE = oSEDE[0];
                    }
                }

            }
            return oPERSONAL;
        }

        /// <summary>
        /// Devuelve los datos del personal que corresponde al nombre de usuario 
        /// </summary>
        /// <param name="NombreUsuario">nombre de usuario al cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public static BE_PERSONAL SeleccionarPersonalPorUsuario(String NombreUsuario)
        {
            return new DA_PERSONAL().SeleccionarPersonalPorUsuario(NombreUsuario);
        }

        /// <summary>
        /// Devuelve los datos de todas las personas que pertenecen a un puesto
        /// </summary>        
        /// <param name="puesto_id">Puesto Id a la cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public static List<BE_PERSONAL> SeleccionarPersonalPorPuesto(Guid puesto_id)
        {
            List<BE_PERSONAL> oPERSONAL = null;
            BE_AREA oAREA = null;
            BE_COORDINACION oCOORDINACION = null;
            List<BE_GERENCIA> oGERENCIA = null;
            List<BE_EMPRESA> oEMPRESA = null;
            BE_PUESTO oPUESTO = null;
            List<BE_SEDE> oSEDE = null;
            List<BE_GRUPO_ORGANIZACIONAL> oGRUPO_ORGANIZACIONAL = null;

            oPERSONAL = new DA_PERSONAL().SeleccionarPersonalPorPuesto(puesto_id);

            if (oPERSONAL != null)
            {
                foreach (var oBE_PERSONAL_TMP in oPERSONAL)
                {
                    oEMPRESA = new DA_EMPRESA().SeleccionarEmpresaPorId(oBE_PERSONAL_TMP.EMPRESA_ID);

                    if (oEMPRESA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_EMPRESA = oEMPRESA[0];
                    }

                    oGERENCIA = new DA_GERENCIA().SeleccionarGerenciaPorId(oBE_PERSONAL_TMP.GERENCIA_ID);

                    if (oGERENCIA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_GERENCIA = oGERENCIA[0];
                    }
                    oAREA = new DA_AREA().SeleccionarAreaPorId(oBE_PERSONAL_TMP.AREA_ID);

                    if (oAREA != null)
                    {
                        oBE_PERSONAL_TMP.oBE_AREA = oAREA;
                    }

                    oCOORDINACION = new DA_COORDINACION().SeleccionarCoordinacionPorId(oBE_PERSONAL_TMP.COORDINACION_ID);
                    if (oCOORDINACION != null)
                    {
                        oBE_PERSONAL_TMP.oBE_COORDINACION = oCOORDINACION;
                    }

                    oPUESTO = new DA_PUESTO().SeleccionarPuestoPorId(oBE_PERSONAL_TMP.PUESTO_ID);
                    if (oPUESTO != null)
                    {
                        oBE_PERSONAL_TMP.oBE_PUESTO = oPUESTO;
                    }

                    oGRUPO_ORGANIZACIONAL = new DA_GRUPO_ORGANIZACIONAL().SeleccionarGrupoOrganizacionalPorId(oBE_PERSONAL_TMP.GRUPO_ORGANIZACIONAL_ID);
                    if (oGRUPO_ORGANIZACIONAL != null)
                    {
                        oBE_PERSONAL_TMP.oBE_GRUPO_ORGANIZACIONAL = oGRUPO_ORGANIZACIONAL[0];
                    }

                    oSEDE = new DA_SEDE().SeleccionarSedePorId(oBE_PERSONAL_TMP.SEDE_ID);
                    if (oSEDE != null)
                    {
                        oBE_PERSONAL_TMP.oBE_SEDE = oSEDE[0];
                    }
                }

            }
            return oPERSONAL;
        }
        


        /// <summary>
        /// Ingresa un nuevo Personal
        /// </summary>
        /// <param name="oBE_PERSONAL">Objeto BE_PERSONAL con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static  Boolean InsertarPersonal(BE_PERSONAL oBE_PERSONAL)
        {
            return new DA_PERSONAL().InsertarPersonal(oBE_PERSONAL);
        }
       

        /// <summary>
        /// Actualizar un Personal
        /// </summary>
        /// <param name="oBE_PERSONAL">Objeto BE_PERSONAL con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean ActualizarPersonal(BE_PERSONAL oBE_PERSONAL)
        {
            return new DA_PERSONAL().ActualizarPersonal(oBE_PERSONAL);
        }
        

        /// <summary>
        /// Elimina un Personal
        /// </summary>
        /// <param name="personal_id">Codigo del personal al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public static Boolean EliminarPersonal(Guid personal_id)
        {
            return new DA_PERSONAL().EliminarPersonal(personal_id);
        }
    }
}
