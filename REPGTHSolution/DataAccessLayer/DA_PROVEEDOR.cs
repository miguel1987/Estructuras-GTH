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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla PROVEEDORES
    /// </summary>
    public class DA_PROVEEDOR
    {

        /// <summary>
        ///  Devuelve los datos de todos los Proveedores.
        /// </summary>
        /// <returns> List de BE_PROVEEDOR con los objetos de la entidad, que a su vez representan la tabla PROVEEDORES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_PROVEEDOR> SeleccionarProveedores()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PROVEEDOR> oPROVEEDOR = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PROVEEDOR_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PROVEEDOR_ID = dr.GetOrdinal("PROVEEDOR_ID");
                    int PROVEEDOR_DESCRIPCION = dr.GetOrdinal("PROVEEDOR_DESCRIPCION");
                    int PROVEEDOR_TIPO = dr.GetOrdinal("PROVEEDOR_TIPO");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int PROVEEDOR_ESTADO = dr.GetOrdinal("PROVEEDOR_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPROVEEDOR = new List<BE_PROVEEDOR>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PROVEEDOR oBE_PROVEEDOR = new BE_PROVEEDOR();
                            oBE_PROVEEDOR.ID = (Guid)Valores.GetValue(PROVEEDOR_ID);
                            oBE_PROVEEDOR.DESCRIPCION = Valores.GetValue(PROVEEDOR_DESCRIPCION).ToString();
                            oBE_PROVEEDOR.TIPO = Convert.ToInt32(Valores.GetValue(PROVEEDOR_TIPO));
                            oBE_PROVEEDOR.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_PROVEEDOR.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_PROVEEDOR.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_PROVEEDOR.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_PROVEEDOR.ESTADO = Convert.ToInt32(Valores.GetValue(PROVEEDOR_ESTADO));

                            BE_TIPO_SOLICITUD oBE_TIPO_SOLICITUD = new BE_TIPO_SOLICITUD();
                            oBE_TIPO_SOLICITUD.CODIGO = oBE_PROVEEDOR.TIPO;
                            if (oBE_PROVEEDOR.TIPO == 1)
                                oBE_TIPO_SOLICITUD.DESCRIPCION = BE_PROVEEDOR.TIPO_PROVEEDOR.Nacional.ToString();
                            else
                                oBE_TIPO_SOLICITUD.DESCRIPCION = BE_PROVEEDOR.TIPO_PROVEEDOR.International.ToString();
                            oBE_PROVEEDOR.oBE_TIPO_SOLICITUD = oBE_TIPO_SOLICITUD;

                            oPROVEEDOR.Add(oBE_PROVEEDOR);
                            
                        }
                    }


                }

                return oPROVEEDOR;
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
        ///  Devuelve los datos de todos los Proveedores Por Tipo.
        /// </summary>
        /// <param name="tipo">int Tipo de Proveedor:Nacional o Internacional</param>
        /// <returns> List de BE_PROVEEDOR con los objetos de la entidad, que a su vez representan la tabla PROVEEDORES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_PROVEEDOR> SeleccionarProveedoresPorTipo(int tipo)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PROVEEDOR> oPROVEEDOR = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PROVEEDOR_SELECCIONAR_POR_TIPO"
                })
                {
                    objCmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = tipo;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PROVEEDOR_ID = dr.GetOrdinal("PROVEEDOR_ID");
                    int PROVEEDOR_DESCRIPCION = dr.GetOrdinal("PROVEEDOR_DESCRIPCION");
                    int PROVEEDOR_TIPO = dr.GetOrdinal("PROVEEDOR_TIPO");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int PROVEEDOR_ESTADO = dr.GetOrdinal("PROVEEDOR_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPROVEEDOR = new List<BE_PROVEEDOR>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PROVEEDOR oBE_PROVEEDOR = new BE_PROVEEDOR();
                            oBE_PROVEEDOR.ID = (Guid)Valores.GetValue(PROVEEDOR_ID);
                            oBE_PROVEEDOR.DESCRIPCION = Valores.GetValue(PROVEEDOR_DESCRIPCION).ToString();
                            oBE_PROVEEDOR.TIPO = Convert.ToInt32(Valores.GetValue(PROVEEDOR_TIPO));
                            oBE_PROVEEDOR.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_PROVEEDOR.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_PROVEEDOR.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_PROVEEDOR.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_PROVEEDOR.ESTADO = Convert.ToInt32(Valores.GetValue(PROVEEDOR_ESTADO));
                            oPROVEEDOR.Add(oBE_PROVEEDOR);

                        }
                    }


                }

                return oPROVEEDOR;
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
        /// Ingresa un nuevo Proveedor
        /// </summary>
        /// <param name="oBE_PROVEEDOR">Objeto BE_PROVEEDOR con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarProveedor(BE_PROVEEDOR oBE_PROVEEDOR)
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
                        CommandText = "USP_PROVEEDOR_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@PROVEEDOR_DESCRIPCION", SqlDbType.VarChar).Value = oBE_PROVEEDOR.DESCRIPCION;
                    objCmd.Parameters.Add("@PROVEEDOR_TIPO", SqlDbType.Int).Value = oBE_PROVEEDOR.TIPO;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_PROVEEDOR.USUARIO_CREACION;

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
        /// Actualizar un Proveedor
        /// </summary>
        /// <param name="oBE_PROVEEDOR">Objeto BE_PROVEEDOR con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarProveedor(BE_PROVEEDOR oBE_PROVEEDOR)
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
                        CommandText = "USP_PROVEEDOR_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@PROVEEDOR_ID", SqlDbType.UniqueIdentifier).Value = oBE_PROVEEDOR.ID;
                    objCmd.Parameters.Add("@PROVEEDOR_DESCRIPCION", SqlDbType.VarChar).Value = oBE_PROVEEDOR.DESCRIPCION;
                    objCmd.Parameters.Add("@PROVEEDOR_TIPO", SqlDbType.VarChar).Value = oBE_PROVEEDOR.TIPO;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_PROVEEDOR.USUARIO_CREACION;

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
        /// Eliminar un Proveedor
        /// </summary>
        /// <param name="proveedorId">Identificador del proveedor a eliminar</param>        
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarProveedor(Guid proveedorId)
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
                        CommandText = "USP_PROVEEDOR_ELIMINAR"
                    }
                    )
                {
                    objCmd.Parameters.Add("@PROVEEDOR_ID", SqlDbType.UniqueIdentifier).Value = proveedorId;


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
