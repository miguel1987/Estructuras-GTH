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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla SEDES
    /// </summary>
    public class DA_SEDE
    {
        /// <summary>
        ///  Devuelve los datos de todas las SEDES.
        /// </summary>
        /// <returns> List de BE_SEDE con los objetos de la entidad, que a su vez representan la tabla SEDES de la base de datos.En caso existan datos devuelve nothing </returns>
        public List<BE_SEDE> SeleccionarSede()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_SEDE> oSEDE = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_SEDE_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int SEDE_ID = dr.GetOrdinal("SEDE_ID");
                    int SEDE_CODIGO = dr.GetOrdinal("SEDE_CODIGO");
                    int SEDE_DESCRIPCION = dr.GetOrdinal("SEDE_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int SEDE_ESTADO = dr.GetOrdinal("SEDE_ESTADO");
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oSEDE = new List<BE_SEDE>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_SEDE oBE_SEDE = new BE_SEDE();
                            oBE_SEDE.ID = (Guid)Valores.GetValue(SEDE_ID);
                            oBE_SEDE.CODIGO = Valores.GetValue(SEDE_CODIGO).ToString();
                            oBE_SEDE.DESCRIPCION = Valores.GetValue(SEDE_DESCRIPCION).ToString();
                            oBE_SEDE.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_SEDE.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_SEDE.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_SEDE.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_SEDE.ESTADO = Convert.ToInt32(Valores.GetValue(SEDE_ESTADO));
                            oBE_SEDE.EMPRESA_ID = (Guid)Valores.GetValue(EMPRESA_ID);
                            oSEDE.Add(oBE_SEDE);
                        }
                    }


                }

                return oSEDE;
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
        /// Devuelve los datos de una sede específica
        /// </summary>
        /// <param name="sede_id">Id del la Sede que se desea consultar</param>
        /// <returns> BE_SEDE con todos sus atributos de la entidad, que a su vez representan la tabla SEDES de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_SEDE> SeleccionarSedePorId(Guid sede_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_SEDE> oSEDE = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_SEDE_SELECCIONAR_POR_ID"


                })
                {

                    objCmd.Parameters.Add("@SEDE_ID", SqlDbType.UniqueIdentifier).Value = sede_id;


                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int SEDE_ID = dr.GetOrdinal("SEDE_ID");
                    int SEDE_CODIGO = dr.GetOrdinal("SEDE_CODIGO");
                    int SEDE_DESCRIPCION = dr.GetOrdinal("SEDE_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int SEDE_ESTADO = dr.GetOrdinal("SEDE_ESTADO");
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oSEDE = new List<BE_SEDE>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_SEDE oBE_SEDE = new BE_SEDE();
                            oBE_SEDE.ID = (Guid)Valores.GetValue(SEDE_ID);
                            oBE_SEDE.CODIGO = Valores.GetValue(SEDE_CODIGO).ToString();
                            oBE_SEDE.DESCRIPCION = Valores.GetValue(SEDE_DESCRIPCION).ToString();
                            oBE_SEDE.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_SEDE.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_SEDE.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_SEDE.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_SEDE.ESTADO = Convert.ToInt32(Valores.GetValue(SEDE_ESTADO));
                            oBE_SEDE.EMPRESA_ID = (Guid)Valores.GetValue(EMPRESA_ID);

                            oSEDE.Add(oBE_SEDE);
                        }
                    }


                }

                return oSEDE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { cnx.Close(); }

        }

        /// <summary>
        /// Devuelve los datos de las sedes por empresa
        /// </summary>
        /// <param name="empresa_id">Codigo del la empresa de que se desea consultar todas sus sedes</param>
        /// <returns> BE_SEDE con todos sus atributos de la entidad, que a su vez representan la tabla SEDES de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_SEDE> SeleccionarSedePorEmpresa(Guid empresa_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_SEDE> oSEDE = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_SEDE_SELECCIONAR_POR_EMPRESA"


                })
                {

                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = empresa_id;


                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int SEDE_ID = dr.GetOrdinal("SEDE_ID");
                    int SEDE_CODIGO = dr.GetOrdinal("SEDE_CODIGO");
                    int SEDE_DESCRIPCION = dr.GetOrdinal("SEDE_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int SEDE_ESTADO = dr.GetOrdinal("SEDE_ESTADO");
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oSEDE = new List<BE_SEDE>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_SEDE oBE_SEDE = new BE_SEDE();
                            oBE_SEDE.ID = (Guid)Valores.GetValue(SEDE_ID);
                            oBE_SEDE.CODIGO = Valores.GetValue(SEDE_CODIGO).ToString();
                            oBE_SEDE.DESCRIPCION = Valores.GetValue(SEDE_DESCRIPCION).ToString();
                            oBE_SEDE.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_SEDE.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_SEDE.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_SEDE.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_SEDE.ESTADO = Convert.ToInt32(Valores.GetValue(SEDE_ESTADO));
                            oBE_SEDE.EMPRESA_ID = (Guid)Valores.GetValue(EMPRESA_ID);

                            oSEDE.Add(oBE_SEDE);
                        }
                    }


                }

                return oSEDE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { cnx.Close(); }


        }

        /// <summary>
        /// Inserta los datos de una Sede
        /// </summary>
        /// <param name="oBE_SEDE">Entidad BE_SEDE, que representa la tabla SEDES, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarSede(BE_SEDE oBE_SEDE)
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
                        CommandText = "USP_SEDE_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@SEDE_CODIGO", SqlDbType.VarChar).Value = oBE_SEDE.CODIGO;
                    objCmd.Parameters.Add("@SEDE_DESCRIPCION", SqlDbType.VarChar).Value = oBE_SEDE.DESCRIPCION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_SEDE.USUARIO_CREACION;
                    objCmd.Parameters.Add("@SEDE_ESTADO", SqlDbType.Int).Value = oBE_SEDE.ESTADO;
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = oBE_SEDE.EMPRESA_ID;

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
        /// Actualiza los datos de una Sede
        /// </summary>
        /// <param name="oBE_SEDE">Entidad BE_SEDE, que representa la tabla SEDES, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarSede(BE_SEDE oBE_SEDE)
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
                        CommandText = "USP_SEDE_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@SEDE_ID", SqlDbType.UniqueIdentifier).Value = oBE_SEDE.ID;
                    objCmd.Parameters.Add("@SEDE_CODIGO", SqlDbType.VarChar).Value = oBE_SEDE.CODIGO;
                    objCmd.Parameters.Add("@SEDE_DESCRIPCION", SqlDbType.VarChar).Value = oBE_SEDE.DESCRIPCION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_SEDE.USUARIO_CREACION;
                    objCmd.Parameters.Add("@SEDE_ESTADO", SqlDbType.Int).Value = oBE_SEDE.ESTADO;
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = oBE_SEDE.EMPRESA_ID;

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
        /// Elimina los dato de una sede
        /// </summary>
        /// <param name="sede_id">Is del la Sede al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarSede(Guid sede_id)
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
                        CommandText = "USP_SEDE_ELIMINAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@SEDE_ID", SqlDbType.UniqueIdentifier).Value = sede_id;


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
