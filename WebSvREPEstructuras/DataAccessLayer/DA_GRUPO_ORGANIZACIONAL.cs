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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla GRUPOS_ORGANIZACIONALES
    /// </summary>
    public class DA_GRUPO_ORGANIZACIONAL
    {
        /// <summary>
        ///  Devuelve los datos de todas los GRUPOS ORGANIZACIONALES.
        /// </summary>
        /// <returns> List de BE_GRUPO_ORGANIZACIONAL con los objetos de la entidad, que a su vez representan la tabla GRUPOS_ORGANIZACIONALES de la base de datos.En caso existan datos devuelve nothing </returns>
        public List<BE_GRUPO_ORGANIZACIONAL> SeleccionarGrupoOrganizacional()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_GRUPO_ORGANIZACIONAL> oGRUPO_ORGANIZACIONAL = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_GRUPO_ORGANIZACIONAL_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int GRUPO_ORGANIZACIONAL_ID = dr.GetOrdinal("GRUPO_ORGANIZACIONAL_ID");
                    int GRUPO_ORGANIZACIONAL_CODIGO = dr.GetOrdinal("GRUPO_ORGANIZACIONAL_CODIGO");
                    int GRUPO_ORGANIZACIONAL_DESCRIPCION = dr.GetOrdinal("GRUPO_ORGANIZACIONAL_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int GRUPO_ORGANIZACIONAL_ESTADO = dr.GetOrdinal("GRUPO_ORGANIZACIONAL_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oGRUPO_ORGANIZACIONAL = new List<BE_GRUPO_ORGANIZACIONAL>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_GRUPO_ORGANIZACIONAL oBE_GRUPO_ORGANIZACIONAL = new BE_GRUPO_ORGANIZACIONAL();
                            oBE_GRUPO_ORGANIZACIONAL.ID = (Guid)Valores.GetValue(GRUPO_ORGANIZACIONAL_ID);
                            oBE_GRUPO_ORGANIZACIONAL.CODIGO = Valores.GetValue(GRUPO_ORGANIZACIONAL_CODIGO).ToString();
                            oBE_GRUPO_ORGANIZACIONAL.DESCRIPCION = Valores.GetValue(GRUPO_ORGANIZACIONAL_DESCRIPCION).ToString();
                            oBE_GRUPO_ORGANIZACIONAL.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_GRUPO_ORGANIZACIONAL.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_GRUPO_ORGANIZACIONAL.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_GRUPO_ORGANIZACIONAL.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_GRUPO_ORGANIZACIONAL.ESTADO = Convert.ToInt32(Valores.GetValue(GRUPO_ORGANIZACIONAL_ESTADO));
                            oGRUPO_ORGANIZACIONAL.Add(oBE_GRUPO_ORGANIZACIONAL);
                        }
                    }


                }

                return oGRUPO_ORGANIZACIONAL;
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
        /// Devuelve los datos de una empresa específica
        /// </summary>
        /// <param name="grupo_organizacional_id">Id del Grupo Organizacional que se desea consultar</param>
        /// <returns> BE_GRUPO_ORGANIZACIONAL con todos sus atributos de la entidad, que a su vez representan la tabla EMPRESAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_GRUPO_ORGANIZACIONAL> SeleccionarGrupoOrganizacionalPorId(Guid grupo_organizacional_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_GRUPO_ORGANIZACIONAL> oGRUPO_ORGANIZACIONAL = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_GRUPO_ORGANIZACIONAL_SELECCIONAR_POR_ID"


                })
                {

                    objCmd.Parameters.Add("@GRUPO_ORGANIZACIONAL_ID", SqlDbType.UniqueIdentifier).Value = grupo_organizacional_id;


                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int GRUPO_ORGANIZACIONAL_ID = dr.GetOrdinal("GRUPO_ORGANIZACIONAL_ID");
                    int GRUPO_ORGANIZACIONAL_CODIGO = dr.GetOrdinal("GRUPO_ORGANIZACIONAL_CODIGO");
                    int GRUPO_ORGANIZACIONAL_DESCRIPCION = dr.GetOrdinal("GRUPO_ORGANIZACIONAL_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int GRUPO_ORGANIZACIONAL_ESTADO = dr.GetOrdinal("GRUPO_ORGANIZACIONAL_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oGRUPO_ORGANIZACIONAL = new List<BE_GRUPO_ORGANIZACIONAL>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_GRUPO_ORGANIZACIONAL oBE_GRUPO_ORGANIZACIONAL = new BE_GRUPO_ORGANIZACIONAL();
                            oBE_GRUPO_ORGANIZACIONAL.ID = (Guid)Valores.GetValue(GRUPO_ORGANIZACIONAL_ID);
                            oBE_GRUPO_ORGANIZACIONAL.CODIGO = DBNull.Value == Valores.GetValue(GRUPO_ORGANIZACIONAL_CODIGO) ? String.Empty : Valores.GetValue(GRUPO_ORGANIZACIONAL_CODIGO).ToString();  
                            oBE_GRUPO_ORGANIZACIONAL.DESCRIPCION = Valores.GetValue(GRUPO_ORGANIZACIONAL_DESCRIPCION).ToString();
                            oBE_GRUPO_ORGANIZACIONAL.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_GRUPO_ORGANIZACIONAL.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_GRUPO_ORGANIZACIONAL.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_GRUPO_ORGANIZACIONAL.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_GRUPO_ORGANIZACIONAL.ESTADO = Convert.ToInt32(Valores.GetValue(GRUPO_ORGANIZACIONAL_ESTADO));

                            oGRUPO_ORGANIZACIONAL.Add(oBE_GRUPO_ORGANIZACIONAL);
                        }
                    }

                }

                return oGRUPO_ORGANIZACIONAL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { cnx.Close(); }


        }
        /// <summary>
        /// Inserta los datos de un Grupo Organizacional
        /// </summary>
        /// <param name="oBE_GRUPO_ORGANIZACIONAL">Entidad BE_GRUPO_ORGANIZACIONAL, que representa la tabla GRUPOS_ORGANIZACIONALES, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarGrupoOrganizacional(BE_GRUPO_ORGANIZACIONAL oBE_GRUPO_ORGANIZACIONAL)
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
                        CommandText = "USP_GRUPO_ORGANIZACIONAL_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@GRUPO_ORGANIZACIONAL_CODIGO", SqlDbType.VarChar).Value = oBE_GRUPO_ORGANIZACIONAL.CODIGO;
                    objCmd.Parameters.Add("@GRUPO_ORGANIZACIONAL_DESCRIPCION", SqlDbType.VarChar).Value = oBE_GRUPO_ORGANIZACIONAL.DESCRIPCION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_GRUPO_ORGANIZACIONAL.USUARIO_CREACION;
                    objCmd.Parameters.Add("@GRUPO_ORGANIZACIONAL_ESTADO", SqlDbType.Int).Value = oBE_GRUPO_ORGANIZACIONAL.ESTADO;

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
        /// Actualiza los datos de un Grupo Organizacional
        /// </summary>
        /// <param name="oBE_GRUPO_ORGANIZACIONAL">Entidad BE_GRUPO_ORGANIZACIONAL, que representa la tabla GRUPOS ORGANIZACIONAL, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarGrupoOrganizacional(BE_GRUPO_ORGANIZACIONAL oBE_GRUPO_ORGANIZACIONAL)
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
                        CommandText = "USP_GRUPO_ORGANIZACIONAL_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@GRUPO_ORGANIZACIONAL_ID", SqlDbType.UniqueIdentifier).Value = oBE_GRUPO_ORGANIZACIONAL.ID;
                    objCmd.Parameters.Add("@GRUPO_ORGANIZACIONAL_CODIGO", SqlDbType.VarChar).Value = oBE_GRUPO_ORGANIZACIONAL.CODIGO;
                    objCmd.Parameters.Add("@GRUPO_ORGANIZACIONAL_DESCRIPCION", SqlDbType.VarChar).Value = oBE_GRUPO_ORGANIZACIONAL.DESCRIPCION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_GRUPO_ORGANIZACIONAL.USUARIO_CREACION;
                    objCmd.Parameters.Add("@GRUPO_ORGANIZACIONAL_ESTADO", SqlDbType.Int).Value = oBE_GRUPO_ORGANIZACIONAL.ESTADO;

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
        /// Elimina los dato de un grupo organizacional
        /// </summary>
        /// <param name="grupo_organizacional_id">Id del grupo organizacional al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarGrupoOrganizacional(Guid grupo_organizacional_id)
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
                        CommandText = "USP_GRUPO_ORGANIZACIONAL_ELIMINAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@GRUPO_ORGANIZACIONAL_ID", SqlDbType.UniqueIdentifier).Value = grupo_organizacional_id;


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
