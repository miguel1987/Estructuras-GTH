using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataConnectionComponent;
using BussinesEntities;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace DataAccessLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para la tabla PERSONAL
    /// </summary>
    public class DA_PERSONAL
    {

        /// <summary>
        /// Devuelve los datos de todo el Personal.
        /// </summary>        
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonal()
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PERSONAL> oPERSONAL = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PERSONAL_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PERSONAL_ID = dr.GetOrdinal("PERSONAL_ID");
                    int PERSONAL_CODIGO_TRABAJO = dr.GetOrdinal("PERSONAL_CODIGO_TRABAJO");
                    int PERSONAL_APELLIDO_PATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_PATERNO");
                    int PERSONAL_APELLIDO_MATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_MATERNO");
                    int PERSONAL_NOMBRES = dr.GetOrdinal("PERSONAL_NOMBRES");
                    int PERSONAL_SEDE_ID = dr.GetOrdinal("PERSONAL_SEDE");
                    int PERSONAL_EMPRESA_ID = dr.GetOrdinal("PERSONAL_EMPRESA");
                    int PERSONAL_GERENCIA_ID = dr.GetOrdinal("PERSONAL_GERENCIA");
                    int PERSONAL_AREA_ID = dr.GetOrdinal("PERSONAL_AREA");
                    int PERSONAL_COORDINACION_ID = dr.GetOrdinal("PERSONAL_COORDINACION");
                    int PERSONAL_PUESTO_ID = dr.GetOrdinal("PERSONAL_PUESTO");                    
                    int PERSONAL_GRUPO_ORGANIZACIONAL_ID = dr.GetOrdinal("PERSONAL_GRUPO_ORGANIZACIONAL");
                    int PERSONAL_CORREO = dr.GetOrdinal("PERSONAL_CORREO");
                    int NOMBRE_USUARIO = dr.GetOrdinal("PERSONAL_NOMBRE_USUARIO");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPERSONAL = new List<BE_PERSONAL>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                            oBE_PERSONAL.ID = (Guid)Valores.GetValue(PERSONAL_ID);
                            oBE_PERSONAL.CODIGO_TRABAJO = Valores.GetValue(PERSONAL_CODIGO_TRABAJO).ToString();
                            oBE_PERSONAL.APELLIDO_PATERNO = Valores.GetValue(PERSONAL_APELLIDO_PATERNO).ToString();
                            oBE_PERSONAL.APELLIDO_MATERNO = Valores.GetValue(PERSONAL_APELLIDO_MATERNO).ToString();
                            oBE_PERSONAL.NOMBRES = Valores.GetValue(PERSONAL_NOMBRES).ToString();
                            oBE_PERSONAL.NOMBRES_COMPLETOS = String.Format("{0} {1}, {2}", oBE_PERSONAL.APELLIDO_PATERNO, oBE_PERSONAL.APELLIDO_MATERNO, oBE_PERSONAL.NOMBRES);
                            oBE_PERSONAL.SEDE_ID = DBNull.Value == Valores.GetValue(PERSONAL_SEDE_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_SEDE_ID);
                            oBE_PERSONAL.EMPRESA_ID = DBNull.Value == Valores.GetValue(PERSONAL_EMPRESA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_EMPRESA_ID);
                            oBE_PERSONAL.GERENCIA_ID = (Guid)Valores.GetValue(PERSONAL_GERENCIA_ID);
                            oBE_PERSONAL.AREA_ID = (Guid)Valores.GetValue(PERSONAL_AREA_ID);
                            oBE_PERSONAL.COORDINACION_ID = DBNull.Value == Valores.GetValue(PERSONAL_COORDINACION_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_COORDINACION_ID);
                            oBE_PERSONAL.PUESTO_ID = (Guid)Valores.GetValue(PERSONAL_PUESTO_ID);
                            oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = DBNull.Value == Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID);                            
                            oBE_PERSONAL.CORREO = Valores.GetValue(PERSONAL_CORREO).ToString();
                            oBE_PERSONAL.NOMBRE_USUARIO = Valores.GetValue(NOMBRE_USUARIO).ToString();

                            if (DBNull.Value != Valores.GetValue(NOMBRE_USUARIO)) oBE_PERSONAL.NOMBRE_USUARIO = Valores.GetValue(NOMBRE_USUARIO).ToString();

                            oPERSONAL.Add(oBE_PERSONAL);
                        }
                    }
                }

                return oPERSONAL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnx.Close();
            }
        }

        /// <summary>
        /// Devuelve los datos de todo el Personal de una Empresa
        /// </summary>
        /// <param name="empresa_id">Empresa Id al cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonalPorEmpresa(Guid empresa_id)
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PERSONAL> oPERSONAL = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PERSONAL_SELECCIONAR_POR_EMPRESA"
                })
                {
                    
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = empresa_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PERSONAL_ID = dr.GetOrdinal("PERSONAL_ID");
                    int PERSONAL_CODIGO_TRABAJO = dr.GetOrdinal("PERSONAL_CODIGO_TRABAJO");
                    int PERSONAL_APELLIDO_PATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_PATERNO");
                    int PERSONAL_APELLIDO_MATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_MATERNO");
                    int PERSONAL_NOMBRES = dr.GetOrdinal("PERSONAL_NOMBRES");
                    int PERSONAL_SEDE_ID = dr.GetOrdinal("PERSONAL_SEDE");
                    int PERSONAL_EMPRESA_ID = dr.GetOrdinal("PERSONAL_EMPRESA");
                    int PERSONAL_GERENCIA_ID = dr.GetOrdinal("PERSONAL_GERENCIA");
                    int PERSONAL_AREA_ID = dr.GetOrdinal("PERSONAL_AREA");
                    int PERSONAL_COORDINACION_ID = dr.GetOrdinal("PERSONAL_COORDINACION");
                    int PERSONAL_PUESTO_ID = dr.GetOrdinal("PERSONAL_PUESTO");                    
                    int PERSONAL_GRUPO_ORGANIZACIONAL_ID = dr.GetOrdinal("PERSONAL_GRUPO_ORGANIZACIONAL");
                    int PERSONAL_CORREO = dr.GetOrdinal("PERSONAL_CORREO");                                      
                    
                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPERSONAL = new List<BE_PERSONAL>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                            oBE_PERSONAL.ID = (Guid)Valores.GetValue(PERSONAL_ID);
                            oBE_PERSONAL.CODIGO_TRABAJO = Valores.GetValue(PERSONAL_CODIGO_TRABAJO).ToString();
                            oBE_PERSONAL.APELLIDO_PATERNO = Valores.GetValue(PERSONAL_APELLIDO_PATERNO).ToString();
                            oBE_PERSONAL.APELLIDO_MATERNO = Valores.GetValue(PERSONAL_APELLIDO_MATERNO).ToString();
                            oBE_PERSONAL.NOMBRES = Valores.GetValue(PERSONAL_NOMBRES).ToString();
                            oBE_PERSONAL.NOMBRES_COMPLETOS = String.Format("{0} {1}, {2}", oBE_PERSONAL.APELLIDO_PATERNO, oBE_PERSONAL.APELLIDO_MATERNO, oBE_PERSONAL.NOMBRES);
                            oBE_PERSONAL.SEDE_ID = DBNull.Value == Valores.GetValue(PERSONAL_SEDE_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_SEDE_ID);
                            oBE_PERSONAL.EMPRESA_ID = DBNull.Value == Valores.GetValue(PERSONAL_EMPRESA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_EMPRESA_ID);
                            oBE_PERSONAL.GERENCIA_ID = (Guid)Valores.GetValue(PERSONAL_GERENCIA_ID);                           
                            oBE_PERSONAL.AREA_ID = DBNull.Value == Valores.GetValue(PERSONAL_AREA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_AREA_ID);
                            oBE_PERSONAL.COORDINACION_ID = DBNull.Value == Valores.GetValue(PERSONAL_COORDINACION_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_COORDINACION_ID);
                            oBE_PERSONAL.PUESTO_ID = (Guid)Valores.GetValue(PERSONAL_PUESTO_ID);
                            oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = DBNull.Value == Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID);                            
                            oBE_PERSONAL.CORREO = Valores.GetValue(PERSONAL_CORREO).ToString();                           

                            oPERSONAL.Add(oBE_PERSONAL);
                        }
                    }
                }

                return oPERSONAL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnx.Close();
            }
        }


        /// <summary>
        /// Devuelve los datos de todos los gerentes
        /// </summary>
        /// <param name="presidencia_id">Empresa Id al cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonalPorPresidencia(Guid presidencia_id)
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PERSONAL> oPERSONAL = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PERSONAL_SELECCIONAR_GERENTES_POR_PRESIDENCIA"
                })
                {
                    objCmd.Parameters.Add("@PRESIDENCIA_ID", SqlDbType.UniqueIdentifier).Value = presidencia_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PERSONAL_ID = dr.GetOrdinal("PERSONAL_ID");
                    int PERSONAL_CODIGO_TRABAJO = dr.GetOrdinal("PERSONAL_CODIGO_TRABAJO");
                    int PERSONAL_APELLIDO_PATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_PATERNO");
                    int PERSONAL_APELLIDO_MATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_MATERNO");
                    int PERSONAL_NOMBRES = dr.GetOrdinal("PERSONAL_NOMBRES");
                    int PERSONAL_SEDE_ID = dr.GetOrdinal("PERSONAL_SEDE");
                    int PERSONAL_EMPRESA_ID = dr.GetOrdinal("PERSONAL_EMPRESA");
                    int PERSONAL_GERENCIA_ID = dr.GetOrdinal("PERSONAL_GERENCIA");
                    int PERSONAL_AREA_ID = dr.GetOrdinal("PERSONAL_AREA");
                    int PERSONAL_COORDINACION_ID = dr.GetOrdinal("PERSONAL_COORDINACION");
                    int PERSONAL_PUESTO_ID = dr.GetOrdinal("PERSONAL_PUESTO");                    
                    int PERSONAL_GRUPO_ORGANIZACIONAL_ID = dr.GetOrdinal("PERSONAL_GRUPO_ORGANIZACIONAL");
                    int PERSONAL_CORREO = dr.GetOrdinal("PERSONAL_CORREO");
                    

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPERSONAL = new List<BE_PERSONAL>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                            oBE_PERSONAL.ID = (Guid)Valores.GetValue(PERSONAL_ID);
                            oBE_PERSONAL.CODIGO_TRABAJO = Valores.GetValue(PERSONAL_CODIGO_TRABAJO).ToString();
                            oBE_PERSONAL.APELLIDO_PATERNO = Valores.GetValue(PERSONAL_APELLIDO_PATERNO).ToString();
                            oBE_PERSONAL.APELLIDO_MATERNO = Valores.GetValue(PERSONAL_APELLIDO_MATERNO).ToString();
                            oBE_PERSONAL.NOMBRES = Valores.GetValue(PERSONAL_NOMBRES).ToString();
                            oBE_PERSONAL.NOMBRES_COMPLETOS = String.Format("{0} {1}, {2}", oBE_PERSONAL.APELLIDO_PATERNO, oBE_PERSONAL.APELLIDO_MATERNO, oBE_PERSONAL.NOMBRES);
                            oBE_PERSONAL.SEDE_ID = DBNull.Value == Valores.GetValue(PERSONAL_SEDE_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_SEDE_ID);
                            oBE_PERSONAL.EMPRESA_ID = DBNull.Value == Valores.GetValue(PERSONAL_EMPRESA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_EMPRESA_ID);
                            oBE_PERSONAL.GERENCIA_ID = (Guid)Valores.GetValue(PERSONAL_GERENCIA_ID);
                            oBE_PERSONAL.AREA_ID = DBNull.Value == Valores.GetValue(PERSONAL_AREA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_AREA_ID);
                            oBE_PERSONAL.COORDINACION_ID = DBNull.Value == Valores.GetValue(PERSONAL_COORDINACION_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_COORDINACION_ID);
                            oBE_PERSONAL.PUESTO_ID = (Guid)Valores.GetValue(PERSONAL_PUESTO_ID);
                            oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = DBNull.Value == Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID);                            
                            oBE_PERSONAL.CORREO = Valores.GetValue(PERSONAL_CORREO).ToString();
                            

                            

                            oPERSONAL.Add(oBE_PERSONAL);
                        }
                    }
                }

                return oPERSONAL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnx.Close();
            }
        }

        /// <summary>
        /// Devuelve los datos de todas las personas que pertenecen a una gerencia
        /// </summary>
        /// <param name="gerencia_id">Gerencia Id al cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonalPorGerencia(Guid gerencia_id)
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PERSONAL> oPERSONAL = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PERSONAL_SELECCIONAR_POR_GERENCIA"
                })
                {
                    objCmd.Parameters.Add("@GERENCIA_ID", SqlDbType.UniqueIdentifier).Value = gerencia_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PERSONAL_ID = dr.GetOrdinal("PERSONAL_ID");
                    int PERSONAL_CODIGO_TRABAJO = dr.GetOrdinal("PERSONAL_CODIGO_TRABAJO");
                    int PERSONAL_APELLIDO_PATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_PATERNO");
                    int PERSONAL_APELLIDO_MATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_MATERNO");
                    int PERSONAL_NOMBRES = dr.GetOrdinal("PERSONAL_NOMBRES");
                    int PERSONAL_SEDE_ID = dr.GetOrdinal("PERSONAL_SEDE");
                    int PERSONAL_EMPRESA_ID = dr.GetOrdinal("PERSONAL_EMPRESA");
                    int PERSONAL_GERENCIA_ID = dr.GetOrdinal("PERSONAL_GERENCIA");
                    int PERSONAL_AREA_ID = dr.GetOrdinal("PERSONAL_AREA");
                    int PERSONAL_COORDINACION_ID = dr.GetOrdinal("PERSONAL_COORDINACION");
                    int PERSONAL_PUESTO_ID = dr.GetOrdinal("PERSONAL_PUESTO");                    
                    int PERSONAL_GRUPO_ORGANIZACIONAL_ID = dr.GetOrdinal("PERSONAL_GRUPO_ORGANIZACIONAL");
                    int PERSONAL_CORREO = dr.GetOrdinal("PERSONAL_CORREO");
                    

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPERSONAL = new List<BE_PERSONAL>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                            oBE_PERSONAL.ID = (Guid)Valores.GetValue(PERSONAL_ID);
                            oBE_PERSONAL.CODIGO_TRABAJO = Valores.GetValue(PERSONAL_CODIGO_TRABAJO).ToString();
                            oBE_PERSONAL.APELLIDO_PATERNO = Valores.GetValue(PERSONAL_APELLIDO_PATERNO).ToString();
                            oBE_PERSONAL.APELLIDO_MATERNO = Valores.GetValue(PERSONAL_APELLIDO_MATERNO).ToString();
                            oBE_PERSONAL.NOMBRES = Valores.GetValue(PERSONAL_NOMBRES).ToString();
                            oBE_PERSONAL.NOMBRES_COMPLETOS = String.Format("{0} {1}, {2}", oBE_PERSONAL.APELLIDO_PATERNO, oBE_PERSONAL.APELLIDO_MATERNO, oBE_PERSONAL.NOMBRES);
                            oBE_PERSONAL.SEDE_ID = DBNull.Value == Valores.GetValue(PERSONAL_SEDE_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_SEDE_ID);
                            oBE_PERSONAL.EMPRESA_ID = DBNull.Value == Valores.GetValue(PERSONAL_EMPRESA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_EMPRESA_ID);
                            oBE_PERSONAL.GERENCIA_ID = (Guid)Valores.GetValue(PERSONAL_GERENCIA_ID);
                            oBE_PERSONAL.AREA_ID = DBNull.Value == Valores.GetValue(PERSONAL_AREA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_AREA_ID);
                            oBE_PERSONAL.COORDINACION_ID = DBNull.Value == Valores.GetValue(PERSONAL_COORDINACION_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_COORDINACION_ID);
                            oBE_PERSONAL.PUESTO_ID = (Guid)Valores.GetValue(PERSONAL_PUESTO_ID);
                            oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = DBNull.Value == Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID);                            
                            oBE_PERSONAL.CORREO = Valores.GetValue(PERSONAL_CORREO).ToString();
                            

                           

                            oPERSONAL.Add(oBE_PERSONAL);
                        }
                    }
                }

                return oPERSONAL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            
            {
                cnx.Close();
            }
        }

        /// <summary>
        /// Devuelve los datos de todas las personas de un departamento o área
        /// </summary>
        /// <param name="area_id">Gerencia Id al cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonalPorArea(Guid area_id)
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PERSONAL> oPERSONAL = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PERSONAL_SELECCIONAR_POR_AREA"
                })
                {
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = area_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PERSONAL_ID = dr.GetOrdinal("PERSONAL_ID");
                    int PERSONAL_CODIGO_TRABAJO = dr.GetOrdinal("PERSONAL_CODIGO_TRABAJO");
                    int PERSONAL_APELLIDO_PATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_PATERNO");
                    int PERSONAL_APELLIDO_MATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_MATERNO");
                    int PERSONAL_NOMBRES = dr.GetOrdinal("PERSONAL_NOMBRES");
                    int PERSONAL_SEDE_ID = dr.GetOrdinal("PERSONAL_SEDE");
                    int PERSONAL_EMPRESA_ID = dr.GetOrdinal("PERSONAL_EMPRESA");
                    int PERSONAL_GERENCIA_ID = dr.GetOrdinal("PERSONAL_GERENCIA");
                    int PERSONAL_AREA_ID = dr.GetOrdinal("PERSONAL_AREA");
                    int PERSONAL_COORDINACION_ID = dr.GetOrdinal("PERSONAL_COORDINACION");
                    int PERSONAL_PUESTO_ID = dr.GetOrdinal("PERSONAL_PUESTO");
                    int PERSONAL_GRUPO_ORGANIZACIONAL_ID = dr.GetOrdinal("PERSONAL_GRUPO_ORGANIZACIONAL");
                    int PERSONAL_CORREO = dr.GetOrdinal("PERSONAL_CORREO");
                    

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPERSONAL = new List<BE_PERSONAL>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                            oBE_PERSONAL.ID = (Guid)Valores.GetValue(PERSONAL_ID);
                            oBE_PERSONAL.CODIGO_TRABAJO = Valores.GetValue(PERSONAL_CODIGO_TRABAJO).ToString();
                            oBE_PERSONAL.APELLIDO_PATERNO = Valores.GetValue(PERSONAL_APELLIDO_PATERNO).ToString();
                            oBE_PERSONAL.APELLIDO_MATERNO = Valores.GetValue(PERSONAL_APELLIDO_MATERNO).ToString();
                            oBE_PERSONAL.NOMBRES = Valores.GetValue(PERSONAL_NOMBRES).ToString();
                            oBE_PERSONAL.NOMBRES_COMPLETOS = String.Format("{0} {1}, {2}", oBE_PERSONAL.APELLIDO_PATERNO, oBE_PERSONAL.APELLIDO_MATERNO, oBE_PERSONAL.NOMBRES);
                            oBE_PERSONAL.SEDE_ID = DBNull.Value == Valores.GetValue(PERSONAL_SEDE_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_SEDE_ID);
                            oBE_PERSONAL.EMPRESA_ID = DBNull.Value == Valores.GetValue(PERSONAL_EMPRESA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_EMPRESA_ID);
                            oBE_PERSONAL.GERENCIA_ID = (Guid)Valores.GetValue(PERSONAL_GERENCIA_ID);
                            oBE_PERSONAL.AREA_ID = DBNull.Value == Valores.GetValue(PERSONAL_AREA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_AREA_ID);
                            oBE_PERSONAL.COORDINACION_ID = DBNull.Value == Valores.GetValue(PERSONAL_COORDINACION_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_COORDINACION_ID);
                            oBE_PERSONAL.PUESTO_ID = (Guid)Valores.GetValue(PERSONAL_PUESTO_ID);
                            oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = DBNull.Value == Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID);                            
                            oBE_PERSONAL.CORREO = Valores.GetValue(PERSONAL_CORREO).ToString();
                            

                            

                            oPERSONAL.Add(oBE_PERSONAL);
                        }
                    }
                }

                return oPERSONAL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnx.Close();
            }
        }

        /// <summary>
        /// Devuelve los datos de todas las personas de una coordinación
        /// </summary>
        /// <param name="coordinacion_id">Coordinacion Id a la cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonalPorCoordinacion(Guid coordinacion_id)
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PERSONAL> oPERSONAL = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PERSONAL_SELECCIONAR_POR_COORDINACION"
                })
                {
                    objCmd.Parameters.Add("@COORDINACION_ID", SqlDbType.UniqueIdentifier).Value = coordinacion_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PERSONAL_ID = dr.GetOrdinal("PERSONAL_ID");
                    int PERSONAL_CODIGO_TRABAJO = dr.GetOrdinal("PERSONAL_CODIGO_TRABAJO");
                    int PERSONAL_APELLIDO_PATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_PATERNO");
                    int PERSONAL_APELLIDO_MATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_MATERNO");
                    int PERSONAL_NOMBRES = dr.GetOrdinal("PERSONAL_NOMBRES");
                    int PERSONAL_SEDE_ID = dr.GetOrdinal("PERSONAL_SEDE");
                    int PERSONAL_EMPRESA_ID = dr.GetOrdinal("PERSONAL_EMPRESA");
                    int PERSONAL_GERENCIA_ID = dr.GetOrdinal("PERSONAL_GERENCIA");
                    int PERSONAL_AREA_ID = dr.GetOrdinal("PERSONAL_AREA");
                    int PERSONAL_COORDINACION_ID = dr.GetOrdinal("PERSONAL_COORDINACION");
                    int PERSONAL_PUESTO_ID = dr.GetOrdinal("PERSONAL_PUESTO");
                    int PERSONAL_GRUPO_ORGANIZACIONAL_ID = dr.GetOrdinal("PERSONAL_GRUPO_ORGANIZACIONAL");
                    int PERSONAL_CORREO = dr.GetOrdinal("PERSONAL_CORREO");
                    

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPERSONAL = new List<BE_PERSONAL>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                            oBE_PERSONAL.ID = (Guid)Valores.GetValue(PERSONAL_ID);
                            oBE_PERSONAL.CODIGO_TRABAJO = Valores.GetValue(PERSONAL_CODIGO_TRABAJO).ToString();
                            oBE_PERSONAL.APELLIDO_PATERNO = Valores.GetValue(PERSONAL_APELLIDO_PATERNO).ToString();
                            oBE_PERSONAL.APELLIDO_MATERNO = Valores.GetValue(PERSONAL_APELLIDO_MATERNO).ToString();
                            oBE_PERSONAL.NOMBRES = Valores.GetValue(PERSONAL_NOMBRES).ToString();
                            oBE_PERSONAL.NOMBRES_COMPLETOS = String.Format("{0} {1}, {2}", oBE_PERSONAL.APELLIDO_PATERNO, oBE_PERSONAL.APELLIDO_MATERNO, oBE_PERSONAL.NOMBRES);
                            oBE_PERSONAL.SEDE_ID = DBNull.Value == Valores.GetValue(PERSONAL_SEDE_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_SEDE_ID);
                            oBE_PERSONAL.EMPRESA_ID = DBNull.Value == Valores.GetValue(PERSONAL_EMPRESA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_EMPRESA_ID);
                            oBE_PERSONAL.GERENCIA_ID = (Guid)Valores.GetValue(PERSONAL_GERENCIA_ID);
                            oBE_PERSONAL.AREA_ID = DBNull.Value == Valores.GetValue(PERSONAL_AREA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_AREA_ID);
                            oBE_PERSONAL.COORDINACION_ID = DBNull.Value == Valores.GetValue(PERSONAL_COORDINACION_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_COORDINACION_ID);
                            oBE_PERSONAL.PUESTO_ID = (Guid)Valores.GetValue(PERSONAL_PUESTO_ID);
                            oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = DBNull.Value == Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID);                            
                            oBE_PERSONAL.CORREO = Valores.GetValue(PERSONAL_CORREO).ToString();
                            

                            

                            oPERSONAL.Add(oBE_PERSONAL);
                        }
                    }
                }

                return oPERSONAL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnx.Close();
            }
        }

        /// <summary>
        /// Devuelve los datos de todas las personas de una sede
        /// </summary>
        /// <param name="sede_id">Sede Id a la cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonalPorSede(Guid sede_id)
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PERSONAL> oPERSONAL = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PERSONAL_SELECCIONAR_POR_SEDE"
                })
                {
                    objCmd.Parameters.Add("@SEDE_ID", SqlDbType.UniqueIdentifier).Value = sede_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PERSONAL_ID = dr.GetOrdinal("PERSONAL_ID");
                    int PERSONAL_CODIGO_TRABAJO = dr.GetOrdinal("PERSONAL_CODIGO_TRABAJO");
                    int PERSONAL_APELLIDO_PATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_PATERNO");
                    int PERSONAL_APELLIDO_MATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_MATERNO");
                    int PERSONAL_NOMBRES = dr.GetOrdinal("PERSONAL_NOMBRES");
                    int PERSONAL_SEDE_ID = dr.GetOrdinal("PERSONAL_SEDE");
                    int PERSONAL_EMPRESA_ID = dr.GetOrdinal("PERSONAL_EMPRESA");
                    int PERSONAL_GERENCIA_ID = dr.GetOrdinal("PERSONAL_GERENCIA");
                    int PERSONAL_AREA_ID = dr.GetOrdinal("PERSONAL_AREA");
                    int PERSONAL_COORDINACION_ID = dr.GetOrdinal("PERSONAL_COORDINACION");
                    int PERSONAL_PUESTO_ID = dr.GetOrdinal("PERSONAL_PUESTO");
                    int PERSONAL_GRUPO_ORGANIZACIONAL_ID = dr.GetOrdinal("PERSONAL_GRUPO_ORGANIZACIONAL");
                    int PERSONAL_CORREO = dr.GetOrdinal("PERSONAL_CORREO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPERSONAL = new List<BE_PERSONAL>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                            oBE_PERSONAL.ID = (Guid)Valores.GetValue(PERSONAL_ID);
                            oBE_PERSONAL.CODIGO_TRABAJO = Valores.GetValue(PERSONAL_CODIGO_TRABAJO).ToString();
                            oBE_PERSONAL.APELLIDO_PATERNO = Valores.GetValue(PERSONAL_APELLIDO_PATERNO).ToString();
                            oBE_PERSONAL.APELLIDO_MATERNO = Valores.GetValue(PERSONAL_APELLIDO_MATERNO).ToString();
                            oBE_PERSONAL.NOMBRES = Valores.GetValue(PERSONAL_NOMBRES).ToString();
                            oBE_PERSONAL.NOMBRES_COMPLETOS = String.Format("{0} {1}, {2}", oBE_PERSONAL.APELLIDO_PATERNO, oBE_PERSONAL.APELLIDO_MATERNO, oBE_PERSONAL.NOMBRES);
                            oBE_PERSONAL.SEDE_ID = DBNull.Value == Valores.GetValue(PERSONAL_SEDE_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_SEDE_ID);
                            oBE_PERSONAL.EMPRESA_ID = DBNull.Value == Valores.GetValue(PERSONAL_EMPRESA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_EMPRESA_ID);
                            oBE_PERSONAL.GERENCIA_ID = (Guid)Valores.GetValue(PERSONAL_GERENCIA_ID);
                            oBE_PERSONAL.AREA_ID = DBNull.Value == Valores.GetValue(PERSONAL_AREA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_AREA_ID);
                            oBE_PERSONAL.COORDINACION_ID = DBNull.Value == Valores.GetValue(PERSONAL_COORDINACION_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_COORDINACION_ID);
                            oBE_PERSONAL.PUESTO_ID = (Guid)Valores.GetValue(PERSONAL_PUESTO_ID);
                            oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = DBNull.Value == Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID);
                            oBE_PERSONAL.CORREO = Valores.GetValue(PERSONAL_CORREO).ToString();




                            oPERSONAL.Add(oBE_PERSONAL);
                        }
                    }
                }

                return oPERSONAL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnx.Close();
            }
        }

        /// <summary>
        /// Devuelve los datos de todas las personas de un grupo organizacional
        /// </summary>
        /// <param name="grupo_organizacional_id">Grupo Organizacion Id a la cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonalPorGrupoOrganizacional(Guid grupo_organizacional_id)
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PERSONAL> oPERSONAL = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PERSONAL_SELECCIONAR_POR_GRUPO_ORGANIZACIONAL"
                })
                {
                    objCmd.Parameters.Add("@GRUPO_ORGANIZACIONAL_ID", SqlDbType.UniqueIdentifier).Value = grupo_organizacional_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PERSONAL_ID = dr.GetOrdinal("PERSONAL_ID");
                    int PERSONAL_CODIGO_TRABAJO = dr.GetOrdinal("PERSONAL_CODIGO_TRABAJO");
                    int PERSONAL_APELLIDO_PATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_PATERNO");
                    int PERSONAL_APELLIDO_MATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_MATERNO");
                    int PERSONAL_NOMBRES = dr.GetOrdinal("PERSONAL_NOMBRES");
                    int PERSONAL_SEDE_ID = dr.GetOrdinal("PERSONAL_SEDE");
                    int PERSONAL_EMPRESA_ID = dr.GetOrdinal("PERSONAL_EMPRESA");
                    int PERSONAL_GERENCIA_ID = dr.GetOrdinal("PERSONAL_GERENCIA");
                    int PERSONAL_AREA_ID = dr.GetOrdinal("PERSONAL_AREA");
                    int PERSONAL_COORDINACION_ID = dr.GetOrdinal("PERSONAL_COORDINACION");
                    int PERSONAL_PUESTO_ID = dr.GetOrdinal("PERSONAL_PUESTO");
                    int PERSONAL_GRUPO_ORGANIZACIONAL_ID = dr.GetOrdinal("PERSONAL_GRUPO_ORGANIZACIONAL");
                    int PERSONAL_CORREO = dr.GetOrdinal("PERSONAL_CORREO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPERSONAL = new List<BE_PERSONAL>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                            oBE_PERSONAL.ID = (Guid)Valores.GetValue(PERSONAL_ID);
                            oBE_PERSONAL.CODIGO_TRABAJO = Valores.GetValue(PERSONAL_CODIGO_TRABAJO).ToString();
                            oBE_PERSONAL.APELLIDO_PATERNO = Valores.GetValue(PERSONAL_APELLIDO_PATERNO).ToString();
                            oBE_PERSONAL.APELLIDO_MATERNO = Valores.GetValue(PERSONAL_APELLIDO_MATERNO).ToString();
                            oBE_PERSONAL.NOMBRES = Valores.GetValue(PERSONAL_NOMBRES).ToString();
                            oBE_PERSONAL.NOMBRES_COMPLETOS = String.Format("{0} {1}, {2}", oBE_PERSONAL.APELLIDO_PATERNO, oBE_PERSONAL.APELLIDO_MATERNO, oBE_PERSONAL.NOMBRES);
                            oBE_PERSONAL.SEDE_ID = DBNull.Value == Valores.GetValue(PERSONAL_SEDE_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_SEDE_ID);
                            oBE_PERSONAL.EMPRESA_ID = DBNull.Value == Valores.GetValue(PERSONAL_EMPRESA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_EMPRESA_ID);
                            oBE_PERSONAL.GERENCIA_ID = (Guid)Valores.GetValue(PERSONAL_GERENCIA_ID);
                            oBE_PERSONAL.AREA_ID = DBNull.Value == Valores.GetValue(PERSONAL_AREA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_AREA_ID);
                            oBE_PERSONAL.COORDINACION_ID = DBNull.Value == Valores.GetValue(PERSONAL_COORDINACION_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_COORDINACION_ID);
                            oBE_PERSONAL.PUESTO_ID = (Guid)Valores.GetValue(PERSONAL_PUESTO_ID);
                            oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = DBNull.Value == Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID);
                            oBE_PERSONAL.CORREO = Valores.GetValue(PERSONAL_CORREO).ToString();




                            oPERSONAL.Add(oBE_PERSONAL);
                        }
                    }
                }

                return oPERSONAL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnx.Close();
            }
        }


        /// <summary>
        /// Devuelve los datos del usuario que ingresa a la aplicación
        /// </summary>
        /// <param name="NombreUsuario">nombre de usuario al cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla BE_PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public BE_PERSONAL SeleccionarPersonalPorUsuario(String NombreUsuario)
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            BE_PERSONAL oBE_PERSONAL = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PERSONAL_SELECCIONAR_POR_USUARIO"
                })
                {
                    objCmd.Parameters.Add("@PERSONAL_NOMBRE_USUARIO", SqlDbType.VarChar).Value = NombreUsuario;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PERSONAL_ID = dr.GetOrdinal("PERSONAL_ID");
                    int PERSONAL_CODIGO_TRABAJO = dr.GetOrdinal("PERSONAL_CODIGO_TRABAJO");
                    int PERSONAL_APELLIDO_PATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_PATERNO");
                    int PERSONAL_APELLIDO_MATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_MATERNO");
                    int PERSONAL_NOMBRES = dr.GetOrdinal("PERSONAL_NOMBRES");
                    int PERSONAL_SEDE_ID = dr.GetOrdinal("PERSONAL_SEDE");
                    int PERSONAL_EMPRESA_ID = dr.GetOrdinal("PERSONAL_EMPRESA");
                    int PERSONAL_GERENCIA_ID = dr.GetOrdinal("PERSONAL_GERENCIA");
                    int PERSONAL_AREA_ID = dr.GetOrdinal("PERSONAL_AREA");
                    int PERSONAL_COORDINACION_ID = dr.GetOrdinal("PERSONAL_COORDINACION");
                    int PERSONAL_PUESTO_ID = dr.GetOrdinal("PERSONAL_PUESTO");                    
                    int PERSONAL_GRUPO_ORGANIZACIONAL_ID = dr.GetOrdinal("PERSONAL_GRUPO_ORGANIZACIONAL");
                    int PERSONAL_CORREO = dr.GetOrdinal("PERSONAL_CORREO");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oBE_PERSONAL = new BE_PERSONAL();
                        if (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            // BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                            oBE_PERSONAL.ID = (Guid)Valores.GetValue(PERSONAL_ID);
                            oBE_PERSONAL.CODIGO_TRABAJO = Valores.GetValue(PERSONAL_CODIGO_TRABAJO).ToString();
                            oBE_PERSONAL.APELLIDO_PATERNO = Valores.GetValue(PERSONAL_APELLIDO_PATERNO).ToString();
                            oBE_PERSONAL.APELLIDO_MATERNO = Valores.GetValue(PERSONAL_APELLIDO_MATERNO).ToString();
                            oBE_PERSONAL.NOMBRES = Valores.GetValue(PERSONAL_NOMBRES).ToString();
                            oBE_PERSONAL.NOMBRES_COMPLETOS = String.Format("{0} {1}, {2}", oBE_PERSONAL.APELLIDO_PATERNO, oBE_PERSONAL.APELLIDO_MATERNO, oBE_PERSONAL.NOMBRES);
                            oBE_PERSONAL.SEDE_ID = DBNull.Value == Valores.GetValue(PERSONAL_SEDE_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_SEDE_ID);
                            oBE_PERSONAL.EMPRESA_ID = (Guid)Valores.GetValue(PERSONAL_EMPRESA_ID);
                            oBE_PERSONAL.GERENCIA_ID = (Guid)Valores.GetValue(PERSONAL_GERENCIA_ID);
                            oBE_PERSONAL.AREA_ID = (Guid)Valores.GetValue(PERSONAL_AREA_ID); oBE_PERSONAL.COORDINACION_ID = DBNull.Value == Valores.GetValue(PERSONAL_COORDINACION_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_COORDINACION_ID);
                            oBE_PERSONAL.PUESTO_ID = (Guid)Valores.GetValue(PERSONAL_PUESTO_ID);
                            oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = DBNull.Value == Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID);                            
                            oBE_PERSONAL.CORREO = Valores.GetValue(PERSONAL_CORREO).ToString();
                           

                        }
                    }
                }

                return oBE_PERSONAL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnx.Close();
            }
        }

        /// <summary>
        /// Devuelve los datos de todo el Personal que pertenece a un puesto
        /// </summary>
        /// <param name="puesto_id">Puesto Id al cual se desea consultar</param>
        /// <returns>List de BE_PERSONAL con los objetos de la entidad, que a su vez representan la tabla PERSONAL de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERSONAL> SeleccionarPersonalPorPuesto(Guid puesto_id)
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PERSONAL> oPERSONAL = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PERSONAL_SELECCIONAR_POR_PUESTO"
                })
                {

                    objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value = puesto_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PERSONAL_ID = dr.GetOrdinal("PERSONAL_ID");
                    int PERSONAL_CODIGO_TRABAJO = dr.GetOrdinal("PERSONAL_CODIGO_TRABAJO");
                    int PERSONAL_APELLIDO_PATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_PATERNO");
                    int PERSONAL_APELLIDO_MATERNO = dr.GetOrdinal("PERSONAL_APELLIDO_MATERNO");
                    int PERSONAL_NOMBRES = dr.GetOrdinal("PERSONAL_NOMBRES");
                    int PERSONAL_SEDE_ID = dr.GetOrdinal("PERSONAL_SEDE");
                    int PERSONAL_EMPRESA_ID = dr.GetOrdinal("PERSONAL_EMPRESA");
                    int PERSONAL_GERENCIA_ID = dr.GetOrdinal("PERSONAL_GERENCIA");
                    int PERSONAL_AREA_ID = dr.GetOrdinal("PERSONAL_AREA");
                    int PERSONAL_COORDINACION_ID = dr.GetOrdinal("PERSONAL_COORDINACION");
                    int PERSONAL_PUESTO_ID = dr.GetOrdinal("PERSONAL_PUESTO");
                    int PERSONAL_GRUPO_ORGANIZACIONAL_ID = dr.GetOrdinal("PERSONAL_GRUPO_ORGANIZACIONAL");
                    int PERSONAL_CORREO = dr.GetOrdinal("PERSONAL_CORREO");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPERSONAL = new List<BE_PERSONAL>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PERSONAL oBE_PERSONAL = new BE_PERSONAL();
                            oBE_PERSONAL.ID = (Guid)Valores.GetValue(PERSONAL_ID);
                            oBE_PERSONAL.CODIGO_TRABAJO = Valores.GetValue(PERSONAL_CODIGO_TRABAJO).ToString();
                            oBE_PERSONAL.APELLIDO_PATERNO = Valores.GetValue(PERSONAL_APELLIDO_PATERNO).ToString();
                            oBE_PERSONAL.APELLIDO_MATERNO = Valores.GetValue(PERSONAL_APELLIDO_MATERNO).ToString();
                            oBE_PERSONAL.NOMBRES = Valores.GetValue(PERSONAL_NOMBRES).ToString();
                            oBE_PERSONAL.NOMBRES_COMPLETOS = String.Format("{0} {1}, {2}", oBE_PERSONAL.APELLIDO_PATERNO, oBE_PERSONAL.APELLIDO_MATERNO, oBE_PERSONAL.NOMBRES);
                            oBE_PERSONAL.SEDE_ID = DBNull.Value == Valores.GetValue(PERSONAL_SEDE_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_SEDE_ID);
                            oBE_PERSONAL.EMPRESA_ID = DBNull.Value == Valores.GetValue(PERSONAL_EMPRESA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_EMPRESA_ID);
                            oBE_PERSONAL.GERENCIA_ID = (Guid)Valores.GetValue(PERSONAL_GERENCIA_ID);
                            oBE_PERSONAL.AREA_ID = DBNull.Value == Valores.GetValue(PERSONAL_AREA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_AREA_ID);
                            oBE_PERSONAL.COORDINACION_ID = DBNull.Value == Valores.GetValue(PERSONAL_COORDINACION_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_COORDINACION_ID);
                            oBE_PERSONAL.PUESTO_ID = (Guid)Valores.GetValue(PERSONAL_PUESTO_ID);
                            oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID = DBNull.Value == Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID) ? Guid.Empty : (Guid)Valores.GetValue(PERSONAL_GRUPO_ORGANIZACIONAL_ID);
                            oBE_PERSONAL.CORREO = Valores.GetValue(PERSONAL_CORREO).ToString();

                            oPERSONAL.Add(oBE_PERSONAL);
                        }
                    }
                }

                return oPERSONAL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnx.Close();
            }
        }

        /// <summary>
        /// Ingresa un nuevo Personal
        /// </summary>
        /// <param name="oBE_PERSONAL">Objeto BE_PERSONAL con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarPersonal(BE_PERSONAL oBE_PERSONAL)
        {
            SqlConnection cnx = new SqlConnection();
            bool bIndicador = false;

            cnx = DC_Connection.getConnection();

            try
            {

                using (
                    SqlCommand objCmd = new SqlCommand()
                    {
                        Connection = cnx,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "USP_PERSONAL_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@PERSONAL_CODIGO_TRABAJO", SqlDbType.VarChar).Value = oBE_PERSONAL.CODIGO_TRABAJO;
                    objCmd.Parameters.Add("@PERSONAL_APELLIDO_PATERNO", SqlDbType.VarChar).Value = oBE_PERSONAL.APELLIDO_PATERNO;
                    objCmd.Parameters.Add("@PERSONAL_APELLIDO_MATERNO", SqlDbType.VarChar).Value = oBE_PERSONAL.APELLIDO_MATERNO;
                    objCmd.Parameters.Add("@PERSONAL_NOMBRES", SqlDbType.VarChar).Value = oBE_PERSONAL.NOMBRES;
                    objCmd.Parameters.Add("@PERSONAL_SEDE", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.SEDE_ID;
                    objCmd.Parameters.Add("@PERSONAL_EMPRESA", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.EMPRESA_ID;
                    objCmd.Parameters.Add("@PERSONAL_GERENCIA", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.GERENCIA_ID;
                    objCmd.Parameters.Add("@PERSONAL_AREA", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.AREA_ID;
                    objCmd.Parameters.Add("@PERSONAL_COORDINACION", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.COORDINACION_ID;
                    objCmd.Parameters.Add("@PERSONAL_PUESTO", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.PUESTO_ID;
                    objCmd.Parameters.Add("@PERSONAL_GRUPO_ORGANIZACION", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID;
                    objCmd.Parameters.Add("@PERSONAL_CORREO", SqlDbType.VarChar).Value = oBE_PERSONAL.CORREO;
                    objCmd.Parameters.Add("@PERSONAL_NOMBRE_USUARIO", SqlDbType.VarChar).Value = oBE_PERSONAL.NOMBRE_USUARIO;
                    objCmd.Parameters.Add("@PERSONAL_ESTADO", SqlDbType.Int).Value = oBE_PERSONAL.ESTADO;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.USUARIO_CREACION;
                    
                    cnx.Open();

                    bIndicador = objCmd.ExecuteNonQuery() > 0;
                }

                //AC_Transaction.Insert(1, "I", "DataAccessLayer", "DA_DOCUMENTO", "registrarSolicitudDocumento", "Registro de Solicitud Documento");

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
                //AC_LogError.Insert(1, "I", "DataAccessLayer", "DA_DOCUMENTO", "registrarSolicitudDocumento", ex.Message);

            }
            finally
            {
                cnx.Close();
            }
            return false;
        }

        
        /// <summary>
        /// Actualizar un Personal
        /// </summary>
        /// <param name="oBE_PERSONAL">Objeto BE_PERSONAL con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarPersonal(BE_PERSONAL oBE_PERSONAL)
        {
            SqlConnection cnx = new SqlConnection();
            bool bIndicador = false;

            cnx = DC_Connection.getConnection();

            try
            {

                using (
                    SqlCommand objCmd = new SqlCommand()
                    {
                        Connection = cnx,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "USP_PERSONAL_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@PERSONAL_ID", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.ID;
                    objCmd.Parameters.Add("@PERSONAL_CODIGO_TRABAJO", SqlDbType.VarChar).Value = oBE_PERSONAL.CODIGO_TRABAJO;
                    objCmd.Parameters.Add("@PERSONAL_APELLIDO_PATERNO", SqlDbType.VarChar).Value = oBE_PERSONAL.APELLIDO_PATERNO;
                    objCmd.Parameters.Add("@PERSONAL_APELLIDO_MATERNO", SqlDbType.VarChar).Value = oBE_PERSONAL.APELLIDO_MATERNO;
                    objCmd.Parameters.Add("@PERSONAL_NOMBRES", SqlDbType.VarChar).Value = oBE_PERSONAL.NOMBRES;
                    objCmd.Parameters.Add("@PERSONAL_SEDE", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.SEDE_ID;
                    objCmd.Parameters.Add("@PERSONAL_EMPRESA", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.EMPRESA_ID;
                    objCmd.Parameters.Add("@PERSONAL_GERENCIA", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.GERENCIA_ID;
                    objCmd.Parameters.Add("@PERSONAL_AREA", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.AREA_ID;
                    objCmd.Parameters.Add("@PERSONAL_COORDINACION", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.COORDINACION_ID;
                    objCmd.Parameters.Add("@PERSONAL_PUESTO", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.PUESTO_ID;
                    objCmd.Parameters.Add("@PERSONAL_GRUPO_ORGANIZACION", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.GRUPO_ORGANIZACIONAL_ID;
                    objCmd.Parameters.Add("@PERSONAL_CORREO", SqlDbType.VarChar).Value = oBE_PERSONAL.CORREO;
                    objCmd.Parameters.Add("@PERSONAL_NOMBRE_USUARIO", SqlDbType.VarChar).Value = oBE_PERSONAL.NOMBRE_USUARIO;
                    objCmd.Parameters.Add("@PERSONAL_ESTADO", SqlDbType.Int).Value = oBE_PERSONAL.ESTADO;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_PERSONAL.USUARIO_CREACION;


                    cnx.Open();

                    bIndicador = objCmd.ExecuteNonQuery() > 0;
                }

                //AC_Transaction.Insert(1, "I", "DataAccessLayer", "DA_DOCUMENTO", "registrarSolicitudDocumento", "Registro de Solicitud Documento");

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
                //AC_LogError.Insert(1, "I", "DataAccessLayer", "DA_DOCUMENTO", "registrarSolicitudDocumento", ex.Message);

            }
            finally
            {
                cnx.Close();
            }
            return false;
        }


        /// <summary>
        /// Elimina un Personal
        /// </summary>
        /// <param name="personal_id">Codigo del personal al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarPersonal(Guid personal_id)
        {
            SqlConnection cnx = new SqlConnection();
            bool bIndicador = false;

            cnx = DC_Connection.getConnection();

            try
            {

                using (
                    SqlCommand objCmd = new SqlCommand()
                    {
                        Connection = cnx,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "USP_PERSONAL_ELIMINAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@PERSONAL_ID", SqlDbType.UniqueIdentifier).Value = personal_id;
                    


                    cnx.Open();

                    bIndicador = objCmd.ExecuteNonQuery() > 0;
                }

                //AC_Transaction.Insert(1, "I", "DataAccessLayer", "DA_DOCUMENTO", "registrarSolicitudDocumento", "Registro de Solicitud Documento");

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
                //AC_LogError.Insert(1, "I", "DataAccessLayer", "DA_DOCUMENTO", "registrarSolicitudDocumento", ex.Message);

            }
            finally
            {
                cnx.Close();
            }
            return false;
        }

    }
}
