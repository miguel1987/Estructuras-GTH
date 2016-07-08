using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BL_PERSONAL
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        //wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();

        /// <summary>
        /// Devuelve los datos de todo el personal
        /// </summary>        
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonal()
        {
            wsMaestros.BE_PERSONAL[] oLista = wsMantenimientoEstructuras.SeleccionarPersonal();
            
            List<BE_PERSONAL> oPERSONAL = new List<BE_PERSONAL>();
            BE_PERFILES oBE_PERFILES = null;
            BE_USUARIO oBE_USUARIO = null;

            if (oLista != null)
            {            

                foreach (var item in  oLista)
                {
                    BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                    oBE_PERSONAL.ID = item.ID;
                    oBE_PERSONAL.CODIGO_TRABAJO = item.CODIGO_TRABAJO;
                    oBE_PERSONAL.APELLIDO_PATERNO = item.APELLIDO_PATERNO;
                    oBE_PERSONAL.APELLIDO_MATERNO = item.APELLIDO_MATERNO;
                    oBE_PERSONAL.NOMBRES = item.NOMBRES;
                    oBE_PERSONAL.NOMBRES_COMPLETOS = item.NOMBRES_COMPLETOS;
                    oBE_PERSONAL.GERENCIA_ID = item.GERENCIA_ID;
                    oBE_PERSONAL.AREA_ID = item.AREA_ID;                    
                    oBE_PERSONAL.PUESTO_ID = item.PUESTO_ID;
                    oBE_PERSONAL.CORREO = item.CORREO;
                    oBE_PERSONAL.NOMBRE_USUARIO = item.NOMBRE_USUARIO;
                    oBE_PERSONAL.EMPRESA_ID = item.EMPRESA_ID;
                    oBE_PERSONAL.COORDINACION_ID = item.COORDINACION_ID;
                    oBE_PERSONAL.SEDE_ID = item.SEDE_ID;
                    oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = item.GRUPO_ORGANIZACIONAL_ID;

                    oBE_USUARIO = BL_USUARIO.SeleccionarPersonalPorUsuario(oBE_PERSONAL.NOMBRE_USUARIO);

                    if (oBE_USUARIO != null)
                        oBE_PERSONAL.PERFIL_ID = oBE_USUARIO.PERFIL_ID;
                    else
                        oBE_PERSONAL.PERFIL_ID = 0; //Sin Perfil

                    oBE_PERFILES = new DA_PERFILES().SeleccionarPerfilesPorID(oBE_PERSONAL.PERFIL_ID);

                    if (oBE_PERFILES != null)
                    {
                        oBE_PERSONAL.oBE_PERFILES = oBE_PERFILES;
                    }

                    wsMaestros.BE_COORDINACION oCoordinacion = wsMantenimientoEstructuras.SeleccionarCoordinacionPorId(oBE_PERSONAL.COORDINACION_ID);

                    if (oCoordinacion != null)
                    {
                        BE_COORDINACION oBE_COORDINACION = new BE_COORDINACION();
                        oBE_COORDINACION.ID = oCoordinacion.ID;
                        oBE_COORDINACION.DESCRIPCION = oCoordinacion.DESCRIPCION;
                        oBE_COORDINACION.CODIGO = oCoordinacion.CODIGO;
                        oBE_COORDINACION.AREA_ID = oCoordinacion.AREA_ID;
                        oBE_PERSONAL.oBE_COORDINACION = oBE_COORDINACION;

                    }

                    wsMaestros.BE_SEDE[] oSede = wsMantenimientoEstructuras.SeleccionarSedePorId(oBE_PERSONAL.SEDE_ID);
                    if (oSede != null)
                    {
                        foreach (var itemSede in oSede)
                        {
                            BE_SEDE oBE_SEDE = new BE_SEDE();
                            oBE_SEDE.ID = itemSede.ID;
                            oBE_SEDE.CODIGO = itemSede.CODIGO;
                            oBE_SEDE.DESCRIPCION = itemSede.DESCRIPCION;
                            oBE_SEDE.EMPRESA_ID = itemSede.EMPRESA_ID;
                            oBE_PERSONAL.oBE_SEDE = oBE_SEDE;
                        }
                    }

                    wsMaestros.BE_PUESTO oPuesto = wsMantenimientoEstructuras.SeleccionarPuestoPorId(oBE_PERSONAL.PUESTO_ID);
                    if (oPuesto != null)
                    {
                        BE_PUESTO oBE_PUESTO = new BE_PUESTO();
                        oBE_PUESTO.ID = oPuesto.ID;
                        oBE_PUESTO.DESCRIPCION = oPuesto.DESCRIPCION;
                        oBE_PUESTO.CODIGO = oPuesto.CODIGO;
                        oBE_PUESTO.EMPRESA_ID = oPuesto.EMPRESA_ID;
                        oBE_PERSONAL.oBE_PUESTO = oBE_PUESTO;

                    }

                    wsMaestros.BE_GRUPO_ORGANIZACIONAL[] oGrupoOrganizacional = wsMantenimientoEstructuras.SeleccionarGrupoOrganizacionalPorId(oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID);
                    if (oGrupoOrganizacional != null)
                    {
                        foreach (var itemSede in oGrupoOrganizacional)
                        {
                            BE_GRUPO_ORGANIZACIONAL oBE_GRUPO_ORGANIZACIONAL = new BE_GRUPO_ORGANIZACIONAL();
                            oBE_GRUPO_ORGANIZACIONAL.ID = itemSede.ID;
                            oBE_GRUPO_ORGANIZACIONAL.CODIGO = itemSede.CODIGO;
                            oBE_GRUPO_ORGANIZACIONAL.DESCRIPCION = itemSede.DESCRIPCION;
                            oBE_PERSONAL.oBE_GRUPO_ORGANIZACIONAL = oBE_GRUPO_ORGANIZACIONAL;
                        }

                    }

                    wsMaestros.BE_AREA[] oArea = wsMantenimientoEstructuras.SeleccionarAreas();
                    if (oArea != null)
                    {
                        foreach (var itemArea in oArea)
                        {
                            BE_AREA oBE_AREA = new BE_AREA();
                            if (oBE_PERSONAL.AREA_ID == itemArea.ID)
                            {
                                oBE_AREA.ID = itemArea.ID;
                                oBE_AREA.DESCRIPCION = itemArea.DESCRIPCION;
                                oBE_AREA.GERENCIA_ID = itemArea.GERENCIA_ID;
                                oBE_PERSONAL.oBE_AREA = oBE_AREA;

                                wsMaestros.BE_GERENCIA[] oGerencia = wsMantenimientoEstructuras.SeleccionarGerencia();
                                if (oGerencia != null)
                                {
                                    foreach (var itemGerencia in oGerencia)
                                    {
                                        BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();

                                        if (oBE_PERSONAL.GERENCIA_ID == itemGerencia.ID)
                                        {
                                            oBE_GERENCIA.ID = itemGerencia.ID;
                                            oBE_GERENCIA.DESCRIPCION = itemGerencia.DESCRIPCION;
                                            oBE_PERSONAL.oBE_GERENCIA = oBE_GERENCIA;

                                            wsMaestros.BE_EMPRESA[] oEmpresa = wsMantenimientoEstructuras.SeleccionarEmpresa();
                                            if (oEmpresa != null)
                                            {
                                                foreach (var itemEmpresa in oEmpresa)
                                                {
                                                    BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();

                                                    if (oBE_PERSONAL.EMPRESA_ID == itemEmpresa.ID)
                                                    {
                                                        oBE_EMPRESA.ID = itemEmpresa.ID;
                                                        oBE_EMPRESA.DESCRIPCION = itemEmpresa.DESCRIPCION;
                                                        oBE_PERSONAL.oBE_EMPRESA = oBE_EMPRESA;
                                                    }

                                                }
                                            }


                                        }

                                    }
                                }

                            }

                        }
                    }

                    oPERSONAL.Add(oBE_PERSONAL);                                
                }

            }
            
            return oPERSONAL;
        }

        /// <summary>
        /// Devuelve los datos de todo el personal que pertenece a una empresa
        /// </summary>        
        /// <param name="empresa_id">Id de la empresa cuyo personal se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonalPorEmpresa(Guid empresa_id)
        {
            wsMaestros.BE_PERSONAL[] oLista = wsMantenimientoEstructuras.SeleccionarPersonalPorEmpresa(empresa_id);

            List<BE_PERSONAL> oPERSONAL = new List<BE_PERSONAL>();            

            if (oLista != null)
            {
            
                foreach (var item in oLista)
                {
                    BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                    oBE_PERSONAL.ID = item.ID;
                    oBE_PERSONAL.CODIGO_TRABAJO = item.CODIGO_TRABAJO;
                    oBE_PERSONAL.APELLIDO_PATERNO = item.APELLIDO_PATERNO;
                    oBE_PERSONAL.APELLIDO_MATERNO = item.APELLIDO_MATERNO;
                    oBE_PERSONAL.NOMBRES = item.NOMBRES;
                    oBE_PERSONAL.NOMBRES_COMPLETOS = item.NOMBRES_COMPLETOS;
                    oBE_PERSONAL.GERENCIA_ID = item.GERENCIA_ID;
                    oBE_PERSONAL.AREA_ID = item.AREA_ID;
                    oBE_PERSONAL.DEPARTAMENTO = item.DEPARTAMENTO;
                    oBE_PERSONAL.PUESTO = item.PUESTO;
                    oBE_PERSONAL.CORREO = item.CORREO;
                    oBE_PERSONAL.NOMBRE_USUARIO = item.NOMBRE_USUARIO;
                    oBE_PERSONAL.EMPRESA_ID = item.EMPRESA_ID;
                    oBE_PERSONAL.COORDINACION_ID = item.COORDINACION_ID;
                    oBE_PERSONAL.SEDE_ID = item.SEDE_ID;
                    oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = item.GRUPO_ORGANIZACIONAL_ID;            

                    oPERSONAL.Add(oBE_PERSONAL);
                }
            }

            return oPERSONAL;
        }

        /// <summary>
        /// Devuelve los datos de todo el personal que pertenece a una gerencia
        /// </summary>        
        /// <param name="gerencia_id">Id de la gerencia cuyo personal se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonalPorGerencia(Guid gerencia_id)
        {
            wsMaestros.BE_PERSONAL[] oLista = wsMantenimientoEstructuras.SeleccionarPersonalPorGerencia(gerencia_id);

            List<BE_PERSONAL> oPERSONAL = new List<BE_PERSONAL>();

            if (oLista != null)
            {

                foreach (var item in oLista)
                {
                    BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                    oBE_PERSONAL.ID = item.ID;
                    oBE_PERSONAL.CODIGO_TRABAJO = item.CODIGO_TRABAJO;
                    oBE_PERSONAL.APELLIDO_PATERNO = item.APELLIDO_PATERNO;
                    oBE_PERSONAL.APELLIDO_MATERNO = item.APELLIDO_MATERNO;
                    oBE_PERSONAL.NOMBRES = item.NOMBRES;
                    oBE_PERSONAL.NOMBRES_COMPLETOS = item.NOMBRES_COMPLETOS;
                    oBE_PERSONAL.GERENCIA_ID = item.GERENCIA_ID;
                    oBE_PERSONAL.AREA_ID = item.AREA_ID;
                    oBE_PERSONAL.DEPARTAMENTO = item.DEPARTAMENTO;
                    oBE_PERSONAL.PUESTO = item.PUESTO;
                    oBE_PERSONAL.CORREO = item.CORREO;
                    oBE_PERSONAL.NOMBRE_USUARIO = item.NOMBRE_USUARIO;
                    oBE_PERSONAL.EMPRESA_ID = item.EMPRESA_ID;
                    oBE_PERSONAL.COORDINACION_ID = item.COORDINACION_ID;
                    oBE_PERSONAL.SEDE_ID = item.SEDE_ID;
                    oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = item.GRUPO_ORGANIZACIONAL_ID;

                    oPERSONAL.Add(oBE_PERSONAL);
                }

            }
            return oPERSONAL;
        }

        /// <summary>
        /// Devuelve los datos de todo el personal que pertenece a una área
        /// </summary>        
        /// <param name="area_id">Id de la gerencia cuyo personal se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonalPorArea(Guid area_id)
        {
            wsMaestros.BE_PERSONAL[] oLista = wsMantenimientoEstructuras.SeleccionarPersonalPorArea(area_id);

            List<BE_PERSONAL> oPERSONAL = new List<BE_PERSONAL>();

            if (oLista != null)
            {

                foreach (var item in oLista)
                {
                    BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                    oBE_PERSONAL.ID = item.ID;
                    oBE_PERSONAL.CODIGO_TRABAJO = item.CODIGO_TRABAJO;
                    oBE_PERSONAL.APELLIDO_PATERNO = item.APELLIDO_PATERNO;
                    oBE_PERSONAL.APELLIDO_MATERNO = item.APELLIDO_MATERNO;
                    oBE_PERSONAL.NOMBRES = item.NOMBRES;
                    oBE_PERSONAL.NOMBRES_COMPLETOS = item.NOMBRES_COMPLETOS;
                    oBE_PERSONAL.GERENCIA_ID = item.GERENCIA_ID;
                    oBE_PERSONAL.AREA_ID = item.AREA_ID;
                    oBE_PERSONAL.DEPARTAMENTO = item.DEPARTAMENTO;
                    oBE_PERSONAL.PUESTO = item.PUESTO;
                    oBE_PERSONAL.CORREO = item.CORREO;
                    oBE_PERSONAL.NOMBRE_USUARIO = item.NOMBRE_USUARIO;
                    oBE_PERSONAL.EMPRESA_ID = item.EMPRESA_ID;
                    oBE_PERSONAL.COORDINACION_ID = item.COORDINACION_ID;
                    oBE_PERSONAL.SEDE_ID = item.SEDE_ID;
                    oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = item.GRUPO_ORGANIZACIONAL_ID;

                    oPERSONAL.Add(oBE_PERSONAL);
                }
            }

            return oPERSONAL;
        }



        /// <summary>
        /// Devuelve los datos de todo el personal que pertenece a una coordinación
        /// </summary>        
        /// <param name="coordinacion_id">Id de la coordinacion cuyo personal se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonalPorCoordinacion(Guid coordinacion_id)
        {
            wsMaestros.BE_PERSONAL[] oLista = wsMantenimientoEstructuras.SeleccionarPersonalPorCoordinacion(coordinacion_id);

            List<BE_PERSONAL> oPERSONAL = new List<BE_PERSONAL>();

            if (oLista != null)
            {

                foreach (var item in oLista)
                {
                    BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                    oBE_PERSONAL.ID = item.ID;
                    oBE_PERSONAL.CODIGO_TRABAJO = item.CODIGO_TRABAJO;
                    oBE_PERSONAL.APELLIDO_PATERNO = item.APELLIDO_PATERNO;
                    oBE_PERSONAL.APELLIDO_MATERNO = item.APELLIDO_MATERNO;
                    oBE_PERSONAL.NOMBRES = item.NOMBRES;
                    oBE_PERSONAL.NOMBRES_COMPLETOS = item.NOMBRES_COMPLETOS;
                    oBE_PERSONAL.GERENCIA_ID = item.GERENCIA_ID;
                    oBE_PERSONAL.AREA_ID = item.AREA_ID;
                    oBE_PERSONAL.DEPARTAMENTO = item.DEPARTAMENTO;
                    oBE_PERSONAL.PUESTO = item.PUESTO;
                    oBE_PERSONAL.CORREO = item.CORREO;
                    oBE_PERSONAL.NOMBRE_USUARIO = item.NOMBRE_USUARIO;
                    oBE_PERSONAL.EMPRESA_ID = item.EMPRESA_ID;
                    oBE_PERSONAL.COORDINACION_ID = item.COORDINACION_ID;
                    oBE_PERSONAL.SEDE_ID = item.SEDE_ID;
                    oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = item.GRUPO_ORGANIZACIONAL_ID;

                    oPERSONAL.Add(oBE_PERSONAL);
                }
            }

            return oPERSONAL;
        }

        /// <summary>
        /// Devuelve los datos de todo el personal que pertenece a una sede
        /// </summary>        
        /// <param name="sede_id">Id de la sede cuyo personal se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonalPorSede(Guid sede_id)
        {
            wsMaestros.BE_PERSONAL[] oLista = wsMantenimientoEstructuras.SeleccionarPersonalPorSede(sede_id);

            List<BE_PERSONAL> oPERSONAL = new List<BE_PERSONAL>();

            if (oLista != null)
            {
                foreach (var item in oLista)
                {
                    BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                    oBE_PERSONAL.ID = item.ID;
                    oBE_PERSONAL.CODIGO_TRABAJO = item.CODIGO_TRABAJO;
                    oBE_PERSONAL.APELLIDO_PATERNO = item.APELLIDO_PATERNO;
                    oBE_PERSONAL.APELLIDO_MATERNO = item.APELLIDO_MATERNO;
                    oBE_PERSONAL.NOMBRES = item.NOMBRES;
                    oBE_PERSONAL.NOMBRES_COMPLETOS = item.NOMBRES_COMPLETOS;
                    oBE_PERSONAL.GERENCIA_ID = item.GERENCIA_ID;
                    oBE_PERSONAL.AREA_ID = item.AREA_ID;
                    oBE_PERSONAL.DEPARTAMENTO = item.DEPARTAMENTO;
                    oBE_PERSONAL.PUESTO = item.PUESTO;
                    oBE_PERSONAL.CORREO = item.CORREO;
                    oBE_PERSONAL.NOMBRE_USUARIO = item.NOMBRE_USUARIO;
                    oBE_PERSONAL.EMPRESA_ID = item.EMPRESA_ID;
                    oBE_PERSONAL.COORDINACION_ID = item.COORDINACION_ID;
                    oBE_PERSONAL.SEDE_ID = item.SEDE_ID;
                    oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = item.GRUPO_ORGANIZACIONAL_ID;

                    oPERSONAL.Add(oBE_PERSONAL);
                }
            }

            return oPERSONAL;
        }

        /// <summary>
        /// Devuelve los datos de todo el personal que pertenece a un grupo organizacional
        /// </summary>        
        /// <param name="grupo_organizacional_id">Id del grupo organizacional cuyo personal se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonalPorGrupoOrganizacional(Guid grupo_organizacional_id)
        {
            wsMaestros.BE_PERSONAL[] oLista = wsMantenimientoEstructuras.SeleccionarPersonalPorGrupoOrganizacional(grupo_organizacional_id);

            List<BE_PERSONAL> oPERSONAL = new List<BE_PERSONAL>();

            if (oLista != null)
            {

                foreach (var item in oLista)
                {
                    BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                    oBE_PERSONAL.ID = item.ID;
                    oBE_PERSONAL.CODIGO_TRABAJO = item.CODIGO_TRABAJO;
                    oBE_PERSONAL.APELLIDO_PATERNO = item.APELLIDO_PATERNO;
                    oBE_PERSONAL.APELLIDO_MATERNO = item.APELLIDO_MATERNO;
                    oBE_PERSONAL.NOMBRES = item.NOMBRES;
                    oBE_PERSONAL.NOMBRES_COMPLETOS = item.NOMBRES_COMPLETOS;
                    oBE_PERSONAL.GERENCIA_ID = item.GERENCIA_ID;
                    oBE_PERSONAL.AREA_ID = item.AREA_ID;
                    oBE_PERSONAL.DEPARTAMENTO = item.DEPARTAMENTO;
                    oBE_PERSONAL.PUESTO = item.PUESTO;
                    oBE_PERSONAL.CORREO = item.CORREO;
                    oBE_PERSONAL.NOMBRE_USUARIO = item.NOMBRE_USUARIO;
                    oBE_PERSONAL.EMPRESA_ID = item.EMPRESA_ID;
                    oBE_PERSONAL.COORDINACION_ID = item.COORDINACION_ID;
                    oBE_PERSONAL.SEDE_ID = item.SEDE_ID;
                    oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = item.GRUPO_ORGANIZACIONAL_ID;

                    oPERSONAL.Add(oBE_PERSONAL);
                }
            }

            return oPERSONAL;
        }

        /// <summary>
        /// Devuelve los datos del personal que corresponde al nombre de usuario 
        /// </summary>
        /// <param name="NombreUsuario">nombre de usuario al cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public BE_PERSONAL SeleccionarPersonalPorUsuario(String NombreUsuario)
        {
            wsMaestros.BE_PERSONAL oPersonal = wsMantenimientoEstructuras.SeleccionarPersonalPorUsuario(NombreUsuario);
            
            BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
            BE_GRUPO_ORGANIZACIONAL oGRUPO_ORGANIZACIONAL = new BE_GRUPO_ORGANIZACIONAL();
            
            if (oPersonal != null)
            {
                oBE_PERSONAL.ID = oPersonal.ID;
                oBE_PERSONAL.CODIGO_TRABAJO = oPersonal.CODIGO_TRABAJO;
                oBE_PERSONAL.APELLIDO_PATERNO = oPersonal.APELLIDO_PATERNO;
                oBE_PERSONAL.APELLIDO_MATERNO = oPersonal.APELLIDO_MATERNO;
                oBE_PERSONAL.NOMBRES = oPersonal.NOMBRES;
                oBE_PERSONAL.NOMBRES_COMPLETOS = oPersonal.NOMBRES_COMPLETOS;
                oBE_PERSONAL.GERENCIA_ID = oPersonal.GERENCIA_ID;
                oBE_PERSONAL.AREA_ID = oPersonal.AREA_ID;
                oBE_PERSONAL.DEPARTAMENTO = oPersonal.DEPARTAMENTO;
                oBE_PERSONAL.PUESTO = oPersonal.PUESTO;
                oBE_PERSONAL.CORREO = oPersonal.CORREO;
                oBE_PERSONAL.NOMBRE_USUARIO = oPersonal.NOMBRE_USUARIO;
                oBE_PERSONAL.EMPRESA_ID = oPersonal.EMPRESA_ID;
                oBE_PERSONAL.COORDINACION_ID = oPersonal.COORDINACION_ID;
                oBE_PERSONAL.SEDE_ID = oPersonal.SEDE_ID;
                oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = oPersonal.GRUPO_ORGANIZACIONAL_ID;               

                if (oPersonal.oBE_GRUPO_ORGANIZACIONAL != null)
                {
                    oGRUPO_ORGANIZACIONAL.CODIGO = oPersonal.oBE_GRUPO_ORGANIZACIONAL.CODIGO;
                    oGRUPO_ORGANIZACIONAL.DESCRIPCION = oPersonal.oBE_GRUPO_ORGANIZACIONAL.DESCRIPCION;
                    oBE_PERSONAL.oBE_GRUPO_ORGANIZACIONAL = oGRUPO_ORGANIZACIONAL;
                }
                
            }

             return oBE_PERSONAL;
        }        

        /// <summary>
        /// Ingresa un nuevo Personal
        /// </summary>
        /// <param name="oBE_PERSONAL">Objeto BE_PERSONAL con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarPersonal(BE_PERSONAL oBE_PERSONAL)
        {
            wsMaestros.BE_PERSONAL oPersonal = new wsMaestros.BE_PERSONAL();
            oPersonal.ID = oBE_PERSONAL.ID;
            oPersonal.CODIGO_TRABAJO = oBE_PERSONAL.CODIGO_TRABAJO;
            oPersonal.NOMBRES = oBE_PERSONAL.NOMBRES;
            oPersonal.APELLIDO_PATERNO = oBE_PERSONAL.APELLIDO_PATERNO;
            oPersonal.APELLIDO_MATERNO = oBE_PERSONAL.APELLIDO_MATERNO;                        
            oPersonal.CORREO = oBE_PERSONAL.CORREO;
            oPersonal.NOMBRE_USUARIO = oBE_PERSONAL.NOMBRE_USUARIO;
            oPersonal.EMPRESA_ID = oBE_PERSONAL.EMPRESA_ID;
            oPersonal.GERENCIA_ID = oBE_PERSONAL.GERENCIA_ID;
            oPersonal.AREA_ID = oBE_PERSONAL.AREA_ID;
            oPersonal.ESTADO = oBE_PERSONAL.ESTADO;            
            oPersonal.COORDINACION_ID = oBE_PERSONAL.COORDINACION_ID;
            oPersonal.PUESTO_ID = oBE_PERSONAL.PUESTO_ID;
            oPersonal.GRUPO_ORGANIZACIONAL_ID = oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID;
            oPersonal.SEDE_ID = oBE_PERSONAL.SEDE_ID;
            oPersonal.USUARIO_CREACION = oBE_PERSONAL.USUARIO_CREACION; 
           
            //Inserto personal en tabla de usuarios
            if (oBE_PERSONAL.PERFIL_ID != 0)
            {
                BE_USUARIO oUsuario = new BE_USUARIO();
                oUsuario.PERSONAL_ID = oPersonal.ID;
                oUsuario.PERFIL_ID = oBE_PERSONAL.PERFIL_ID;
                oUsuario.USUARIO_CREACION = oPersonal.USUARIO_CREACION;
                BL_USUARIO.InsertarUsuario(oUsuario);
            }

            return wsMantenimientoEstructuras.InsertarPersonal(oPersonal);

        }

        /// <summary>
        /// Actualizar un Personal
        /// </summary>
        /// <param name="oBE_PERSONAL">Objeto BE_PERSONAL con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarPersonal(BE_PERSONAL oBE_PERSONAL)
        {

            wsMaestros.BE_PERSONAL oPersonal = new wsMaestros.BE_PERSONAL();
            oPersonal.ID = oBE_PERSONAL.ID;
            oPersonal.CODIGO_TRABAJO = oBE_PERSONAL.CODIGO_TRABAJO;
            oPersonal.NOMBRES = oBE_PERSONAL.NOMBRES;
            oPersonal.APELLIDO_PATERNO = oBE_PERSONAL.APELLIDO_PATERNO;
            oPersonal.APELLIDO_MATERNO = oBE_PERSONAL.APELLIDO_MATERNO;            
            oPersonal.PUESTO_ID = oBE_PERSONAL.PUESTO_ID;
            oPersonal.CORREO = oBE_PERSONAL.CORREO;
            oPersonal.NOMBRE_USUARIO = oBE_PERSONAL.NOMBRE_USUARIO;
            oPersonal.GERENCIA_ID = oBE_PERSONAL.GERENCIA_ID;
            oPersonal.AREA_ID = oBE_PERSONAL.AREA_ID;
            oPersonal.ESTADO = oBE_PERSONAL.ESTADO;
            oPersonal.EMPRESA_ID = oBE_PERSONAL.EMPRESA_ID;
            oPersonal.COORDINACION_ID = oBE_PERSONAL.COORDINACION_ID;
            oPersonal.GRUPO_ORGANIZACIONAL_ID = oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID;
            oPersonal.SEDE_ID = oBE_PERSONAL.SEDE_ID;
            oPersonal.USUARIO_CREACION = oBE_PERSONAL.USUARIO_CREACION;

            //Actualizo personal en usuario
            if (oBE_PERSONAL.PERFIL_ID != 0)
            {
                BE_USUARIO oBE_USUARIO = new BE_USUARIO();
                oBE_USUARIO = BL_USUARIO.SeleccionarPersonalPorUsuario(oBE_PERSONAL.NOMBRE_USUARIO);
                if (oBE_USUARIO != null)
                {
                    BE_USUARIO oUsuario = new BE_USUARIO();
                    oUsuario.USUARIO_ID = oBE_USUARIO.USUARIO_ID;
                    oUsuario.PERSONAL_ID = oPersonal.ID;
                    oUsuario.PERFIL_ID = oBE_PERSONAL.PERFIL_ID;
                    oUsuario.USUARIO_CREACION = oPersonal.USUARIO_CREACION;
                    BL_USUARIO.ActualizarUsuario(oUsuario);
                }
                else
                {
                    BE_USUARIO oUsuario = new BE_USUARIO();
                    oUsuario.PERSONAL_ID = oPersonal.ID;
                    oUsuario.PERFIL_ID = oBE_PERSONAL.PERFIL_ID;
                    oUsuario.USUARIO_CREACION = oPersonal.USUARIO_CREACION;
                    BL_USUARIO.InsertarUsuario(oUsuario);
                }
            }

            return wsMantenimientoEstructuras.ActualizarPersonal(oPersonal);
        }
        
        /// <summary>
        /// Elimina un Personal
        /// </summary>
        /// <param name="personal_id">Codigo del personal al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarPersonal(Guid personal_id)
        {
            BL_USUARIO.EliminarUsuarioPorPersonal(personal_id);
            return wsMantenimientoEstructuras.EliminarPersonal(personal_id);
        }
    }
}
