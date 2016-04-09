using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using DataConnectionComponent;
using BusinessEntities;

namespace DataAccessLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla CENTROS DE COSTOS
    /// </summary>
    public class DA_CENTRO_COSTO
    {
        /// <summary>
        ///  Devuelve los datos de todos los Centros de Costo.
        /// </summary>
        /// <returns> List de BE_CENTRO_COSTO con los objetos de la entidad, que a su vez representan la tabla CENTROS DE COSTO de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_CENTRO_COSTO> SeleccionarCentrosCostos()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_CENTRO_COSTO> oCENTRO_COSTO = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_CENTRO_COSTO_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int CENTRO_COSTO_ID = dr.GetOrdinal("CENTRO_COSTO_ID");
                    int CENTRO_COSTO_CODIGO = dr.GetOrdinal("CENTRO_COSTO_CODIGO");
                    int CENTRO_COSTO_DESCRIPCION = dr.GetOrdinal("CENTRO_COSTO_DESCRIPCION");
                    int AREA_ID = dr.GetOrdinal("AREA_ID");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int CENTRO_COSTO_ESTADO = dr.GetOrdinal("CENTRO_COSTO_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oCENTRO_COSTO = new List<BE_CENTRO_COSTO>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_CENTRO_COSTO oBE_CENTRO_COSTO = new BE_CENTRO_COSTO();
                            oBE_CENTRO_COSTO.ID = (Guid)Valores.GetValue(CENTRO_COSTO_ID);
                            oBE_CENTRO_COSTO.CODIGO = Valores.GetValue(CENTRO_COSTO_CODIGO).ToString();
                            oBE_CENTRO_COSTO.DESCRIPCION = Valores.GetValue(CENTRO_COSTO_DESCRIPCION).ToString();
                            oBE_CENTRO_COSTO.AREA_ID = (Guid)Valores.GetValue(AREA_ID);
                            oBE_CENTRO_COSTO.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_CENTRO_COSTO.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_CENTRO_COSTO.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_CENTRO_COSTO.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_CENTRO_COSTO.ESTADO = Convert.ToInt32(Valores.GetValue(CENTRO_COSTO_ESTADO));
                            oCENTRO_COSTO.Add(oBE_CENTRO_COSTO);

                        }
                    }


                }

                return oCENTRO_COSTO;
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
        ///  Devuelve los datos de todos los Centros de Costo.
        /// </summary>
        /// <param name="areaId">Id del área cuyos centros de costo se desean listar </param>
        /// <returns> List de BE_CENTRO_COSTO con los objetos de la entidad, que a su vez representan la tabla CENTROS DE COSTO de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_CENTRO_COSTO> SeleccionarCentroCostoArea(Guid area_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_CENTRO_COSTO> oCENTRO_COSTO = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_CENTRO_COSTO_SELECCIONAR_POR_AREA"
                })
                {
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = area_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int CENTRO_COSTO_ID = dr.GetOrdinal("CENTRO_COSTO_ID");
                    int CENTRO_COSTO_CODIGO = dr.GetOrdinal("CENTRO_COSTO_CODIGO");
                    int CENTRO_COSTO_DESCRIPCION = dr.GetOrdinal("CENTRO_COSTO_DESCRIPCION");
                    int AREA_ID = dr.GetOrdinal("AREA_ID");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int CENTRO_COSTO_ESTADO = dr.GetOrdinal("CENTRO_COSTO_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oCENTRO_COSTO = new List<BE_CENTRO_COSTO>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_CENTRO_COSTO oBE_CENTRO_COSTO = new BE_CENTRO_COSTO();
                            oBE_CENTRO_COSTO.ID = (Guid)Valores.GetValue(CENTRO_COSTO_ID);
                            oBE_CENTRO_COSTO.CODIGO = Valores.GetValue(CENTRO_COSTO_CODIGO).ToString();
                            oBE_CENTRO_COSTO.DESCRIPCION = Valores.GetValue(CENTRO_COSTO_DESCRIPCION).ToString();
                            oBE_CENTRO_COSTO.CODIGO_DESCRIPCION = String.Format("{0} - {1}", oBE_CENTRO_COSTO.CODIGO, oBE_CENTRO_COSTO.DESCRIPCION);
                            oBE_CENTRO_COSTO.AREA_ID = (Guid)Valores.GetValue(AREA_ID);
                            oBE_CENTRO_COSTO.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_CENTRO_COSTO.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_CENTRO_COSTO.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_CENTRO_COSTO.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_CENTRO_COSTO.ESTADO = Convert.ToInt32(Valores.GetValue(CENTRO_COSTO_ESTADO));
                            oCENTRO_COSTO.Add(oBE_CENTRO_COSTO);

                        }
                    }


                }

                return oCENTRO_COSTO;
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
        /// Ingresa un nuevo Centro de Costo
        /// </summary>
        /// <param name="oBE_CENTRO_COSTO">Objeto BE_CENTRO_COSTO con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Guid InsertarCentroCosto(BE_CENTRO_COSTO oBE_CENTRO_COSTO)
        {
            SqlConnection cnx = new SqlConnection();
            Guid centroCosto_id = Guid.Empty;

            cnx = DC_Connection.getConnection();

            try
            {

                using (
                    SqlCommand objCmd = new SqlCommand()
                    {
                        Connection = cnx,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "USP_CENTRO_COSTO_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@CENTRO_COSTO_CODIGO", SqlDbType.VarChar).Value = oBE_CENTRO_COSTO.CODIGO;
                    objCmd.Parameters.Add("@CENTRO_COSTO_DESCRIPCION", SqlDbType.VarChar).Value = oBE_CENTRO_COSTO.DESCRIPCION;
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = oBE_CENTRO_COSTO.AREA_ID;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_CENTRO_COSTO.USUARIO_CREACION;

                    cnx.Open();

                    centroCosto_id = (Guid)objCmd.ExecuteScalar();
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


            return centroCosto_id;
        }

        /// <summary>
        /// Actualizar un Centro de Costo
        /// </summary>
        /// <param name="oBE_CENTRO_COSTO">Objeto BE_CENTRO_COSTO con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarCentroCosto(BE_CENTRO_COSTO oBE_CENTRO_COSTO)
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
                        CommandText = "USP_CENTRO_COSTO_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@CENTRO_COSTO_ID", SqlDbType.UniqueIdentifier).Value = oBE_CENTRO_COSTO.ID;
                    objCmd.Parameters.Add("@CENTRO_COSTO_CODIGO", SqlDbType.VarChar).Value = oBE_CENTRO_COSTO.CODIGO;
                    objCmd.Parameters.Add("@CENTRO_COSTO_DESCRIPCION", SqlDbType.VarChar).Value = oBE_CENTRO_COSTO.DESCRIPCION;
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = oBE_CENTRO_COSTO.AREA_ID;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_CENTRO_COSTO.USUARIO_CREACION;

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
        /// Eliminar un Centro de Costo
        /// </summary>
        /// <param name="centroCostoId">Identificador del centro de costo a eliminar</param>        
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarCentroCosto(Guid centroCostoId)
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
                        CommandText = "USP_CENTRO_COSTO_ELIMINAR"
                    }
                    )
                {
                    objCmd.Parameters.Add("@CENTRO_COSTO_ID", SqlDbType.UniqueIdentifier).Value = centroCostoId;


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
