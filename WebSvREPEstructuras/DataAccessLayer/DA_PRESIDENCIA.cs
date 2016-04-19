using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using DataConnectionComponent;
using BussinesEntities;

namespace DataAccessLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla PRESIDENCIAS
    /// </summary>
    public class DA_PRESIDENCIA
    {
        /// <summary>
        ///  Devuelve los datos de todas las PRESIDENCIAS.
        /// </summary>
        /// <returns> List de BE_PRESIDENCIA con los objetos de la entidad, que a su vez representan la tabla PRESIDENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_PRESIDENCIA> SeleccionarPresidencia()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PRESIDENCIA> oPRESIDENCIA = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PRESIDENCIA_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PRESIDENCIA_ID = dr.GetOrdinal("PRESIDENCIA_ID");
                    int PRESIDENCIA_CODIGO = dr.GetOrdinal("PRESIDENCIA_CODIGO");
                    int PRESIDENCIA_DESCRIPCION = dr.GetOrdinal("PRESIDENCIA_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int PRESIDENCIA_ESTADO = dr.GetOrdinal("PRESIDENCIA_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPRESIDENCIA = new List<BE_PRESIDENCIA>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PRESIDENCIA oBE_PRESIDENCIA = new BE_PRESIDENCIA();
                            oBE_PRESIDENCIA.ID = (Guid)Valores.GetValue(PRESIDENCIA_ID);
                            oBE_PRESIDENCIA.CODIGO = Valores.GetValue(PRESIDENCIA_CODIGO).ToString();
                            oBE_PRESIDENCIA.DESCRIPCION = Valores.GetValue(PRESIDENCIA_DESCRIPCION).ToString();
                            oBE_PRESIDENCIA.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_PRESIDENCIA.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_PRESIDENCIA.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_PRESIDENCIA.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_PRESIDENCIA.ESTADO = Convert.ToInt32(Valores.GetValue(PRESIDENCIA_ESTADO));
                            oPRESIDENCIA.Add(oBE_PRESIDENCIA);
                        }
                    }


                }

                return oPRESIDENCIA;
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
        /// Devuelve los datos de una presidencia específica
        /// </summary>
        /// <param name="presidencia_id">Codigo del la Presidencia que se desea consultar</param>
        /// <returns> BE_PRESIDENCIA con todos sus atributos de la entidad, que a su vez representan la tabla PRESIDENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_PRESIDENCIA> SeleccionarPresidenciaPorId(Guid presidencia_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PRESIDENCIA> oPRESIDENCIA = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PRESIDENCIA_SELECCIONAR_POR_ID"


                })
                {

                    objCmd.Parameters.Add("@PRESIDENCIA_ID", SqlDbType.UniqueIdentifier).Value = presidencia_id;


                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PRESIDENCIA_ID = dr.GetOrdinal("PRESIDENCIA_ID");
                    int PRESIDENCIA_CODIGO = dr.GetOrdinal("PRESIDENCIA_CODIGO");
                    int PRESIDENCIA_DESCRIPCION = dr.GetOrdinal("PRESIDENCIA_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int PRESIDENCIA_ESTADO = dr.GetOrdinal("PRESIDENCIA_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPRESIDENCIA = new List<BE_PRESIDENCIA>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PRESIDENCIA oBE_PRESIDENCIA = new BE_PRESIDENCIA();
                            oBE_PRESIDENCIA.ID = (Guid)Valores.GetValue(PRESIDENCIA_ID);
                            oBE_PRESIDENCIA.CODIGO = Valores.GetValue(PRESIDENCIA_CODIGO).ToString();
                            oBE_PRESIDENCIA.DESCRIPCION = Valores.GetValue(PRESIDENCIA_DESCRIPCION).ToString();
                            oBE_PRESIDENCIA.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_PRESIDENCIA.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_PRESIDENCIA.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_PRESIDENCIA.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_PRESIDENCIA.ESTADO = Convert.ToInt32(Valores.GetValue(PRESIDENCIA_ESTADO));
                            oPRESIDENCIA.Add(oBE_PRESIDENCIA);
                        }
                    }


                }

                return oPRESIDENCIA;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { cnx.Close(); }


        }

        /// <summary>
        /// Devuelve los datos las presidencias asignadas a una empresa específica
        /// </summary>
        /// <param name="empresa_id">Codigo de la empresa en la cual se desea consultar sus presidencias</param>
        /// <returns> BE_PRESIDENCIA con todos sus atributos de la entidad, que a su vez representan la tabla PRESIDENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_PRESIDENCIA> SeleccionarPresidenciaPorEmpresa(Guid empresa_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PRESIDENCIA> oPRESIDENCIA = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PRESIDENCIA_SELECCIONAR_POR_EMPRESA"


                })
                {

                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = empresa_id;


                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PRESIDENCIA_ID = dr.GetOrdinal("PRESIDENCIA_ID");
                    int PRESIDENCIA_CODIGO = dr.GetOrdinal("PRESIDENCIA_CODIGO");
                    int PRESIDENCIA_DESCRIPCION = dr.GetOrdinal("PRESIDENCIA_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int PRESIDENCIA_ESTADO = dr.GetOrdinal("PRESIDENCIA_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPRESIDENCIA = new List<BE_PRESIDENCIA>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PRESIDENCIA oBE_PRESIDENCIA = new BE_PRESIDENCIA();
                            oBE_PRESIDENCIA.ID = (Guid)Valores.GetValue(PRESIDENCIA_ID);
                            oBE_PRESIDENCIA.CODIGO = Valores.GetValue(PRESIDENCIA_CODIGO).ToString();
                            oBE_PRESIDENCIA.DESCRIPCION = Valores.GetValue(PRESIDENCIA_DESCRIPCION).ToString();
                            oBE_PRESIDENCIA.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_PRESIDENCIA.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_PRESIDENCIA.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_PRESIDENCIA.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_PRESIDENCIA.ESTADO = Convert.ToInt32(Valores.GetValue(PRESIDENCIA_ESTADO));
                            oPRESIDENCIA.Add(oBE_PRESIDENCIA);
                        }
                    }


                }

                return oPRESIDENCIA;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { cnx.Close(); }


        }

        /// <summary>
        /// Inserta los datos de una Presidencia
        /// </summary>
        /// <param name="oBE_PRESIDENCIA">Entidad BE_PRESIDENCIA, que representa la tabla PRESIDENCIA, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarPresidencia(BE_PRESIDENCIA oBE_PRESIDENCIA)
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
                        CommandText = "USP_PRESIDENCIA_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@PRESIDENCIA_CODIGO ", SqlDbType.VarChar).Value = oBE_PRESIDENCIA.CODIGO;
                    objCmd.Parameters.Add("@PRESIDENCIA_DESCRIPCION ", SqlDbType.VarChar).Value = oBE_PRESIDENCIA.DESCRIPCION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_PRESIDENCIA.USUARIO_CREACION;
                    objCmd.Parameters.Add("@PRESIDENCIA_ESTADO", SqlDbType.Int).Value = oBE_PRESIDENCIA.ESTADO;
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = oBE_PRESIDENCIA.EMPRESA_ID;

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
        /// Actualiza los datos de una Presidencia
        /// </summary>
        /// <param name="oBE_PRESIDENCIA">Entidad BE_PRESIDENCIA, que representa la tabla PRESIDENCIAS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarPresidencia(BE_PRESIDENCIA oBE_PRESIDENCIA)
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
                        CommandText = "USP_PRESIDENCIA_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@PRESIDENCIA_ID", SqlDbType.UniqueIdentifier).Value = oBE_PRESIDENCIA.ID;
                    objCmd.Parameters.Add("@PRESIDENCIA_CODIGO", SqlDbType.VarChar).Value = oBE_PRESIDENCIA.CODIGO;
                    objCmd.Parameters.Add("@PRESIDENCIA_DESCRIPCION", SqlDbType.VarChar).Value = oBE_PRESIDENCIA.DESCRIPCION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_PRESIDENCIA.USUARIO_CREACION;
                    objCmd.Parameters.Add("@PRESIDENCIA_ESTADO", SqlDbType.Int).Value = oBE_PRESIDENCIA.ESTADO;
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = oBE_PRESIDENCIA.EMPRESA_ID;

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
        /// Elimina los dato de una presidencia
        /// </summary>
        /// <param name="presidencia_id">Codigo del la Presidencia que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarPresidencia(Guid presidencia_id)
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
                        CommandText = "USP_PRESIDENCIA_ELIMINAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@PRESIDENCIA_ID", SqlDbType.UniqueIdentifier).Value = presidencia_id;


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
