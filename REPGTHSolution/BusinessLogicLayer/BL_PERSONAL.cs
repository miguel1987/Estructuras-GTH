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
                oBE_PERSONAL.DEPARTAMENTO = item.DEPARTAMENTO;
                oBE_PERSONAL.PUESTO = item.PUESTO;
                oBE_PERSONAL.CORREO = item.CORREO;
                oBE_PERSONAL.NOMBRE_USUARIO = item.NOMBRE_USUARIO;
                oBE_PERSONAL.EMPRESA_ID = item.EMPRESA_ID;
                oBE_PERSONAL.ES_JEFE = item.ES_JEFE;

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

                BE_TIPO_JEFE oBE_TIPO_JEFE= new BE_TIPO_JEFE();
                oBE_TIPO_JEFE.CODIGO = oBE_PERSONAL.ES_JEFE;
                if (oBE_PERSONAL.ES_JEFE == 1)
                    oBE_TIPO_JEFE.DESCRIPCION = "Si";
                else
                    oBE_TIPO_JEFE.DESCRIPCION = "No";
                oBE_PERSONAL.oBE_TIPO_JEFE = oBE_TIPO_JEFE;

                oPERSONAL.Add(oBE_PERSONAL);                                
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
                oBE_PERSONAL.ES_JEFE = oPersonal.ES_JEFE; 
            }

             return oBE_PERSONAL;
        }

        /// <summary>
        /// Devuelve el email del jefe que debe autorizar la solicitud
        /// </summary>
        /// <param name="autorizador_id">id del jefe que autoriza la solicitud</param>
        /// <param name="gerencia_id">id gerencia a la que pertenece el jefe que autoriza la solicitud</param>
        /// <returns>String con el email del jefe que autoriza la solicitud. En caso no haiga datos devuelve string.empty.</returns>
        //public string GetEmailAutorizador(Guid autorizador_id, Guid gerencia_id)
        //{
        //    wsMaestros.BE_PERSONAL[] oLista = wsMantenimientoEstructuras.SeleccionarPersonalGenericoJefesPorGerencia(gerencia_id);

        //    string email = String.Empty;

        //    foreach (var item in oLista)
        //    {
        //        if (item.ID == autorizador_id)
        //        {
        //            if (item.CORREO != null)
        //                email = item.CORREO;
        //            else
        //                email = string.Empty;
        //        }
        //    }

        //    return email;
        //}

        /// <summary>
        /// Devuelve los datos de los jefes que corresponden a una gerencia especificada
        /// </summary>
        /// <param name="gerencia_id">nombre de usuario al cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        //public List<BE_PERSONAL> SeleccionarPersonalJefesPorGerencia(Guid gerencia_id)
        //{
        //    wsMaestros.BE_PERSONAL[] oLista = wsMantenimientoEstructuras.SeleccionarPersonalGenericoJefesPorGerencia(gerencia_id);

        //    List<BE_PERSONAL> oPERSONAL = new List<BE_PERSONAL>();

        //    if (oLista != null)
        //    {

        //        foreach (var item in oLista)
        //        {
        //            BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
        //            oBE_PERSONAL.ID = item.ID;
        //            oBE_PERSONAL.CODIGO_TRABAJO = item.CODIGO_TRABAJO;
        //            oBE_PERSONAL.APELLIDO_PATERNO = item.APELLIDO_PATERNO;
        //            oBE_PERSONAL.APELLIDO_MATERNO = item.APELLIDO_MATERNO;
        //            oBE_PERSONAL.NOMBRES = item.NOMBRES;
        //            oBE_PERSONAL.NOMBRES_COMPLETOS = item.NOMBRES_COMPLETOS;
        //            oBE_PERSONAL.GERENCIA_ID = item.GERENCIA_ID;
        //            oBE_PERSONAL.AREA_ID = item.AREA_ID;
        //            oBE_PERSONAL.DEPARTAMENTO = item.DEPARTAMENTO;
        //            oBE_PERSONAL.PUESTO = item.PUESTO;
        //            oBE_PERSONAL.CORREO = item.CORREO;
        //            oBE_PERSONAL.NOMBRE_USUARIO = item.NOMBRE_USUARIO;
        //            oBE_PERSONAL.EMPRESA_ID = item.EMPRESA_ID;
        //            oBE_PERSONAL.ES_JEFE = item.ES_JEFE;
        //            oBE_PERSONAL.NOMBRES_COMPLETOS_EMAIL = String.Format("{0} <{1}>", oBE_PERSONAL.NOMBRES_COMPLETOS, oBE_PERSONAL.CORREO);

        //            oPERSONAL.Add(oBE_PERSONAL);
        //        }
        //    }

        //    return oPERSONAL;
        //}

        /// <summary>
        ///  Devuelve los tipos de jefe: Si o no.
        /// </summary>       
        /// <returns> List de BE_TIPO_JEFE con los objetos de la entidad.En caso no existan datos devuelve nothing </returns>
        public static List<BE_TIPO_JEFE> SeleccionarTipoJefe()
        {
            List<BE_TIPO_JEFE> oListaTipoJefe = new List<BE_TIPO_JEFE>();

            BE_TIPO_JEFE oEsJefe = new BE_TIPO_JEFE();
            oEsJefe.CODIGO = 1;
            oEsJefe.DESCRIPCION = "Si";
            oListaTipoJefe.Add(oEsJefe);

            BE_TIPO_JEFE oNoEsJefe = new BE_TIPO_JEFE();
            oNoEsJefe.CODIGO = 0;
            oNoEsJefe.DESCRIPCION = "No";

            oListaTipoJefe.Add(oNoEsJefe);

            return oListaTipoJefe;

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
            oPersonal.DEPARTAMENTO = string.Empty;
            oPersonal.PUESTO = oBE_PERSONAL.PUESTO;
            oPersonal.CORREO = oBE_PERSONAL.CORREO;
            oPersonal.NOMBRE_USUARIO = oBE_PERSONAL.NOMBRE_USUARIO;
            oPersonal.GERENCIA_ID = oBE_PERSONAL.GERENCIA_ID;
            oPersonal.AREA_ID = oBE_PERSONAL.AREA_ID;
            oPersonal.ESTADO = oBE_PERSONAL.ESTADO;
            oPersonal.EMPRESA_ID = oBE_PERSONAL.EMPRESA_ID;
            oPersonal.ES_JEFE = oBE_PERSONAL.ES_JEFE;
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
            oPersonal.DEPARTAMENTO = string.Empty;
            oPersonal.PUESTO = oBE_PERSONAL.PUESTO;
            oPersonal.CORREO = oBE_PERSONAL.CORREO;
            oPersonal.NOMBRE_USUARIO = oBE_PERSONAL.NOMBRE_USUARIO;
            oPersonal.GERENCIA_ID = oBE_PERSONAL.GERENCIA_ID;
            oPersonal.AREA_ID = oBE_PERSONAL.AREA_ID;
            oPersonal.ESTADO = oBE_PERSONAL.ESTADO;
            oPersonal.EMPRESA_ID = oBE_PERSONAL.EMPRESA_ID;
            oPersonal.ES_JEFE = oBE_PERSONAL.ES_JEFE;
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
