using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using BussinesLogicLayer;
using BussinesEntities;

namespace WebSv
{
    /// <summary>
    /// Summary description for REP_Mantenimiento_Estructuras
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class mantenimientoEstructuras : System.Web.Services.WebService
    {
        //Métodos para mantenimiento y consultas a tabla: EMPRESAS
       
        //Seleccionar todas las Empresas
        [WebMethod]
        public List<BE_EMPRESA> SeleccionarEmpresa()
        {
            return BL_EMPRESA.SeleccionarEmpresa();
        }

        //Seleccionar una Empresa por su ID
        [WebMethod]
        public List<BE_EMPRESA> SeleccionarEmpresaPorId(Guid empresa_id)
        {
            return BL_EMPRESA.SeleccionarEmpresaPorId(empresa_id);
        }

        //Insertar una Empresa
        [WebMethod]
        public Boolean InsertarEmpresa(BE_EMPRESA oBE_EMPRESA)
        {
            return BL_EMPRESA.InsertarEmpresa(oBE_EMPRESA);
        }

        //Actualizar una Empresa
        [WebMethod]
        public Boolean ActualizarEmpresa(BE_EMPRESA oBE_EMPRESA)
        {
            return BL_EMPRESA.ActualizarEmpresa(oBE_EMPRESA);
        }

        //Eliminar una Empresa
        [WebMethod]
        public Boolean EliminarEmpresa(Guid empresa_id)
        {
            return BL_EMPRESA.EliminarEmpresa(empresa_id);
        }

        //Métodos para mantenimiento y consultas a tabla: PRESIDENCIA

        //Seleccionar todas las Presidencias
        [WebMethod]
        public List<BE_PRESIDENCIA> SeleccionarPresidencia()
        {
            return BL_PRESIDENCIA.SeleccionarPresidencia();
        }

        //Seleccionar una Presidencia por Id
        [WebMethod]
        public List<BE_PRESIDENCIA> SeleccionarPresidenciaPorId(Guid presidencia_id)
        {
            return BL_PRESIDENCIA.SeleccionarPresidenciaPorId(presidencia_id);
        }

        //Seleccionar todas las Presidencias de una Empresa
        [WebMethod]
        public List<BE_PRESIDENCIA> SeleccionarPresidenciaPorEmpresa(Guid empresa_id)
        {
            return BL_PRESIDENCIA.SeleccionarPresidenciaPorEmpresa(empresa_id);
        }  

        //Métodos para mantenimiento y consultas a tabla: GERENCIAS

        //Seleccionar todas las Gerencias
        [WebMethod]
        public List<BE_GERENCIA> SeleccionarGerencia()
        {
            return BL_GERENCIA.SeleccionarGerencia();
        }

        //Seleccionar una Gerencia por Id
        [WebMethod]
        public List<BE_GERENCIA> SeleccionarGerenciaPorId(Guid gerencia_id)
        {
            return BL_GERENCIA.SeleccionarGerenciaPorId(gerencia_id);
        }

        //Seleccionar todas las Gerencias de una Empresa
        [WebMethod]
        public List<BE_GERENCIA> SeleccionarGerenciaPorEmpresa(Guid empresa_id)
        {
            return BL_GERENCIA.SeleccionarGerenciaPorEmpresa(empresa_id);
        }            

        //Insertar Gerencia
        [WebMethod]
        public Boolean InsertarGerencia(BE_GERENCIA oBE_GERENCIA)
        {
            return BL_GERENCIA.InsertarGerencia(oBE_GERENCIA);
        }

        //Actualizar Gerencia
        [WebMethod]
        public Boolean ActualizarGerencia(BE_GERENCIA oBE_GERENCIA)
        {
            return BL_GERENCIA.ActualizarGerencia(oBE_GERENCIA);
        }

        //Eliminar Gerencia
        [WebMethod]
        public Boolean EliminarGerencia(Guid gerencia_id)
        {
            return BL_GERENCIA.EliminarGerencia(gerencia_id);
        }

        //Métodos para mantenimiento y consultas a tabla: AREAS

        //Seleccionar todas las Áreas
        [WebMethod]
        public List<BE_AREA> SeleccionarAreas()
        {
            return BL_AREA.SeleccionarAreas();
        }

        //Seleccionar todas las Áreas por Gerencia
        [WebMethod]
        public List<BE_AREA> SeleccionarAreaPorGerencia(Guid gerencia_id)
        {
            return BL_AREA.SeleccionarAreaPorGerencia(gerencia_id);
        }

        //Seleccionar todas las Áreas por Id
        [WebMethod]
        public BE_AREA SeleccionarAreaPorId(Guid area_id)
        {
            return BL_AREA.SeleccionarAreaPorId(area_id);
        }

        //Insertar Area
        [WebMethod]
        public Boolean InsertarArea(BE_AREA oBE_AREA)
        {
            return BL_AREA.InsertarArea(oBE_AREA);
        }

        //Actualizar Area
        [WebMethod]
        public Boolean ActualizarArea(BE_AREA oBE_AREA)
        {
            return BL_AREA.ActualizarArea(oBE_AREA);
        }

        //Eliminar Area
        [WebMethod]
        public Boolean EliminarArea(Guid area_id)
        {
            return BL_AREA.EliminarArea(area_id);
        }

        //Métodos para mantenimiento y consultas a tabla: COORDINACION

        //Seleccionar Todas Las Coordinaciones
        [WebMethod]
        public List<BE_COORDINACION> SeleccionarCoordinaciones()
        {
            return BL_COORDINACION.SeleccionarCoordinaciones();
        }

        //Seleccionar las Coordinaciones por Área 
        [WebMethod]
        public List<BE_COORDINACION> SeleccionarCoordinacionesPorArea(Guid area_id)
        {
            return BL_COORDINACION.SeleccionarCoordinacionesPorArea(area_id);
        }

        //Seleccionar Coordinación por Id        
        [WebMethod]
        public BE_COORDINACION SeleccionarCoordinacionPorId(Guid coordinacion_id)
        {
            return BL_COORDINACION.SeleccionarCoordinacionPorId(coordinacion_id);
        }

        //Insertar Coordinación
        [WebMethod]
        public Boolean InsertarCoordinacion(BE_COORDINACION oBE_COORDINACION)
        {
            return BL_COORDINACION.InsertarCoordinacion(oBE_COORDINACION);
        }

        //Actualizar Coordinación
        [WebMethod]
        public Boolean ActualizarCoordinacion(BE_COORDINACION oBE_COORDINACION)
        {
            return BL_COORDINACION.ActualizarCoordinacion(oBE_COORDINACION);
        }

        //Eliminar Coordinación
        [WebMethod]
        public Boolean EliminarCoordinacion(Guid coordinacion_id)
        {
            return BL_COORDINACION.EliminarCoordinacion(coordinacion_id);
        }

        //Métodos para mantenimiento y consultas a tabla: PUESTO
        
        //Seleccionar todos los puestos
        [WebMethod]
        public List<BE_PUESTO> SeleccionarPuestos()
        {
            return BL_PUESTO.SeleccionarPuestos();
        }

        //Seleccionar todos los puestos
        [WebMethod]
        public List<BE_PUESTO> SeleccionarPuestosPorEmpresa(Guid empresa_id)
        {
            return BL_PUESTO.SeleccionarPuestoPorEmpresa(empresa_id);
        }


        //Seleccionar puesto por Id
        [WebMethod]
        public BE_PUESTO SeleccionarPuestoPorId(Guid puesto_id)
        {
            return BL_PUESTO.SeleccionarPuestoPorId(puesto_id);
        }

        //Seleccionar puestos por Presidencia
        [WebMethod]
        public List<BE_PUESTO> SeleccionarPuestoPorPresidencia(Guid presidencia_id)
        {
            return BL_PUESTO.SeleccionarPuestoPorPresidencia(presidencia_id);
        }

        //Seleccionar puestos por Gerencia
        [WebMethod]
        public List<BE_PUESTO> SeleccionarPuestoPorGerencia(Guid gerencia_id)
        {
            return BL_PUESTO.SeleccionarPuestoPorGerencia(gerencia_id);
        }

        //Seleccionar puestos por Área
        [WebMethod]
        public List<BE_PUESTO> SeleccionarPuestoPorArea(Guid area_id)
        {
            return BL_PUESTO.SeleccionarPuestoPorArea(area_id);
        }

        //Seleccionar puestos por Coordinación
        [WebMethod]
        public List<BE_PUESTO> SeleccionarPuestoPorCoordinacion(Guid coordinacion_id)
        {
            return BL_PUESTO.SeleccionarPuestoPorCoordinacion(coordinacion_id);
        }

        //Insertar
        [WebMethod]
        public Boolean InsertarPuesto(BE_PUESTO oBE_PUESTO)
        {
            return BL_PUESTO.InsertarPuesto(oBE_PUESTO);
        }

        ////Actualizar
        [WebMethod]
        public Boolean ActualizarPuesto(BE_PUESTO oBE_PUESTO)
        {
            return BL_PUESTO.ActualizarPuesto(oBE_PUESTO);
        }

        ////Eliminar
        [WebMethod]
        public Boolean EliminarPuesto(Guid puesto_id)
        {
            return BL_PUESTO.EliminarPuesto(puesto_id);
        }

        //Métodos para mantenimiento y consultas a tabla: SEDES

        //Seleccionar todas las Sedes
        [WebMethod]
        public List<BE_SEDE> SeleccionarSede()
        {
            return BL_SEDE.SeleccionarSede();
        }

        //Seleccionar una Sede por Id
        [WebMethod]
        public List<BE_SEDE> SeleccionarSedePorId(Guid sede_id)
        {
            return BL_SEDE.SeleccionarSedePorId(sede_id);
        }

        //Seleccionar todas las Sedes de una Empresa
        [WebMethod]
        public List<BE_SEDE> SeleccionarSedePorEmpresa(Guid empresa_id)
        {
            return BL_SEDE.SeleccionarSedePorEmpresa(empresa_id);
        }

        //Insertar Sede
        [WebMethod]
        public Boolean InsertarSede(BE_SEDE oBE_SEDE)
        {
            return BL_SEDE.InsertarSede(oBE_SEDE);
        }

        //Actualizar Sede
        [WebMethod]
        public Boolean ActualizarSede(BE_SEDE oBE_SEDE)
        {
            return BL_SEDE.ActualizarSede(oBE_SEDE);
        }

        //Eliminar Sede
        [WebMethod]
        public Boolean EliminarSede(Guid sede_id)
        {
            return BL_SEDE.EliminarSede(sede_id);
        }


        //Métodos para mantenimiento y consultas a tabla: GRUPOS_ORGANIZACIONALES

        //Seleccionar todos los Grupos Organizacionales
        [WebMethod]
        public List<BE_GRUPO_ORGANIZACIONAL> SeleccionarGrupoOrganizacional()
        {
            return BL_GRUPO_ORGANIZACIONAL.SeleccionarGrupoOrganizacional();
        }

        //Seleccionar una Grupo Organizacional por Id
        [WebMethod]
        public List<BE_GRUPO_ORGANIZACIONAL> SeleccionarGrupoOrganizacionalPorId(Guid grupo_organizacinal_id)
        {
            return BL_GRUPO_ORGANIZACIONAL.SeleccionarGrupoOrganizacionalPorId(grupo_organizacinal_id);
        }     

        //Insertar Grupo Organizacional
        [WebMethod]
        public Boolean InsertarGrupoOrganizacional(BE_GRUPO_ORGANIZACIONAL oBE_GRUPO_ORGANIZACIONAL)
        {
            return BL_GRUPO_ORGANIZACIONAL.InsertarGrupoOrganizacional(oBE_GRUPO_ORGANIZACIONAL);
        }

        //Actualizar Grupo OrganizacionaL
        [WebMethod]
        public Boolean ActualizarGrupoOrganizacional(BE_GRUPO_ORGANIZACIONAL oBE_GRUPO_ORGANIZACIONAL)
        {
            return BL_GRUPO_ORGANIZACIONAL.ActualizarGrupoOrganizacional(oBE_GRUPO_ORGANIZACIONAL);
        }

        //Eliminar Grupo OrganizacionaL
        [WebMethod]
        public Boolean EliminarGrupoOrganizacional(Guid grupo_organizacional_id)
        {
            return BL_GRUPO_ORGANIZACIONAL.EliminarGrupoOrganizacional(grupo_organizacional_id);
        }
        
        //Métodos para mantenimiento y consultas a tabla: PERSONAL

        //Seleccionar todos los colaboradores 
        [WebMethod]
        public List<BE_PERSONAL> SeleccionarPersonal()
        {
            return BL_PERSONAL.SeleccionarPersonal();
        }

        //Seleccionar todos los colaboradores de una empresa
        [WebMethod]
        public List<BE_PERSONAL> SeleccionarPersonalPorEmpresa(Guid empresa_id)
        {
            return BL_PERSONAL.SeleccionarPersonalPorEmpresa(empresa_id);
        }

        //Seleccionar todos los gerentes de una empresa
        [WebMethod]
        public List<BE_PERSONAL> SeleccionarPersonalPorPresidencia(Guid presidencia_id)
        {
            return BL_PERSONAL.SeleccionarPersonalPorPresidencia(presidencia_id);
        }

        //Seleccionar todos los colaboradores de una gerencia
        [WebMethod]
        public List<BE_PERSONAL> SeleccionarPersonalPorGerencia(Guid gerencia_id)
        {
            return BL_PERSONAL.SeleccionarPersonalPorGerencia(gerencia_id);
        }

        //Seleccionar todos los colaboradores de una área
        [WebMethod]
        public List<BE_PERSONAL> SeleccionarPersonalPorArea(Guid area_id)
        {
            return BL_PERSONAL.SeleccionarPersonalPorArea(area_id);
        }

        //Seleccionar todos los colaboradores de una coordinación
        [WebMethod]
        public List<BE_PERSONAL> SeleccionarPersonalPorCoordinacion(Guid coordinacion_id)
        {
            return BL_PERSONAL.SeleccionarPersonalPorCoordinacion(coordinacion_id);
        }

        //Seleccionar todos los colaboradores de una sede
        [WebMethod]
        public List<BE_PERSONAL> SeleccionarPersonalPorSede(Guid sede_id)
        {
            return BL_PERSONAL.SeleccionarPersonalPorSede(sede_id);
        }

        //Seleccionar todos los colaboradores que perteneces a un grupo organizacional
        [WebMethod]
        public List<BE_PERSONAL> SeleccionarPersonalPorGrupoOrganizacional(Guid grupo_organizacional_id)
        {
            return BL_PERSONAL.SeleccionarPersonalPorGrupoOrganizacional(grupo_organizacional_id);
        }

        //Seleccionar datos de Personal por username
        [WebMethod]
        public BE_PERSONAL SeleccionarPersonalPorUsuario(String NombreUsuario)
        {
            return BL_PERSONAL.SeleccionarPersonalPorUsuario(NombreUsuario);
        }

        //Seleccionar todos los colaboradores de que pertenecen a un puesto
        [WebMethod]
        public List<BE_PERSONAL> SeleccionarPersonalPorPuesto(Guid puesto_id)
        {
            return BL_PERSONAL.SeleccionarPersonalPorPuesto(puesto_id);
        }


        //Insertar
        [WebMethod]
        public Boolean InsertarPersonal(BE_PERSONAL oBE_PERSONAL)
        {
            return BL_PERSONAL.InsertarPersonal(oBE_PERSONAL);
        }

        //Actualizar
        [WebMethod]
        public Boolean ActualizarPersonal(BE_PERSONAL oBE_PERSONAL)
        {
            return BL_PERSONAL.ActualizarPersonal(oBE_PERSONAL);
        }

        //Eliminar
        [WebMethod]
        public Boolean EliminarPersonal(Guid personal_id)
        {
            return BL_PERSONAL.EliminarPersonal(personal_id);
        }

    }
}
