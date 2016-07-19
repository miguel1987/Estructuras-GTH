using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataConnectionComponent;
using BusinessEntities;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace DataAccessLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla USUARIOS
    /// </summary>
    public class DA_USUARIO
    {
        /// <summary>
        /// Devuelve los datos de todos los Usuarios
        /// </summary>
        /// <returns>List de BE_USUARIO con los objetos de la entidad, que a su vez representan la tabla USUARIOS de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public List<BE_USUARIO> SeleccionarUsuarios()
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_USUARIO> oUSUARIOS = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_USUARIOS_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int USUARIO_ID = dr.GetOrdinal("USUARIO_ID");
                    int PERSONAL_ID = dr.GetOrdinal("PERSONAL_ID");
                    int PERFIL_ID = dr.GetOrdinal("PERFIL_ID");                    
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oUSUARIOS = new List<BE_USUARIO>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_USUARIO oBE_USUARIOS = new BE_USUARIO();
                            oBE_USUARIOS.USUARIO_ID = (Guid)Valores.GetValue(USUARIO_ID);
                            oBE_USUARIOS.PERSONAL_ID = (Guid)Valores.GetValue(PERSONAL_ID);
                            oBE_USUARIOS.PERFIL_ID =  Int32.Parse(Valores.GetValue(PERFIL_ID).ToString());
                            oBE_USUARIOS.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_USUARIOS.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_USUARIOS.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_USUARIOS.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oUSUARIOS.Add(oBE_USUARIOS);
                        }
                    }
                }

                return oUSUARIOS;
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
        /// Devuelve los datos un Usuario en especifico
        /// </summary>
        /// <returns>BE_USUARIO con los objetos de la entidad, que a su vez representan la tabla USUARIOS de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public BE_USUARIO SeleccionarUsuarioPorPersonalId(Guid personal_id)
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            BE_USUARIO oBE_USUARIO = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_USUARIO_SELECCIONAR_POR_PERSONAL_ID"
                })
                {
                    objCmd.Parameters.Add("@PERSONAL_ID", SqlDbType.UniqueIdentifier).Value = personal_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int USUARIO_ID = dr.GetOrdinal("USUARIO_ID");
                    int PERSONAL_ID = dr.GetOrdinal("PERSONAL_ID");
                    int PERFIL_ID = dr.GetOrdinal("PERFIL_ID");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oBE_USUARIO = new BE_USUARIO();
                        if (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            //BE_PERFILES oBE_PERFILES = new BE_PERFILES();
                            oBE_USUARIO.USUARIO_ID = (Guid)Valores.GetValue(USUARIO_ID);
                            oBE_USUARIO.PERSONAL_ID = (Guid)Valores.GetValue(PERSONAL_ID);
                            oBE_USUARIO.PERFIL_ID = Int32.Parse(Valores.GetValue(PERFIL_ID).ToString());                           
                        }
                    }
                }

                return oBE_USUARIO;
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
        /// Ingresa un nuevo Usuario
        /// </summary>
        /// <param name="oBE_USUARIO">Objeto BE_USUARIO con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarUsuario(BE_USUARIO oBE_USUARIO)
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
                        CommandText = "USP_USUARIO_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@PERSONAL_ID", SqlDbType.UniqueIdentifier).Value = oBE_USUARIO.PERSONAL_ID;
                    objCmd.Parameters.Add("@PERFIL_ID", SqlDbType.Int).Value = oBE_USUARIO.PERFIL_ID;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_USUARIO.USUARIO_CREACION;
                    
                    cnx.Open();

                    bIndicador = objCmd.ExecuteNonQuery() > 0;
                }                

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);                

            }
            finally
            {
                cnx.Close();
            }


            return bIndicador;
        }

        /// <summary>
        /// Actualizar un nuevo Usuario
        /// </summary>
        /// <param name="oBE_USUARIO">Objeto BE_USUARIO con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarUsuario(BE_USUARIO oBE_USUARIO)
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
                        CommandText = "USP_USUARIO_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@USUARIO_ID", SqlDbType.UniqueIdentifier).Value = oBE_USUARIO.USUARIO_ID;
                    objCmd.Parameters.Add("@PERSONAL_ID", SqlDbType.UniqueIdentifier).Value = oBE_USUARIO.PERSONAL_ID;
                    objCmd.Parameters.Add("@PERFIL_ID", SqlDbType.Int).Value = oBE_USUARIO.PERFIL_ID;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_USUARIO.USUARIO_CREACION;

                    cnx.Open();

                    bIndicador = objCmd.ExecuteNonQuery() > 0;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);

            }
            finally
            {
                cnx.Close();
            }

            return bIndicador;
        }

        /// <summary>
        /// Elimina los dato de una usuario
        /// </summary>
        /// <param name="gerencia_id">Codigo del Usuario al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarUsuario(Guid usuario_id)
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
                        CommandText = "USP_USUARIO_ELIMINAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@USUARIO_ID", SqlDbType.UniqueIdentifier).Value = usuario_id;


                    cnx.Open();

                    bIndicador = objCmd.ExecuteNonQuery() > 0;
                }               

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);                

            }
            finally
            {
                cnx.Close();
            }
            return bIndicador;
        }

        /// <summary>
        /// Elimina los dato de una usuario
        /// </summary>
        /// <param name="personal_id">Codigo del Personal al cual se desea eliminar de la tabla de usuarios</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarUsuarioPorPersonal(Guid personal_id)
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
                        CommandText = "USP_USUARIO_ELIMINAR_POR_PERSONAL"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@PERSONAL_ID", SqlDbType.UniqueIdentifier).Value = personal_id;


                    cnx.Open();

                    bIndicador = objCmd.ExecuteNonQuery() > 0;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);

            }
            finally
            {
                cnx.Close();
            }
            return bIndicador;
        }
    }
}
