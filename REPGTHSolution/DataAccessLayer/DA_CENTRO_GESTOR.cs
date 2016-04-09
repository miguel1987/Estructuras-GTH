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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla CENTROS GESTORES
    /// </summary>
    public class DA_CENTRO_GESTOR
    {
        /// <summary>
        ///  Devuelve los datos de todos los Centros Gestores.
        /// </summary>
        /// <returns> List de BE_CENTRO_GESTOR con los objetos de la entidad, que a su vez representan la tabla CENTROS GESTORES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_CENTRO_GESTOR> SeleccionarCentrosGestores()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_CENTRO_GESTOR> oCENTRO_GESTOR = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_CENTRO_GESTOR_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int CENTRO_GESTOR_ID = dr.GetOrdinal("CENTRO_GESTOR_ID");
                    int CENTRO_GESTOR_CODIGO = dr.GetOrdinal("CENTRO_GESTOR_CODIGO");
                    int CENTRO_GESTOR_DESCRIPCION = dr.GetOrdinal("CENTRO_GESTOR_DESCRIPCION");
                    int AREA_ID = dr.GetOrdinal("AREA_ID");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int CENTRO_GESTOR_ESTADO = dr.GetOrdinal("CENTRO_GESTOR_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oCENTRO_GESTOR = new List<BE_CENTRO_GESTOR>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_CENTRO_GESTOR oBE_CENTRO_GESTOR = new BE_CENTRO_GESTOR();
                            oBE_CENTRO_GESTOR.ID = (Guid)Valores.GetValue(CENTRO_GESTOR_ID);
                            oBE_CENTRO_GESTOR.CODIGO = Valores.GetValue(CENTRO_GESTOR_CODIGO).ToString();
                            oBE_CENTRO_GESTOR.DESCRIPCION = Valores.GetValue(CENTRO_GESTOR_DESCRIPCION).ToString();
                            oBE_CENTRO_GESTOR.CODIGO_DESCRIPCION = String.Format("{0} - {1}", oBE_CENTRO_GESTOR.CODIGO, oBE_CENTRO_GESTOR.DESCRIPCION);
                            oBE_CENTRO_GESTOR.AREA_ID = (Guid)Valores.GetValue(AREA_ID);
                            oBE_CENTRO_GESTOR.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_CENTRO_GESTOR.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_CENTRO_GESTOR.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_CENTRO_GESTOR.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_CENTRO_GESTOR.ESTADO = Convert.ToInt32(Valores.GetValue(CENTRO_GESTOR_ESTADO));
                            oCENTRO_GESTOR.Add(oBE_CENTRO_GESTOR);

                        }
                    }


                }

                return oCENTRO_GESTOR;
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
        ///  Devuelve los datos de todos los Centros Gestores.
        /// </summary>
        /// <param name="areaId">Id del área cuyos centros de costo se desean listar </param>
        /// <returns> List de BE_CENTRO_GESTOR con los objetos de la entidad, que a su vez representan la tabla CENTROS GESTORES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_CENTRO_GESTOR> SeleccionarCentrosGestoresPorArea(Guid areaId)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_CENTRO_GESTOR> oCENTRO_GESTOR = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_CENTRO_GESTOR_SELECCIONAR_POR_AREA"
                })
                {
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = areaId;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int CENTRO_GESTOR_ID = dr.GetOrdinal("CENTRO_GESTOR_ID");
                    int CENTRO_GESTOR_CODIGO = dr.GetOrdinal("CENTRO_GESTOR_CODIGO");
                    int CENTRO_GESTOR_DESCRIPCION = dr.GetOrdinal("CENTRO_GESTOR_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int CENTRO_GESTOR_ESTADO = dr.GetOrdinal("CENTRO_GESTOR_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oCENTRO_GESTOR = new List<BE_CENTRO_GESTOR>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_CENTRO_GESTOR oBE_CENTRO_GESTOR = new BE_CENTRO_GESTOR();
                            oBE_CENTRO_GESTOR.ID = (Guid)Valores.GetValue(CENTRO_GESTOR_ID);
                            oBE_CENTRO_GESTOR.CODIGO = Valores.GetValue(CENTRO_GESTOR_CODIGO).ToString();
                            oBE_CENTRO_GESTOR.DESCRIPCION = Valores.GetValue(CENTRO_GESTOR_DESCRIPCION).ToString();
                            oBE_CENTRO_GESTOR.CODIGO_DESCRIPCION = String.Format("{0} - {1}", oBE_CENTRO_GESTOR.CODIGO, oBE_CENTRO_GESTOR.DESCRIPCION);
                            oBE_CENTRO_GESTOR.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_CENTRO_GESTOR.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_CENTRO_GESTOR.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_CENTRO_GESTOR.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_CENTRO_GESTOR.ESTADO = Convert.ToInt32(Valores.GetValue(CENTRO_GESTOR_ESTADO));
                            oCENTRO_GESTOR.Add(oBE_CENTRO_GESTOR);

                        }
                    }


                }

                return oCENTRO_GESTOR;
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
        /// Ingresa un nuevo Centro Gestor
        /// </summary>
        /// <param name="oBE_CENTRO_GESTOR">Objeto BE_CENTRO_GESTOR con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Guid InsertarCentroGestor(BE_CENTRO_GESTOR oBE_CENTRO_GESTOR)
        {
            SqlConnection cnx = new SqlConnection();
            Guid centroGestor_id = Guid.Empty;

            cnx = DC_Connection.getConnection();

            try
            {

                using (
                    SqlCommand objCmd = new SqlCommand()
                    {
                        Connection = cnx,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "USP_CENTRO_GESTOR_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@CENTRO_GESTOR_CODIGO", SqlDbType.VarChar).Value = oBE_CENTRO_GESTOR.CODIGO;
                    objCmd.Parameters.Add("@CENTRO_GESTOR_DESCRIPCION", SqlDbType.VarChar).Value = oBE_CENTRO_GESTOR.DESCRIPCION;
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = oBE_CENTRO_GESTOR.AREA_ID;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_CENTRO_GESTOR.USUARIO_CREACION;

                    cnx.Open();

                    centroGestor_id = (Guid)objCmd.ExecuteScalar();
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


            return centroGestor_id;
        }

        /// <summary>
        /// Actualizar un Centro Gestor
        /// </summary>
        /// <param name="oBE_CENTRO_GESTOR">Objeto BE_CENTRO_GESTOR con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarCentroGestor(BE_CENTRO_GESTOR oBE_CENTRO_GESTOR)
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
                        CommandText = "USP_CENTRO_GESTOR_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@CENTRO_GESTOR_ID", SqlDbType.UniqueIdentifier).Value = oBE_CENTRO_GESTOR.ID;
                    objCmd.Parameters.Add("@CENTRO_GESTOR_CODIGO", SqlDbType.VarChar).Value = oBE_CENTRO_GESTOR.CODIGO;
                    objCmd.Parameters.Add("@CENTRO_GESTOR_DESCRIPCION", SqlDbType.VarChar).Value = oBE_CENTRO_GESTOR.DESCRIPCION;
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = oBE_CENTRO_GESTOR.AREA_ID;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_CENTRO_GESTOR.USUARIO_CREACION;

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
        /// Eliminar un Centro Gestor
        /// </summary>
        /// <param name="centroGestorId">Identificador del centro gestor a eliminar</param>        
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarCentroGestor(Guid centroGestorId)
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
                        CommandText = "USP_CENTRO_GESTOR_ELIMINAR"
                    }
                    )
                {
                    objCmd.Parameters.Add("@CENTRO_GESTOR_ID", SqlDbType.UniqueIdentifier).Value = centroGestorId;


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
