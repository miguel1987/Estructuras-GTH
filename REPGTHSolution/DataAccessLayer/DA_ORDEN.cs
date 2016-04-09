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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla ORDENES
    /// </summary>
    public class DA_ORDEN
    {
        /// <summary>
        ///  Devuelve los datos de todos las Órdenes.
        /// </summary>
        /// <returns> List de BE_ORDEN con los objetos de la entidad, que a su vez representan la tabla ORDENES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_ORDEN> SeleccionarOrdenes()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_ORDEN> oORDEN = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_ORDEN_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int ORDEN_ID = dr.GetOrdinal("ORDEN_ID");
                    int ORDEN_CODIGO = dr.GetOrdinal("ORDEN_CODIGO");
                    int ORDEN_DESCRIPCION = dr.GetOrdinal("ORDEN_DESCRIPCION");
                    int AREA_ID = dr.GetOrdinal("AREA_ID");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int ORDEN_ESTADO = dr.GetOrdinal("ORDEN_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oORDEN = new List<BE_ORDEN>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_ORDEN oBE_ORDEN = new BE_ORDEN();
                            oBE_ORDEN.ID = (Guid)Valores.GetValue(ORDEN_ID);
                            oBE_ORDEN.CODIGO = Valores.GetValue(ORDEN_CODIGO).ToString();
                            oBE_ORDEN.DESCRIPCION = Valores.GetValue(ORDEN_DESCRIPCION).ToString();
                            oBE_ORDEN.AREA_ID = (Guid)Valores.GetValue(AREA_ID);
                            oBE_ORDEN.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_ORDEN.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_ORDEN.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_ORDEN.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_ORDEN.ESTADO = Convert.ToInt32(Valores.GetValue(ORDEN_ESTADO));
                            oORDEN.Add(oBE_ORDEN);

                        }
                    }


                }

                return oORDEN;
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
        ///  Devuelve los datos de todos las Órdenes.
        /// </summary>
        /// <param name="areaId">Id del área cuyas órdenes se desean listar </param>
        /// <returns> List de BE_ORDEN con los objetos de la entidad, que a su vez representan la tabla ORDENES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_ORDEN> SeleccionarOrdenesPorArea(Guid area_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_ORDEN> oORDEN = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_ORDEN_SELECCIONAR_POR_AREA"
                })
                {
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = area_id;
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int ORDEN_ID = dr.GetOrdinal("ORDEN_ID");
                    int ORDEN_CODIGO = dr.GetOrdinal("ORDEN_CODIGO");
                    int ORDEN_DESCRIPCION = dr.GetOrdinal("ORDEN_DESCRIPCION");
                    int AREA_ID = dr.GetOrdinal("AREA_ID");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int ORDEN_ESTADO = dr.GetOrdinal("ORDEN_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oORDEN = new List<BE_ORDEN>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_ORDEN oBE_ORDEN = new BE_ORDEN();
                            oBE_ORDEN.ID = (Guid)Valores.GetValue(ORDEN_ID);
                            oBE_ORDEN.CODIGO = Valores.GetValue(ORDEN_CODIGO).ToString();
                            oBE_ORDEN.DESCRIPCION = Valores.GetValue(ORDEN_DESCRIPCION).ToString();
                            oBE_ORDEN.CODIGO_DESCRIPCION = String.Format("{0} - {1}", oBE_ORDEN.CODIGO, oBE_ORDEN.DESCRIPCION);
                            oBE_ORDEN.AREA_ID = (Guid)Valores.GetValue(AREA_ID);
                            oBE_ORDEN.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_ORDEN.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_ORDEN.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_ORDEN.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_ORDEN.ESTADO = Convert.ToInt32(Valores.GetValue(ORDEN_ESTADO));
                            oORDEN.Add(oBE_ORDEN);

                        }
                    }


                }

                return oORDEN;
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
        /// Ingresa un nueva Orden
        /// </summary>
        /// <param name="oBE_ORDEN">Objeto BE_ORDEN con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Guid InsertarOrden(BE_ORDEN oBE_ORDEN)
        {
            SqlConnection cnx = new SqlConnection();
            Guid orden_id = Guid.Empty;

            cnx = DC_Connection.getConnection();

            try
            {

                using (
                    SqlCommand objCmd = new SqlCommand()
                    {
                        Connection = cnx,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "USP_ORDEN_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@ORDEN_CODIGO", SqlDbType.VarChar).Value = oBE_ORDEN.CODIGO;
                    objCmd.Parameters.Add("@ORDEN_DESCRIPCION", SqlDbType.VarChar).Value = oBE_ORDEN.DESCRIPCION;
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = oBE_ORDEN.AREA_ID;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_ORDEN.USUARIO_CREACION;

                    cnx.Open();

                    orden_id = (Guid)objCmd.ExecuteScalar();

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


            return orden_id;
        }

        /// <summary>
        /// Actualizar una Orden
        /// </summary>
        /// <param name="oBE_ORDEN">Objeto BE_ORDEN con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarOrden(BE_ORDEN oBE_ORDEN)
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
                        CommandText = "USP_ORDEN_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@ORDEN_ID", SqlDbType.UniqueIdentifier).Value = oBE_ORDEN.ID;
                    objCmd.Parameters.Add("@ORDEN_CODIGO", SqlDbType.VarChar).Value = oBE_ORDEN.CODIGO;
                    objCmd.Parameters.Add("@ORDEN_DESCRIPCION", SqlDbType.VarChar).Value = oBE_ORDEN.DESCRIPCION;
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = oBE_ORDEN.AREA_ID;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_ORDEN.USUARIO_CREACION;

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
        /// Eliminar una Orden
        /// </summary>
        /// <param name="ordenId">Identificador de la orden a eliminar</param>        
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarOrden(Guid ordenId)
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
                        CommandText = "USP_ORDEN_ELIMINAR"
                    }
                    )
                {
                    objCmd.Parameters.Add("@ORDEN_ID", SqlDbType.UniqueIdentifier).Value = ordenId;


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
